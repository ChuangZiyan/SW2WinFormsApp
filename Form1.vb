Imports System.IO
Imports Newtonsoft.Json

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppInitModule.InitializeMainApp()
        MainFormController.SetForm1TitleStatus("完成")
        Navigate_Url_TextBox.Text = "https://www.facebook.com/"
        'NavigateTo_Url_Button.Enabled = False
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

    Private Sub DeleteSelectedUserDataFolderButton_Click(sender As Object, e As EventArgs) Handles DeleteSelectedUserDataFolderButton.Click

        MainFormController.DeleteUserDataFolders()

        'Dim folderName = WebviewUserDataFolder_CheckedListBox.SelectedItem
        'MainFormController.DeleteUserDataFolder(folderName)
    End Sub

    Private Async Sub WebviewUserDataFolder_CheckedListBox_DoubleClick(sender As Object, e As EventArgs) Handles WebviewUserDataFolder_CheckedListBox.DoubleClick
        Try
            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(WebviewUserDataFolder_CheckedListBox.SelectedItem, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))
            End If
            ' need to auto detect debug port
            ' use 9222 for development
            Dim debugPort = DebugForm.Webview_Edge_Debug_Port_NumericUpDown.Value
            'Dim debugPort = 9222
            Await RestartMainWebView2(userDataFolder, debugPort)


        Catch ex As Exception
            Debug.WriteLine(ex)
            'MsgBox("初始化失敗")
        End Try
    End Sub

    Private Sub SaveUserData_Button_Click(sender As Object, e As EventArgs) Handles SaveUserData_Button.Click
        MainFormController.SaveUserData(WebviewUserDataFolder_CheckedListBox.SelectedItem)
    End Sub

    Private Sub FilterAvailableUserData_CheckBox_Click(sender As Object, e As EventArgs) Handles FilterAvailableUserData_CheckBox.Click
        MainFormController.UpdateWebviewUserDataCheckListBox()
    End Sub

    Private Sub FilterUnavailableUserData_CheckBox_Click(sender As Object, e As EventArgs) Handles FilterUnavailableUserData_CheckBox.Click
        MainFormController.UpdateWebviewUserDataCheckListBox()
    End Sub

    Private Sub Move_UserDataFolder_Button_Click(sender As Object, e As EventArgs) Handles Move_UserDataFolder_Button.Click
        MainFormController.MoveUserDataFolder()
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

    Private Sub WebviewUserDataFolder_CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WebviewUserDataFolder_CheckedListBox.SelectedIndexChanged
        DisplayUserData(WebviewUserDataFolder_CheckedListBox.SelectedItem)
    End Sub

    Private Sub ReadCookie_Button_Click(sender As Object, e As EventArgs) Handles ReadCookie_Button.Click
        ReadCookie()
        ' save to user data after read cookie
        ' ... to be ddd

    End Sub

    Private Sub ShowDebugPanel_Button_Click(sender As Object, e As EventArgs) Handles ShowDebugPanel_Button.Click
        If DebugForm.Visible = False Then
            DebugForm.Show()
        Else
            DebugForm.Hide()
        End If

    End Sub

    Private Sub SetCookie_Button_Click(sender As Object, e As EventArgs) Handles SetCookie_Button.Click
        SetCookie()
    End Sub

    Private Async Sub TurnOnSetSeleteKeyboardShortcuts_Button_Click(sender As Object, e As EventArgs) Handles TurnOnSetSeleteKeyboardShortcuts_Button.Click
        For Each item As String In WebviewUserDataFolder_CheckedListBox.CheckedItems

            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(item, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))

                Dim debugPort = DebugForm.Webview_Edge_Debug_Port_NumericUpDown.Value
                Await Webview2Controller.RestartMainWebView2(userDataFolder, debugPort)
                Await Webview2Controller.Delay_msec(1000)
                Await Webview2Controller.TurnOnFBKeyboardShortcuts_Task()
                Await Webview2Controller.Delay_msec(1000)
                'Debug.WriteLine("EOF")
            End If
        Next
    End Sub

    Private Async Sub SetSeletedFBLanguageTo_zhTW_Button_Click(sender As Object, e As EventArgs) Handles SetSeletedFBLanguageTo_zhTW_Button.Click

        For Each item As String In WebviewUserDataFolder_CheckedListBox.CheckedItems
            'Debug.WriteLine("item : " & item)

            Dim userDataFolder = Nothing
            Dim folderName() As String = Split(item, "\")

            If folderName(1) <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName(0), folderName(1))
            End If

            Dim debugPort = DebugForm.Webview_Edge_Debug_Port_NumericUpDown.Value
            Await Webview2Controller.RestartMainWebView2(userDataFolder, debugPort)
            Await Webview2Controller.Delay_msec(1000)

            Await SetFBLanguageTo_zhTW_Task()
            Await Webview2Controller.Delay_msec(1000)
            'Debug.WriteLine("EOF")
        Next

    End Sub

End Class
