<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FroggSecurityChecker
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FroggSecurityChecker))
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.TabPortScan = New System.Windows.Forms.TabPage()
        Me.TxtSignature = New System.Windows.Forms.Label()
        Me.ImgFrogg = New System.Windows.Forms.PictureBox()
        Me.InputScanProgress = New System.Windows.Forms.ProgressBar()
        Me.TxtPortRange = New System.Windows.Forms.Label()
        Me.TxtPortScanIP = New System.Windows.Forms.Label()
        Me.InputScanStart = New System.Windows.Forms.Button()
        Me.InputScanPort1 = New System.Windows.Forms.TextBox()
        Me.InputScanPort2 = New System.Windows.Forms.TextBox()
        Me.InputScanIp = New System.Windows.Forms.TextBox()
        Me.TabTemp1 = New System.Windows.Forms.TabPage()
        Me.TabTemp2 = New System.Windows.Forms.TabPage()
        Me.MenuMain = New System.Windows.Forms.MenuStrip()
        Me.MenuTabFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTabItemSaveLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTabItemClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTabItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTabOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuTabHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListViewResult = New System.Windows.Forms.ListView()
        Me.TabMain.SuspendLayout()
        Me.TabPortScan.SuspendLayout()
        CType(Me.ImgFrogg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabPortScan)
        Me.TabMain.Controls.Add(Me.TabTemp1)
        Me.TabMain.Controls.Add(Me.TabTemp2)
        resources.ApplyResources(Me.TabMain, "TabMain")
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        '
        'TabPortScan
        '
        Me.TabPortScan.Controls.Add(Me.TxtSignature)
        Me.TabPortScan.Controls.Add(Me.ImgFrogg)
        Me.TabPortScan.Controls.Add(Me.InputScanProgress)
        Me.TabPortScan.Controls.Add(Me.TxtPortRange)
        Me.TabPortScan.Controls.Add(Me.TxtPortScanIP)
        Me.TabPortScan.Controls.Add(Me.InputScanStart)
        Me.TabPortScan.Controls.Add(Me.InputScanPort1)
        Me.TabPortScan.Controls.Add(Me.InputScanPort2)
        Me.TabPortScan.Controls.Add(Me.InputScanIp)
        resources.ApplyResources(Me.TabPortScan, "TabPortScan")
        Me.TabPortScan.Name = "TabPortScan"
        Me.TabPortScan.UseVisualStyleBackColor = True
        '
        'TxtSignature
        '
        resources.ApplyResources(Me.TxtSignature, "TxtSignature")
        Me.TxtSignature.ForeColor = System.Drawing.Color.OliveDrab
        Me.TxtSignature.Name = "TxtSignature"
        '
        'ImgFrogg
        '
        Me.ImgFrogg.Image = Global.FroggSecurityChecker.My.Resources.Resources._min_frogg1
        resources.ApplyResources(Me.ImgFrogg, "ImgFrogg")
        Me.ImgFrogg.Name = "ImgFrogg"
        Me.ImgFrogg.TabStop = False
        '
        'InputScanProgress
        '
        resources.ApplyResources(Me.InputScanProgress, "InputScanProgress")
        Me.InputScanProgress.Name = "InputScanProgress"
        '
        'TxtPortRange
        '
        resources.ApplyResources(Me.TxtPortRange, "TxtPortRange")
        Me.TxtPortRange.Name = "TxtPortRange"
        '
        'TxtPortScanIP
        '
        resources.ApplyResources(Me.TxtPortScanIP, "TxtPortScanIP")
        Me.TxtPortScanIP.Name = "TxtPortScanIP"
        '
        'InputScanStart
        '
        resources.ApplyResources(Me.InputScanStart, "InputScanStart")
        Me.InputScanStart.Name = "InputScanStart"
        Me.InputScanStart.UseVisualStyleBackColor = True
        '
        'InputScanPort1
        '
        resources.ApplyResources(Me.InputScanPort1, "InputScanPort1")
        Me.InputScanPort1.Name = "InputScanPort1"
        '
        'InputScanPort2
        '
        resources.ApplyResources(Me.InputScanPort2, "InputScanPort2")
        Me.InputScanPort2.Name = "InputScanPort2"
        '
        'InputScanIp
        '
        resources.ApplyResources(Me.InputScanIp, "InputScanIp")
        Me.InputScanIp.Name = "InputScanIp"
        '
        'TabTemp1
        '
        resources.ApplyResources(Me.TabTemp1, "TabTemp1")
        Me.TabTemp1.Name = "TabTemp1"
        Me.TabTemp1.UseVisualStyleBackColor = True
        '
        'TabTemp2
        '
        Me.TabTemp2.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.TabTemp2, "TabTemp2")
        Me.TabTemp2.Name = "TabTemp2"
        '
        'MenuMain
        '
        Me.MenuMain.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.MenuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuTabFile, Me.MenuTabOptions, Me.MenuTabHelp})
        resources.ApplyResources(Me.MenuMain, "MenuMain")
        Me.MenuMain.Name = "MenuMain"
        '
        'MenuTabFile
        '
        Me.MenuTabFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuTabItemSaveLog, Me.MenuTabItemClear, Me.MenuTabItemExit})
        Me.MenuTabFile.Name = "MenuTabFile"
        resources.ApplyResources(Me.MenuTabFile, "MenuTabFile")
        '
        'MenuTabItemSaveLog
        '
        resources.ApplyResources(Me.MenuTabItemSaveLog, "MenuTabItemSaveLog")
        Me.MenuTabItemSaveLog.Name = "MenuTabItemSaveLog"
        '
        'MenuTabItemClear
        '
        resources.ApplyResources(Me.MenuTabItemClear, "MenuTabItemClear")
        Me.MenuTabItemClear.Name = "MenuTabItemClear"
        '
        'MenuTabItemExit
        '
        Me.MenuTabItemExit.Name = "MenuTabItemExit"
        resources.ApplyResources(Me.MenuTabItemExit, "MenuTabItemExit")
        '
        'MenuTabOptions
        '
        Me.MenuTabOptions.Name = "MenuTabOptions"
        resources.ApplyResources(Me.MenuTabOptions, "MenuTabOptions")
        '
        'MenuTabHelp
        '
        Me.MenuTabHelp.Name = "MenuTabHelp"
        resources.ApplyResources(Me.MenuTabHelp, "MenuTabHelp")
        '
        'ListViewResult
        '
        resources.ApplyResources(Me.ListViewResult, "ListViewResult")
        Me.ListViewResult.Name = "ListViewResult"
        Me.ListViewResult.UseCompatibleStateImageBehavior = False
        '
        'FroggSecurityChecker
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListViewResult)
        Me.Controls.Add(Me.TabMain)
        Me.Controls.Add(Me.MenuMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuMain
        Me.MaximizeBox = False
        Me.Name = "FroggSecurityChecker"
        Me.TabMain.ResumeLayout(False)
        Me.TabPortScan.ResumeLayout(False)
        Me.TabPortScan.PerformLayout()
        CType(Me.ImgFrogg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuMain.ResumeLayout(False)
        Me.MenuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPortScan As System.Windows.Forms.TabPage
    Friend WithEvents InputScanProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents TxtPortRange As System.Windows.Forms.Label
    Friend WithEvents TxtPortScanIP As System.Windows.Forms.Label
    Friend WithEvents InputScanStart As System.Windows.Forms.Button
    Friend WithEvents InputScanPort1 As System.Windows.Forms.TextBox
    Friend WithEvents InputScanPort2 As System.Windows.Forms.TextBox
    Friend WithEvents InputScanIp As System.Windows.Forms.TextBox
    Friend WithEvents TabTemp1 As System.Windows.Forms.TabPage
    Friend WithEvents TabTemp2 As System.Windows.Forms.TabPage
    Friend WithEvents MenuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuTabFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTabItemSaveLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTabItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTabOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuTabHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImgFrogg As System.Windows.Forms.PictureBox
    Friend WithEvents TxtSignature As System.Windows.Forms.Label
    Friend WithEvents MenuTabItemClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListViewResult As System.Windows.Forms.ListView

End Class
