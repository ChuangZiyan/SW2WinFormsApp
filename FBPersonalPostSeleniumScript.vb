Imports OpenQA.Selenium
Imports System.IO

Module FBPersonalPostSeleniumScript


    Public Async Function WritePersonalPostOnFacebook(myUrl As String, myAssetFolderPath As String) As Task(Of Boolean)
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

            Return Await Task.Run(Async Function() As Task(Of Boolean)
                                      Try

                                          Await Navigate_GoToUrl(myUrl)

                                          Await Delay_msec(300)
                                          '送出1個ESC鍵
                                          Dim bodyElement As IWebElement = edgeDriver.FindElement(By.TagName("body"))
                                          bodyElement.SendKeys(Keys.Escape)

                                          Await Delay_msec(1000)
                                          '點發帖
                                          Webview2Controller.ClickByCssSelector("div.xqmpxtq.x13fuv20.x178xt8z.x78zum5.x1a02dak.x1vqgdyp.x1l1ennw.x14vqqas.x6ikm8r.x10wlt62.x1y1aw1k.xh8yej3 > div:nth-child(2)")
                                          Await Delay_msec(2000)

                                          Dim text_input = edgeDriver.FindElement(By.CssSelector("div.xzsf02u.x1a2a7pz.x1n2onr6.x14wi4xw.x9f619.x1lliihq.x5yr21d.xh8yej3.notranslate"))
                                          'text_input.SendKeys(myText)

                                          Dim media_input = edgeDriver.FindElement(By.CssSelector("div.x1n2onr6.x1ja2u2z.x9f619.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.x1y1aw1k.xwib8y2 > div > div:nth-child(1) > input"))

                                          ' upload media files
                                          Dim mediaFileList As New List(Of String)
                                          Dim mediaFileFolderPath = Path.Combine(myAssetFolderPath, "media")

                                          Dim allowedExtension As String() = {".WEBP", ".webp", ".bmp", ".BMP", ".jpe", ".JPE", ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG", ".mp4", ".MP4"}
                                          Dim myFiles As String() = Directory.GetFiles(mediaFileFolderPath)
                                          For Each file As String In myFiles
                                              If allowedExtension.Contains(Path.GetExtension(file)) Then
                                                  'Debug.WriteLine("file" & Path.GetFileName(file))
                                                  mediaFileList.Add(file)
                                              End If
                                          Next

                                          ' 上傳文字
                                          Await Delay_msec(2000)

                                          text_input.SendKeys(myText)

                                          Await Delay_msec(2000)

                                          If mediaFileList.Count > 0 Then
                                              media_input.SendKeys(String.Join(vbLf, mediaFileList))
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
