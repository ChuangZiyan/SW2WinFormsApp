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


                                          Await Delay_msec(2000)


                                          If myMedia <> Nothing Then
                                              Dim media_input As IWebElement = edgeDriver.FindElement(By.CssSelector("div.x6s0dn4.x1ey2m1c.x78zum5.xl56j7k.x10l6tqk.x1vjfegm.xat24cr.x3oybdh.x1g2r6go.x11xpdln.x1th4bbo > input"))
                                              'Debug.WriteLine("Media File : " & myMedia)
                                              media_input.SendKeys(myMedia)
                                          End If

                                          Await Delay_msec(2000)


                                          Dim text_input As IWebElement = edgeDriver.FindElement(By.CssSelector("div[aria-label='訊息']"))

                                          Dim lines As String() = myText.Split(New String() {vbCrLf, vbCr, vbLf}, StringSplitOptions.None)
                                          For Each line As String In lines
                                              'line = line.Replace(vbCr, "").Replace(vbLf, "").Replace(Environment.NewLine, "")
                                              text_input.SendKeys(line)
                                              Await Delay_msec(500)
                                              text_input.SendKeys(Keys.LeftShift + Keys.Return)
                                          Next


                                          'Return True


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
