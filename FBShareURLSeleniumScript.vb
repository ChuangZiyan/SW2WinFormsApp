Imports OpenQA.Selenium
Imports System.IO

Module FBShareURLSeleniumScript

    Public Async Function WritePostAndShareURLOnFacebook(myUrl As String, myAssetFolderPath As String) As Task(Of Boolean)
        Try

            'Dim enableClipboard As Boolean = Form1.EnableClipboard_CheckBox.Checked
            Dim myText As String = ""

            Dim textFileFolderPath = Path.Combine(myAssetFolderPath, "TextFiles")
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

            Dim mySharedURL As String = File.ReadAllText(Path.Combine(myAssetFolderPath, "myBaseURL.txt"))


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

                                          Dim text_input As IWebElement

                                          ClickByCssSelectorWaitUntil("div.x6s0dn4.x78zum5.x1l90r2v.x1pi30zi.x1swvt13.xz9dl7a > div", 5)
                                          Await Delay_msec(1000)

                                          text_input = edgeDriver.FindElement(By.CssSelector("div.x9f619.x1iyjqo2.xg7h5cd.x1pi30zi.x1swvt13.x1n2onr6.xh8yej3.x1ja2u2z.x1t1ogtf > div > div > div > div > div._5rpb > div"))

                                          ' 上傳網址連結
                                          If mySharedURL <> "" Then
                                              text_input.SendKeys(mySharedURL)
                                              Await Delay_msec(2000)
                                              text_input.SendKeys(Keys.LeftControl + "a")
                                              Await Delay_msec(1000)
                                              text_input.SendKeys(Keys.Delete)
                                          End If

                                          ' 上傳文字內容
                                          Await Delay_msec(1000)

                                          text_input.SendKeys(myText)

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
