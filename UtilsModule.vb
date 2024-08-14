Imports System.Net.NetworkInformation
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar

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



End Module
