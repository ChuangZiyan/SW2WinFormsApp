Imports System.Collections.ObjectModel
Imports Microsoft.Web.WebView2.Core
Imports Newtonsoft.Json
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Edge
Imports OpenQA.Selenium.Support.UI

Module Webview2Controller
    Public edgeDriver As IWebDriver
    Private webview2_environment As CoreWebView2Environment

    Public ActivedWebview2UserData = ""

    Public IsWebview2Lock As Boolean = False


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

    Public Async Function RestartMainWebView2(userDataFolder As String, debugPort As Integer) As Task(Of Boolean)

        Try
            IsWebview2Lock = True
            Debug.WriteLine("IsWebview2Lock" & IsWebview2Lock)
            SetForm1TitleStatus("載入中...")

            ResetWebview2()
            Await Webview2Controller.InitializeWebView2(userDataFolder, debugPort)
            Await Webview2Controller.InitializeEdgeDriver_Task(debugPort)

            Await Navigate_GoToUrl_Task("https://www.facebook.com/")
            Dim folderName = Split(userDataFolder, "\")
            ActivedWebview2UserData = folderName(UBound(folderName))
            SetForm1TitleStatus("完成")
            IsWebview2Lock = False
            Debug.WriteLine("EOF")
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            IsWebview2Lock = False
            'MsgBox("重啟失敗")
            Return False
        End Try

    End Function

    Public Sub ResetWebview2()
        Try
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
            ActivedWebview2UserData = ""
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

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


    Private Function ClickByCssSelector(CssSelector)
        Try
            edgeDriver.FindElement(By.CssSelector(CssSelector)).Click()
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
    End Function

    Private Sub ClickByCssSelectorWaitUntil(cssSelector As String, TimeSpanSec As Integer)
        Try
            Dim wait As WebDriverWait = New WebDriverWait(edgeDriver, TimeSpan.FromSeconds(TimeSpanSec))
            Dim element As IWebElement = wait.Until(Function(d) d.FindElement(By.CssSelector(cssSelector)))
            element.Click()
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Sub ReadCookie()
        Try
            'Debug.WriteLine("Read Cookie")
            If ActivedWebview2UserData = "" Then
                MsgBox("未偵測到啟用的Webview2")
                Exit Sub
            End If

            Dim cookies As ReadOnlyCollection(Of OpenQA.Selenium.Cookie) = edgeDriver.Manage().Cookies.AllCookies
            Dim cookieList As New List(Of myCookie)

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

    Public Async Sub SetCookie()
        Try
            If ActivedWebview2UserData = "" Then
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
                'Debug.WriteLine("#### " + ck.Domain + " " + ck.Name + " " + ck.Value)
                Dim cookie As New OpenQA.Selenium.Cookie(ck.Name, ck.Value, ck.Domain, ck.Path, DateTime.Now.AddDays(365))
                edgeDriver.Manage.Cookies.AddCookie(cookie)
            Next
            'MsgBox("設定成功")
            Await Delay_msec(500)
            Await Navigate_GoToUrl_Task(edgeDriver.Url)
            'Debug.WriteLine("EOF")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("Cookie設定失敗")
        End Try
    End Sub


    Public Function TurnOnFBKeyboardShortcuts_Task() As Task(Of Boolean)
        Return Task.Run(Function() TurnOnFBKeyboardShortcuts())
    End Function

    Private Async Function TurnOnFBKeyboardShortcuts() As Task(Of Boolean)
        Try
            ClickByCssSelector("div.x1i10hfl.x1qjc9v5.xjbqb8w.xjqpnuy.xa49m3k.xqeqjp1.x2hbi6w.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x972fbf.xcfux6l.x1qhh985.xm0m39n.x9f619.x1ypdohk.xdl72j9.x2lah0s.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x2lwn1j.xeuugli.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1n2onr6.x16tdsg8.x1hl2dhg.xggy1nq.x1ja2u2z.x1t137rt.x1o1ewxj.x3x9cwd.x1e5q0jg.x13rtm0m.x1q0g3np.x87ps6o.x1lku1pv.x1a2a7pz.xzsf02u.x1rg5ohu")
            Await Delay_msec(500)
            ClickByCssSelector("div.x1iorvi4.x4uap5.xwib8y2.xkhd6sd > div > div:nth-child(3) > div")
            Await Delay_msec(500)
            ClickByCssSelector("div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div > div > div.x9f619.x1ja2u2z.x1k90msu.x6o7n8i.x1qfuztq.x10l6tqk.x17qophe.x13vifvy.x1hc1fzr.x71s49j.xh8yej3 > div > div.x1e56ztr.x1i64zmx.x1emribx.x1gslohp > div.x1n2onr6.x1ja2u2z.x9f619.x78zum5.xdt5ytf.x2lah0s.x193iq5w > div > div > div")
            Await Delay_msec(500)
            ClickByCssSelector("div.x1e56ztr.x1i64zmx.x1emribx.x1gslohp > div:nth-child(3) > div > div:nth-child(2) > label > div > div > div > div")
            Await Delay_msec(500)


            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
    End Function


    Public Function SetFBLanguageTo_zhTW_Task() As Task(Of Boolean)
        Return Task.Run(Function() SetFBLanguageTo_zhTW())
    End Function


    Private Async Function SetFBLanguageTo_zhTW() As Task(Of Boolean)
        Try
            ClickByCssSelector("div.x1i10hfl.x1qjc9v5.xjbqb8w.xjqpnuy.xa49m3k.xqeqjp1.x2hbi6w.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x972fbf.xcfux6l.x1qhh985.xm0m39n.x9f619.x1ypdohk.xdl72j9.x2lah0s.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x2lwn1j.xeuugli.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1n2onr6.x16tdsg8.x1hl2dhg.xggy1nq.x1ja2u2z.x1t137rt.x1o1ewxj.x3x9cwd.x1e5q0jg.x13rtm0m.x1q0g3np.x87ps6o.x1lku1pv.x1a2a7pz.xzsf02u.x1rg5ohu")
            Await Delay_msec(500)
            ClickByCssSelector("div.x1iorvi4.x4uap5.xwib8y2.xkhd6sd > div > div:nth-child(1) > div")
            Await Delay_msec(500)
            ClickByCssSelector("div.x1y1aw1k.x4uap5.xwxc41k.xkhd6sd > div > div:nth-child(2) > div")
            Await Delay_msec(500)
            'Dim Lang_span = edgeDriver.FindElement(By.CssSelector("div.x1y1aw1k.x4uap5.xwxc41k.xkhd6sd > div > div:nth-child(2) > div > div.x6s0dn4.x1q0q8m5.x1qhh985.xu3j5b3.xcfux6l.x26u7qi.xm0m39n.x13fuv20.x972fbf.x9f619.x78zum5.x1q0g3np.x1iyjqo2.xs83m0k.x1qughib.xat24cr.x11i5rnm.x1mh8g0r.xdj266r.xeuugli.x18d9i69.x1sxyh0.xurb0ha.xexx8yu.x1n2onr6.x1ja2u2z.x1gg8mnh > div.x6s0dn4.xkh2ocl.x1q0q8m5.x1qhh985.xu3j5b3.xcfux6l.x26u7qi.xm0m39n.x13fuv20.x972fbf.x9f619.x78zum5.x1q0g3np.x1iyjqo2.xs83m0k.x1qughib.xat24cr.x11i5rnm.x1mh8g0r.xdj266r.x2lwn1j.xeuugli.x18d9i69.x4uap5.xkhd6sd.xexx8yu.x1n2onr6.x1ja2u2z > div.x1qjc9v5.x1q0q8m5.x1qhh985.xu3j5b3.xcfux6l.x26u7qi.xm0m39n.x13fuv20.x972fbf.x9f619.x78zum5.x1r8uery.xdt5ytf.x1iyjqo2.xs83m0k.x1qughib.xat24cr.x11i5rnm.x1mh8g0r.xdj266r.x2lwn1j.xeuugli.x4uap5.xkhd6sd.x1n2onr6.x1ja2u2z.x1y1aw1k.xwib8y2 > div > div > div:nth-child(2) > span")).GetAttribute("innerHTML")
            'Debug.WriteLine("lang:" & Lang_span)
            'If Lang_span.Trim <> "繁體中文（台灣）" Then
            ClickByCssSelector("div.x9f619.x1ja2u2z.x1k90msu.x6o7n8i.x1qfuztq.x10l6tqk.x17qophe.x13vifvy.x1hc1fzr.x71s49j.xh8yej3 > div > div.x1y1aw1k.x4uap5.xwxc41k.xkhd6sd > div > div:nth-child(2) > div")
            Await Delay_msec(500)
            Dim LanguageSearch_Input = edgeDriver.FindElement(By.CssSelector("div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.x2lah0s.x1qughib.x1qjc9v5.xozqiw3.x1q0g3np.x1sxyh0.xurb0ha.x1l90r2v.xexx8yu.xykv574.xbmpl8g.x4cne27.xifccgj > div > div > div:nth-child(1) > div > div > label > input"))
            LanguageSearch_Input.SendKeys("Taiwan")
            Await Delay_msec(1000)
            ClickByCssSelectorWaitUntil("#zh_TWRECENT > div > div", 5)
            'End If
            Await Delay_msec(500)
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
    End Function

    Private Async Function SetFBLanguageTo_zhTW_Back() As Task(Of Boolean)
        Try
            Await Navigate_GoToUrl_Task("https://www.facebook.com/settings?tab=language")
            Await Delay_msec(500)
            Dim lang_span = edgeDriver.FindElement(By.CssSelector("div:nth-child(2) > div > div > div:nth-child(2) > div > div > div > div > div > div > div > div > div.x9f619.x1n2onr6.x1ja2u2z.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x78zum5 > div > div > div > div.x6s0dn4.x78zum5.xl56j7k.x1608yet.xljgi0e.x1e0frkt > div > span > span")).GetAttribute("innerHTML")

            If lang_span <> "中文(台灣)" Then ' if language is not zh-TW
                Debug.WriteLine("set lang")
                ClickByCssSelector("div:nth-child(2) > div > div > div:nth-child(2) > div > div > div > div > div > div > div > div > div.x9f619.x1n2onr6.x1ja2u2z.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x78zum5 > div > div")
                Await Delay_msec(1000)
                Dim LanguageSearch_Input = edgeDriver.FindElement(By.CssSelector("div.x78zum5.xdt5ytf.x1t2pt76 > div > label > input"))
                LanguageSearch_Input.SendKeys("Taiwan")
                Await Delay_msec(1000)
                ClickByCssSelectorWaitUntil("div.x78zum5.xdt5ytf.x1iyjqo2.x1n2onr6.xaci4zi.x129vozr > div > div > div:nth-child(2) > div", 5)
                Await Delay_msec(1000)
                ClickByCssSelector("div.html-div.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1ey2m1c.x1jx94hy.x190bdop.xp3hrpj.x13xjmei.xv7j57z.xh8yej3 > div > div > div > div > div:nth-child(1) > div")
                Await Delay_msec(1000)
            End If



            'LanguageSearch_Input.SendKeys("Taiwan")
            'Await Delay_msec(1000)
            'ClickByCssSelectorWaitUntil("#zh_TWRECENT > div > div", 5)
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
    End Function

    Public Class myCookie
        Public Property Domain As String
        Public Property Name As String
        Public Property Value As String
        Public Property Path As String

    End Class

End Module
