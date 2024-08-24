Imports System.Collections.ObjectModel
Imports Microsoft.Web.WebView2.Core
Imports Newtonsoft.Json
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Edge
Imports OpenQA.Selenium.Support.UI
Imports System.Net
Imports System.Net.NetworkInformation
Imports WebDriverManager.Helpers
Imports WebDriverManager
Imports WebDriverManager.DriverConfigs.Impl
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports OpenQA.Selenium.Support.Extensions
Imports AngleSharp.Dom
Imports System.IO

Module Webview2Controller
    Public edgeDriver As EdgeDriver
    Private driverManager = New DriverManager()
    Private webview2_environment As CoreWebView2Environment

    Public ActivedWebview2UserData = "N/A"
    Public ActivedUserDataFolderPath As String

    Public DebugPortInUse As Integer = 0

    Public IsWebview2Lock As Boolean = False

    Public Webview2EdgeVersion As String

    Public Async Function InitializeWebView2(userDataFolder As String, debugPort As Integer) As Task
        webview2_environment = Await CoreWebView2Environment.CreateAsync(Nothing, userDataFolder, New CoreWebView2EnvironmentOptions("--remote-debugging-port=" & debugPort))
        Await Form1.Main_WebView2.EnsureCoreWebView2Async(webview2_environment)
        Form1.Main_WebView2.ZoomFactor = 0.75
    End Function

    Public Function InitializeEdgeDriver_Task(debugPort As Integer) As Task(Of Boolean)
        Return Task.Run(Function() InitializeEdgeDriver(debugPort))
    End Function

    Public Function InitializeEdgeDriver(debugPort As Integer) As Boolean
        Try
            'Dim driverManager = New DriverManager()
            'driverManager.SetUpDriver(New EdgeConfig(), VersionResolveStrategy.MatchingBrowser) 'automatically download a chromedriver.exe matching the version of the browser
            driverManager.SetUpDriver(New EdgeConfig(), Webview2EdgeVersion) 'Use specify version.

            Dim options As EdgeOptions = New EdgeOptions()
            options.AddArguments("--disable-dev-shm-usage", "--no-sandbox")
            options.DebuggerAddress = "localhost:" & debugPort

            Dim serv As EdgeDriverService = EdgeDriverService.CreateDefaultService
            serv.HideCommandPromptWindow = True

            'Threading.Thread.Sleep(500)
            edgeDriver = New EdgeDriver(serv, options)
            'Debug.WriteLine("init port " & debugPort)
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try

    End Function

    Public Async Function RestartMainWebView2(userDataFolder As String, Optional debugPort As String = Nothing) As Task(Of Boolean)

        Try
            IsWebview2Lock = True
            'Debug.WriteLine("IsWebview2Lock" & IsWebview2Lock)
            SetForm1TitleStatus("載入中...")

            Dim RandomDebugPort = UtilsModule.GetAvailablePort(50000, 65000)
            'Debug.WriteLine("Use Port : " & RandomDebugPort)
            Await ResetWebview2()
            Await Webview2Controller.InitializeWebView2(userDataFolder, RandomDebugPort)
            Await Webview2Controller.InitializeEdgeDriver_Task(RandomDebugPort)
            ActivedUserDataFolderPath = userDataFolder
            DebugPortInUse = RandomDebugPort
            'Await Navigate_GoToUrl_Task("https://www.facebook.com/")
            Dim folderName = Split(userDataFolder, "\")
            ActivedWebview2UserData = folderName(UBound(folderName))
            SetForm1TitleStatus("完成")
            IsWebview2Lock = False
            'Debug.WriteLine("EOF")
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            IsWebview2Lock = False
            'MsgBox("重啟失敗")
            Return False
        End Try

    End Function


    Public Async Function GetWebview2EdgeVersion() As Task
        Await Form1.Main_WebView2.EnsureCoreWebView2Async(Nothing)
        If Form1.Main_WebView2.CoreWebView2 IsNot Nothing Then
            Webview2EdgeVersion = Form1.Main_WebView2.CoreWebView2.Environment.BrowserVersionString
        End If
    End Function


    Public Sub SyncWebdriverVersion()
        Try
            driverManager.SetUpDriver(New EdgeConfig(), Webview2EdgeVersion)
            MsgBox("同步成功")
        Catch ex As Exception
            Debug.WriteLine(ex)
            MsgBox("同步失敗")
        End Try
    End Sub

    Public Async Function ResetWebview2() As Task
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
            ActivedWebview2UserData = "N/A"
            ActivedUserDataFolderPath = Nothing
            DebugPortInUse = 0
            Await Delay_msec(500)
            'Debug.WriteLine("reset webview2 EOF")
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Function




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


    Private Async Sub ClickByAriaLable(text As String)
        Try
            edgeDriver.FindElement(By.CssSelector("div[aria-label$='" + text + "']")).Click()
            Await Delay_msec(500)

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Async Function ClickByCssSelector_Task(cssSelector) As Task(Of Boolean)
        Try
            Return Await Task.Run(Function()
                                      Try
                                          edgeDriver.FindElement(By.CssSelector(cssSelector)).Click()
                                          Return True
                                      Catch ex As Exception
                                          Debug.WriteLine(ex)
                                          Return False
                                      End Try
                                  End Function)
        Catch ex As Exception
            Return False
        End Try

    End Function




    Private Function IsElementPresentByCssSelector(cssSelector) As Boolean
        Try
            If edgeDriver.FindElements(By.CssSelector(cssSelector)).Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub ReadCookie()
        Try
            'Debug.WriteLine("Read Cookie")
            If ActivedWebview2UserData = "N/A" Then
                MsgBox("未偵測到啟用的Webview2")
                Exit Sub
            End If

            Dim cookies As ReadOnlyCollection(Of OpenQA.Selenium.Cookie) = edgeDriver.Manage().Cookies.AllCookies
            Dim cookieList As New List(Of MyCookie)

            For Each cookie As OpenQA.Selenium.Cookie In cookies
                Debug.WriteLine($"Cookie Name: {cookie.Name}, Value: {cookie.Value}")
                Dim myCookieObj As New MyCookie With {
                    .Name = cookie.Name,
                    .Value = cookie.Value,
                    .Domain = cookie.Domain,
                    .Path = cookie.Path
                }
                cookieList.Add(myCookieObj)
            Next

            Dim jsonStr As String = JsonConvert.SerializeObject(cookieList, Formatting.Indented)

            Form1.FBCookie_RichTextBox.Text = jsonStr

            ' to be edit
            'MainFormController.SaveUserData(Form1.WebviewUserDataFolder_CheckedListBox.SelectedItem)

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
    End Sub

    Public Async Sub SetCookie()
        Try
            If ActivedWebview2UserData = "N/A" Then
                MsgBox("未偵測到啟用的Webview2")
                Exit Sub
            End If

            Dim JsonText = Form1.FBCookie_RichTextBox.Text
            Dim CookieList As List(Of MyCookie) = JsonConvert.DeserializeObject(Of List(Of MyCookie))(JsonText)

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
            ClickByCssSelector("div.x9f619.x1ja2u2z.x1k90msu.x6o7n8i.x1qfuztq.x17qophe.x10l6tqk.x13vifvy.x1hc1fzr.x71s49j.xh8yej3 > div > div.x1e56ztr.x1i64zmx.x1emribx.x1gslohp > div.x1n2onr6.x1ja2u2z.x9f619.x78zum5.xdt5ytf.x2lah0s.x193iq5w > div > div > div")
            Await Delay_msec(500)
            ClickByCssSelector("div.x9f619.x1ja2u2z.x1k90msu.x6o7n8i.x1qfuztq.x17qophe.x10l6tqk.x13vifvy.x1hc1fzr.x71s49j.xh8yej3 > div > div.x1e56ztr.x1i64zmx.x1emribx.x1gslohp > div:nth-child(3) > div > div:nth-child(2) > label > div > div > div > div")
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

    Public Async Function FBRquestFrient() As Task

        Await Task.Run(Function()
                           Try
                               Dim div_eles = edgeDriver.FindElements(By.CssSelector("div.x1ifrov1.x1i1uccp.x1stjdt1.x1yaem6q.x4ckvhe.x2k3zez.xjbssrd.x1ltux0g.xit7rg8.xc9uqle.x17quhge > div > div > div"))

                               For Each ele In div_eles
                                   Try
                                       Dim target_ele = ele.FindElement(By.CssSelector("[aria-label='加朋友']"))
                                       target_ele.Click()
                                       Exit For
                                       'Debug.WriteLine("aria-lbl: " & target_ele.GetAttribute("aria-label"))
                                   Catch ex As Exception
                                       'Debug.WriteLine(ex)
                                   End Try

                               Next

                               Return True

                           Catch ex As Exception
                               Debug.WriteLine(ex)
                               Return False
                           End Try
                       End Function)
        Await Delay_msec(500)

    End Function


    Public Async Sub GetFBGroupList()
        If ActivedUserDataFolderPath Is Nothing Then
            MsgBox("未偵測到啟用的edgedriver")
            Exit Sub
        End If
        'Await Navigate_GoToUrl_Task("https://www.facebook.com/groups/joins/?nav_source=tab&ordering=viewer_added")
        Debug.WriteLine("GetFBGroupList")
        Dim items = Await Task.Run(Async Function()
                                       Dim itemList As New List(Of ListViewItem)()
                                       Try

                                           edgeDriver.Navigate.GoToUrl("https://www.facebook.com/groups/joins/?nav_source=tab&ordering=viewer_added")
                                           Dim lastHeight As Long = 0
                                           Dim newHeight As Long = 0

                                           Dim default_wait_msec = 2000

                                           Do
                                               Await Delay_msec(default_wait_msec)
                                               edgeDriver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);")

                                               Await Delay_msec(default_wait_msec)

                                               newHeight = Convert.ToInt64(edgeDriver.ExecuteScript("return document.body.scrollHeight"))

                                               If newHeight = lastHeight Then
                                                   Exit Do
                                               End If

                                               lastHeight = newHeight
                                           Loop

                                           Await Delay_msec(default_wait_msec)

                                           Dim elements = edgeDriver.FindElements(By.CssSelector("div.x1cy8zhl.x78zum5.xdt5ytf.x1iyjqo2.x1a02dak.x1sy10c2.x1pi30zi > div > div:nth-child(1) > span > span > div > a"))
                                           For Each elm In elements
                                               Dim name = elm.GetAttribute("innerHTML")
                                               Dim url = elm.GetAttribute("href")

                                               Dim item As New ListViewItem(name)
                                               item.SubItems.Add(url)
                                               itemList.Add(item)
                                           Next

                                           Return itemList
                                       Catch ex As Exception
                                           Debug.WriteLine(ex)
                                           Return itemList
                                       End Try
                                   End Function)

        Form1.FBGroups_ListView.Items.Clear()
        For Each item In items
            Form1.FBGroups_ListView.Items.Add(item)
        Next

    End Sub


    Public Async Sub GetJoinedGroupList()
        If ActivedUserDataFolderPath Is Nothing Then
            MsgBox("未偵測到啟用的edgedriver")
            Exit Sub
        End If

        Debug.WriteLine("GetFBGroupList")
        Dim items = Await Task.Run(Async Function()
                                       Dim itemList As New List(Of ListViewItem)()
                                       Try
                                           Dim default_wait_msec = 2000
                                           edgeDriver.Navigate.GoToUrl("https://www.facebook.com/groups/joins/?nav_source=tab&ordering=viewer_added")
                                           Dim divElement As IWebElement = edgeDriver.FindElement(By.CssSelector("div.xb57i2i.x1q594ok.x5lxg6s.x78zum5.xdt5ytf.x6ikm8r.x1ja2u2z.x1pq812k.x1rohswg.xfk6m8.x1yqm8si.xjx87ck.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.xx8ngbg.xwo3gff.x1oyok0e.x1odjw0f.x1e4zzel.x1n2onr6.xq1qtft"))


                                           Dim jsExecutor As IJavaScriptExecutor = CType(edgeDriver, IJavaScriptExecutor)

                                           Dim lastHeight As Long = CLng(jsExecutor.ExecuteScript("return arguments[0].scrollHeight;", divElement))

                                           While True

                                               jsExecutor.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight;", divElement)

                                               Await Delay_msec(default_wait_msec)
                                               Dim newHeight As Long = CLng(jsExecutor.ExecuteScript("return arguments[0].scrollHeight;", divElement))
                                               If newHeight = lastHeight Then
                                                   Exit While
                                               End If

                                               lastHeight = newHeight
                                           End While

                                           Await Delay_msec(default_wait_msec)

                                           Dim i = 0
                                           Dim elements = edgeDriver.FindElements(By.CssSelector("div.xb57i2i.x1q594ok.x5lxg6s.x78zum5.xdt5ytf.x6ikm8r.x1ja2u2z.x1pq812k.x1rohswg.xfk6m8.x1yqm8si.xjx87ck.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.xx8ngbg.xwo3gff.x1oyok0e.x1odjw0f.x1e4zzel.x1n2onr6.xq1qtft > div.x78zum5.xdt5ytf.x1iyjqo2.x1n2onr6 > div > div > div > div > a"))
                                           '"div.xb57i2i.x1q594ok.x5lxg6s.x78zum5.xdt5ytf.x6ikm8r.x1ja2u2z.x1pq812k.x1rohswg.xfk6m8.x1yqm8si.xjx87ck.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.xx8ngbg.xwo3gff.x1oyok0e.x1odjw0f.x1e4zzel.x1n2onr6.xq1qtft > div.x78zum5.xdt5ytf.x1iyjqo2.x1n2onr6 > div:nth-child(11) > div > div > div > a > div.x9f619.x1n2onr6.x1ja2u2z.x1qjc9v5.x78zum5.xdt5ytf.x1iyjqo2.xl56j7k.xeuugli.x1sxyh0.xurb0ha.xwib8y2.x1y1aw1k.xykv574.xbmpl8g.x4vbgl9.x1rdy4ex.x1wiwyrm > div > div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.x1iyjqo2.xs83m0k.xeuugli.x1qughib.x6s0dn4.x1a02dak.x1q0g3np.xdl72j9 > div > div > div > div:nth-child(1) > span > span > span"
                                           For Each elm In elements
                                               Debug.WriteLine("ele")
                                               If i < 3 Then
                                                   i += 1
                                                   Continue For
                                               Else
                                                   i += 1
                                               End If


                                               Dim name = elm.FindElement(By.CssSelector("div.x9f619.x1n2onr6.x1ja2u2z.x1qjc9v5.x78zum5.xdt5ytf.x1iyjqo2.xl56j7k.xeuugli.x1sxyh0.xurb0ha.xwib8y2.x1y1aw1k.xykv574.xbmpl8g.x4vbgl9.x1rdy4ex.x1wiwyrm > div > div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.x1iyjqo2.xs83m0k.xeuugli.x1qughib.x6s0dn4.x1a02dak.x1q0g3np.xdl72j9 > div > div > div > div:nth-child(1) > span > span > span")).GetAttribute("innerHTML")
                                               Dim url = elm.GetAttribute("href")

                                               Dim item As New ListViewItem(name)
                                               item.SubItems.Add(url)
                                               itemList.Add(item)

                                           Next

                                           Return itemList
                                       Catch ex As Exception
                                           Debug.WriteLine(ex)
                                           Return itemList
                                       End Try
                                   End Function)

        Form1.FBGroups_ListView.Items.Clear()
        For Each item In items
            Form1.FBGroups_ListView.Items.Add(item)
        Next
    End Sub

    '1. 關閉瀏覽器
    '2. 開啟瀏覽器,直接到群組畫面
    '3. 送出1個ESC鍵 (必需要,很多時會彈出一個窗口,被人舉報說什麼什麼違規)
    '4. 按下討論區 (討論區的位置不固定的, 要跟加好友的寫法一樣) 如果按不列討論區直接顯示失敗
    '5. 按下"留個言吧..."，如果按不到直接顯示失敗
    '6. 抽出資料夾,抽出txt檔,送出txt檔內容
    '7. 送出全部圖片影片
    '8. 送出帖文(如果有影片，網頁一直會處於送出狀態(上載中)，所以我把關閉瀏覽器放在第1. ，我自己增加等待時間就可以，無需判斷是否送出，因為影片可以卡很久的。
    Private Async Function EnsureControlHandleCreated(ctrl As Control) As Task
        If ctrl.IsHandleCreated Then
            Return
        End If

        ' 主動創建控制代碼
        Dim handle = ctrl.Handle

        ' 等待控制代碼創建
        Await Task.Run(Sub()
                           While Not ctrl.IsHandleCreated
                               Threading.Thread.Sleep(50) ' 等待 50 毫秒
                           End While
                       End Sub)
    End Function


    Public Async Function WritePostOnFacebook(myUrl As String, myAssetFolderPath As String, item As ListViewItem) As Task(Of Boolean)
        Try
            'Debug.WriteLine("WritePostOnFacebook")

            Return Await Task.Run(Async Function() As Task(Of Boolean)
                                      Try


                                          Await Navigate_GoToUrl(myUrl)

                                          Await Delay_msec(300)
                                          '送出1個ESC鍵
                                          Dim bodyElement As IWebElement = edgeDriver.FindElement(By.TagName("body"))
                                          bodyElement.SendKeys(Keys.Escape)

                                          Await Delay_msec(1000)
                                          '按下"留個言吧..."，如果按不到直接顯示失敗
                                          edgeDriver.ExecuteScript("window.scrollTo(0, 250);")

                                          Await Delay_msec(1000)

                                          Dim discussion_spanElements = edgeDriver.FindElements(By.CssSelector("div.x1ey2m1c.x9f619.xds687c.x10l6tqk.x17qophe.x13vifvy > a"))
                                          For Each elm In discussion_spanElements
                                              'Debug.WriteLine("#################")
                                              Dim span_innerHTML = elm.FindElement(By.CssSelector("span")).GetAttribute("innerHTML")

                                              If span_innerHTML.Trim() = "討論區" Or span_innerHTML.Trim() = "討論" Then
                                                  elm.Click()
                                                  Exit For
                                              End If

                                          Next

                                          Await Delay_msec(1000)



                                          Dim myText As String = ""
                                          Dim media_input As IWebElement
                                          Dim text_input As IWebElement

                                          'div.x9f619.x1iyjqo2.xg7h5cd.x1pi30zi.x1swvt13.x1n2onr6.xh8yej3.x1ja2u2z.x1t1ogtf > div > div > div > div > div._5rpb > div


                                          ClickByCssSelectorWaitUntil("div.x6s0dn4.x78zum5.x1l90r2v.x1pi30zi.x1swvt13.xz9dl7a > div", 5)
                                          Await Delay_msec(1000)


                                          If IsElementPresentByCssSelector("div.x6s0dn4.x1jx94hy.x8cjs6t.x1ch86jh.x80vd3b.xckqwgs.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x178xt8z.xm81vs4.xso031l.xy80clv.xev17xk.x9f619.x78zum5.x1qughib.xktsk01.x1d52u69.x1y1aw1k.x1sxyh0.xwib8y2.xurb0ha > div.x78zum5 > div:nth-child(1) > input") Then

                                              media_input = edgeDriver.FindElement(By.CssSelector("div.x6s0dn4.x1jx94hy.x8cjs6t.x1ch86jh.x80vd3b.xckqwgs.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x178xt8z.xm81vs4.xso031l.xy80clv.xev17xk.x9f619.x78zum5.x1qughib.xktsk01.x1d52u69.x1y1aw1k.x1sxyh0.xwib8y2.xurb0ha > div.x78zum5 > div:nth-child(1) > input"))
                                              text_input = edgeDriver.FindElement(By.CssSelector("div.x9f619.x1iyjqo2.xg7h5cd.x1pi30zi.x1swvt13.x1n2onr6.xh8yej3.x1ja2u2z.x1t1ogtf > div > div > div > div > div._5rpb > div"))
                                          Else
                                              ClickByAriaLable("相片／影片")
                                              Await Delay_msec(1000)
                                              media_input = edgeDriver.FindElement(By.CssSelector("div.x1n2onr6.x1ja2u2z.x9f619.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.x1y1aw1k.xwib8y2 > div > div:nth-child(1) > input"))
                                              text_input = edgeDriver.FindElement(By.CssSelector("div.x9f619.x1iyjqo2.xg7h5cd.x1swvt13.x1n2onr6.xh8yej3.x1ja2u2z.x11eofan > div > div > div > div > div._5rpb > div"))
                                          End If


                                          ' upload media files
                                          Dim mediaFileList As New List(Of String)
                                          Dim mediaFileFolderPath = Path.Combine(myAssetFolderPath, "media")

                                          Debug.WriteLine("FFFFF : " & mediaFileFolderPath)

                                          Dim allowedExtension As String() = {".bmp", ".BMP", ".jpe", ".JPE", ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG", ".mp4", ".MP4"}
                                          Dim myFiles As String() = Directory.GetFiles(mediaFileFolderPath)
                                          For Each file As String In myFiles
                                              If allowedExtension.Contains(Path.GetExtension(file)) Then
                                                  'Debug.WriteLine("file" & Path.GetFileName(file))
                                                  mediaFileList.Add(file)
                                              End If
                                          Next


                                          ' 上傳文字
                                          Await Delay_msec(1000)


                                          'Debug.WriteLine("Content : " & content)


                                          Dim textFileFolderPath = Path.Combine(myAssetFolderPath, "TextFiles")
                                          Dim textFiles As String() = Directory.GetFiles(textFileFolderPath, "*.txt")

                                          If textFiles.Length > 0 Then

                                              If Directory.Exists(textFileFolderPath) Then

                                                  Dim rand As New Random()
                                                  Dim randomIndex As Integer = rand.Next(0, textFiles.Length)
                                                  Dim randomTextFile As String = textFiles(randomIndex)
                                                  myText = File.ReadAllText(randomTextFile)
                                                  'Debug.WriteLine("Textfile : " & randomTextFile)
                                                  text_input.SendKeys(myText)
                                              End If
                                          Else
                                              Debug.WriteLine("資料夾內無文字檔")
                                          End If

                                          Await Delay_msec(1000)


                                          If mediaFileList.Count > 0 Then
                                              media_input.SendKeys(String.Join(vbLf, mediaFileList))
                                          End If

                                          Debug.WriteLine("EOF")
                                          Return True
                                      Catch ex As Exception
                                          Debug.WriteLine(ex)
                                          Return False
                                      End Try
                                  End Function)
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
    End Function




    Public Class MyCookie
        Public Property Domain As String
        Public Property Name As String
        Public Property Value As String
        Public Property Path As String

    End Class

End Module
