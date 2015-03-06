Imports System.Net.Sockets
Imports System.Text

Public Class CheckPort

    '==[ VAR ]==
    Private _IP As String
    Private _port As Integer
    Private _busy As Boolean
    Private _form As FroggSecurityChecker

    '==[ INIT ]==
    Public Sub New(ByRef form As FroggSecurityChecker, ByVal IP As String, ByVal port As Integer)
        _form = form
        _IP = IP
        _port = port
    End Sub

    '==[ FUNC ]==
    Public Sub checkAPort()

        'init tcp client
        Dim scan = New TcpClient()

        'tcp options
        scan.ReceiveTimeout = _form.receiveTimeOut
        scan.SendTimeout = _form.sendTimeOut

        'create ascync handle
        Dim result As IAsyncResult = scan.BeginConnect(_IP, _port, Nothing, Nothing)
        Dim success As Boolean = result.AsyncWaitHandle.WaitOne(_form.connectTimeOut, True) 'timeOut for the async

        'connexion success !
        If success Then

            If (scan.Connected) Then

                'result
                Dim streamRes = "open"

                Try

                    'open stream
                    Dim netStream As NetworkStream = scan.GetStream()

                    'taken from MS VB web site
                    If netStream.CanRead Then
                        ' Reads the NetworkStream into a byte buffer.
                        Dim bytes(scan.ReceiveBufferSize) As Byte
                        ' Read can return anything from 0 to numBytesToRead. 
                        ' This method blocks until at least one byte is read.
                        netStream.Read(bytes, 0, CInt(scan.ReceiveBufferSize))
                        ' Returns the data received from the host to the console.
                        streamRes = Encoding.ASCII.GetString(bytes)
                    Else
                        streamRes &= " | cannot read data"
                    End If

                    'clean stream
                    netStream.Close()

                Catch ex As Exception

                    'streamRes = ex.Message

                End Try

                'add result to result listview
                _form.setResult(_IP, _port.ToString("D5"), streamRes)

            End If

        End If

        'clean connexion
        scan.Close()

        ' Close the wait handle.
        result.AsyncWaitHandle.Close()

        'decraese thread
        _form.threadNb = _form.threadNb - 1

    End Sub

End Class
