Imports System.IO

Public Class DebugForm
    Private Sub Activate_WebviewEdge_Button_Click(sender As Object, e As EventArgs) Handles Activate_WebviewEdge_Button.Click
        Try
            Dim userDataFolder = Nothing
            Dim folderName = Form1.WebviewUserDataFolder_CheckedListBox.SelectedItem
            If folderName <> "" Then
                userDataFolder = Path.Combine(webivewUserDataDirectory, folderName)
            End If
            Dim debugPort = Webview_Edge_Debug_Port_NumericUpDown.Value
            Webview2Controller.RestartMainWebView2(userDataFolder, debugPort)
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


    Private Sub RestartWebview_Button_Click(sender As Object, e As EventArgs) Handles RestartWebview_Button.Click
        Dim debugPort = Webview_Edge_Debug_Port_NumericUpDown.Value
        Webview2Controller.RestartMainWebView2(Nothing, debugPort)
    End Sub

    Private Sub UpdateCheckedListBox_Button_Click(sender As Object, e As EventArgs) Handles UpdateCheckedListBox_Button.Click
        MainFormController.UpdateWebviewUserDataCheckListBox()
    End Sub

End Class