Imports OpenQA.Selenium
Imports System.IO

Module FBMessengerSeleniumScript


    Public Async Function SendMessageThroughMessenger(myUrl As String, myAssetFolderPath As String) As Task(Of Boolean)
        Try
            ' Text Files
            Dim myText As String = ""
            Dim textFileFolderPath = Path.Combine(myAssetFolderPath, "textFiles")
            Dim textFiles As String() = Directory.GetFiles(textFileFolderPath, "*.txt")

            If textFiles.Length > 0 Then

                If Directory.Exists(textFileFolderPath) Then

                    Dim rand As New Random()
                    Dim randomIndex As Integer = rand.Next(0, textFiles.Length)
                    Dim randomTextFile As String = textFiles(randomIndex)
                    myText = File.ReadAllText(randomTextFile)
                End If

            Else
                Debug.WriteLine("資料夾內無文字檔")
            End If

            ' Media Files
            Dim myMedia As String = Nothing
            Dim mediaFileFolderPath = Path.Combine(myAssetFolderPath, "media")
            Dim mediaFiles As String() = Directory.GetFiles(mediaFileFolderPath)

            If mediaFiles.Length > 0 Then

                If Directory.Exists(mediaFileFolderPath) Then

                    Dim rand As New Random()
                    Dim randomIndex As Integer = rand.Next(0, mediaFiles.Length)
                    Dim randomMediaFile As String = mediaFiles(randomIndex)
                    myMedia = randomMediaFile
                End If

            Else
                Debug.WriteLine("資料夾內無文字檔")
            End If

            Return Await Task.Run(Async Function() As Task(Of Boolean)
                                      Try

                                          Await Navigate_GoToUrl(myUrl)


                                          Await Delay_msec(5000)


                                          If myMedia <> Nothing Then
                                              Dim media_input As IWebElement = edgeDriver.FindElement(By.CssSelector("div.x6s0dn4.x1ey2m1c.x78zum5.xl56j7k.x10l6tqk.x1vjfegm.xat24cr.x3oybdh.x1g2r6go.x11xpdln.x1th4bbo > input"))
                                              'Debug.WriteLine("Media File : " & myMedia)
                                              media_input.SendKeys(myMedia)
                                          End If

                                          Await Delay_msec(2000)


                                          Dim text_input As IWebElement = edgeDriver.FindElement(By.CssSelector("div[aria-label='訊息']"))

                                          ' 如果內容是空白就不要輸入
                                          If myText.Trim() <> "" Then
                                              Dim lines As String() = myText.Split(New String() {vbCrLf, vbCr, vbLf}, StringSplitOptions.None)
                                              For Each line As String In lines
                                                  'line = line.Replace(vbCr, "").Replace(vbLf, "").Replace(Environment.NewLine, "")
                                                  text_input.SendKeys(line)
                                                  Await Delay_msec(500)
                                                  text_input.SendKeys(Keys.LeftShift + Keys.Return)
                                              Next
                                          End If

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


    Public Async Function ReplyRequestMessage(myAssetFolderPath As String) As Task(Of Boolean)
        Try
            ' Text Files
            Dim myText As String = ""
            Dim textFileFolderPath = Path.Combine(myAssetFolderPath, "textFiles")
            Dim textFiles As String() = Directory.GetFiles(textFileFolderPath, "*.txt")

            If textFiles.Length > 0 Then

                If Directory.Exists(textFileFolderPath) Then

                    Dim rand As New Random()
                    Dim randomIndex As Integer = rand.Next(0, textFiles.Length)
                    Dim randomTextFile As String = textFiles(randomIndex)
                    myText = File.ReadAllText(randomTextFile)
                End If

            Else
                Debug.WriteLine("資料夾內無文字檔")
            End If

            ' Media Files
            Dim myMedia As String = Nothing
            Dim mediaFileFolderPath = Path.Combine(myAssetFolderPath, "media")
            Dim mediaFiles As String() = Directory.GetFiles(mediaFileFolderPath)

            If mediaFiles.Length > 0 Then

                If Directory.Exists(mediaFileFolderPath) Then

                    Dim rand As New Random()
                    Dim randomIndex As Integer = rand.Next(0, mediaFiles.Length)
                    Dim randomMediaFile As String = mediaFiles(randomIndex)
                    myMedia = randomMediaFile
                End If

            Else
                Debug.WriteLine("資料夾內無文字檔")
            End If

            Return Await Task.Run(Async Function() As Task(Of Boolean)
                                      Try
                                          Await Navigate_GoToUrl("https://www.messenger.com/requests/")
                                          Await Delay_msec(5000)
                                          Dim tryCounter As Integer = 0
                                          Dim elmCounter As Integer = 0

                                          While True


                                              Dim messengerCssSelector = ".x1i10hfl.x1qjc9v5.xjbqb8w.xjqpnuy.xa49m3k.xqeqjp1.x2hbi6w.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x972fbf.xcfux6l.x1qhh985.xm0m39n.x9f619.x1ypdohk.xdl72j9.x2lah0s.xe8uvvx.x2lwn1j.xeuugli.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x1n2onr6.x16tdsg8.x1hl2dhg.xggy1nq.x1ja2u2z.x1t137rt.x1q0g3np.x87ps6o.x1lku1pv.x1a2a7pz.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.x78zum5"
                                              Dim elms = Nothing
                                              Try
                                                  elms = edgeDriver.FindElements(By.CssSelector(messengerCssSelector))
                                              Catch ex As Exception
                                                  Debug.WriteLine("not found elms")
                                                  Exit While
                                              End Try

                                              If elmCounter = elms.Count Then
                                                  tryCounter += 1
                                              Else
                                                  elmCounter = elms.Count
                                              End If


                                              If tryCounter > 5 Then
                                                  Exit While
                                              End If


                                              Debug.WriteLine("elms count : " & elms.Count)

                                              For Each elm As IWebElement In elms
                                                  Try
                                                      elm.Click()
                                                      Await Delay_msec(3000)
                                                      Dim text_input As IWebElement = edgeDriver.FindElement(By.CssSelector("div[aria-label='訊息']"))
                                                      Await Delay_msec(1000)
                                                      text_input.SendKeys(myText)
                                                      Await Delay_msec(3000)
                                                      text_input.SendKeys(Keys.Enter)
                                                      Await Delay_msec(1000)
                                                      Exit For
                                                  Catch ex As Exception
                                                      Continue For
                                                  End Try

                                              Next


                                          End While


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


End Module
