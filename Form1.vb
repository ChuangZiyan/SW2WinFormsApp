Imports System.IO
Imports System.Security.Policy
Imports Newtonsoft.Json

Public Class Form1


    Private Sub Form1_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainFormController.SetForm1TitleStatus("關閉中...")
        If Webview2Controller.edgeDriver IsNot Nothing Then
            Webview2Controller.edgeDriver.Quit()
        End If


    End Sub

    Private Async Sub NavigateTo_Url_Button_Click(sender As Object, e As EventArgs) Handles NavigateTo_Url_Button.Click
        Dim myUrl = Navigate_Url_TextBox.Text
        Await Navigate_GoToUrl_Task(myUrl)
    End Sub


    Private Sub CreateUserDataFolderButton_Click(sender As Object, e As EventArgs) Handles CreateUserDataFolderButton.Click
        Dim folderName = UserDataFolderName_TextBox.Text
        MainFormController.CreateUserDataFolder(folderName)
    End Sub

    Private Sub SaveUserData_Button_Click(sender As Object, e As EventArgs) Handles SaveUserData_Button.Click
        MainFormController.SaveUserData(WebviewUserDataFolder_ListBox.SelectedItem)
    End Sub

    Private Sub Move_UserDataFolder_Button_Click(sender As Object, e As EventArgs) Handles Move_UserDataFolder_Button.Click
        MainFormController.MoveUserDataFolder()
    End Sub


    Private Async Sub WebviewUserDataFolder_ListBox_DoubleClick(sender As Object, e As EventArgs) Handles WebviewUserDataFolder_ListBox.DoubleClick
        Try
            'Debug.WriteLine("IsWebview2Lock" & IsWebview2Lock)
            If WebviewUserDataFolder_ListBox.SelectedItem = "" Then
                Exit Sub
            End If

            If IsWebview2Lock = True Then
                MsgBox("Webview2載入中，請稍後")
                Exit Sub
            End If

            Dim userDataFolder = Nothing
            Dim folderName = Split(WebviewUserDataFolder_ListBox.SelectedItem, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(webivewUserDataDirectory, folderName(0), folderName(1))
            End If
            ' need to auto detect debug port
            ' use 9222 for development
            'Dim debugPort = DebugForm.Webview_Edge_Debug_Port_NumericUpDown.Value
            'Dim debugPort = 9222
            Await RestartMainWebView2(userDataFolder)
            Await Navigate_GoToUrl_Task(Navigate_Url_TextBox.Text)
        Catch ex As Exception
            Debug.WriteLine(ex)
            'MsgBox("初始化失敗")
        End Try
    End Sub



    Private Sub RevealFBPasswordText_Button_Click(sender As Object, e As EventArgs) Handles RevealFBPasswordText_Button.Click
        If FBPassword_TextBox.PasswordChar = "*" Then
            RevealFBPasswordText_Button.Text = "隱藏"
            FBPassword_TextBox.PasswordChar = vbNullChar
        ElseIf FBPassword_TextBox.PasswordChar = vbNullChar Then
            RevealFBPasswordText_Button.Text = "顯示"
            FBPassword_TextBox.PasswordChar = "*"
        End If

    End Sub

    Private Sub RevealEmailPasswordText_Button_Click(sender As Object, e As EventArgs) Handles RevealEmailPasswordText_Button.Click
        If EmailPassword_TextBox.PasswordChar = "*" Then
            RevealEmailPasswordText_Button.Text = "隱藏"
            EmailPassword_TextBox.PasswordChar = vbNullChar
        ElseIf EmailPassword_TextBox.PasswordChar = vbNullChar Then
            RevealEmailPasswordText_Button.Text = "顯示"
            EmailPassword_TextBox.PasswordChar = "*"
        End If
    End Sub

    Private Sub WebviewUserDataFolder_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WebviewUserDataFolder_ListBox.SelectedIndexChanged
        MainFormController.DisplayUserData(WebviewUserDataFolder_ListBox.SelectedItem)
        MainFormController.DisplayGroupList(WebviewUserDataFolder_ListBox.SelectedItem)
    End Sub

    Private Sub ReadCookie_Button_Click(sender As Object, e As EventArgs) Handles ReadCookie_Button.Click
        ReadCookie()
    End Sub


    Private Sub SetCookie_Button_Click(sender As Object, e As EventArgs) Handles SetCookie_Button.Click
        SetCookie()
    End Sub

    Private Async Sub TurnOnSetSeleteKeyboardShortcuts_Button_Click(sender As Object, e As EventArgs) Handles TurnOnSetSeleteKeyboardShortcuts_Button.Click

        Dim WebviewUserDataFolders As New List(Of String)()
        For Each item In WebviewUserDataFolder_ListBox.SelectedItems
            WebviewUserDataFolders.Add(item.ToString)
        Next

        For Each item As String In WebviewUserDataFolders

            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(item, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))

                Await Webview2Controller.RestartMainWebView2(userDataFolder)
                Await Webview2Controller.Navigate_GoToUrl_Task("https://www.facebook.com/")
                Await Webview2Controller.Delay_msec(1000)
                Await Webview2Controller.TurnOnFBKeyboardShortcuts_Task()
                Await Webview2Controller.Delay_msec(1000)
                'Debug.WriteLine("EOF")
            End If
        Next
    End Sub

    Private Async Sub SetSeletedFBLanguageTo_zhTW_Button_Click(sender As Object, e As EventArgs) Handles SetSeletedFBLanguageTo_zhTW_Button.Click

        Dim WebviewUserDataFolders As New List(Of String)()
        For Each item In WebviewUserDataFolder_ListBox.SelectedItems
            WebviewUserDataFolders.Add(item.ToString)
        Next

        For Each item As String In WebviewUserDataFolders
            'Debug.WriteLine("item : " & item)

            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(item, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))
            End If

            Await Webview2Controller.RestartMainWebView2(userDataFolder)
            Await Webview2Controller.Navigate_GoToUrl_Task("https://www.facebook.com/")
            Await Webview2Controller.Delay_msec(1000)

            Await SetFBLanguageTo_zhTW_Task()
            Await Webview2Controller.Delay_msec(1000)
            'Debug.WriteLine("EOF")
        Next

    End Sub

    Private Async Sub RequestFriend_Button_Click(sender As Object, e As EventArgs) Handles RequestFriend_Button.Click
        Dim WebviewUserDataFolders As New List(Of String)()
        For Each item In WebviewUserDataFolder_ListBox.SelectedItems
            WebviewUserDataFolders.Add(item.ToString)
        Next

        For Each item As String In WebviewUserDataFolders
            'Debug.WriteLine("item : " & item)

            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(item, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))
            End If

            Await Webview2Controller.RestartMainWebView2(userDataFolder)
            Await Webview2Controller.Delay_msec(1000)

            Await Navigate_GoToUrl_Task(Navigate_Url_TextBox.Text)

            Await FBRquestFrient()

            Await Webview2Controller.Delay_msec(1000)
            'Debug.WriteLine("EOF")
        Next
    End Sub

    Private Sub GetCurrentUrl_Button_Click(sender As Object, e As EventArgs) Handles GetCurrentUrl_Button.Click
        Try
            Navigate_Url_TextBox.Text = Webview2Controller.edgeDriver.Url
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("未偵測到Edge driver")
        End Try

    End Sub

    Private Sub GetFBGroupList_Button_Click(sender As Object, e As EventArgs) Handles GetFBGroupList_Button.Click
        Webview2Controller.GetFBGroupList()
    End Sub

    Private Sub SaveListviewGroupList_Button_Click(sender As Object, e As EventArgs) Handles SaveListviewGroupList_Button.Click
        MainFormController.SaveGroupListviewData()
    End Sub

    Private Sub FBGroups_ListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FBGroups_ListView.SelectedIndexChanged
        MainFormController.DisplaySelectedGroup()
    End Sub

    Private Async Sub NavigateToSelectedGroup_Button_Click(sender As Object, e As EventArgs) Handles NavigateToSelectedGroup_Button.Click
        Try
            If edgeDriver IsNot Nothing Then
                Await Webview2Controller.Navigate_GoToUrl_Task(FBGroupUrl_TextBox.Text)
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Private Sub DisplayCurrUrlToGroupUrl_Button_Click(sender As Object, e As EventArgs) Handles DisplayCurrUrlToGroupUrl_Button.Click
        Try
            If edgeDriver IsNot Nothing Then
                FBGroupUrl_TextBox.Text = edgeDriver.Url
            Else
                MsgBox("未偵測到EdgeDriver")
            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Private Sub AddGroupDataToGroupListview_Button_Click(sender As Object, e As EventArgs) Handles AddGroupDataToGroupListview_Button.Click
        MainFormController.AddNewGroupDataToGroupListview()
    End Sub

    Private Sub EditSelectedGroupListviewItem_Button_Click(sender As Object, e As EventArgs) Handles EditSelectedGroupListviewItem_Button.Click
        MainFormController.EditSelectedGroupListviewItem()
    End Sub

    Private Sub DeleteSelectedGroup_Button_Click(sender As Object, e As EventArgs) Handles DeleteSelectedGroup_Button.Click
        MainFormController.DeleteSelectedGroupList()
    End Sub

    Private Sub GetJoinedGroupList_Button_Click(sender As Object, e As EventArgs) Handles GetJoinedGroupList_Button.Click
        Webview2Controller.GetJoinedGroupList()
    End Sub

    Private Sub CreateNewAssetFolder_Button_Click(sender As Object, e As EventArgs) Handles CreateNewAssetFolder_Button.Click
        MainFormController.CreateNewAssetFolder(NewAssetFolderName_TextBox.Text)
    End Sub

    Private Sub DeleteSelectedAssetFolder_Button_Click(sender As Object, e As EventArgs) Handles DeleteSelectedAssetFolder_Button.Click

        MainFormController.DeletedSelectedAssetFolders()
    End Sub
    Private Sub MyAssetsFolder_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MyAssetsFolder_ListBox.SelectedIndexChanged
        Dim selectedItem = MyAssetsFolder_ListBox.SelectedItem
        If selectedItem IsNot Nothing Then
            MainFormController.UpdateTextFileSelectorListBoxItems(selectedItem)
            MainFormController.UpdateMediaSelectorListBoxItems(selectedItem)
        End If
    End Sub

    Private Sub MediaSelector_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MediaSelector_ListBox.SelectedIndexChanged
        Dim selectedItem = MediaSelector_ListBox.SelectedItem
        If selectedItem IsNot Nothing Then
            MainFormController.PreviewMediaToPictureBox(selectedItem)
        End If


    End Sub

    Private Sub TextFileSelector_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TextFileSelector_ListBox.SelectedIndexChanged
        Dim selectedItem = TextFileSelector_ListBox.SelectedItem
        If selectedItem IsNot Nothing Then
            MainFormController.PreviewTextFileToRichTextBox(selectedItem)
        End If
    End Sub

    Private Sub CreateNewTextFile_Button_Click(sender As Object, e As EventArgs) Handles CreateNewTextFile_Button.Click
        Dim fileName = NewTextFileName_TextBox.Text
        MainFormController.CreateNewTextFile(fileName)
    End Sub

    Private Sub SaveEditedTextFile_Button_Click(sender As Object, e As EventArgs) Handles SaveEditedTextFile_Button.Click
        Dim selectedItem = TextFileSelector_ListBox.SelectedItem
        If selectedItem IsNot Nothing Then
            MainFormController.SaveEditedTextFile(selectedItem)
        Else
            MsgBox("未選擇檔案")
        End If

    End Sub


    Public PAUSE As Boolean = False

    Private Async Sub ExecutionScriptQueue_Button_Click(sender As Object, e As EventArgs) Handles ExecutionScriptQueue_Button.Click
        Dim executionCount As Integer = ScriptExecutionCount_NumericUpDown.Value
        ExecutionScriptQueue_Button.Enabled = False
        For run = 1 To executionCount Step 1
            ExecutionScriptQueue_Button.Text = "剩餘次數 : " & executionCount - run
            Await ExecutionListviewScript()
        Next

        ExecutionScriptQueue_Button.Enabled = True
        ExecutionScriptQueue_Button.Text = "執行腳本"
    End Sub



    ' 這個是主要執行腳本的功能區段
    Private Async Function ExecutionListviewScript() As Task
        PAUSE = False
        For Each item As ListViewItem In ScriptQueue_ListView.Items

            Dim userData As String = item.SubItems(0).Text
            Dim executionTime As String = item.SubItems(1).Text
            Dim myUrlName As String = item.SubItems(2).Text
            Dim myUrl As String = item.SubItems(3).Text
            Dim action As String = item.SubItems(4).Text
            Dim content As String = item.SubItems(5).Text
            Dim uploadWaitTime = item.SubItems(6).Text
            Dim submitWaitTime = item.SubItems(7).Text

            Dim executionSuccessResultCount As String = item.SubItems(8).Text
            Dim executionFailResultCount As String = item.SubItems(9).Text
            Dim waitSecond As String = item.SubItems(10).Text
            Dim remark As String = item.SubItems(11).Text

            'Debug.WriteLine("############## Run #################")
            'Debug.WriteLine("userData: " & userData)
            'Debug.WriteLine("executionTime: " & executionTime)
            'Debug.WriteLine("myUrlName: " & myUrlName)
            'Debug.WriteLine("myUrl: " & myUrl)
            'Debug.WriteLine("content: " & content)
            'Debug.WriteLine("executionResult: " & executionResult)
            'Debug.WriteLine("waitSecond: " & waitSecond)

            ' 判斷略過
            If remark = "略過" Then
                Continue For
            End If


            ' 執行的那行要變色
            item.BackColor = Color.SteelBlue
            item.ForeColor = Color.White


            '用選的userData 初始化webview
            Dim userDataFolderPath = Path.Combine(AppInitModule.webivewUserDataDirectory, userData)
            ' 初始化webivew
            Await Webview2Controller.RestartMainWebView2(userDataFolderPath)


            'Main Routing 主要路由在這

            'Debug.WriteLine("#######")
            Dim result = False
            Await Delay_msec(1000)
            Select Case action
                Case "發帖"
                    'Debug.WriteLine("發帖")
                    Dim assetFolderPath = GetRandomAssetFolder(content)
                    item.SubItems(5).Text = "資料夾->" & Path.GetFileName(assetFolderPath)
                    result = Await Webview2Controller.WritePostOnFacebook(myUrl, assetFolderPath)

                    ' 執行完後復原執行內容
                    item.SubItems(5).Text = content
            End Select

            ' 增加成功或者失敗的次數
            If result Then
                item.SubItems(8).Text = (CInt(item.SubItems(6).Text) + 1).ToString
            ElseIf Not result Then
                item.SubItems(9).Text = (CInt(item.SubItems(7).Text) + 1).ToString
            End If



            '跑完腳本後等待
            Dim splitedWaitSecond = waitSecond.Split("±")
            Dim myWaitSecs = CInt(splitedWaitSecond(0)) + UtilsModule.GetRandomRangeValue(CInt(splitedWaitSecond(1)))

            If myWaitSecs > 0 Then
                For i As Integer = myWaitSecs To 0 Step -1
                    While PAUSE
                        Await Delay_msec(1000)
                    End While
                    item.SubItems(10).Text = i.ToString()
                    Await Delay_msec(1000)
                Next
            Else
                item.SubItems(10).Text = "0"
            End If

            While PAUSE
                Await Delay_msec(1000)
            End While


            ' 等待完後重設
            item.SubItems(10).Text = waitSecond
            item.BackColor = Color.White
            item.ForeColor = Color.Black

        Next

    End Function




    Private mainFormEventHandlers As New MainFormEventHandlers()

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Main_WebView2.Source = New Uri("about:blank")
        AppInitModule.InitializeMainApp()
        MainFormController.LoadFileToScriptListview()

        Navigate_Url_TextBox.Text = "https://www.facebook.com/"
        'NavigateTo_Url_Button.Enabled = False
        Await Webview2Controller.GetWebview2EdgeVersion()
        'Webview2EdgeVersion_TextBox.Text = Webview2Controller.Webview2EdgeVersion

        ' Register to event Event Handlers
        AddHandler MyAssetsFolder_ListBox.DoubleClick, AddressOf mainFormEventHandlers.RevealAssetFolderInFileExplorer_DoubleClick
        AddHandler DeleteSelectedTextFiles_Button.Click, AddressOf mainFormEventHandlers.DeleteSelectedTextFiles_Button_Click
        AddHandler RevealMediaFoldesrInFileExplorer_Button.Click, AddressOf mainFormEventHandlers.RevealMediaFoldersInFileExplorer_Button_Click
        AddHandler DeleteSelectedMedia_Button.Click, AddressOf mainFormEventHandlers.DeleteSelectedMediaFile_Button_Click
        AddHandler DeleteSelectedUserDataFolderButton.Click, AddressOf mainFormEventHandlers.DeleteUserDataFolders_Button_Click
        AddHandler FilterAvailableUserData_CheckBox.Click, AddressOf mainFormEventHandlers.UpdateWebviewUserDataCheckListBox_CheckBox_Click
        AddHandler FilterUnavailableUserData_CheckBox.Click, AddressOf mainFormEventHandlers.UpdateWebviewUserDataCheckListBox_CheckBox_Click
        AddHandler TextFileSelector_ListBox.DoubleClick, AddressOf mainFormEventHandlers.EditSelectedTextFileWithNotepad
        AddHandler MediaSelector_ListBox.DoubleClick, AddressOf mainFormEventHandlers.PlaySelectedMedia
        AddHandler InsertToQueueListview_Button.Click, AddressOf mainFormEventHandlers.InsertToQueueListview_Button_Click
        AddHandler DeselectAllMyAssetFolderListboxItems_Button.Click, AddressOf mainFormEventHandlers.DeselectAllMyAssetFolderListboxItems_Button_Click
        AddHandler PauseScriptExecution_Button.Click, AddressOf mainFormEventHandlers.PauseScriptExecution_Button_Click
        AddHandler ContinueScriptExecution_Button.Click, AddressOf mainFormEventHandlers.ContinueScriptExecution_Button_Click
        AddHandler MarkUserDataToSkip_Button.Click, AddressOf mainFormEventHandlers.MarkUserDataToSkip_Button_Click
        AddHandler UnmarkUserDataToSkip_Button_Button.Click, AddressOf mainFormEventHandlers.UnmarkUserDataToSkip_Button_Button_Click
        AddHandler SveScriptListViewToCSVFile_Button.Click, AddressOf mainFormEventHandlers.SaveScriptListViewToFile_Button_Click
        AddHandler MarkSelectedScriptListviewItem_Button.Click, AddressOf mainFormEventHandlers.MarkSelectedScriptListviewItem_Button_Click
        AddHandler UnmarkSelectedScriptListviewItem_Button.Click, AddressOf mainFormEventHandlers.UnmarkSelectedScriptListviewItem_Button_Click

        AddHandler ScriptQueue_ListView.SelectedIndexChanged, AddressOf mainFormEventHandlers.ScriptQueue_ListView_SelectedIndexChanged

        AddHandler DeleteSelectedScriptListviewItem_Button.Click, AddressOf mainFormEventHandlers.DeleteSelectedScriptListviewItem_Button_Click

        AddHandler DeleteScriptListviewItemByUserData_Button.Click, AddressOf mainFormEventHandlers.DeleteScriptListviewItemByUserData_Button_Click


        AddHandler ModifySelectedScriptListviewWaitTime_Button.Click, AddressOf mainFormEventHandlers.ModifySelectedScriptListviewWaitTime
        AddHandler ModifySelectedScriptListviewAsset_Button.Click, AddressOf mainFormEventHandlers.ModifySelectedScriptListviewAsset_Button_Click
        AddHandler ResetScript_Button.Click, AddressOf mainFormEventHandlers.ResetScript_Button_Click
        MainFormController.SetForm1TitleStatus("完成")
    End Sub


End Class
