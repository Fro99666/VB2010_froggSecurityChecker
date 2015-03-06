Imports System.Net

Public Class FroggSecurityChecker

    '*****************************
    ' = TODO = : 
    ' * Copyright info window [BUG]
    ' * Info port open [MORE]
    ' * Options
    ' * Proxy
    ' * Other test
    ' * Ajouter une skin
    '*****************************

#Region "Default options"

    '=================Default options=======================

    '*==Log
    'show date in log
    Public showDate = True
    'keep result for each scan
    Public keepResult = False
    '*==Port
    'check port time out
    Public connectTimeOut = 10
    Public receiveTimeOut = 10
    Public sendTimeOut = 10
    'nb thraed max
    Public maxThread = 1000

#End Region

#Region "Port Scan Var"

    '=====================Port Scan Var==========================

    'port scan thread
    Dim pScanThread
    Dim pScanThreadEach
    'scan vars
    Public scanActive = False
    Public threadAvailable = False
    Public threadNb = 0
    'time var
    Dim dateNow As DateTime
    Dim dateScan = ""
    Dim timeScan = ""
    'server vars
    Dim serverIP = ""
    Dim srvPort1 = ""
    Dim srvPort2 = ""
    'events
    Dim sortEvent = False
    'result timer
    Dim waitMax = 500 'in millisec

#End Region

#Region "Port Scan Function"

    '=====================Port Scan Function==========================

    'start scan display
    Sub startScan()
        'set list sortable
        addListViewResult()
        'reset thread
        threadNb = 0
        'execution time
        dateNow = getNow()
        dateScan = getDate()
        timeScan = getTime()
        'Display progress bar
        InputScanProgress.Value = InputScanProgress.Minimum
        TxtSignature.Visible = False
        InputScanProgress.Visible = True
        'start Scan Process & update infos
        scanActive = True
        InputScanStart.Text = "Stop"
    End Sub

    'end scan display
    Sub endScan(ByVal showResult As Boolean)
        'if display result, wait the end of threads
        If showResult Then
            If waitMax < connectTimeOut Then waitMax = connectTimeOut
            If waitMax < receiveTimeOut Then waitMax = receiveTimeOut
            If waitMax < sendTimeOut Then waitMax = sendTimeOut
            Threading.Thread.Sleep(waitMax)
        End If
        'execution time
        setResult("Scanned", "in", ((DateTime.Now - dateNow).TotalMilliseconds / 1000) & " s")
        'scan is stoped var
        scanActive = False
        'restore display
        InputScanStart.Text = "Start"
        InputScanProgress.Visible = False
        TxtSignature.Visible = True
        'show result or reset
        If showResult Then
            'change height
            Me.Height = 445
            'enable menu
            MenuTabItemSaveLog.Enabled = True
            MenuTabItemClear.Enabled = True
        Else
            'change height
            Me.Height = 194
            'disable menu
            MenuTabItemSaveLog.Enabled = False
            MenuTabItemClear.Enabled = False
            ListViewResult.Items.Clear()
        End If
        'cleanning thread
        pScanThread.Abort()
    End Sub

    'reset scan display
    Sub resetScan()
        'reset backgrounds color
        InputScanPort1.BackColor = Color.White
        InputScanPort2.BackColor = Color.White
        InputScanIp.BackColor = Color.White
        MenuTabItemSaveLog.Enabled = False
        MenuTabItemClear.Enabled = False
        If Not keepResult Then
            ListViewResult.Items.Clear()
        End If
    End Sub

    'check ip format
    Function checkIp()
        'check IP value
        If IsValidIPAddress(InputScanIp.Text) = False Then
            InputScanIp.BackColor = Color.Red
            MsgBox("IP is not valid, should be 255.255.255.255 format", 0, "An error occured")
            Return False
        Else
            Return True
        End If
    End Function

    'check port format
    Function checkPort()
        'init Port values
        Dim portS = InputScanPort1.Text
        Dim portSint As Integer
        Dim portE = InputScanPort2.Text
        Dim portEint As Integer

        'check if port1 is an integer
        If Not Integer.TryParse(portS, portSint) Then
            InputScanPort1.BackColor = Color.Red
            MsgBox("Port start must be an integer", 0, "An error occured")
            Return False
        End If

        'check Port1 range values
        If portSint < 1 Or portSint > 65535 Then
            InputScanPort1.BackColor = Color.Red
            MsgBox("Port range must be between 1 to 65535", 0, "An error occured")
            Return False
        End If

        'check if port2 is an integer
        If Not Integer.TryParse(portE, portEint) Then
            InputScanPort2.BackColor = Color.Red
            MsgBox("Port end must be an integer", 0, "An error occured")
            Return False
        End If

        'check Port2 range values
        If portEint < 1 Or portEint > 65535 Then
            InputScanPort2.BackColor = Color.Red
            MsgBox("Port range must be between 1 to 65535", 0, "An error occured")
            Return False
        End If

        'check if Port1 > Port2
        If portSint > portEint Then
            InputScanPort1.BackColor = Color.Red
            InputScanPort2.BackColor = Color.Red
            MsgBox("Port startcannot be greater than end", 0, "An error occured")
            Return False
        End If

        Return True
    End Function

    'display a line in result list
    Sub setResult(ByVal IP, ByVal port, ByVal info)
        ListViewResult.Items.Add(New ListViewItem({IP, port, info}))
    End Sub

#End Region

#Region "Port Scan"

    '=====================Port Scan==========================

    'Start scan click
    Private Sub PortScanStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputScanStart.Click

        ' ** [ Case Stop Port Scan Process ] **
        'if scan is active, cancel scan
        If scanActive = True Then
            endScan(True)
            Exit Sub
        End If

        ' ** [ Case Start Port Scan Process ] **
        'reset display
        resetScan()

        'test ip format
        If Not checkIp() Then Exit Sub

        'test ports format
        If Not checkPort() Then Exit Sub

        '**All test passed ! Starting process
        startScan()

        'Start process
        pScanThread = New System.Threading.Thread(AddressOf testPort)
        pScanThread.Start()

    End Sub

    'start ports scan
    Sub testPort()
        Dim IP = InputScanIp.Text
        Dim portStart = InputScanPort1.Text
        Dim portEnd = InputScanPort2.Text

        'set global data
        serverIP = IP
        srvPort1 = portStart
        srvPort2 = portEnd

        'check ip connection
        Dim host As IPAddress
        Try
            host = Dns.GetHostEntry(IP).AddressList(0)
        Catch
            MsgBox("Cannot connect to " & IP, 0, "An error occured")
            endScan(True)
            Exit Sub
        End Try

        'set progress bar
        InputScanProgress.Minimum = portStart
        InputScanProgress.Maximum = portEnd

        'check each port
        For port As Integer = portStart To portEnd
            'increment thread amount
            Me.threadNb = Me.threadNb + 1
            'progressbar evolution
            InputScanProgress.Value = port
            'check each port
            Dim cp = New CheckPort(Me, IP, port)
            pScanThreadEach = New System.Threading.Thread(AddressOf cp.checkAPort)
            Call pScanThreadEach.Start()
            While Me.threadNb >= maxThread
                'Wait for available thread
            End While
        Next

        endScan(True)

    End Sub

#End Region

#Region "Global Function"

    '=====================Global Function==========================

    'check if IP is valid
    Public Function IsValidIPAddress(ByVal strIPAddress As String) As Boolean
        On Error GoTo Handler
        Dim varAddress As Object, n As Long, lCount As Long
        varAddress = Split(strIPAddress, ".", , vbTextCompare)
        If IsArray(varAddress) Then
            For n = LBound(varAddress) To UBound(varAddress)
                lCount = lCount + 1
                varAddress(n) = CByte(varAddress(n))
            Next
            IsValidIPAddress = (lCount = 4)
        End If
Handler:
    End Function

    'get current date
    Public Function getNow() As String
        getNow = DateTime.Now
    End Function

    'get current date
    Public Function getDate() As String
        getDate = dateNow.ToString("yyyy/M/d")
    End Function

    'get current time
    Public Function getTime() As String
        getTime = dateNow.ToString("hh:mm:ss")
    End Function

#End Region

#Region "Menu Function"

    '========================Menu Part=======================

    '====[FILE MENU]====

    '**Exit application
    Private Sub ExitMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTabItemExit.Click
        pScanThread.Abort()
        System.Environment.Exit(-1)
        System.Windows.Forms.Application.Exit()
        Close()
        End ' Visual Basic only
    End Sub

    '**Clear results
    Private Sub ClearResultsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTabItemClear.Click
        endScan(False)
    End Sub

    '**Save Log
    Private Sub SaveLogMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTabItemSaveLog.Click
        'as user for log filename
        Dim askFileName As New SaveFileDialog()
        askFileName.Filter = "log files (*.log)|*.log|txt files (*.txt)|*.txt|All files (*.*)|*.*"
        askFileName.FilterIndex = 1
        askFileName.RestoreDirectory = True
        askFileName.FileName = "result.log"
        'test if filename is given
        If askFileName.ShowDialog() = DialogResult.OK Then
            'create log file
            Dim logFile As String = askFileName.FileName
            Dim streamFile As New System.IO.StreamWriter(logFile, False)
            'add date if user asked for
            If showDate Then
                streamFile.WriteLine("[ " & dateScan & " " & timeScan & " ]")
                streamFile.WriteLine("")
            End If
            'add infos if result is unique
            If Not keepResult Then
                streamFile.WriteLine("Port scan " & serverIP & " from " & srvPort1 & " to " & srvPort2)
                streamFile.WriteLine("")
            End If
            'add result
            streamFile.WriteLine(ListViewResult.Columns(0).Text.PadRight(15) & " | " & ListViewResult.Columns(1).Text.PadRight(5) & " | " & ListViewResult.Columns(2).Text)
            streamFile.WriteLine("-----------------------------------------------------------------------------")
            Dim nb = ListViewResult.Items.Count
            For i = 0 To nb - 1
                streamFile.WriteLine(ListViewResult.Items(i).SubItems(0).Text().PadRight(15) & " | " & ListViewResult.Items(i).SubItems(1).Text().PadRight(5) & " | " & ListViewResult.Items(i).SubItems(2).Text())
            Next i
            'end file stream
            streamFile.Close()
        End If
    End Sub

    '====[OPTION MENU]====

    Private Sub OptionsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTabOptions.Click
        MsgBox("TODO : No implemented", 0, "@ Work !")
    End Sub

    '====[? MENU]====

    Private Sub MenuTabHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTabHelp.Click
        FroggAbout.Show()
    End Sub

#End Region

#Region "List View Events"

    'draw list view
    Sub addListViewResult()
        If Not sortEvent Then
            'set default sort
            Me.ListViewResult.Sorting = SortOrder.Ascending
            'set line selectable
            Me.ListViewResult.FullRowSelect = True
            'set type of display
            Me.ListViewResult.View = View.Details
            'set columns
            Me.ListViewResult.Columns.Add(New ColHeader("IP", 90, HorizontalAlignment.Left, True))
            Me.ListViewResult.Columns.Add(New ColHeader("Port", 50, HorizontalAlignment.Center, True))
            Me.ListViewResult.Columns.Add(New ColHeader("Information", 190, HorizontalAlignment.Left, True))
            'add sort event
            AddHandler Me.ListViewResult.ColumnClick, AddressOf ListViewResult_ColumnClick
            'event has been set 
            sortEvent = True
        End If
    End Sub

    'list view click
    Private Sub ListViewResult_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
        'disable sorting to prevent Cast exeption
        Me.ListViewResult.Sorting = SortOrder.None
        ' Create an instance of the ColHeader class.  
        Dim clickedCol As ColHeader = CType(Me.ListViewResult.Columns(e.Column), ColHeader)
        ' Set the ascending property to sort in the opposite order.
        clickedCol.ascending = Not clickedCol.ascending
        ' Get the number of items in the list. 
        Dim numItems As Integer = Me.ListViewResult.Items.Count
        ' Turn off display while data is repoplulated. 
        Me.ListViewResult.BeginUpdate()
        ' Populate an ArrayList with a SortWrapper of each list item. 
        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(Me.ListViewResult.Items(i), e.Column))
        Next i
        ' Sort the elements in the ArrayList using a new instance of the SortComparer 
        ' class. The parameters are the starting index, the length of the range to sort, 
        ' and the IComparer implementation to use for comparing elements. Note that 
        ' the IComparer implementation (SortComparer) requires the sort   
        ' direction for its constructor; true if ascending, othwise false.
        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))
        ' Clear the list, and repopulate with the sorted items. 
        Me.ListViewResult.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.ListViewResult.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z
        ' Turn display back on. 
        Me.ListViewResult.EndUpdate()
    End Sub

#End Region

End Class
