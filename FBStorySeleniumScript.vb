Imports OpenQA.Selenium
Imports System.IO

Module FBStorySeleniumScript
    Public Async Function CreatePhotoStoryOnFacebook(myUrl As String, myAssetFolderPath As String) As Task(Of Boolean)
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
                                              Dim media_input As IWebElement = edgeDriver.FindElement(By.CssSelector("div.x9f619.x2lah0s.x1nhvcw1.x1qjc9v5.xozqiw3.x1q0g3np.x78zum5.x1iyjqo2.x1t2pt76.x1n2onr6.x1ja2u2z > div.x9f619.x1n2onr6.x1ja2u2z.xdt5ytf.x193iq5w.xeuugli.x1r8uery.x1iyjqo2.xs83m0k.x78zum5.x1t2pt76 > div > div > div > div > input"))
                                              media_input.SendKeys(myMedia)
                                          End If


                                          Await Delay_msec(2000)


                                          myText = ""
                                          If myText <> "" Then
                                              Webview2Controller.ClickByCssSelector("div.x9f619.x78zum5.x1r8uery.xdt5ytf.x1iyjqo2.xs83m0k.x1nhvcw1.x1swvt13.x1pi30zi.xh8yej3 > div > div")
                                              Await Delay_msec(2000)
                                              Dim text_input As IWebElement = edgeDriver.FindElement(By.CssSelector("input[aria-label$='開始輸入']"))
                                              text_input.SendKeys(myText)
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
End Module
