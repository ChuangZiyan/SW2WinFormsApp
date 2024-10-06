Imports System.ComponentModel
Imports System.IO
Imports System.Security.Policy
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ICSharpCode.SharpZipLib.Zip.ExtendedUnixData
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports OpenQA.Selenium
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

        Try
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
            MainFormController.ResetListviewItemsBackgroundColor(ScriptQueue_ListView)

            ' 執行的那行要變色
            item.BackColor = Color.SteelBlue
            item.ForeColor = Color.White
            MainFormController.CenterSelectedItem(ScriptQueue_ListView, item)

            '用選的userData 初始化webview
            Dim userDataFolderPath = Path.Combine(AppInitModule.webivewUserDataDirectory, userData)
            ' 初始化webivew
            Await Webview2Controller.RestartMainWebView2(userDataFolderPath)

            '選擇WebviewUserDataFolder_ListBox
            WebviewUserDataFolder_ListBox.SelectedItem = userData


            '處理隨機網址
            If myUrl.Contains("隨機") Then
                Dim randomItem As JToken

                If action = "留言" Then
                    randomItem = MainFormController.GetRandomFBActivityLogUrl(userDataFolderPath)
                Else
                    randomItem = MainFormController.GetRandomGroupsUrl(userDataFolderPath)
                End If
                item.SubItems(2).Text = "隨機->" & randomItem("Name").ToString()
                item.SubItems(3).Text = "隨機->" & randomItem("Url").ToString()
                myUrl = randomItem("Url").ToString()

            End If

            '### Main Routing 主要路由在這 ###
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
                            ' result = Await Webview2Controller.ClickByCssSelector_Task("div[aria-label$='發佈']")

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
                        If result Then
                            ' 這邊要等待上傳完成
                            For seconds = CInt(item.SubItems(7).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(7).Text = seconds
                            Next

                            '將商品新增到其他社團後等待
                            Await FBMarketplaceSeleniumScript.AddYourListingToOtherGroups(assetFolderPath)
                            For seconds = CInt(item.SubItems(8).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(8).Text = seconds
                            Next

                            '點發佈 你如果要實際發佈，就取消註解下面這行
                            ' Webview2Controller.ClickByAriaLable("發佈")

                        End If

                    Catch ex As Exception
                        Debug.WriteLine(ex)
                        result = False
                    End Try
                Case "分享"
                    Try

                        Debug.WriteLine("分享")
                        Dim assetFolderPath = GetRandomAssetFolder(content, AppInitModule.FBPostShareURLAssetsDirectory)
                        item.SubItems(6).Text = Path.GetFileName(assetFolderPath)

                        Dim FBWritePostShareURLWaitSecondsCfg = File.ReadAllText(Path.Combine(assetFolderPath, "FBPostShareURLWaitSecondsConfig.txt"))
                        item.SubItems(7).Text = Split(FBWritePostShareURLWaitSecondsCfg, ",")(0)
                        item.SubItems(8).Text = Split(FBWritePostShareURLWaitSecondsCfg, ",")(1)

                        result = Await FBShareURLSeleniumScript.WritePostAndShareURLOnFacebook(myUrl, assetFolderPath)
                        'result = False

                        ' 如果流程都沒問題
                        If result Then
                            ' 這邊要等待上傳完成
                            For seconds = CInt(item.SubItems(7).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(7).Text = seconds
                            Next

                            ' 如果你要發佈貼文就取消註解下面那行
                            'result = Await Webview2Controller.ClickByCssSelector_Task("div[aria-label$='發佈']")

                            ' 發佈後等待
                            For seconds = CInt(item.SubItems(8).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(8).Text = seconds
                            Next


                        End If
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                        result = False
                    End Try
                Case "留言"
                    Try
                        Debug.WriteLine("留言")
                        Dim assetFolderPath = GetRandomAssetFolder(content, AppInitModule.FBCommentAssetsDirectory)
                        item.SubItems(6).Text = Path.GetFileName(assetFolderPath)

                        Dim FBCommentWaitSecondsCfg = File.ReadAllText(Path.Combine(assetFolderPath, "FBCommentWaitSecondsConfig.txt"))
                        item.SubItems(7).Text = Split(FBCommentWaitSecondsCfg, ",")(0)
                        item.SubItems(8).Text = Split(FBCommentWaitSecondsCfg, ",")(1)

                        result = Await FBCommentSeleniumScript.CommentOnThePost(myUrl, assetFolderPath)
                        'result = False

                        ' 如果流程都沒問題
                        If result Then
                            ' 這邊要等待上傳完成
                            For seconds = CInt(item.SubItems(7).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(7).Text = seconds
                            Next

                            ' 如果你要送出留言就取消註解下面那行
                            ' result = Await Webview2Controller.ClickByCssSelector_Task("#focused-state-composer-submit > span > div")

                            ' 送出留言後等待
                            For seconds = CInt(item.SubItems(8).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(8).Text = seconds
                            Next


                        End If
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                        result = False
                    End Try
                    '########################################################################### 測試項功能 ###############################################################################################

                Case "自訂"
                    Try
                        Dim assetFolderPath = GetRandomAssetFolder(content, AppInitModule.FBCustomizeCommentAssetsDirectory)
                        item.SubItems(6).Text = Path.GetFileName(assetFolderPath)

                        Dim FBCustomizeCommentWaitSecondsCfg = File.ReadAllText(Path.Combine(assetFolderPath, "FBCustomizeCommentWaitSecondsConfig.txt"))
                        item.SubItems(7).Text = Split(FBCustomizeCommentWaitSecondsCfg, ",")(0)
                        item.SubItems(8).Text = Split(FBCustomizeCommentWaitSecondsCfg, ",")(1)

                        result = Await FBCustomizeCommentSeleniumScript.CustomizeCommentOnThePost(myUrl, assetFolderPath)
                        'result = False

                        ' 如果流程都沒問題
                        If result Then
                            ' 這邊要等待上傳完成
                            For seconds = CInt(item.SubItems(7).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(7).Text = seconds
                            Next

                            ' 如果你要送出留言就取消註解下面那行
                            'result = Await Webview2Controller.ClickByCssSelector_Task("#focused-state-composer-submit > span > div")

                            ' 送出留言後等待
                            For seconds = CInt(item.SubItems(8).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(8).Text = seconds
                            Next


                        End If
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                        result = False
                    End Try
                Case "回應"
                    Try
                        Dim assetFolderPath = GetRandomAssetFolder(content, AppInitModule.FBResponseAssetsDirectory)
                        item.SubItems(6).Text = Path.GetFileName(assetFolderPath)

                        Dim FBResponseWaitSecondsCfg = File.ReadAllText(Path.Combine(assetFolderPath, "FBResponseWaitSecondsConfig.txt"))
                        item.SubItems(7).Text = Split(FBResponseWaitSecondsCfg, ",")(0)
                        item.SubItems(8).Text = Split(FBResponseWaitSecondsCfg, ",")(1)

                        result = Await FBResponseSeleniumScript.RespondThePost(myUrl, assetFolderPath)
                        'result = False

                        ' 如果流程都沒問題
                        If result Then
                            ' 這邊要等待上傳完成
                            For seconds = CInt(item.SubItems(7).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(7).Text = seconds
                            Next

                            ' 如果你要送出留言就取消註解下面那行
                            'result = Await Webview2Controller.ClickByCssSelector_Task("#focused-state-composer-submit > span > div")

                            ' 送出留言後等待
                            For seconds = CInt(item.SubItems(8).Text) To 0 Step -1
                                Await Delay_msec(1000)
                                item.SubItems(8).Text = seconds
                            Next

                        End If
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                        result = False
                    End Try

                Case "讀取已讀通知"
                    result = Await Webview2Controller.ReadFBNotifications(True, False)
                Case "讀取未讀通知"
                    result = Await Webview2Controller.ReadFBNotifications(False, True)
                Case "已讀全部通知"
                    result = Await Webview2Controller.MarkAllFBNotificationsAsRead()
                Case "順序回應通知"
                    Dim myListbox = WebviewUserDataFolder_ListBox
                    Dim index As Integer = myListbox.Items.IndexOf(userData)
                    If index <> -1 Then
                        myListbox.SelectedIndex = index
                    Else
                        myListbox.SelectedIndex = -1
                    End If
                    Await Delay_msec(500)
                    Action_TabControl.SelectedTab = FBRespondNotificationsAssets_TabPage

                    Dim FBNotificationItems = FBNotificationsData_Listview.Items

                    For Each notificationItem As ListViewItem In FBNotificationItems
                        Try
                            notificationItem.BackColor = Color.SteelBlue
                            notificationItem.ForeColor = Color.White
                            MainFormController.CenterSelectedItem(FBNotificationsData_Listview, notificationItem)

                            Dim assetFolderPath = GetRandomAssetFolder(content, AppInitModule.FBResponseAssetsDirectory)
                            item.SubItems(6).Text = Path.GetFileName(assetFolderPath)

                            Dim FBResponseWaitSecondsCfg = File.ReadAllText(Path.Combine(assetFolderPath, "FBResponseWaitSecondsConfig.txt"))
                            item.SubItems(7).Text = Split(FBResponseWaitSecondsCfg, ",")(0)
                            item.SubItems(8).Text = Split(FBResponseWaitSecondsCfg, ",")(1)
                            myUrl = notificationItem.SubItems(1).Text
                            result = Await FBResponseSeleniumScript.RespondThePost(myUrl, assetFolderPath)
                            'result = False

                            ' 如果流程都沒問題
                            If result Then
                                ' 這邊要等待上傳完成
                                For seconds = CInt(item.SubItems(7).Text) To 0 Step -1
                                    Await Delay_msec(1000)
                                    item.SubItems(7).Text = seconds
                                Next

                                ' 如果你要送出留言就取消註解下面那行
                                'result = Await Webview2Controller.ClickByCssSelector_Task("#focused-state-composer-submit > span > div")

                                ' 送出留言後等待
                                For seconds = CInt(item.SubItems(8).Text) To 0 Step -1
                                    Await Delay_msec(1000)
                                    item.SubItems(8).Text = seconds
                                Next

                            End If

                        Catch ex As Exception
                            Debug.WriteLine(ex)
                            result = False
                        End Try

                        ' 執行完後變回來
                        notificationItem.BackColor = Color.White
                        notificationItem.ForeColor = Color.Black

                    Next
                Case "讀取未讀聊天室"
                    Try
                        Await Navigate_GoToUrl_Task("https://www.messenger.com/")
                        Await Delay_msec(2000)
                        Dim messengerItems = Await Webview2Controller.ReadFBMessenger("聊天室", False, True)
                        FBMessengerData_Listview.Items.Clear()
                        For Each mgsItem In messengerItems
                            FBMessengerData_Listview.Items.Add(mgsItem)
                        Next
                        result = True
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                    End Try

                Case "讀取己讀聊天室"
                    Try
                        Await Navigate_GoToUrl_Task("https://www.messenger.com/")
                        Await Delay_msec(2000)
                        Dim messengerItems = Await Webview2Controller.ReadFBMessenger("聊天室", True, False)
                        FBMessengerData_Listview.Items.Clear()
                        For Each mgsItem In messengerItems
                            FBMessengerData_Listview.Items.Add(mgsItem)
                        Next
                        result = False
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                    End Try

                Case "讀取未讀Marketplace"
                    Try
                        Await Navigate_GoToUrl_Task("https://www.messenger.com/")
                        Await Delay_msec(2000)
                        Dim messengerItems = Await Webview2Controller.ReadFBMessenger("Marketplace", False, True)
                        FBMessengerData_Listview.Items.Clear()
                        For Each mgsItem In messengerItems
                            FBMessengerData_Listview.Items.Add(mgsItem)
                        Next
                        result = True
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                    End Try
                Case "讀取己讀Marketplace"
                    Try
                        Await Navigate_GoToUrl_Task("https://www.messenger.com/")
                        Await Delay_msec(2000)
                        Dim messengerItems = Await Webview2Controller.ReadFBMessenger("Marketplace", True, False)
                        FBMessengerData_Listview.Items.Clear()
                        For Each mgsItem In messengerItems
                            FBMessengerData_Listview.Items.Add(mgsItem)
                        Next
                        result = True
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                    End Try
                Case "讀取未讀陌生訊息"
                    Try
                        Await Navigate_GoToUrl_Task("https://www.messenger.com/")
                        Await Delay_msec(2000)
                        Dim messengerItems = Await Webview2Controller.ReadFBMessenger("Marketplace", False, True)
                        messengerItems.AddRange(Await Webview2Controller.ReadFBMessenger("Marketplace", False, True))

                        FBMessengerData_Listview.Items.Clear()
                        For Each mgsItem In messengerItems
                            FBMessengerData_Listview.Items.Add(mgsItem)
                        Next
                        result = True
                    Catch ex As Exception
                        Debug.WriteLine(ex)
                    End Try
                Case "讀取己讀陌生訊息"
                    Try
                        Await Navigate_GoToUrl_Task("https://www.messenger.com/")
                        Await Delay_msec(2000)
                        Dim messengerItems = Await Webview2Controller.ReadFBMessenger("Marketplace", True, False)
                        messengerItems.AddRange(Await Webview2Controller.ReadFBMessenger("Marketplace", True, False))

                        FBMessengerData_Listview.Items.Clear()
                        For Each mgsItem In messengerItems
                            FBMessengerData_Listview.Items.Add(mgsItem)
                        Next
                        result = True
                    Catch ex As Exception
                        Debug.WriteLine(ex)
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


        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Function


    Private mainFormEventHandlers As New MainFormEventHandlers()
    Private FBPostEventHandlers As New FBPostEventHandlers()
    Private FBMarketplaceEventHandlers As New FBMarketplaceEventHandlers()
    Private FBPostShareURLEventHandlers As New FBPostShareURLEventHandlers()
    Private FBCommentEventHandlers As New FBCommentEventHandlers()
    Private FBCustomizeCommentEventHandlers As New FBCustomizeCommentEventHandlers()
    Private FBResponseEventHandlers As New FBResponseEventHandlers()
    Private FBMessengerEventHandlers As New FBMessengerEventHandlers()




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
        AddHandler SelectScriptListviewItemsByUserDataButton.Click, AddressOf mainFormEventHandlers.SelectListviewItemsByUserDataButton_Click
        AddHandler DefaultScriptInsertion_RadioButton.Click, AddressOf mainFormEventHandlers.DefaultScriptInsertion_RadioButton_Click
        AddHandler CustomizeScriptInsertion_RadioButton.Click, AddressOf mainFormEventHandlers.CustomizeScriptInsertion_RadioButton_Click
        AddHandler FBUrlData_TabControl.SelectedIndexChanged, AddressOf mainFormEventHandlers.FBUrlData_TabControl_SelectedIndexChanged
        AddHandler Action_TabControl.SelectedIndexChanged, AddressOf mainFormEventHandlers.Action_TabControl_SelectedIndexChanged
        AddHandler DeselecteAllFBGroups_ListViewItems_Button.Click, AddressOf mainFormEventHandlers.DeselecteAllFBGroups_ListViewItems_Button_Click


        ' ### FB ActivityLogs
        AddHandler ReadActivityLogs_Button.Click, AddressOf mainFormEventHandlers.ReadActivityLogs_Button_Click
        AddHandler NavigateToActivityLogsPage_Button.Click, AddressOf mainFormEventHandlers.NavigateToActivityLogsPage_Button_Click
        AddHandler SaveFBActivityLogListview_Button.Click, AddressOf mainFormEventHandlers.SaveFBActivityLogListview_Button_Click
        AddHandler FBActivityLogs_ListView.SelectedIndexChanged, AddressOf mainFormEventHandlers.FBActivityLogs_ListView_SelectedIndexChanged
        AddHandler DeleteSelectedFBActivityLogListviewItems_Button.Click, AddressOf mainFormEventHandlers.DeleteSelectedFBActivityLogListviewItems_Button_Click
        AddHandler NavigateToFBActivityLogSelectedGroupURL_Button.Click, AddressOf mainFormEventHandlers.NavigateToFBActivityLogSelectedGroupURL_Button_Click
        AddHandler DisplayCurrUrlToFBActivityLogUrl_Button.Click, AddressOf mainFormEventHandlers.DisplayCurrUrlToFBActivityLogUrl_Button_Click
        AddHandler AddItemToFBActivityLogListview_Button.Click, AddressOf mainFormEventHandlers.AddItemToFBActivityLogListview_Button_Click
        AddHandler EditSelectedFBActivityLogListviewItem_Button.Click, AddressOf mainFormEventHandlers.EditSelectedFBActivityLogListviewItem_Button_Click

        AddHandler DeselectAllFBActivityLogs_ListViewItems_Button.Click, AddressOf mainFormEventHandlers.DeselectAllFBActivityLogs_ListViewItems_Button_Click

        ' ### FB Notifications
        AddHandler ReadFBNotifications_Button.Click, AddressOf mainFormEventHandlers.ReadFBNotifications_Button_Click
        AddHandler SaveFBNotificationsListview_Button.Click, AddressOf mainFormEventHandlers.SaveFBNotificationsListview_Button_Click
        AddHandler FBNotificationsData_Listview.SelectedIndexChanged, AddressOf mainFormEventHandlers.FBNotificationsData_Listview_SelectedIndexChanged
        AddHandler DeleteSelectedFBNotificationsListviewItems_Button.Click, AddressOf mainFormEventHandlers.DeleteSelectedFBNotificationsListviewItems_Button_Click
        AddHandler FBNotificationsDisplayCurrUrl_Button.Click, AddressOf mainFormEventHandlers.FBNotificationsDisplayCurrUrl_Button_Click
        AddHandler FBNotificationsNavigateToSelectedURL_Button.Click, AddressOf mainFormEventHandlers.FBNotificationsNavigateToSelectedURL_Button_Click
        AddHandler FBNotificationsAddItemToListview_Button.Click, AddressOf mainFormEventHandlers.FBNotificationsAddItemToListview_Button_Click
        AddHandler FBNotificationsEditSelectedListviewItem_Button.Click, AddressOf mainFormEventHandlers.FBNotificationsEditSelectedListviewItem_Button_Click

        AddHandler DeselecteAllFBNotificationsData_ListviewItems_Button.Click, AddressOf mainFormEventHandlers.DeselecteAllFBNotificationsData_ListviewItems_Button_Click


        ' ### FB Messenger
        'AddHandler ReadFBNotifications_Button.Click, AddressOf mainFormEventHandlers.ReadFBNotifications_Button_Click

        AddHandler SaveFBMessengerListview_Button.Click, AddressOf mainFormEventHandlers.SaveFBMessengerListview_Button_Click
        AddHandler FBMessengerData_Listview.SelectedIndexChanged, AddressOf mainFormEventHandlers.FBMessengerData_Listview_SelectedIndexChanged
        AddHandler DeleteSelectedFBMessengerListviewItems_Button.Click, AddressOf mainFormEventHandlers.DeleteSelectedFBMessengerListviewItems_Button_Click
        AddHandler FBMessengerDisplayCurrUrl_Button.Click, AddressOf mainFormEventHandlers.FBMessengerDisplayCurrUrl_Button_Click
        AddHandler FBMessengerNavigateToSelectedURL_Button.Click, AddressOf mainFormEventHandlers.FBMessengerNavigateToSelectedURL_Button_Click
        AddHandler FBMessengerAddItemToListview_Button.Click, AddressOf mainFormEventHandlers.FBMessengerAddItemToListview_Button_Click
        AddHandler FBMessengerEditSelectedListviewItem_Button.Click, AddressOf mainFormEventHandlers.FBMessengerEditSelectedListviewItem_Button_Click
        AddHandler DeselecteAllFBMessenger_ListviewItems_Button.Click, AddressOf mainFormEventHandlers.DeselecteAllFBMessengerData_ListviewItems_Button_Click
        AddHandler FBMessengerNavigateToMessenger_Button.Click, AddressOf mainFormEventHandlers.FBMessengerNavigateToMessenger_Button_Click
        AddHandler FBMessengerReadMessage_Button.Click, AddressOf mainFormEventHandlers.FBMessengerReadMessage_Button_Click

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
        AddHandler FBMarketplaceDeleteSelectedMedia_Button.Click, AddressOf FBMarketplaceEventHandlers.FBMarketplaceDeleteSelectedMedia_Button_Click
        AddHandler FBMarkplaceProducts_ListBox.DoubleClick, AddressOf FBMarketplaceEventHandlers.FBMarkplaceProducts_ListBox_DoubleClick
    End Sub

    Private Sub RegisterFBPostShareURLEventHanders()
        ' 這邊是用來發帖分享網址相關的事件
        AddHandler FBPostShareURLCreateNewAssetFolder_Button.Click, AddressOf FBPostShareURLEventHandlers.FBPostShareURLCreateNewAssetFolder_Button_Click
        AddHandler FBPostShareURLDeselectAllAssetFolderListboxItems_Button.Click, AddressOf FBPostShareURLEventHandlers.FBPostShareURLDeselectAllAssetFolderListboxItems_Button_Click
        AddHandler FBPostShareURLAssetFolder_ListBox.DoubleClick, AddressOf FBPostShareURLEventHandlers.FBPostShareURLAssetFolder_ListBox_DoubleClick
        AddHandler FBPostShareURLDeleteSelectedAssetFolder_Button.Click, AddressOf FBPostShareURLEventHandlers.FBPostShareURLDeleteSelectedAssetFolder_Button_Click
        AddHandler FBPostShareURLCreateNewTextFile_Button.Click, AddressOf FBPostShareURLEventHandlers.FBPostShareURLCreateNewTextFile_Button_Click
        AddHandler FBPostShareURLDeleteSelectedTextFile_Button.Click, AddressOf FBPostShareURLEventHandlers.FBPostShareURLDeleteSelectedTextFile_Button_Click
        AddHandler FBPostShareURLAssetFolder_ListBox.SelectedIndexChanged, AddressOf FBPostShareURLEventHandlers.FBPostShareURLAssetFolder_ListBox_SelectedIndexChanged
        AddHandler FBPostShareURLTextFile_ListBox.SelectedIndexChanged, AddressOf FBPostShareURLEventHandlers.FBPostShareURLTextFile_ListBox_SelectedIndexChanged
        AddHandler FBPostShareURLSaveTextFile_Button.Click, AddressOf FBPostShareURLEventHandlers.FBPostShareURLSaveTextFile_Button_Click
        AddHandler FBPostShareURLTextFile_ListBox.DoubleClick, AddressOf FBPostShareURLEventHandlers.FBPostShareURLTextFile_ListBox_DoubleClick
        AddHandler FBPostShareURLGetCurrentURL_Button.Click, AddressOf FBPostShareURLEventHandlers.FBPostShareURLGetCurrentURL_Button_Click
        AddHandler FBPostShareURLNavigateToURL_Button.Click, AddressOf FBPostShareURLEventHandlers.FBPostShareURLNavigateToURL_Button_Click

    End Sub


    Private Sub RegisterFBCommentEventHanders()
        ' 留言相關的事件
        AddHandler FBCommentCreateNewAssetFolder_Button.Click, AddressOf FBCommentEventHandlers.FBCommentCreateNewAssetFolder_Button_Click
        AddHandler FBCommentDeselectAllAssetFolderListboxItems_Button.Click, AddressOf FBCommentEventHandlers.FBCommentDeselectAllAssetFolderListboxItems_Button_Click
        AddHandler FBCommentDeleteSelectedAssetFolder_Button.Click, AddressOf FBCommentEventHandlers.FBCommentDeleteSelectedAssetFolder_Button_Click
        AddHandler FBCommentCreateNewTextFile_Button.Click, AddressOf FBCommentEventHandlers.FBCommentCreateNewTextFile_Button_Click
        AddHandler FBCommentAssetFolder_ListBox.SelectedIndexChanged, AddressOf FBCommentEventHandlers.FBCommentAssetFolder_ListBox_SelectedIndexChanged
        AddHandler FBCommentTextFileSelector_ListBox.SelectedIndexChanged, AddressOf FBCommentEventHandlers.FBCommentTextFileSelector_ListBox_SelectedIndexChanged
        AddHandler FBCommentDeleteSelectedTextFile_Button.Click, AddressOf FBCommentEventHandlers.FBCommentDeleteSelectedTextFile_Button_Click
        AddHandler FBCommentSaveTextFile_Button.Click, AddressOf FBCommentEventHandlers.FBCommentSaveTextFile_Button_Click
        AddHandler FBCommentMediaSelector_ListBox.SelectedIndexChanged, AddressOf FBCommentEventHandlers.FBCommentMediaSelector_ListBox_SelectedIndexChanged
        AddHandler FBCommentRevealMediaFoldesrInFileExplorer_Button.Click, AddressOf FBCommentEventHandlers.FBCommentRevealMediaFoldesrInFileExplorer_Button_Click
        AddHandler FBCommentDeleteSelectedMedia_Button.Click, AddressOf FBCommentEventHandlers.FBCommentDeleteSelectedMedia_Button_Click
        AddHandler FBCommentAssetFolder_ListBox.DoubleClick, AddressOf FBCommentEventHandlers.FBCommentAssetFolder_ListBox_DoubleClick
        AddHandler FBCommentTextFileSelector_ListBox.DoubleClick, AddressOf FBCommentEventHandlers.FBCommentTextFileSelector_ListBox_DoubleClick
    End Sub


    Private Sub RegisterFBCustomizeCommentEventhandlers()
        ' 自訂留言的事件
        AddHandler FBCustomizeCommentCreateNewAssetFolder_Button.Click, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentCreateNewAssetFolder_Button_Click
        AddHandler FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button.Click, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentDeselectAllAssetFolderListboxItems_Button_Click
        AddHandler FBCustomizeCommentDeleteSelectedAssetFolder_Button.Click, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentDeleteSelectedAssetFolder_Button_Click
        AddHandler FBCustomizeCommentCreateNewTextFile_Button.Click, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentCreateNewTextFile_Button_Click
        AddHandler FBCustomizeCommentAssetFolder_ListBox.SelectedIndexChanged, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentAssetFolder_ListBox_SelectedIndexChanged
        AddHandler FBCustomizeCommentTextFileSelector_ListBox.SelectedIndexChanged, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentTextFileSelector_ListBox_SelectedIndexChanged
        AddHandler FBCustomizeCommentDeleteSelectedTextFile_Button.Click, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentDeleteSelectedTextFile_Button_Click
        AddHandler FBCustomizeCommentSaveTextFile_Button.Click, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentSaveTextFile_Button_Click
        AddHandler FBCustomizeCommentMediaSelector_ListBox.SelectedIndexChanged, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentMediaSelector_ListBox_SelectedIndexChanged
        AddHandler FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button.Click, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentRevealMediaFoldesrInFileExplorer_Button_Click
        AddHandler FBCustomizeCommentDeleteSelectedMedia_Button.Click, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentDeleteSelectedMedia_Button_Click
        AddHandler FBCustomizeCommentAssetFolder_ListBox.DoubleClick, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentAssetFolder_ListBox_DoubleClick
        AddHandler FBCustomizeCommentTextFileSelector_ListBox.DoubleClick, AddressOf FBCustomizeCommentEventHandlers.FBCustomizeCommentTextFileSelector_ListBox_DoubleClick
    End Sub

    Private Sub RegisterFBResponseEventhandlers()
        ' 回應通知的事件
        AddHandler FBResponseCreateNewAssetFolder_Button.Click, AddressOf FBResponseEventHandlers.FBResponseCreateNewAssetFolder_Button_Click
        AddHandler FBResponseDeselectAllAssetFolderListboxItems_Button.Click, AddressOf FBResponseEventHandlers.FBResponseDeselectAllAssetFolderListboxItems_Button_Click
        AddHandler FBResponseDeleteSelectedAssetFolder_Button.Click, AddressOf FBResponseEventHandlers.FBResponseDeleteSelectedAssetFolder_Button_Click
        AddHandler FBResponseCreateNewTextFile_Button.Click, AddressOf FBResponseEventHandlers.FBResponseCreateNewTextFile_Button_Click
        AddHandler FBResponseAssetFolder_ListBox.SelectedIndexChanged, AddressOf FBResponseEventHandlers.FBResponseAssetFolder_ListBox_SelectedIndexChanged
        AddHandler FBResponseTextFileSelector_ListBox.SelectedIndexChanged, AddressOf FBResponseEventHandlers.FBResponseTextFileSelector_ListBox_SelectedIndexChanged
        AddHandler FBResponseDeleteSelectedTextFile_Button.Click, AddressOf FBResponseEventHandlers.FBResponseDeleteSelectedTextFile_Button_Click
        AddHandler FBResponseSaveTextFile_Button.Click, AddressOf FBResponseEventHandlers.FBResponseSaveTextFile_Button_Click
        AddHandler FBResponseMediaSelector_ListBox.SelectedIndexChanged, AddressOf FBResponseEventHandlers.FBResponseMediaSelector_ListBox_SelectedIndexChanged
        AddHandler FBResponseRevealMediaFoldesrInFileExplorer_Button.Click, AddressOf FBResponseEventHandlers.FBResponseRevealMediaFoldesrInFileExplorer_Button_Click
        AddHandler FBResponseDeleteSelectedMedia_Button.Click, AddressOf FBResponseEventHandlers.FBResponseDeleteSelectedMedia_Button_Click
        AddHandler FBResponseAssetFolder_ListBox.DoubleClick, AddressOf FBResponseEventHandlers.FBResponseAssetFolder_ListBox_DoubleClick
        AddHandler FBResponseTextFileSelector_ListBox.DoubleClick, AddressOf FBResponseEventHandlers.FBResponseTextFileSelector_ListBox_DoubleClick
    End Sub

    Private Sub RegisterFBMessegnerEventhandlers()
        ' 回應通知的事件
        AddHandler FBMessengerCreateNewAssetFolder_Button.Click, AddressOf FBMessengerEventHandlers.FBMessengerCreateNewAssetFolder_Button_Click
        AddHandler FBMessengerDeselectAllAssetFolderListboxItems_Button.Click, AddressOf FBMessengerEventHandlers.FBMessengerDeselectAllAssetFolderListboxItems_Button_Click
        AddHandler FBMessengerDeleteSelectedAssetFolder_Button.Click, AddressOf FBMessengerEventHandlers.FBMessengerDeleteSelectedAssetFolder_Button_Click
        AddHandler FBMessengerCreateNewTextFile_Button.Click, AddressOf FBMessengerEventHandlers.FBMessengerCreateNewTextFile_Button_Click
        AddHandler FBMessengerAssetFolder_ListBox.SelectedIndexChanged, AddressOf FBMessengerEventHandlers.FBMessengerAssetFolder_ListBox_SelectedIndexChanged
        AddHandler FBMessengerTextFileSelector_ListBox.SelectedIndexChanged, AddressOf FBMessengerEventHandlers.FBMessengerTextFileSelector_ListBox_SelectedIndexChanged
        AddHandler FBMessengerDeleteSelectedTextFile_Button.Click, AddressOf FBMessengerEventHandlers.FBMessengerDeleteSelectedTextFile_Button_Click
        AddHandler FBMessengerSaveTextFile_Button.Click, AddressOf FBMessengerEventHandlers.FBMessengerSaveTextFile_Button_Click
        AddHandler FBMessengerMediaSelector_ListBox.SelectedIndexChanged, AddressOf FBMessengerEventHandlers.FBMessengerMediaSelector_ListBox_SelectedIndexChanged
        AddHandler FBMessengerRevealMediaFoldesrInFileExplorer_Button.Click, AddressOf FBMessengerEventHandlers.FBMessengerRevealMediaFoldesrInFileExplorer_Button_Click
        AddHandler FBMessengerDeleteSelectedMedia_Button.Click, AddressOf FBMessengerEventHandlers.FBMessengerDeleteSelectedMedia_Button_Click
        AddHandler FBMessengerAssetFolder_ListBox.DoubleClick, AddressOf FBMessengerEventHandlers.FBMessengerAssetFolder_ListBox_DoubleClick
        AddHandler FBMessengerTextFileSelector_ListBox.DoubleClick, AddressOf FBMessengerEventHandlers.FBMessengerTextFileSelector_ListBox_DoubleClick
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
        RegisterFBPostShareURLEventHanders()
        RegisterFBCommentEventHanders()
        RegisterFBCustomizeCommentEventhandlers()
        RegisterFBResponseEventhandlers()
        RegisterFBMessegnerEventhandlers()

        ' EOF
        MainFormController.SetForm1TitleStatus("完成")
        emojiPickerForm = New EmojiPickerForm With {
            .Owner = Me,
            .TopMost = True
        }
        'emojiPickerForm.Show()
    End Sub



End Class
