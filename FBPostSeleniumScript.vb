Imports OpenQA.Selenium
Imports System.IO

Module FBPostSeleniumScript

    '1. 關閉瀏覽器
    '2. 開啟瀏覽器,直接到群組畫面
    '3. 送出1個ESC鍵 (必需要,很多時會彈出一個窗口,被人舉報說什麼什麼違規)
    '4. 按下討論區 (討論區的位置不固定的, 要跟加好友的寫法一樣) 如果按不列討論區直接顯示失敗
    '5. 按下"留個言吧..."，如果按不到直接顯示失敗
    '6. 抽出資料夾,抽出txt檔,送出txt檔內容
    '7. 送出全部圖片影片
    '8. 送出帖文(如果有影片，網頁一直會處於送出狀態(上載中)，所以我把關閉瀏覽器放在第1. ，我自己增加等待時間就可以，無需判斷是否送出，因為影片可以卡很久的。


    Public Async Function WritePostOnFacebook(myUrl As String, myAssetFolderPath As String) As Task(Of Boolean)
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

                                          Dim media_input As IWebElement
                                          Dim text_input As IWebElement

                                          ClickByCssSelectorWaitUntil("div.x6s0dn4.x78zum5.x1l90r2v.x1pi30zi.x1swvt13.xz9dl7a > div", 5)
                                          Await Delay_msec(3000)


                                          If IsElementPresentByCssSelector("div.x6s0dn4.x1jx94hy.x8cjs6t.x1ch86jh.x80vd3b.xckqwgs.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x178xt8z.xm81vs4.xso031l.xy80clv.xev17xk.x9f619.x78zum5.x1qughib.xktsk01.x1d52u69.x1y1aw1k.x1sxyh0.xwib8y2.xurb0ha > div.x78zum5 > div:nth-child(1) > input") Then

                                              media_input = edgeDriver.FindElement(By.CssSelector("div.x6s0dn4.x1jx94hy.x8cjs6t.x1ch86jh.x80vd3b.xckqwgs.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.x13fuv20.xu3j5b3.x1q0q8m5.x26u7qi.x178xt8z.xm81vs4.xso031l.xy80clv.xev17xk.x9f619.x78zum5.x1qughib.xktsk01.x1d52u69.x1y1aw1k.x1sxyh0.xwib8y2.xurb0ha > div.x78zum5 > div:nth-child(1) > input"))
                                              text_input = edgeDriver.FindElement(By.CssSelector("div > div > div > div > div._5rpb > div"))
                                          Else
                                              ClickByAriaLable("相片／影片")
                                              Await Delay_msec(2500)
                                              media_input = edgeDriver.FindElement(By.CssSelector("div.x1n2onr6.x1ja2u2z.x9f619.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.x1y1aw1k.xwib8y2 > div > div:nth-child(1) > input"))
                                              text_input = edgeDriver.FindElement(By.CssSelector("div > div > div > div > div._5rpb > div"))
                                          End If

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
                                          Await Delay_msec(1000)

                                          text_input.SendKeys(myText)

                                          Await Delay_msec(1000)

                                          If mediaFileList.Count > 0 Then
                                              media_input.SendKeys(String.Join(vbLf, mediaFileList))
                                          End If

                                          'Debug.WriteLine("EOF")
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
