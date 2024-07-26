Imports System.IO

Public Class DebugForm
    Private Async Sub Activate_WebviewEdge_Button_Click(sender As Object, e As EventArgs) Handles Activate_WebviewEdge_Button.Click
        Try
            Dim userDataFolder = Nothing
            Dim folderName = Form1.WebviewUserDataFolder_ListBox.SelectedItem
            If folderName <> "" Then
                userDataFolder = Path.Combine(webivewUserDataDirectory, folderName)
            End If
            Dim debugPort = Webview_Edge_Debug_Port_NumericUpDown.Value
            Await Webview2Controller.RestartMainWebView2(userDataFolder, debugPort)
        Catch ex As Exception
            Debug.WriteLine(ex)
            'MsgBox("初始化失敗")
        End Try
    End Sub

    Private Sub Quit_EdgeDriver_Button_Click(sender As Object, e As EventArgs) Handles Quit_EdgeDriver_Button.Click
        Try
            Webview2Controller.edgeDriver.Quit()
            MsgBox("關閉成功")
        Catch ex As Exception
            MsgBox("關閉失敗")
        End Try

    End Sub


    Private Async Sub RestartWebview_Button_Click(sender As Object, e As EventArgs) Handles RestartWebview_Button.Click
        Dim debugPort = Webview_Edge_Debug_Port_NumericUpDown.Value
        Await Webview2Controller.RestartMainWebView2(Nothing, debugPort)
    End Sub

    Private Sub UpdateCheckedListBox_Button_Click(sender As Object, e As EventArgs) Handles UpdateCheckedListBox_Button.Click
        MainFormController.UpdateWebviewUserDataCheckListBox()
    End Sub

    Private Sub ResetWebview2_Button_Click(sender As Object, e As EventArgs) Handles ResetWebview2_Button.Click
        Webview2Controller.ResetWebview2()
    End Sub
End Class