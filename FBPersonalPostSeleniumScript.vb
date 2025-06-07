Imports OpenQA.Selenium
Imports System.IO

Module FBPersonalPostSeleniumScript


    Public Async Function WritePersonalPostOnFacebook(myUrl As String, myAssetFolderPath As String, Optional singleMedia As Boolean = False) As Task(Of Boolean)
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

                                          Debug.WriteLine("####!!!!")
                                          Await Delay_msec(1000)
                                          '點發帖
                                          Webview2Controller.ClickByCssSelector("div.x1cy8zhl.x78zum5.x1iyjqo2.xs83m0k.xh8yej3 > div")
                                          Await Delay_msec(2000)

                                          Dim text_input = edgeDriver.FindElement(By.CssSelector("div.xzsf02u.x1a2a7pz.x1n2onr6.x14wi4xw.x9f619.x1lliihq.x5yr21d.xh8yej3.notranslate"))

                                          'text_input.SendKeys(myText)

                                          Dim media_input = edgeDriver.FindElement(By.CssSelector("div.x6s0dn4.x1jx94hy.x8cjs6t.x3sou0m.x80vd3b.x12u81az.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.x13fuv20.x18b5jzi.x1q0q8m5.x1t7ytsu.x178xt8z.x1lun4ml.xso031l.xpilrb4.xev17xk.x9f619.x78zum5.x1qughib.x1ys307a.xyqm7xq.x1y1aw1k.xf159sx.xwib8y2.xmzvs34 > div:nth-child(2) > div > div:nth-child(1) > input"))

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

                                              If singleMedia Then
                                                  Dim rand As New Random()
                                                  Dim randomIndex As Integer = rand.Next(0, mediaFileList.Count)
                                                  media_input.SendKeys(mediaFileList(randomIndex))
                                              Else
                                                  media_input.SendKeys(String.Join(vbLf, mediaFileList))
                                              End If


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
