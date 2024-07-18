Imports Microsoft.Web.WebView2.Core
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Edge

Module Webview2Controller
    Public edgeDriver As IWebDriver
    Private webview2_environment As CoreWebView2Environment

    Public Async Function InitializeWebView2(debugPort) As Task
        webview2_environment = Await CoreWebView2Environment.CreateAsync(Nothing, Nothing, New CoreWebView2EnvironmentOptions("--remote-debugging-port=" & debugPort))
        Await Form1.Main_WebView2.EnsureCoreWebView2Async(webview2_environment)
    End Function


    Public Function InitializeEdgeDriver_Task(debugPort) As Task(Of Boolean)
        Return Task.Run(Function() InitializeEdgeDriver(debugPort))
    End Function

    Public Function InitializeEdgeDriver(debugPort) As Boolean
        Try
            Dim options As EdgeOptions = New EdgeOptions()
            options.AddArguments("--disable-dev-shm-usage", "--no-sandbox")
            options.DebuggerAddress = "localhost:" & debugPort

            Dim serv As EdgeDriverService = EdgeDriverService.CreateDefaultService
            serv.HideCommandPromptWindow = True 'hide cmd

            Threading.Thread.Sleep(500)
            edgeDriver = New EdgeDriver(serv, options)
            'Debug.WriteLine("init port " & debugPort)
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try


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
