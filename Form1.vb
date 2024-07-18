Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.WriteLine("Form1 Load")
        Navigate_Url_TextBox.Text = "https://www.facebook.com/"
        NavigateTo_Url_Button.Enabled = False
    End Sub

    Private Async Sub Active_WebviewEdge_Button_Click(sender As Object, e As EventArgs) Handles Activate_WebviewEdge_Button.Click
        Try
            Activate_WebviewEdge_Button.Enabled = False
            Dim debugPort = Webview_Edge_Debug_Port_NumericUpDown.Value
            Await Webview2Controller.InitializeWebView2(debugPort)
            Await Webview2Controller.InitializeEdgeDriver_Task(debugPort)
            MsgBox("初始化Webview2 Edge完成")
            NavigateTo_Url_Button.Enabled = True
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("初始化失敗")
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
End Class
