Imports System.IO
Imports System.IO.Pipes

Module PipeServerModule





    Public Sub StartPipeServer(pipeName As String, targetForm As Form)
        Task.Run(Async Function()
                     Debug.WriteLine($"pipe {pipeName} waiting...")
                     While True
                         Using pipeServer As New NamedPipeServerStream(pipeName, PipeDirection.In, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message, PipeOptions.Asynchronous)
                             Try
                                 Await pipeServer.WaitForConnectionAsync()
                                 Debug.WriteLine("mgr pipe connected")

                                 Using reader As New StreamReader(pipeServer)
                                     While Not reader.EndOfStream
                                         Dim command As String = Await reader.ReadLineAsync()
                                         If Not String.IsNullOrWhiteSpace(command) Then
                                             Debug.WriteLine("cmd received: " & command)

                                             ' 這邊要切回Form1的線程，不然UI不會有效果
                                             targetForm.Invoke(Sub()
                                                                   PipeTaskHandler(command)
                                                               End Sub)
                                         End If
                                     End While
                                 End Using
                             Catch ex As Exception
                                 Debug.WriteLine("handle pipe error " & ex.Message)
                             End Try
                         End Using
                     End While
                 End Function)
    End Sub



    Private Sub PipeTaskHandler(cmd As String)
        Try
            Select Case True
                Case cmd.Contains("setOpacity")
                    Dim OpacifyVal As Double = Convert.ToDouble(Split(cmd, ":")(1))
                    'Debug.WriteLine(OpacifyVal)
                    Form1.Opacity = OpacifyVal
                Case cmd = "setForegroundWindow"
                    'Debug.WriteLine("#setForegroundWindow")
                    UtilsModule.SetForegroundWindow(Form1.Handle)

                Case cmd.Contains("setLocation")
                    'Debug.WriteLine("#setLocation")
                    Dim locationVal As String = Split(cmd, ":")(1)
                    Dim location_x = CInt(Split(locationVal, ",")(0))
                    Dim location_y = CInt(Split(locationVal, ",")(1))
                    'Debug.WriteLine($"setLocation: {location_x},{location_y} ")
                    Form1.Location = New Point(location_x, location_y)

                Case cmd = "setLiteModeNormal"
                    MainFormController.SetLiteMode("normal")
                Case cmd = "setLiteModeWebview"
                    MainFormController.SetLiteMode("webview")
                Case cmd = "setLiteModeScriptListView"
                    MainFormController.SetLiteMode("script_queue_listview")
                Case cmd = "closeApp"
                    MainFormController.SetForm1TitleStatus("關閉中...")
                    If Webview2Controller.edgeDriver IsNot Nothing Then
                        Webview2Controller.edgeDriver.Quit()
                    End If
                    Form1.Close()
            End Select
        Catch ex As Exception
            Debug.WriteLine("Pipe command parse failed")
            Debug.WriteLine(ex)
        End Try


    End Sub


End Module
