﻿Imports OpenQA.Selenium
Imports SW2WinFormsApp.FBMarketplaceEventHandlers
Imports System.IO

Module FBMarketplaceSeleniumScript
    Public Async Function SellSomething(myUrl As String, myAssetFolderPath As String) As Task(Of Boolean)
        Try
            Dim product As FBMarketplaceEventHandlers.FBMarketPlaceProduct = FBMarketplaceEventHandlers.GetProduct(myAssetFolderPath)

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

                                              If span_innerHTML.Trim() = "商品買賣" Then
                                                  elm.Click()
                                                  Exit For
                                              End If

                                          Next
                                          Await Delay_msec(1000)


                                          ClickByAriaLable("商品拍賣")

                                          Await Delay_msec(2000)

                                          ClickByCssSelectorWaitUntil("div.xamitd3.x78zum5.x1q0g3np.x1a02dak.x1e56ztr.xw3qccf.x1sliqq.x14vqqas.xh8yej3.x1ni0lre.xlqeb66 > div:nth-child(1) > div > span > div > div", 5)

                                          ' 開很慢，要等久一點
                                          Await Delay_msec(3000)

                                          ' 上傳圖片
                                          Dim media_input As IWebElement
                                          media_input = edgeDriver.FindElement(By.CssSelector("div.x1gslohp.x1swvt13.x1pi30zi > label:nth-child(2) > input"))

                                          ' upload media files
                                          Dim mediaFileList As New List(Of String)
                                          Dim mediaFileFolderPath = Path.Combine(myAssetFolderPath, "media")

                                          'Debug.WriteLine("FFFFF : " & mediaFileFolderPath)

                                          Dim allowedExtension As String() = {".bmp", ".BMP", ".jpe", ".JPE", ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG", ".mp4", ".MP4"}
                                          Dim myFiles As String() = Directory.GetFiles(mediaFileFolderPath)
                                          For Each file As String In myFiles
                                              If allowedExtension.Contains(Path.GetExtension(file)) Then
                                                  'Debug.WriteLine("file" & Path.GetFileName(file))
                                                  mediaFileList.Add(file)
                                              End If
                                          Next

                                          Await Delay_msec(1000)

                                          If mediaFileList.Count > 0 Then
                                              media_input.SendKeys(String.Join(vbLf, mediaFileList))
                                          End If

                                          'ClickByAriaLable("標題")
                                          '輸入商品名稱
                                          Await Delay_msec(1000)
                                          edgeDriver.FindElement(By.CssSelector("div.x9f619.x1ja2u2z.x1k90msu.x6o7n8i.x1qfuztq.x17qophe.x10l6tqk.x13vifvy.x1hc1fzr.x71s49j.xh8yej3 > div > div:nth-child(4) > div:nth-child(3) > div > div > div > div > label > input")).SendKeys(product.Name)

                                          '輸入商品價格
                                          Await Delay_msec(1000)
                                          edgeDriver.FindElement(By.CssSelector("div.x9f619.x1ja2u2z.x1k90msu.x6o7n8i.x1qfuztq.x17qophe.x10l6tqk.x13vifvy.x1hc1fzr.x71s49j.xh8yej3 > div > div:nth-child(4) > div:nth-child(4) > div > div > div > div > label > input")).SendKeys(product.Price)

                                          '輸入商品狀況
                                          Await Delay_msec(1000)
                                          ClickByCssSelectorWaitUntil("div.x9f619.x1ja2u2z.x1k90msu.x6o7n8i.x1qfuztq.x17qophe.x10l6tqk.x13vifvy.x1hc1fzr.x71s49j.xh8yej3 > div > div:nth-child(4) > div:nth-child(5) > div > div > div > div > div > label", 5)
                                          Await Delay_msec(2000)
                                          edgeDriver.FindElement(By.XPath("//span[text()='" & product.Status & "']")).Click()
                                          ClickByCssSelectorWaitUntil("div.x1n2onr6.x1ja2u2z.x9f619.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.xyamay9 > div > div > div:nth-child(1) > div", 5)
                                          Await Delay_msec(2000)

                                          '輸入商品敘述
                                          edgeDriver.FindElement(By.CssSelector("div.x1n2onr6.x1ja2u2z.x9f619.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.xyamay9 > div > div > div:nth-child(2) > div > div > div > div > label > div > textarea")).SendKeys(product.Description)
                                          Await Delay_msec(1000)

                                          '輸入商品標籤
                                          Dim productTagsInput = edgeDriver.FindElement(By.CssSelector("div.x78zum5.x1ye3gou.xn6708d.xtt52l0 > div  > textarea"))
                                          For Each tag In product.Tags
                                              productTagsInput.SendKeys(tag)
                                              Await Delay_msec(500)
                                              productTagsInput.SendKeys(Keys.Return)
                                          Next

                                          '輸入商品地點
                                          Await Delay_msec(1000)
                                          Dim productLocationInput = edgeDriver.FindElement(By.CssSelector("div.x1n2onr6.x1ja2u2z.x9f619.x78zum5.xdt5ytf.x193iq5w.x1l7klhg.x1iyjqo2.xs83m0k.x2lwn1j.xyamay9 > div > div > div:nth-child(4) > div > div > div > div > div > div > div > div > div > label > input"))
                                          productLocationInput.Click()
                                          Await Delay_msec(500)
                                          productLocationInput.SendKeys(Keys.Delete)
                                          Await Delay_msec(500)
                                          productLocationInput.SendKeys(product.Location)
                                          Await Delay_msec(1000)
                                          '搜尋地點後 點第一個符合的
                                          Dim productLocationOption = edgeDriver.FindElements(By.CssSelector("div.x1jx94hy.x1lq5wgf.xgqcy7u.x30kzoy.x9jhf4c.xbsqzb3.x9f619.x78zum5.xdt5ytf.x1iyjqo2.xr9ek0c.xh8yej3 > div > ul > li"))
                                          productLocationOption.ElementAt(0).Click()

                                          Await Delay_msec(1000)

                                          If product.MeetInPerson Then
                                              Await Delay_msec(1000)
                                              edgeDriver.FindElement(By.XPath("//span[text()='公開面交']")).Click()
                                          End If

                                          If product.PickUp Then
                                              Await Delay_msec(1000)
                                              edgeDriver.FindElement(By.XPath("//span[text()='到府取貨']")).Click()
                                          End If

                                          If product.HomeDelivery Then
                                              Await Delay_msec(1000)
                                              edgeDriver.FindElement(By.XPath("//span[text()='送至門口']")).Click()
                                          End If

                                          Await Delay_msec(1000)
                                          ClickByAriaLable("下一步")

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