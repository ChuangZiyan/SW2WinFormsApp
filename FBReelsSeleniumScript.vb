Imports OpenQA.Selenium
Imports System.IO

Module FBReelsSeleniumScript
    Public Async Function CreateReelsOnFacebook(myUrl As String, myAssetFolderPath As String) As Task(Of Boolean)
        Try

            'Debug.WriteLine("WritePostOnFacebook")
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
                Debug.WriteLine("資料夾內無圖片檔")
                Return False
            End If

            Return Await Task.Run(Async Function() As Task(Of Boolean)
                                      Try

                                          Await Navigate_GoToUrl(myUrl)
                                          Await Delay_msec(3000)

                                          If myMedia <> Nothing Then
                                              Dim media_input As IWebElement = edgeDriver.FindElement(By.CssSelector("div.x1xmf6yo.x78zum5.xdt5ytf.x1iyjqo2 > div > div > div.x1u5z0ei > div > input"))
                                              media_input.SendKeys(myMedia)
                                          End If
                                          Await Delay_msec(3000)

                                          ClickByAriaLable("繼續")

                                          Await Delay_msec(3000)

                                          ClickByCssSelectorWaitUntil("div:nth-child(2) > div.x1i10hfl.xjbqb8w.x1ejq31n.xd10rxx.x1sy0etr.x17r0tee.x972fbf.xcfux6l.x1qhh985.xm0m39n.x1ypdohk.xe8uvvx.xdj266r.x11i5rnm.xat24cr.x1mh8g0r.xexx8yu.x4uap5.x18d9i69.xkhd6sd.x16tdsg8.x1hl2dhg.xggy1nq.x1o1ewxj.x3x9cwd.x1e5q0jg.x13rtm0m.x87ps6o.x1lku1pv.x1a2a7pz.x9f619.x3nfvp2.xdt5ytf.xl56j7k.x1n2onr6.xh8yej3", 5)

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
