Imports System.IO
Imports System.Security.Policy
Imports Newtonsoft.Json

Public Class Form1

    Private mainFormEventHandlers As New MainFormEventHandlers()

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Main_WebView2.Source = New Uri("about:blank")
        AppInitModule.InitializeMainApp()
        MainFormController.SetForm1TitleStatus("完成")
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
    End Sub




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


End Class
