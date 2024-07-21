Imports Microsoft.Web.WebView2.Core
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Edge

Module Webview2Controller
    Public edgeDriver As IWebDriver
    Private webview2_environment As CoreWebView2Environment

    Public Async Function InitializeWebView2(userDataFolder As String, debugPort As Integer) As Task
        webview2_environment = Await CoreWebView2Environment.CreateAsync(Nothing, userDataFolder, New CoreWebView2EnvironmentOptions("--remote-debugging-port=" & debugPort))
        Await Form1.Main_WebView2.EnsureCoreWebView2Async(webview2_environment)
    End Function

    Public Function InitializeEdgeDriver_Task(debugPort As Integer) As Task(Of Boolean)
        Return Task.Run(Function() InitializeEdgeDriver(debugPort))
    End Function

    Public Function InitializeEdgeDriver(debugPort As Integer) As Boolean
        Try
            Dim options As EdgeOptions = New EdgeOptions()
            options.AddArguments("--disable-dev-shm-usage", "--no-sandbox")
            options.DebuggerAddress = "localhost:" & debugPort

            Dim serv As EdgeDriverService = EdgeDriverService.CreateDefaultService
            serv.HideCommandPromptWindow = True

            Threading.Thread.Sleep(500)
            edgeDriver = New EdgeDriver(serv, options)
            'Debug.WriteLine("init port " & debugPort)
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try

    End Function

    Public Async Sub RestartMainWebView2(userDataFolder As String, debugPort As Integer)

        Try
            Form1.Text = "MainWebview2Form - 載入中..."

            ResetWebview2()
            Await Webview2Controller.InitializeWebView2(userDataFolder, debugPort)
            Await Webview2Controller.InitializeEdgeDriver_Task(debugPort)

            Await Navigate_GoToUrl_Task("https://www.facebook.com/")
            Form1.Text = "MainWebview2Form - 完成"
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("重啟失敗")
        End Try

    End Sub

    Public Sub ResetWebview2()
        ' reset edgeDriver
        If edgeDriver IsNot Nothing Then
            edgeDriver.Quit()
        End If

        ' reset webview
        Dim webViewLocation As Point = Point.Empty
        Dim webViewSize As Size = Size.Empty

        If Form1.Main_WebView2 IsNot Nothing Then
            ' save location and size 
            webViewLocation = Form1.Main_WebView2.Location
            webViewSize = Form1.Main_WebView2.Size

            ' release WebView2 
            Form1.Main_WebView2.Dispose()
            Form1.Controls.Remove(Form1.Main_WebView2)
            Form1.Main_WebView2 = Nothing
        End If

        ' create new webview2 and restore location and size
        Form1.Main_WebView2 = New Microsoft.Web.WebView2.WinForms.WebView2() With {
            .Location = webViewLocation,
            .Size = webViewSize
        }
        Form1.Controls.Add(Form1.Main_WebView2)
    End Sub

    Public Async Function Delay_msec(msec As Integer) As Task
        Await Task.Delay(msec)
    End Function


    Public Function Navigate_GoToUrl_Task(url) As Task(Of Boolean)
        Return Task.Run(Function() Navigate_GoToUrl(url))
    End Function


    Private Async Function Navigate_GoToUrl(url As String) As Task(Of Boolean)
        Try
            edgeDriver.Navigate.GoToUrl(url)
            Threading.Thread.Sleep(300)
            Await IsAlertPresentAsync()
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try

    End Function
    Private Async Function IsAlertPresentAsync() As Task(Of Boolean)
        Try
            Dim alert As IAlert = Await Task.Run(
                    Function()
                        Try
                            Return edgeDriver.SwitchTo().Alert()
                        Catch ex As Exception
                            Return False
                        End Try
                    End Function
                )
            Await Task.Run(Sub() alert.Accept())

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


End Module
