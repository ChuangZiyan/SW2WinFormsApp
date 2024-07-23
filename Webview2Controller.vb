Imports System.Collections.ObjectModel
Imports Microsoft.Web.WebView2.Core
Imports Newtonsoft.Json
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
        Form1.ActivedWebview2UserData = ""
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


    Public Sub ReadCookie()
        Try
            'Debug.WriteLine("Read Cookie")
            If Form1.ActivedWebview2UserData = "" Then
                MsgBox("未偵測到啟用的Webview2")
                Exit Sub
            End If


            Dim cookies As ReadOnlyCollection(Of OpenQA.Selenium.Cookie) = edgeDriver.Manage().Cookies.AllCookies
            Dim cookieList As New List(Of myCookie)

            ' 顯示每個 cookie 的相關信息
            For Each cookie As OpenQA.Selenium.Cookie In cookies
                Debug.WriteLine($"Cookie Name: {cookie.Name}, Value: {cookie.Value}")
                Dim myCookieObj As New myCookie With {
                    .Name = cookie.Name,
                    .Value = cookie.Value,
                    .Domain = cookie.Domain,
                    .Path = cookie.Path
                }
                cookieList.Add(myCookieObj)
            Next

            Dim jsonStr As String = JsonConvert.SerializeObject(cookieList, Formatting.Indented)

            Form1.FBCookie_RichTextBox.Text = jsonStr

            MainFormController.SaveUserData(Form1.WebviewUserDataFolder_CheckedListBox.SelectedItem)

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Sub SetCookie()
        Try
            If Form1.ActivedWebview2UserData = "" Then
                MsgBox("未偵測到啟用的Webview2")
                Exit Sub
            End If

            Dim JsonText = Form1.FBCookie_RichTextBox.Text
            Dim CookieList As List(Of myCookie) = JsonConvert.DeserializeObject(Of List(Of myCookie))(JsonText)

            If CookieList Is Nothing Then
                MsgBox("Cookie格式錯誤")
                Exit Sub
            End If

            For Each ck In CookieList
                Debug.WriteLine("#### " + ck.Domain + " " + ck.Name + " " + ck.Value)
                Dim cookie As New OpenQA.Selenium.Cookie(ck.Name, ck.Value, ck.Domain, ck.Path, DateTime.Now.AddDays(365))
                edgeDriver.Manage.Cookies.AddCookie(cookie)
            Next

            'MsgBox("設定成功")
            'Me.DialogResult = System.Windows.Forms.DialogResult.OK
            'Me.Close()
            'CookieRichTextBox.Clear()
            ' edgeDriver.Navigate.Refresh()
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("Cookie設定失敗")
        End Try
    End Sub

    Public Class myCookie
        Public Property Domain As String
        Public Property Name As String
        Public Property Value As String
        Public Property Path As String

    End Class

End Module
