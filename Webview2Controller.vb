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
Imports OpenQA.Selenium.Interactions
Imports System.CodeDom.Compiler

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


    Public Async Function Navigate_GoToUrl(url As String) As Task(Of Boolean)
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


    Public Function ClickByCssSelector(CssSelector)
        Try
            edgeDriver.FindElement(By.CssSelector(CssSelector)).Click()
            Return True
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return False
        End Try
    End Function

    Public Sub ClickByCssSelectorWaitUntil(cssSelector As String, TimeSpanSec As Integer)
        Try
            Dim wait As WebDriverWait = New WebDriverWait(edgeDriver, TimeSpan.FromSeconds(TimeSpanSec))
            Dim element As IWebElement = wait.Until(Function(d) d.FindElement(By.CssSelector(cssSelector)))
            element.Click()
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub


    Public Async Sub ClickByAriaLable(text As String)
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




    Public Function IsElementPresentByCssSelector(cssSelector) As Boolean
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

    Public Async Function ScrollToBottom() As Task
        Dim js As IJavaScriptExecutor = DirectCast(edgeDriver, IJavaScriptExecutor)
        Dim lastHeight As Long = CLng(js.ExecuteScript("return document.body.scrollHeight;"))

        Do
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);")
            Await Delay_msec(3000)
            Dim newHeight As Long = CLng(js.ExecuteScript("return document.body.scrollHeight;"))
            If newHeight = lastHeight Then
                Exit Do
            End If

            lastHeight = newHeight
        Loop
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

        'Debug.WriteLine("GetFBGroupList")
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



    Public Async Sub ReadActivityLogs(NumberOfActivityLogs As Integer)
        If ActivedUserDataFolderPath Is Nothing Then
            MsgBox("未偵測到啟用的edgedriver")
            Exit Sub
        End If

        Dim items = Await Task.Run(Async Function()
                                       Dim itemList As New List(Of ListViewItem)()
                                       Try
                                           Dim default_wait_msec = 3000
                                           Await Delay_msec(default_wait_msec)

                                           If NumberOfActivityLogs > 0 Then
                                               Dim js As IJavaScriptExecutor = CType(edgeDriver, IJavaScriptExecutor)
                                               Dim lastHeight As Long = CLng(js.ExecuteScript("return document.body.scrollHeight"))
                                               For i = 0 To NumberOfActivityLogs - 1
                                                   js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);")
                                                   Await Delay_msec(default_wait_msec)
                                                   Dim newHeight As Long = CLng(js.ExecuteScript("return document.body.scrollHeight"))
                                                   If newHeight = lastHeight Then
                                                       Exit For
                                                   End If
                                                   lastHeight = newHeight
                                               Next
                                           End If

                                           Dim pageItemElements = edgeDriver.FindElements(By.CssSelector("div.xgqk73l > div > a"))

                                           For Each elm In pageItemElements

                                               Dim elmSpan As IWebElement = elm.FindElement(By.CssSelector("div.x6s0dn4.x1q0q8m5.x1qhh985.xu3j5b3.xcfux6l.x26u7qi.xm0m39n.x13fuv20.x972fbf.x9f619.x78zum5.x1q0g3np.x1iyjqo2.xs83m0k.x1qughib.xat24cr.x11i5rnm.x1mh8g0r.xdj266r.xeuugli.x18d9i69.x1sxyh0.xurb0ha.xexx8yu.x1n2onr6.x1ja2u2z.x1gg8mnh > div.x6s0dn4.xkh2ocl.x1q0q8m5.x1qhh985.xu3j5b3.xcfux6l.x26u7qi.xm0m39n.x13fuv20.x972fbf.x9f619.x78zum5.x1q0g3np.x1iyjqo2.xs83m0k.x1qughib.xat24cr.x11i5rnm.x1mh8g0r.xdj266r.x2lwn1j.xeuugli.x18d9i69.x4uap5.xkhd6sd.xexx8yu.x1n2onr6.x1ja2u2z > div > div > div > div:nth-child(1) > span  > span > span"))
                                               Dim elmSpanInnerHTML = elmSpan.GetAttribute("innerHTML")

                                               If elmSpanInnerHTML.Contains("社團發佈了貼文") Then
                                                   Debug.WriteLine(elmSpanInnerHTML)
                                                   Dim url = elm.GetAttribute("href")
                                                   Dim groupName As String = elm.FindElement(By.CssSelector("div > strong:nth-child(2) > object > a")).GetAttribute("innerHTML")
                                                   Dim item As New ListViewItem(groupName)
                                                   item.SubItems.Add(url)
                                                   itemList.Add(item)

                                                   'Exit For
                                               End If

                                           Next


                                           Return itemList
                                       Catch ex As Exception
                                           Debug.WriteLine(ex)
                                           Return itemList
                                       End Try
                                   End Function)

        Form1.FBActivityLogs_ListView.Items.Clear()
        For Each item In items
            Form1.FBActivityLogs_ListView.Items.Add(item)
        Next
    End Sub

    Public Async Function ReadFBNotifications(read As Boolean, unread As Boolean) As Task(Of Boolean)
        Try
            Form1.FBUrlData_TabControl.SelectedTab = Form1.FBNotificationsUrlData_TabPage
            Dim items = Await Task.Run(Async Function()
                                           Dim itemList As New List(Of ListViewItem)()
                                           Try
                                               Dim default_wait_msec = 3000

                                               Await Navigate_GoToUrl_Task("https://www.facebook.com/notifications")
                                               Await Delay_msec(default_wait_msec)

                                               ClickByAriaLable("查看先前的通知")

                                               Await ScrollToBottom()

                                               Dim elms = edgeDriver.FindElements(By.CssSelector(".x1i10hfl.x1qjc9v5.xjbqb8w.xjqpnuy.xa49m3k.xqeqjp1.x2hbi6w.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x972fbf.xcfux6l.x1qhh985.xm0m39n.x9f619.x1ypdohk.xdl72j9.x2lah0s.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x2lwn1j.xeuugli.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1n2onr6.x16tdsg8.x1hl2dhg.xggy1nq.x1ja2u2z.x1t137rt.x1q0g3np.x87ps6o.x1lku1pv.x1a2a7pz.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.x1lliihq"))

                                               For Each elm In elms

                                                   ' 檢查是否為未讀通知
                                                   Dim isUnread As Boolean = False
                                                   Try
                                                       Dim unread_elm = elm.FindElement(By.CssSelector("div > span > .x9f619.x1ja2u2z.xzpqnlu.x1hyvwdk.x14bfe9o.xjm9jq1.x6ikm8r.x10wlt62.x10l6tqk.x1i1rx1s"))
                                                       isUnread = True
                                                   Catch ex As NoSuchElementException
                                                   End Try


                                                   If (unread And isUnread) Or (read And Not isUnread) Then
                                                       Try
                                                           Dim innerHtml As String = elm.GetAttribute("innerHTML")
                                                           'If innerHtml.Contains("回應了你") And innerHtml.Contains("的貼文") Then
                                                           Dim href = elm.GetAttribute("href")
                                                           Dim strong_elm = elm.FindElement(By.CssSelector("div > div:nth-child(1) > div > div:nth-child(1) > span > span > strong:nth-of-type(1)")).GetAttribute("innerHTML")
                                                           ' add to listview
                                                           Dim item As New ListViewItem(strong_elm)
                                                           item.SubItems.Add(href)
                                                           itemList.Add(item)
                                                           'End If

                                                       Catch ex As Exception

                                                       End Try
                                                   End If

                                               Next

                                               Return itemList
                                           Catch ex As Exception
                                               Debug.WriteLine(ex)
                                               Return itemList
                                           End Try
                                       End Function)

            Form1.FBNotificationsData_Listview.Items.Clear()
            For Each item In items
                Form1.FBNotificationsData_Listview.Items.Add(item)
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Async Function MarkAllFBNotificationsAsRead() As Task(Of Boolean)
        Try
            Return Await Task.Run(Async Function() As Task(Of Boolean)
                                      Try

                                          Await Navigate_GoToUrl("https://www.facebook.com/notifications")
                                          Await Delay_msec(3000)
                                          ClickByAriaLable("通知動作")
                                          Await Delay_msec(3000)
                                          ClickByCssSelectorWaitUntil("div.x1uvtmcs.x4k7w5x.x1h91t0o.x1beo9mf.xaigb6o.x12ejxvf.x3igimt.xarpa2k.xedcshv.x1lytzrv.x1t2pt76.x7ja8zs.x1n2onr6.x1qrby5j.x1jfb8zj > div > div > div > div > div > div > div.x78zum5.xdt5ytf.x1iyjqo2.x1n2onr6 > div > div", 5)
                                          Await Delay_msec(2000)
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

    Public Async Function ReadFBMessenger(messageSource As String, read As Boolean, unread As Boolean) As Task(Of List(Of ListViewItem))
        'messageSource : 聊天室 | Marketplace | 陌生訊息
        'FBMessenger_TabPage
        Form1.FBUrlData_TabControl.SelectedTab = Form1.FBMessengerUrlData_TabPage
        Dim items As New List(Of ListViewItem)
        Try
            items = Await Task.Run(Async Function()
                                       Dim itemList As New List(Of ListViewItem)()
                                       Try


                                           Dim msgsrcCss As String = Nothing
                                           Dim messengerCssSelector = ".x1i10hfl.x1qjc9v5.xjbqb8w.xjqpnuy.xa49m3k.xqeqjp1.x2hbi6w.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x972fbf.xcfux6l.x1qhh985.xm0m39n.x9f619.x1ypdohk.xdl72j9.x2lah0s.xe8uvvx.x2lwn1j.xeuugli.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1n2onr6.x16tdsg8.x1hl2dhg.xggy1nq.x1ja2u2z.x1t137rt.x1q0g3np.x87ps6o.x1lku1pv.x1a2a7pz.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x78zum5"
                                           Dim scrollDivCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x8mqhxd.x6ikm8r.x10wlt62.x1lcqyv9.xcrg951.xm0m39n.xzhurro.x6gs93r.xpyiiip.x88v6c3.x1qpj6lr.xdhzj85.x1bc3s5a > div > div.x78zum5.xdt5ytf.x1iyjqo2.x6ikm8r.x10wlt62 > div > div > div > div > div"
                                           Select Case messageSource
                                               Case "聊天室"
                                                   msgsrcCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xdj266r > div > span:nth-child(1) > a"
                                                   messengerCssSelector = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x8mqhxd.x6ikm8r.x10wlt62.x1lcqyv9.xcrg951.xm0m39n.xzhurro.x6gs93r.xpyiiip.x88v6c3.x1qpj6lr.xdhzj85.x1bc3s5a > div > div.x78zum5.xdt5ytf.x1iyjqo2.x6ikm8r.x10wlt62 > div > div > div > div > div > div:nth-child(2) > div > div > div > div > div > div > a"

                                               Case "Marketplace"
                                                   msgsrcCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xdj266r > div > span:nth-child(2) > a"
                                                   scrollDivCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x8mqhxd.x6ikm8r.x10wlt62.x1lcqyv9.xcrg951.xm0m39n.xzhurro.x6gs93r.xpyiiip.x88v6c3.x1qpj6lr.xdhzj85.x1bc3s5a > div > div > div > div > div > div"
                                                       'messengerCssSelector = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x8mqhxd.x6ikm8r.x10wlt62.x1lcqyv9.xcrg951.xm0m39n.xzhurro.x6gs93r.xpyiiip.x88v6c3.x1qpj6lr.xdhzj85.x1bc3s5a > div > div > div > div > div > div > div:nth-child(2) > div > div"
                                               Case "陌生訊息"
                                                   msgsrcCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xdj266r > div > span:nth-child(3) > a"
                                                   scrollDivCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x8mqhxd.x6ikm8r.x10wlt62.x1lcqyv9.xcrg951.xm0m39n.xzhurro.x6gs93r.xpyiiip.x88v6c3.x1qpj6lr.xdhzj85.x1bc3s5a > div.x78zum5.xdt5ytf.x1iyjqo2.x6ikm8r.x10wlt62 > div > div > div > div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.x1k70j0n.xat24cr > div > div > div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.x1xmf6yo.xat24cr > div > div > div > div > div > div"
                                               Case "垃圾訊息"
                                                   msgsrcCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xdj266r > div > span:nth-child(3) > a"
                                                   scrollDivCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x8mqhxd.x6ikm8r.x10wlt62.x1lcqyv9.xcrg951.xm0m39n.xzhurro.x6gs93r.xpyiiip.x88v6c3.x1qpj6lr.xdhzj85.x1bc3s5a > div.x78zum5.xdt5ytf.x1iyjqo2.x6ikm8r.x10wlt62 > div > div > div > div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.x1k70j0n.xat24cr > div > div > div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.x1xmf6yo.xat24cr > div > div > div > div > div > div"

                                           End Select

                                           ClickByCssSelectorWaitUntil(msgsrcCss, 5)

                                           If messageSource = "垃圾訊息" Then
                                               Await Delay_msec(2000)
                                               ClickByAriaLable("垃圾訊息")
                                           End If


                                           Await Delay_msec(2000)


                                           Dim scrolldivElement As IWebElement = edgeDriver.FindElement(By.CssSelector(scrollDivCss))
                                           Dim jsExecutor As IJavaScriptExecutor = CType(edgeDriver, IJavaScriptExecutor)

                                           Dim lastHeight As Long = CLng(jsExecutor.ExecuteScript("return arguments[0].scrollHeight;", scrolldivElement))

                                           Dim scrollCounter = 0
                                           While True

                                               jsExecutor.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight;", scrolldivElement)

                                               Await Delay_msec(2000)

                                               Dim elms = edgeDriver.FindElements(By.CssSelector(messengerCssSelector))

                                               For Each elm As IWebElement In elms


                                                   Dim url = elm.GetAttribute("href")
                                                   Dim name = "null"
                                                   Try
                                                       name = elm.FindElement(By.CssSelector("div.x9f619.x1ja2u2z.x78zum5.x1n2onr6.x1iyjqo2.xs83m0k.xeuugli.x1qughib.x6s0dn4.x1a02dak.x1q0g3np.xdl72j9 > div > div > div > span > span")).GetAttribute("innerHTML")
                                                       name = UtilsModule.RemoveHtmlTags(name)
                                                   Catch ex As Exception
                                                       'Debug.WriteLine(ex)
                                                       Continue For
                                                   End Try

                                                   '                                                            div.x9f619.x1ja2u2z.x78zum5.x1n2onr6.x1iyjqo2.xs83m0k.xeuugli.x1qughib.x6s0dn4.x1a02dak.x1q0g3np.xdl72j9 > div > div > div > span > span
                                                   Dim unread_dot As Boolean = False
                                                   Try
                                                       elm.FindElement(By.CssSelector("a > div.x1qjc9v5.x9f619.x78zum5.xdl72j9.xdt5ytf.x2lwn1j.xeuugli.x1n2onr6.x1ja2u2z.x889kno.x1iji9kk.x1a8lsjc.x1sln4lm.x1iyjqo2.xs83m0k > div > div > div:nth-child(3) > div > div > div > div > span"))
                                                       unread_dot = True
                                                   Catch ex As NoSuchElementException

                                                   End Try

                                                   Dim item As New ListViewItem(name)
                                                   item.SubItems.Add(url)

                                                   ' 判斷是否已經被加進去了
                                                   Dim exists As Boolean = itemList.Any(Function(itm) itm.SubItems(1).Text = url)
                                                   If exists Then

                                                       Debug.WriteLine("continue")
                                                       Continue For
                                                   End If

                                                   If unread And unread_dot Then ' 未讀
                                                       itemList.Add(item)
                                                   ElseIf read And Not unread_dot Then ' 已讀
                                                       itemList.Add(item)
                                                   End If

                                               Next

                                               ' test
                                               scrollCounter += 1

                                               If scrollCounter > 3 Then
                                                   Exit While
                                               End If


                                               Dim newHeight As Long = CLng(jsExecutor.ExecuteScript("return arguments[0].scrollHeight;", scrolldivElement))
                                               If newHeight = lastHeight Then
                                                   Exit While
                                               End If

                                               lastHeight = newHeight
                                           End While

                                       Catch ex As Exception
                                           Debug.WriteLine(ex)
                                       End Try
                                       Return itemList
                                   End Function)

            Return items
        Catch ex As Exception
            Debug.WriteLine(ex)
            Return items
        End Try
    End Function

    Public Async Function ArchiveMessenger(messageSource As String, read As Boolean, unread As Boolean) As Task(Of Boolean)
        'messageSource : 聊天室 | Marketplace | 陌生訊息
        'FBMessenger_TabPage
        Form1.FBUrlData_TabControl.SelectedTab = Form1.FBMessengerUrlData_TabPage
        Try
            Await Task.Run(Async Function()
                               Try
                                   Dim actions As New Actions(edgeDriver)

                                   Dim msgsrcCss As String = Nothing
                                   Dim messengerCssSelector As String = Nothing
                                   Dim scrollDivCss As String = Nothing
                                   Select Case messageSource
                                       Case "聊天室"
                                           msgsrcCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xdj266r > div > span:nth-child(1) > a"
                                           messengerCssSelector = "div.x78zum5.xdt5ytf.x1t2pt76.x1n2onr6.x1ja2u2z.x10cihs4 > div > div > div > div > div.x78zum5.xdt5ytf.x1iyjqo2.x6ikm8r.x10wlt62 > div > div > div > div > div > div:nth-child(2) > .x1n2onr6 > .x78zum5.xdt5ytf"
                                           scrollDivCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x8mqhxd.x6ikm8r.x10wlt62.x1lcqyv9.xcrg951.xm0m39n.xzhurro.x6gs93r.xpyiiip.x88v6c3.x1qpj6lr.xdhzj85.x1bc3s5a > div > div.x78zum5.xdt5ytf.x1iyjqo2.x6ikm8r.x10wlt62 > div > div > div > div > div"
                                       Case "Marketplace"
                                           msgsrcCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xdj266r > div > span:nth-child(2) > a"
                                           messengerCssSelector = "div.x78zum5.xdt5ytf.x1t2pt76.x1n2onr6.x1ja2u2z.x10cihs4 > div > div > div > div > div > div > div > div > div > div:nth-child(2) > .x1n2onr6> .x78zum5.xdt5ytf"
                                           scrollDivCss = "div.x9f619.x1n2onr6.x1ja2u2z.x78zum5.xdt5ytf.x2lah0s.x193iq5w.xeuugli.x8mqhxd.x6ikm8r.x10wlt62.x1lcqyv9.xcrg951.xm0m39n.xzhurro.x6gs93r.xpyiiip.x88v6c3.x1qpj6lr.xdhzj85.x1bc3s5a > div > div > div > div > div > div"
                                   End Select

                                   ClickByCssSelectorWaitUntil(msgsrcCss, 5)

                                   Await Delay_msec(2000)

                                   While True

                                       Dim read_chat_counter = 0
                                       Dim unread_chat_counter = 0

                                       Dim elms = edgeDriver.FindElements(By.CssSelector(messengerCssSelector))
                                       For Each elm As IWebElement In elms
                                           Debug.WriteLine("### elm")
                                           Dim unread_dot As Boolean = False
                                           Try
                                               elm.FindElement(By.CssSelector("a > div.x1qjc9v5.x9f619.x78zum5.xdl72j9.xdt5ytf.x2lwn1j.xeuugli.x1n2onr6.x1ja2u2z.x889kno.x1iji9kk.x1a8lsjc.x1sln4lm.x1iyjqo2.xs83m0k > div > div > div:nth-child(3) > div > div > div > div > span"))
                                               unread_dot = True
                                           Catch ex As NoSuchElementException

                                           End Try


                                           Try

                                               If unread_dot Then '未讀
                                                   unread_chat_counter += 1
                                               Else '已讀
                                                   read_chat_counter += 1
                                               End If

                                           Catch ex As Exception
                                               Debug.WriteLine(ex)
                                           End Try

                                       Next

                                       Debug.WriteLine("read_chat: " & read_chat_counter)
                                       Debug.WriteLine("unread_chat: " & unread_chat_counter)

                                       If read Then
                                           '處裡已讀
                                           If read_chat_counter > 0 Then
                                               For Each elm As IWebElement In elms
                                                   Dim unread_dot As Boolean = False
                                                   Try
                                                       elm.FindElement(By.CssSelector("a > div.x1qjc9v5.x9f619.x78zum5.xdl72j9.xdt5ytf.x2lwn1j.xeuugli.x1n2onr6.x1ja2u2z.x889kno.x1iji9kk.x1a8lsjc.x1sln4lm.x1iyjqo2.xs83m0k > div > div > div:nth-child(3) > div > div > div > div > span"))
                                                       unread_dot = True
                                                   Catch ex As NoSuchElementException

                                                   End Try

                                                   If Not unread_dot Then
                                                       Dim jsExecutor As IJavaScriptExecutor = CType(edgeDriver, IJavaScriptExecutor)
                                                       jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", elm)

                                                       actions.MoveToElement(elm).Perform()

                                                       Await Delay_msec(2000)
                                                       elm.FindElement(By.CssSelector("div[aria-label='功能表']")).Click()
                                                       Await Delay_msec(2000)
                                                       elm.FindElement(By.XPath("//div[@class='x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n xe8uvvx x1hl2dhg xggy1nq x1o1ewxj x3x9cwd x1e5q0jg x13rtm0m x87ps6o x1lku1pv x1a2a7pz x6s0dn4 xjyslct x9f619 x1ypdohk x78zum5 x1q0g3np x2lah0s xdj266r xat24cr xnqzcj9 x1gh759c x1344otq x1de53dj x1n2onr6 x16tdsg8 x1ja2u2z x1y1aw1k xwib8y2']//span[text()='封存聊天室']")).Click()
                                                       Await Delay_msec(2000)
                                                       Exit For

                                                   End If

                                               Next
                                           Else
                                               '如果目前頁面沒有符合的元素，就往下滾
                                               If Await UtilsModule.ScrollElement(scrollDivCss) Then
                                                   '如果已經滾到底了，還是沒有符合元素，就結束
                                                   Return True
                                               End If
                                           End If


                                       ElseIf unread Then
                                           '處裡未讀
                                           If unread_chat_counter > 0 Then
                                               For Each elm As IWebElement In elms
                                                   Dim unread_dot As Boolean = False
                                                   Try
                                                       elm.FindElement(By.CssSelector("a > div.x1qjc9v5.x9f619.x78zum5.xdl72j9.xdt5ytf.x2lwn1j.xeuugli.x1n2onr6.x1ja2u2z.x889kno.x1iji9kk.x1a8lsjc.x1sln4lm.x1iyjqo2.xs83m0k > div > div > div:nth-child(3) > div > div > div > div > span"))
                                                       unread_dot = True
                                                   Catch ex As NoSuchElementException

                                                   End Try

                                                   If unread_dot Then
                                                       Dim jsExecutor As IJavaScriptExecutor = CType(edgeDriver, IJavaScriptExecutor)
                                                       jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", elm)
                                                       Await Delay_msec(2000)
                                                       actions.MoveToElement(elm).Perform()
                                                       Await Delay_msec(2000)
                                                       elm.FindElement(By.CssSelector("div[aria-label='功能表']")).Click()
                                                       Await Delay_msec(2000)
                                                       elm.FindElement(By.XPath("//div[@class='x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n xe8uvvx x1hl2dhg xggy1nq x1o1ewxj x3x9cwd x1e5q0jg x13rtm0m x87ps6o x1lku1pv x1a2a7pz x6s0dn4 xjyslct x9f619 x1ypdohk x78zum5 x1q0g3np x2lah0s xdj266r xat24cr xnqzcj9 x1gh759c x1344otq x1de53dj x1n2onr6 x16tdsg8 x1ja2u2z x1y1aw1k xwib8y2']//span[text()='封存聊天室']")).Click()
                                                       Await Delay_msec(2000)
                                                       Exit For

                                                   End If

                                               Next
                                           Else
                                               '如果目前頁面沒有符合的元素，就往下滾
                                               If Await UtilsModule.ScrollElement(scrollDivCss) Then
                                                   '如果已經滾到底了，還是沒有符合元素，就結束
                                                   Return True
                                               End If
                                           End If
                                       End If


                                   End While


                               Catch ex As Exception
                                   Debug.WriteLine(ex)
                               End Try
                               Return True
                           End Function)

            Return True
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
