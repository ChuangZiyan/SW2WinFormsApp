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
                                                                   PipiTaskHandler(command)
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



    Private Sub PipiTaskHandler(cmd As String)

        Select Case True
            Case cmd = "test"
                MsgBox("test")
            Case cmd.Contains("setOpacity")
                Dim OpacifyVal As Double = Convert.ToDouble(Split(cmd, ":")(1))
                Debug.WriteLine(OpacifyVal)
                Form1.Opacity = OpacifyVal
            Case cmd = "setFocus"
                Form1.Focus()
            Case cmd = "setLiteModeNormal"
                MainFormController.SetLiteMode("normal")
            Case cmd = "setLiteModeWebview"
                MainFormController.SetLiteMode("webview")
            Case cmd = "setLiteModeScriptListView"
                MainFormController.SetLiteMode("script_queue_listview")
        End Select
    End Sub


End Module
