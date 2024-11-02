Imports System.IO
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar
Imports OpenQA.Selenium
Imports SkiaSharp

Module UtilsModule

    Public Function GetAvailablePort(minPort As Integer, maxPort As Integer) As Integer
        Dim rand As New Random()
        Dim port As Integer

        For i As Integer = 1 To 100 ' try 100 times
            port = rand.Next(minPort, maxPort + 1)
            If Not IsPortInUse(port) Then
                Return port
            End If
        Next

        Return -1 ' return -1 if not found
    End Function

    Private Function IsPortInUse(port As Integer) As Boolean
        Dim isAvailable As Boolean = True

        Dim ipGlobalProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties
        Dim tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners()

        For Each endpoint In tcpConnInfoArray
            If endpoint.Port = port Then
                isAvailable = False
                Exit For
            End If
        Next

        Return Not isAvailable
    End Function


    Public Function GetRandomRangeValue(range As Integer) As Integer
        Dim rand As New Random()
        Dim randomValue As Integer = rand.Next(-range, range + 1)
        Return randomValue
    End Function

    Public Function ConvertSecondsToTimeFormat(seconds As Integer) As String
        If seconds > 86400 Then
            Return "NULL"
        End If
        Dim timeSpan As TimeSpan = TimeSpan.FromSeconds(seconds)
        Return timeSpan.ToString("hh\:mm\:ss")
    End Function

    Public Function ConvertTimeToSeconds(timeString As String) As Integer
        Dim time As TimeSpan = TimeSpan.Parse(timeString)
        Dim totalSeconds As Integer = CInt(time.TotalSeconds)
        Return totalSeconds
    End Function


    Public Function SKBitmapToBitmap(skBitmap As SKBitmap) As Bitmap
        Using image As SKImage = SKImage.FromBitmap(skBitmap)
            Using data As SKData = image.Encode()
                Using stream As New MemoryStream(data.ToArray())
                    Return New Bitmap(stream)
                End Using
            End Using
        End Using
    End Function



    Public Sub MyWriteFile(text As String, filePath As String)
        Try
            'Debug.WriteLine("path : " & filePath)
            Using writer As New StreamWriter(filePath)

                ' BMP pattern
                Dim pattern_BMP As String = "[\uD800-\uDBFF][\uDC00-\uDFFF]"
                ' remove non BMP char
                Dim inputString = text
                Dim resultString As String = Regex.Replace(inputString, pattern_BMP, "")
                writer.Write(resultString)
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Public Function IsValidUrl(url As String) As Boolean
        Try
            Dim uriResult As New Uri(url)
            Return uriResult.Scheme = Uri.UriSchemeHttp OrElse uriResult.Scheme = Uri.UriSchemeHttps
        Catch ex As UriFormatException
            Return False
        End Try
    End Function


    Public Function RemoveHtmlTags(ByVal input As String) As String
        ' 使用正則表達式來去除 HTML 標籤
        Return Regex.Replace(input, "<.*?>", String.Empty)
    End Function


    Public Async Function ScrollElement(elementCss As String) As Task(Of Boolean)
        Try
            Dim scrolldivElement As IWebElement = edgeDriver.FindElement(By.CssSelector(elementCss))
            Dim jsExecutor As IJavaScriptExecutor = CType(edgeDriver, IJavaScriptExecutor)

            Dim lastHeight As Long = CLng(jsExecutor.ExecuteScript("return arguments[0].scrollHeight;", scrolldivElement))

            jsExecutor.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight;", scrolldivElement)

            Await Delay_msec(3000)

            Dim newHeight As Long = CLng(jsExecutor.ExecuteScript("return arguments[0].scrollHeight;", scrolldivElement))

            If newHeight = lastHeight Then
                Return True
            End If
        Catch ex As NoSuchElementException
            Debug.WriteLine(ex.Message)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

        Return False
    End Function

    Public Async Function DownloadFileAsync(httpClient As HttpClient, url As String, filePath As String) As Task
        Try
            Dim fileBytes = Await httpClient.GetByteArrayAsync(url)
            Await File.WriteAllBytesAsync(filePath, fileBytes)
            Console.WriteLine("已下載：" & filePath)
        Catch ex As Exception
            Console.WriteLine("下載失敗：" & url & " 錯誤訊息：" & ex.Message)
        End Try
    End Function

    Public Async Function DownloadUrlResource(resourceUrl) As Task
        Try

            ' 使用 HttpClient 下載圖片和影片
            Dim downloadTasks As New List(Of Task)
            Using httpClient As New HttpClient()


                Dim fileName = Path.Combine(AppInitModule.DownloadedImagesResourcesAssetsDirectory, "image_" & Guid.NewGuid().ToString() & ".jpg")
                Await DownloadFileAsync(httpClient, resourceUrl, fileName)

                ' 等待所有下載完成
                'Await Task.WhenAll(downloadTasks)
            End Using
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Function


End Module
