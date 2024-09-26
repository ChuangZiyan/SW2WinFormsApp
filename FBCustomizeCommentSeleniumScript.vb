Imports OpenQA.Selenium
Imports System.IO

Module FBCustomizeCommentSeleniumScript

    Public Async Function CustomizeCommentOnThePost(myUrl As String, myAssetFolderPath As String) As Task(Of Boolean)

        Return Await Task.Run(Async Function() As Task(Of Boolean)
                                  Try

                                      Await Navigate_GoToUrl(myUrl)

                                      Await Delay_msec(1000)
                                      '送出1個ESC鍵
                                      Dim bodyElement As IWebElement = edgeDriver.FindElement(By.TagName("body"))
                                      bodyElement.SendKeys(Keys.Escape)

                                      'Await Delay_msec(1000)
                                      '按下"留個言吧..."，如果按不到直接顯示失敗
                                      'edgeDriver.ExecuteScript("window.scrollTo(0, 250);")

                                      'Await Delay_msec(1000)

                                      'Dim discussion_spanElements = edgeDriver.FindElements(By.CssSelector("div.x1ey2m1c.x9f619.xds687c.x10l6tqk.x17qophe.x13vifvy > a"))
                                      'For Each elm In discussion_spanElements
                                      'Debug.WriteLine("#################")
                                      'Dim span_innerHTML = elm.FindElement(By.CssSelector("span")).GetAttribute("innerHTML")

                                      'If span_innerHTML.Trim() = "討論區" Or span_innerHTML.Trim() = "討論" Then
                                      'elm.Click()
                                      'Exit For
                                      'End If
                                      'Next

                                      Await Delay_msec(5000)


                                      Dim myIndex As Integer = 0


                                      For idx = 0 To 9
                                          Try
                                              Debug.WriteLine("idx : " & idx)
                                              bodyElement.SendKeys(Keys.Escape)
                                              Await Delay_msec(2000)
                                              bodyElement.SendKeys("j")
                                              Await Delay_msec(2000)

                                              Dim comment_textboxes = edgeDriver.FindElements(By.CssSelector("div.xzsf02u.x1a2a7pz.x1n2onr6.x14wi4xw.notranslate"))
                                              Dim media_inputs = edgeDriver.FindElements(By.CssSelector("div.x4b6v7d.x1ojsi0c > ul > li:nth-child(3) > input"))

                                              If idx >= comment_textboxes.Count Then
                                                  Exit For
                                              End If

                                              ' send text
                                              Dim myText As String = getText(myAssetFolderPath)
                                              If myText <> Nothing Then
                                                  Dim lines As String() = myText.Split(New String() {vbCrLf, vbCr, vbLf}, StringSplitOptions.None)
                                                  For Each line As String In lines
                                                      'line = line.Replace(vbCr, "").Replace(vbLf, "").Replace(Environment.NewLine, "")
                                                      comment_textboxes(idx).SendKeys(myText)
                                                      Await Delay_msec(500)
                                                      comment_textboxes(idx).SendKeys(Keys.LeftShift + Keys.Return)
                                                  Next

                                                  Await Delay_msec(2000)
                                              End If

                                              ' upload media
                                              Dim myMedia As String = getMedia(myAssetFolderPath)
                                              If myMedia <> Nothing Then
                                                  media_inputs.ElementAt(myIndex).SendKeys(myMedia)
                                              End If

                                              Await Delay_msec(5000)
                                              ' 如果你要送出留言，就取消註解
                                              ' comment_textbox.SendKeys(Keys.Return)
                                          Catch ex As Exception
                                              Debug.WriteLine(ex)
                                          End Try

                                      Next


                                      Return True
                                  Catch ex As Exception
                                      Return False
                                  End Try

                              End Function)



    End Function


    Private Function getText(myAssetFolderPath)
        Try
            Dim textFileFolderPath = Path.Combine(myAssetFolderPath, "textFiles")
            Dim textFiles As String() = Directory.GetFiles(textFileFolderPath, "*.txt")

            If textFiles.Length > 0 Then

                If Directory.Exists(textFileFolderPath) Then

                    Dim rand As New Random()
                    Dim randomIndex As Integer = rand.Next(0, textFiles.Length)
                    Dim randomTextFile As String = textFiles(randomIndex)
                    Dim myText = File.ReadAllText(randomTextFile)
                    Return myText
                End If

            End If

        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
        Return Nothing
    End Function

    Private Function getMedia(myAssetFolderPath)
        Try
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
                    Return myMedia
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try
        Return Nothing
    End Function

End Module
