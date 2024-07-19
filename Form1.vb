Imports System.IO

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppInitModule.InitializeMainApp()
        Me.Text = "MainWebview2Form - 完成"
        Navigate_Url_TextBox.Text = "https://www.facebook.com/"
        'NavigateTo_Url_Button.Enabled = False
    End Sub

    Private Sub Form1_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Text = "MainWebview2Form - 關閉中..."
        If Webview2Controller.edgeDriver IsNot Nothing Then
            Webview2Controller.edgeDriver.Quit()
        End If
    End Sub

    Private Sub Active_WebviewEdge_Button_Click(sender As Object, e As EventArgs) Handles Activate_WebviewEdge_Button.Click
        Try
            Dim userDataFolder = Nothing
            Dim folderName = WebviewUserDataFolder_CheckedListBox.SelectedItem
            If folderName <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName)
            End If
            Dim debugPort = Webview_Edge_Debug_Port_NumericUpDown.Value
            RestartMainWebView2(userDataFolder, debugPort)
        Catch ex As Exception
            Debug.WriteLine(ex)
            'MsgBox("初始化失敗")
        End Try


    End Sub

    Private Async Sub NavigateTo_Url_Button_Click(sender As Object, e As EventArgs) Handles NavigateTo_Url_Button.Click
        Dim myUrl = Navigate_Url_TextBox.Text
        Await Navigate_GoToUrl_Task(myUrl)
    End Sub


    Private Sub Quit_EdgeDriver_Button_Click(sender As Object, e As EventArgs) Handles Quit_EdgeDriver_Button.Click
        Try
            Webview2Controller.edgeDriver.Quit()
            MsgBox("關閉成功")
        Catch ex As Exception
            MsgBox("關閉失敗")
        End Try

    End Sub

    Private Sub CreateUserDataFolderButton_Click(sender As Object, e As EventArgs) Handles CreateUserDataFolderButton.Click
        Dim folderName = UserDataFolderName_TextBox.Text
        MainFormController.CreateUserDataFolder(folderName)
    End Sub

    Private Sub DeleteSelectedUserDataFolderButton_Click(sender As Object, e As EventArgs) Handles DeleteSelectedUserDataFolderButton.Click
        Dim folderName = WebviewUserDataFolder_CheckedListBox.SelectedItem
        MainFormController.DeleteUserDataFolder(folderName)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles RestartWebview_Button.Click
        Webview2Controller.RestartMainWebView2(Nothing, 9222)
    End Sub

    Private Sub WebviewUserDataFolder_CheckedListBox_DoubleClick(sender As Object, e As EventArgs) Handles WebviewUserDataFolder_CheckedListBox.DoubleClick
        Try
            Dim userDataFolder = Nothing
            Dim folderName = WebviewUserDataFolder_CheckedListBox.SelectedItem
            If folderName <> "" Then
                userDataFolder = Path.Combine(AppInitModule.webivewUserDataDirectory, folderName)
            End If
            Dim debugPort = Webview_Edge_Debug_Port_NumericUpDown.Value
            RestartMainWebView2(userDataFolder, debugPort)
        Catch ex As Exception
            Debug.WriteLine(ex)
            'MsgBox("初始化失敗")
        End Try
    End Sub

End Class
