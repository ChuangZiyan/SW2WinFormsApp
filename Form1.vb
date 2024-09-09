Imports System.ComponentModel
Imports System.IO
Imports System.Security.Policy
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ICSharpCode.SharpZipLib.Zip.ExtendedUnixData
Imports Newtonsoft.Json
Imports OpenQA.Selenium.DevTools.V125.Autofill

Public Class Form1


    Private Sub Form1_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainFormController.SetForm1TitleStatus("關閉中...")
        If Webview2Controller.edgeDriver IsNot Nothing Then
            Webview2Controller.edgeDriver.Quit()
        End If


    End Sub


    Public PAUSE As Boolean = False

    Private Async Sub ExecuteSelectedScriptListviewItem_Button_Click(sender As Object, e As EventArgs) Handles ExecuteSelectedScriptListviewItem_Button.Click
        'Dim flag As Boolean = False
        ExecutionScriptQueue_Button.Enabled = False
        ExecuteSelectedScriptListviewItem_Button.Enabled = False
        PauseScriptExecution_Button.Enabled = False
        ContinueScriptExecution_Button.Enabled = False
        ScheduledExecutionScriptQueue_Button.Enabled = False
        StopScheduledExecutionScriptQueue_Button.Enabled = False
        ExecutionScriptQueue_Button.Enabled = False
        Dim selectedItems = ScriptQueue_ListView.SelectedItems
        For Each item As ListViewItem In selectedItems
            Await ExecutionListviewScriptByItem(item, False)
        Next
        MainFormController.EnabledAllExecutionButton(True)
    End Sub


    Private Async Sub ExecutionScriptQueue_Button_Click(sender As Object, e As EventArgs) Handles ExecutionScriptQueue_Button.Click

        ' Disable button
        ExecuteSelectedScriptListviewItem_Button.Enabled = False
        ScheduledExecutionScriptQueue_Button.Enabled = False
        StopScheduledExecutionScriptQueue_Button.Enabled = False

        ' 這個是用來迴圈控制跑腳本的
        Dim executionCount As Integer = ScriptExecutionCount_NumericUpDown.Value
        ExecutionScriptQueue_Button.Enabled = False
        For run = 1 To executionCount Step 1
            ExecutionScriptQueue_Button.Text = "剩餘次數 : " & executionCount - run
            Await ExcutionListviewscriptItems()
        Next

        ExecutionScriptQueue_Button.Enabled = True
        ExecutionScriptQueue_Button.Text = "執行腳本"
        MainFormController.EnabledAllExecutionButton(True)
    End Sub


    Private Async Function ExcutionListviewscriptItems() As Task
        For Each item As ListViewItem In ScriptQueue_ListView.Items
            ' 判斷略過
            If item.SubItems(12).Text = "略過" Then
                Continue For
            End If
            Await ExecutionListviewScriptByItem(item)
        Next
    End Function


    Private Sub StopScheduledExecutionScriptQueue_Button_Click(sender As Object, e As EventArgs) Handles StopScheduledExecutionScriptQueue_Button.Click
        ScheduledRun = False
        ScheduledExecutionScriptQueue_Button.Text = "定時執行"
        MainFormController.EnabledAllExecutionButton(True)
    End Sub

    Public ScheduledRun = False

    Private Async Sub ScheduledExecutionScriptQueue_Button_Click(sender As Object, e As EventArgs) Handles ScheduledExecutionScriptQueue_Button.Click

        ' disable button
        ExecutionScriptQueue_Button.Enabled = False
        ExecuteSelectedScriptListviewItem_Button.Enabled = False
        PauseScriptExecution_Button.Enabled = False
        ContinueScriptExecution_Button.Enabled = False

        ' 定時執行
        If ScheduledRun Then
            Exit Sub
        End If

        ScheduledRun = True
        While ScheduledRun
            Dim currentTime As String = DateTime.Now.ToString("HH:mm:ss")
            'Debug.WriteLine("curr time : " & currentTime)
            ScheduledExecutionScriptQueue_Button.Text = currentTime
            For Each item As ListViewItem In ScriptQueue_ListView.Items
                Dim executionTime = item.SubItems(1).Text
                If item.SubItems(12).Text = "略過" Or executionTime = "NULL" Then
                    Continue For
                End If

                If executionTime = currentTime Then
                    ' 第二個參數設成false就是執行完不等待
                    Await ExecutionListviewScriptByItem(item, False)
                End If

            Next

            Await Delay_msec(1000)
        End While

    End Sub


    ' 這個是主要執行腳本的功能區段，他會執行你傳入的ListviewItem
    Private Async Function ExecutionListviewScriptByItem(item As ListViewItem, Optional isAwaitingCompletion As Boolean = True) As Task
        PAUSE = False
        'For Each item As ListViewItem In ScriptQueue_ListView.Items

        Dim userData As String = item.SubItems(0).Text
        Dim executionTime As String = item.SubItems(1).Text
        Dim myUrlName As String = item.SubItems(2).Text
        Dim myUrl As String = item.SubItems(3).Text
        Dim action As String = item.SubItems(4).Text
        Dim content As String = item.SubItems(5).Text
        Dim uploadWaitTime = item.SubItems(6).Text
        Dim submitWaitTime = item.SubItems(7).Text

        Dim executionSuccessResultCount As String = item.SubItems(9).Text
        Dim executionFailResultCount As String = item.SubItems(10).Text
        Dim waitSecond As String = item.SubItems(11).Text
        Dim remark As String = item.SubItems(12).Text

        '先把之前的顏色變回來
        MainFormController.ResetScriptQueueListviewItemsBackgroundColor()

        ' 執行的那行要變色
        item.BackColor = Color.SteelBlue
        item.ForeColor = Color.White
        MainFormController.CenterSelectedItem(item)

        '用選的userData 初始化webview
        Dim userDataFolderPath = Path.Combine(AppInitModule.webivewUserDataDirectory, userData)
        ' 初始化webivew
        Await Webview2Controller.RestartMainWebView2(userDataFolderPath)


        'Main Routing 主要路由在這

        'Debug.WriteLine("#######")
        '預設結果是失敗
        Dim result = False
        Await Delay_msec(1000)
        Select Case action
                '########################################################################### 發帖功能 ###############################################################################################
            Case "發帖"
                Try
                    'Debug.WriteLine("發帖")
                    Dim assetFolderPath = GetRandomAssetFolder(content, AppInitModule.FBPostAssetsDirectory)
                    item.SubItems(6).Text = Path.GetFileName(assetFolderPath)

                    Dim FBWritePostWaitSecondsCfg = File.ReadAllText(Path.Combine(assetFolderPath, "FBWritePostWaitSecondsConfig.txt"))
                    item.SubItems(7).Text = Split(FBWritePostWaitSecondsCfg, ",")(0)
                    item.SubItems(8).Text = Split(FBWritePostWaitSecondsCfg, ",")(1)

                    result = Await FBPostSeleniumScript.WritePostOnFacebook(myUrl, assetFolderPath)
                    'result = False

                    ' 如果流程都沒問題
                    If result Then
                        ' 這邊要等待上傳完成
                        For seconds = CInt(item.SubItems(7).Text) To 0 Step -1
                            Await Delay_msec(1000)
                            item.SubItems(7).Text = seconds
                        Next

                        ' 如果你要發佈貼文就取消註解下面那行
                        'result = Await ClickByCssSelector_Task("div[aria-label$='發佈']")

                        ' 發佈後等待
                        For seconds = CInt(item.SubItems(8).Text) To 0 Step -1
                            Await Delay_msec(1000)
                            item.SubItems(8).Text = seconds
                        Next

                        ' 執行完後復原執行內容
                        'item.SubItems(5).Text = content

                    End If

                Catch ex As Exception
                    Debug.WriteLine(ex)
                    result = False
                End Try

            Case "拍賣"
                Try
                    Dim assetFolderPath = GetRandomAssetFolder(content, AppInitModule.FBMarketPlaceAssetsDirectory)
                    item.SubItems(6).Text = Path.GetFileName(assetFolderPath)

                    Dim MarketplaceWaitSecondsConfig = File.ReadAllText(Path.Combine(assetFolderPath, "MarketplaceWaitSecondsConfig.txt"))
                    item.SubItems(7).Text = Split(MarketplaceWaitSecondsConfig, ",")(0)
                    item.SubItems(8).Text = Split(MarketplaceWaitSecondsConfig, ",")(1)
                    result = Await FBMarketplaceSeleniumScript.SellSomething(myUrl, assetFolderPath)
                Catch ex As Exception
                    Debug.WriteLine(ex)
                    result = False
                End Try

                '########################################################################### 測試項功能 ###############################################################################################
            Case "測試項"
                Try
                    Await Delay_msec(1000)
                    result = True
                Catch ex As Exception
                    Debug.WriteLine(ex)
                    result = False
                End Try


        End Select

        ' 增加成功或者失敗的次數
        If result Then
            item.SubItems(9).Text = (CInt(item.SubItems(9).Text) + 1).ToString
        ElseIf Not result Then
            item.SubItems(10).Text = (CInt(item.SubItems(10).Text) + 1).ToString
        End If


        If isAwaitingCompletion Then
            '如果是順序執行的話，跑完腳本後等待
            Dim splitedWaitSecond = waitSecond.Split("±")
            Dim myWaitSecs = CInt(splitedWaitSecond(0)) + UtilsModule.GetRandomRangeValue(CInt(splitedWaitSecond(1)))

            If myWaitSecs > 0 Then
                For i As Integer = myWaitSecs To 0 Step -1
                    While PAUSE
                        Await Delay_msec(1000)
                    End While
                    item.SubItems(11).Text = i.ToString()
                    Await Delay_msec(1000)
                Next
            Else
                item.SubItems(11).Text = "0"
            End If

            While PAUSE
                Await Delay_msec(1000)
            End While

        End If


        ' 等待完後重設
        item.SubItems(11).Text = waitSecond
        'item.BackColor = Color.White
        'item.ForeColor = Color.Black

        'Next

    End Function


    Private mainFormEventHandlers As New MainFormEventHandlers()
    Private FBPostEventHandlers As New FBPostEventHandlers()
    Private FBMarketplaceEventHandlers As New FBMarketplaceEventHandlers()

    Private Sub RegisterMainFormEventHanders()
        ' 這邊是用來註冊Form1的事件
        AddHandler DeleteSelectedUserDataFolderButton.Click, AddressOf mainFormEventHandlers.DeleteUserDataFolders_Button_Click
        AddHandler FilterAvailableUserData_CheckBox.Click, AddressOf mainFormEventHandlers.UpdateWebviewUserDataCheckListBox_CheckBox_Click
        AddHandler FilterUnavailableUserData_CheckBox.Click, AddressOf mainFormEventHandlers.UpdateWebviewUserDataCheckListBox_CheckBox_Click
        AddHandler InsertToQueueListview_Button.Click, AddressOf mainFormEventHandlers.InsertToQueueListview_Button_Click
        AddHandler PauseScriptExecution_Button.Click, AddressOf mainFormEventHandlers.PauseScriptExecution_Button_Click
        AddHandler ContinueScriptExecution_Button.Click, AddressOf mainFormEventHandlers.ContinueScriptExecution_Button_Click
        AddHandler MarkUserDataToSkip_Button.Click, AddressOf mainFormEventHandlers.MarkUserDataToSkip_Button_Click
        AddHandler UnmarkUserDataToSkip_Button_Button.Click, AddressOf mainFormEventHandlers.UnmarkUserDataToSkip_Button_Button_Click
        AddHandler SaveScriptListViewToCSVFile_Button.Click, AddressOf mainFormEventHandlers.SaveScriptListViewToFile_Button_Click
        AddHandler MarkSelectedScriptListviewItem_Button.Click, AddressOf mainFormEventHandlers.MarkSelectedScriptListviewItem_Button_Click
        AddHandler UnmarkSelectedScriptListviewItem_Button.Click, AddressOf mainFormEventHandlers.UnmarkSelectedScriptListviewItem_Button_Click
        AddHandler DeleteSelectedScriptListviewItem_Button.Click, AddressOf mainFormEventHandlers.DeleteSelectedScriptListviewItem_Button_Click
        AddHandler DeleteScriptListviewItemByUserData_Button.Click, AddressOf mainFormEventHandlers.DeleteScriptListviewItemByUserData_Button_Click
        AddHandler ModifySelectedScriptListviewWaitTime_Button.Click, AddressOf mainFormEventHandlers.ModifySelectedScriptListviewWaitTime
        AddHandler ModifySelectedScriptListviewAsset_Button.Click, AddressOf mainFormEventHandlers.ModifySelectedScriptListviewAsset_Button_Click
        AddHandler ResetScript_Button.Click, AddressOf mainFormEventHandlers.ResetScript_Button_Click
        AddHandler InsertSchedulerScriptToListview_Button.Click, AddressOf mainFormEventHandlers.InsertSchedulerScriptToListview_Button_Click
        AddHandler ModifyListviewScheduleTime_Button.Click, AddressOf mainFormEventHandlers.ModifyListviewScheduleTime_Button_Click
        AddHandler ModifyListviewScheduleTimeTNull_Button.Click, AddressOf mainFormEventHandlers.ModifyListviewScheduleTimeTNull_Button_Click
        AddHandler SchedulerTime_Label.Click, AddressOf mainFormEventHandlers.SchedulerTime_Label_Click
        AddHandler SyncTimeToDateTimePicker_Label.Click, AddressOf mainFormEventHandlers.SyncTimeToDateTimePicker_Label_Click
        AddHandler SortListviewItemByTime_Button.Click, AddressOf mainFormEventHandlers.SortListviewItemByTime_Button_Click
        AddHandler ScriptQueue_ListView.DoubleClick, AddressOf mainFormEventHandlers.ScriptQueue_ListView_DoubleClick
        AddHandler RevealFBPasswordText_Button.Click, AddressOf mainFormEventHandlers.RevealFBPasswordText_Button_Click
        AddHandler RevealEmailPasswordText_Button.Click, AddressOf mainFormEventHandlers.RevealEmailPasswordText_Button_Click
        AddHandler NavigateTo_Url_Button.Click, AddressOf mainFormEventHandlers.NavigateTo_Url_Button_Click
        AddHandler CreateUserDataFolderButton.Click, AddressOf mainFormEventHandlers.CreateUserDataFolderButton_Click
        AddHandler SaveUserData_Button.Click, AddressOf mainFormEventHandlers.SaveUserData_Button_Click
        AddHandler Move_UserDataFolder_Button.Click, AddressOf mainFormEventHandlers.Move_UserDataFolder_Button_Click
        AddHandler AddGroupDataToGroupListview_Button.Click, AddressOf mainFormEventHandlers.AddGroupDataToGroupListview_Button_Click
        AddHandler EditSelectedGroupListviewItem_Button.Click, AddressOf mainFormEventHandlers.EditSelectedGroupListviewItem_Button_Click
        AddHandler DeleteSelectedGroup_Button.Click, AddressOf mainFormEventHandlers.DeleteSelectedGroup_Button_Click
        AddHandler GetJoinedGroupList_Button.Click, AddressOf mainFormEventHandlers.GetJoinedGroupList_Button_Click
        AddHandler GetCurrentUrl_Button.Click, AddressOf mainFormEventHandlers.GetCurrentUrl_Button_Click
        AddHandler GetFBGroupList_Button.Click, AddressOf mainFormEventHandlers.GetFBGroupList_Button_Click
        AddHandler SaveListviewGroupList_Button.Click, AddressOf mainFormEventHandlers.SaveListviewGroupList_Button_Click
        AddHandler FBGroups_ListView.SelectedIndexChanged, AddressOf mainFormEventHandlers.FBGroups_ListView_SelectedIndexChanged
        AddHandler WebviewUserDataFolder_ListBox.SelectedIndexChanged, AddressOf mainFormEventHandlers.WebviewUserDataFolder_CheckedListBox_SelectedIndexChanged
        AddHandler WebviewUserDataFolder_ListBox.DoubleClick, AddressOf mainFormEventHandlers.WebviewUserDataFolder_ListBox_DoubleClick
        AddHandler ReadCookie_Button.Click, AddressOf mainFormEventHandlers.ReadCookie_Button_Click
        AddHandler SetCookie_Button.Click, AddressOf mainFormEventHandlers.SetCookie_Button_Click
        AddHandler SetSeletedFBLanguageTo_zhTW_Button.Click, AddressOf mainFormEventHandlers.SetSeletedFBLanguageTo_zhTW_Button_Click
        AddHandler RequestFriend_Button.Click, AddressOf mainFormEventHandlers.RequestFriend_Button_Click
        AddHandler TurnOnSetSeleteKeyboardShortcuts_Button.Click, AddressOf mainFormEventHandlers.TurnOnSetSeleteKeyboardShortcuts_Button_Click
        AddHandler NavigateToSelectedGroup_Button.Click, AddressOf mainFormEventHandlers.NavigateToSelectedGroup_Button_Click
        AddHandler DisplayCurrUrlToGroupUrl_Button.Click, AddressOf mainFormEventHandlers.DisplayCurrUrlToGroupUrl_Button_Click
        AddHandler ShowEmojiPicker_Button.Click, AddressOf mainFormEventHandlers.ShowEmojiPicker_Button_Click
        AddHandler MyBase.Move, AddressOf mainFormEventHandlers.Form1_Move
        AddHandler MyBase.Resize, AddressOf mainFormEventHandlers.Form1_Resize
    End Sub

    Private Sub RegisterFBPostEventHanders()
        ' 這邊是用來註冊發帖相關的事件
        AddHandler CreateNewAssetFolder_Button.Click, AddressOf FBPostEventHandlers.CreateNewAssetFolder_Button_Click
        AddHandler MyAssetsFolder_ListBox.DoubleClick, AddressOf FBPostEventHandlers.RevealAssetFolderInFileExplorer_DoubleClick
        AddHandler DeleteSelectedTextFiles_Button.Click, AddressOf FBPostEventHandlers.DeleteSelectedTextFiles_Button_Click
        AddHandler RevealMediaFoldesrInFileExplorer_Button.Click, AddressOf FBPostEventHandlers.RevealMediaFoldersInFileExplorer_Button_Click
        AddHandler DeleteSelectedMedia_Button.Click, AddressOf FBPostEventHandlers.DeleteSelectedMediaFile_Button_Click
        AddHandler TextFileSelector_ListBox.DoubleClick, AddressOf FBPostEventHandlers.EditSelectedTextFileWithNotepad
        AddHandler MediaSelector_ListBox.DoubleClick, AddressOf FBPostEventHandlers.PlaySelectedMedia
        AddHandler SaveFBWritePostWaitSecondsConfig_Button.Click, AddressOf FBPostEventHandlers.SaveFBWritePostWaitSecondsConfig_Button_Click
        AddHandler DeselectAllMyAssetFolderListboxItems_Button.Click, AddressOf FBPostEventHandlers.DeselectAllMyAssetFolderListboxItems_Button_Click
        AddHandler DeleteSelectedAssetFolder_Button.Click, AddressOf FBPostEventHandlers.DeletedSelectedAssetFolders
        AddHandler MyAssetsFolder_ListBox.SelectedIndexChanged, AddressOf FBPostEventHandlers.MyAssetsFolder_ListBox_SelectedIndexChanged
        AddHandler MediaSelector_ListBox.SelectedIndexChanged, AddressOf FBPostEventHandlers.MediaSelector_ListBox_SelectedIndexChanged
        AddHandler TextFileSelector_ListBox.SelectedIndexChanged, AddressOf FBPostEventHandlers.TextFileSelector_ListBox_SelectedIndexChanged
        AddHandler CreateNewTextFile_Button.Click, AddressOf FBPostEventHandlers.CreateNewTextFile_Button_Click
        AddHandler SaveEditedTextFile_Button.Click, AddressOf FBPostEventHandlers.SaveEditedTextFile_Button_Click
    End Sub


    Private Sub RegisterMarketplaceEventHanders()
        ' 這邊是用來註冊拍賣相關的事件
        AddHandler CreateNewMarketplaceAssetFolder_Button.Click, AddressOf FBMarketplaceEventHandlers.CreateNewMarketplaceAssetFolder_Button_Click
        AddHandler FBMarketplaceSavePruductInfo_Button.Click, AddressOf FBMarketplaceEventHandlers.FBMarketplaceSavePruductInfo_Button_Click
        AddHandler FBMarkplaceProducts_ListBox.SelectedIndexChanged, AddressOf FBMarketplaceEventHandlers.MarkplaceProducts_ListBox_SelectedIndexChanged
        AddHandler RevealFBMarketplaceMediaFoldesrInFileExplorer_Button.Click, AddressOf FBMarketplaceEventHandlers.RevealFBMarketplaceMediaFoldesrInFileExplorer_Button_Click
        AddHandler FBMarketplaceMediaSelector_ListBox.SelectedIndexChanged, AddressOf FBMarketplaceEventHandlers.FBMarketplaceMediaSelector_ListBox_SelectedIndexChanged
        AddHandler FBmarketplaceDeselectAllProductFolderListboxItems_Button.Click, AddressOf FBMarketplaceEventHandlers.FBmarketplaceDeselectAllProductFolderListboxItems_Button_Click
        AddHandler FBMarketplaceShareGroupsBySequence_RadioButton.CheckedChanged, AddressOf FBMarketplaceEventHandlers.FBMarketplaceShareGroupsBySequence_RadioButton_CheckedChanged
        AddHandler FBMarketplaceShareGroupsByRandom_RadioButton.CheckedChanged, AddressOf FBMarketplaceEventHandlers.FBMarketplaceShareGroupsByRandom_RadioButton_CheckedChanged
        AddHandler FBMarketplaceDeleteSelectedAssetFolder_Button.Click, AddressOf FBMarketplaceEventHandlers.FBMarketplaceDeleteSelectedAssetFolder_Button_Click
    End Sub

    Private emojiPickerForm As EmojiPickerForm

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Main_WebView2.Source = New Uri("about:blank")
        AppInitModule.InitializeMainApp()
        MainFormController.LoadFileToScriptListview()
        Navigate_Url_TextBox.Text = "https://www.facebook.com/"
        Await Webview2Controller.GetWebview2EdgeVersion()

        'Webview2EdgeVersion_TextBox.Text = Webview2Controller.Webview2EdgeVersion

        ' Register to event Event Handlers
        RegisterMainFormEventHanders()
        RegisterFBPostEventHanders()
        RegisterMarketplaceEventHanders()

        ' EOF
        MainFormController.SetForm1TitleStatus("完成")

        emojiPickerForm = New EmojiPickerForm With {
            .Owner = Me,
            .TopMost = True
        }
        'emojiPickerForm.Show()
    End Sub



End Class
