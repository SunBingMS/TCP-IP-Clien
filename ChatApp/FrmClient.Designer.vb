
Partial Public Class FrmClient
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClient))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.kscMain = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.tlpLeft = New System.Windows.Forms.TableLayoutPanel()
        Me.Navi = New ComponentFactory.Krypton.Navigator.KryptonNavigator()
        Me.KryptonPage1 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.tlpPage1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnShortcutStartMenu = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnStartMenu = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnMenu = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.BtnOGU00MenuHome = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.BtnWeZDB7Home = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.BtnMesgBoxHome = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.BtnResetFolder = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.BtnOGU00Menu = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.BtnWeZDB7 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.BtnMesgBox = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPage2 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.tlpPage2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAtena = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCommon = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCommonClient = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCommonServer = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnNyushi = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnGakuseika = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnKyomu = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnSyomu = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCarrier = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnKaikei = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnDaigakuin = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnHouka = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnTsushin = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnKokusai = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnExtension = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnKarte = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnShisetsu = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnKyosyokuin = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCommonTemplate = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnKaikeiHugeReports = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPage3 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.tlpPage3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCommonWebSV = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonPage4 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.tlpPage4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnTextBoxEx = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnDataGridViewEx = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnCmExcel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.tbMode = New ComponentFactory.Krypton.Toolkit.KryptonTrackBar()
        Me.Label1 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()
        Me.Label2 = New ComponentFactory.Krypton.Toolkit.KryptonWrapLabel()
        Me.tlpRight = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSend = New ComponentFactory.Krypton.Toolkit.KryptonDropButton()
        Me.kcmFace = New ComponentFactory.Krypton.Toolkit.KryptonContextMenu()
        Me.KryptonContextMenuImageSelect1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuImageSelect()
        Me.FaceList = New System.Windows.Forms.ImageList(Me.components)
        Me.tbInput = New System.Windows.Forms.TextBox()
        Me.btnClear = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.dgvConOut = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.TIME = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn()
        Me.USER = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn()
        Me.CONTENT = New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonContextMenuItems1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.timRetry = New System.Windows.Forms.Timer(Me.components)
        Me.KryptonContextMenuItems2 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuItem1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.KryptonManager = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.KryptonRibbon1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbon()
        Me.KryptonRibbonTab1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonTab()
        Me.KryptonRibbonGroup1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup()
        Me.KryptonRibbonGroupLines1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines()
        Me.KryptonRibbonGroupLabel2 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel()
        Me.txtFileServer = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox()
        Me.btnFileServerOK = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.btnFileServerReset = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonGroupLabel1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel()
        Me.txtChatServer = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox()
        Me.btnChatServerOK = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.btnChatServerReset = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonTab2 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonTab()
        Me.KryptonRibbonGroup2 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup()
        Me.KryptonRibbonGroupTriple1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple()
        Me.btnSQLConv = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        CType(Me.kscMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kscMain.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kscMain.Panel1.SuspendLayout()
        CType(Me.kscMain.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kscMain.Panel2.SuspendLayout()
        Me.kscMain.SuspendLayout()
        Me.tlpLeft.SuspendLayout()
        CType(Me.Navi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage1.SuspendLayout()
        Me.tlpPage1.SuspendLayout()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage2.SuspendLayout()
        Me.tlpPage2.SuspendLayout()
        CType(Me.KryptonPage3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage3.SuspendLayout()
        Me.tlpPage3.SuspendLayout()
        CType(Me.KryptonPage4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage4.SuspendLayout()
        Me.tlpPage4.SuspendLayout()
        Me.tlpRight.SuspendLayout()
        CType(Me.dgvConOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.KryptonRibbon1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'kscMain
        '
        Me.kscMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.kscMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kscMain.Location = New System.Drawing.Point(0, 115)
        Me.kscMain.Name = "kscMain"
        '
        'kscMain.Panel1
        '
        Me.kscMain.Panel1.Controls.Add(Me.tlpLeft)
        '
        'kscMain.Panel2
        '
        Me.kscMain.Panel2.Controls.Add(Me.tlpRight)
        Me.kscMain.Size = New System.Drawing.Size(642, 402)
        Me.kscMain.SplitterDistance = 348
        Me.kscMain.TabIndex = 0
        '
        'tlpLeft
        '
        Me.tlpLeft.BackColor = System.Drawing.Color.Transparent
        Me.tlpLeft.ColumnCount = 3
        Me.tlpLeft.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpLeft.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLeft.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tlpLeft.Controls.Add(Me.Navi, 0, 1)
        Me.tlpLeft.Controls.Add(Me.tbMode, 1, 0)
        Me.tlpLeft.Controls.Add(Me.Label1, 0, 0)
        Me.tlpLeft.Controls.Add(Me.Label2, 2, 0)
        Me.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpLeft.Location = New System.Drawing.Point(0, 0)
        Me.tlpLeft.Name = "tlpLeft"
        Me.tlpLeft.RowCount = 2
        Me.tlpLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.tlpLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLeft.Size = New System.Drawing.Size(348, 402)
        Me.tlpLeft.TabIndex = 0
        '
        'Navi
        '
        Me.tlpLeft.SetColumnSpan(Me.Navi, 3)
        Me.Navi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Navi.Location = New System.Drawing.Point(3, 45)
        Me.Navi.Name = "Navi"
        Me.Navi.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.StackCheckButtonGroup
        Me.Navi.Pages.AddRange(New ComponentFactory.Krypton.Navigator.KryptonPage() {Me.KryptonPage1, Me.KryptonPage2, Me.KryptonPage3, Me.KryptonPage4})
        Me.Navi.SelectedIndex = 1
        Me.Navi.Size = New System.Drawing.Size(342, 354)
        Me.Navi.TabIndex = 2
        Me.Navi.Text = "KryptonNavigator1"
        '
        'KryptonPage1
        '
        Me.KryptonPage1.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage1.Controls.Add(Me.tlpPage1)
        Me.KryptonPage1.Flags = 65534
        Me.KryptonPage1.LastVisibleSet = True
        Me.KryptonPage1.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage1.Name = "KryptonPage1"
        Me.KryptonPage1.Size = New System.Drawing.Size(340, 264)
        Me.KryptonPage1.Text = "SKB Main"
        Me.KryptonPage1.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage1.UniqueName = "D17CFC8B780A4311AAA3E9B4ACD064A1"
        '
        'tlpPage1
        '
        Me.tlpPage1.BackColor = System.Drawing.Color.AliceBlue
        Me.tlpPage1.ColumnCount = 6
        Me.tlpPage1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage1.Controls.Add(Me.btnShortcutStartMenu, 0, 0)
        Me.tlpPage1.Controls.Add(Me.btnStartMenu, 2, 0)
        Me.tlpPage1.Controls.Add(Me.btnMenu, 4, 0)
        Me.tlpPage1.Controls.Add(Me.BtnOGU00MenuHome, 1, 2)
        Me.tlpPage1.Controls.Add(Me.BtnWeZDB7Home, 3, 2)
        Me.tlpPage1.Controls.Add(Me.BtnMesgBoxHome, 1, 5)
        Me.tlpPage1.Controls.Add(Me.BtnResetFolder, 3, 5)
        Me.tlpPage1.Controls.Add(Me.BtnOGU00Menu, 1, 3)
        Me.tlpPage1.Controls.Add(Me.BtnWeZDB7, 3, 3)
        Me.tlpPage1.Controls.Add(Me.BtnMesgBox, 1, 6)
        Me.tlpPage1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPage1.Location = New System.Drawing.Point(0, 0)
        Me.tlpPage1.Name = "tlpPage1"
        Me.tlpPage1.RowCount = 8
        Me.tlpPage1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpPage1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPage1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpPage1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.tlpPage1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPage1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpPage1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.0!))
        Me.tlpPage1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPage1.Size = New System.Drawing.Size(340, 264)
        Me.tlpPage1.TabIndex = 1
        '
        'btnShortcutStartMenu
        '
        Me.tlpPage1.SetColumnSpan(Me.btnShortcutStartMenu, 2)
        Me.btnShortcutStartMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShortcutStartMenu.Location = New System.Drawing.Point(3, 3)
        Me.btnShortcutStartMenu.Name = "btnShortcutStartMenu"
        Me.btnShortcutStartMenu.Size = New System.Drawing.Size(106, 32)
        Me.btnShortcutStartMenu.TabIndex = 1
        Me.btnShortcutStartMenu.Values.Text = "ShortStartMenu"
        '
        'btnStartMenu
        '
        Me.tlpPage1.SetColumnSpan(Me.btnStartMenu, 2)
        Me.btnStartMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnStartMenu.Location = New System.Drawing.Point(115, 3)
        Me.btnStartMenu.Name = "btnStartMenu"
        Me.btnStartMenu.Size = New System.Drawing.Size(106, 32)
        Me.btnStartMenu.TabIndex = 2
        Me.btnStartMenu.Values.Text = "StartMenu"
        '
        'btnMenu
        '
        Me.tlpPage1.SetColumnSpan(Me.btnMenu, 2)
        Me.btnMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMenu.Location = New System.Drawing.Point(227, 3)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(110, 32)
        Me.btnMenu.TabIndex = 3
        Me.btnMenu.Values.Text = "Menu"
        '
        'BtnOGU00MenuHome
        '
        Me.tlpPage1.SetColumnSpan(Me.BtnOGU00MenuHome, 2)
        Me.BtnOGU00MenuHome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnOGU00MenuHome.Location = New System.Drawing.Point(59, 49)
        Me.BtnOGU00MenuHome.Name = "BtnOGU00MenuHome"
        Me.BtnOGU00MenuHome.Size = New System.Drawing.Size(106, 32)
        Me.BtnOGU00MenuHome.TabIndex = 4
        Me.BtnOGU00MenuHome.Values.Text = "事務システムHome"
        '
        'BtnWeZDB7Home
        '
        Me.tlpPage1.SetColumnSpan(Me.BtnWeZDB7Home, 2)
        Me.BtnWeZDB7Home.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnWeZDB7Home.Location = New System.Drawing.Point(171, 49)
        Me.BtnWeZDB7Home.Name = "BtnWeZDB7Home"
        Me.BtnWeZDB7Home.Size = New System.Drawing.Size(106, 32)
        Me.BtnWeZDB7Home.TabIndex = 6
        Me.BtnWeZDB7Home.Values.Text = "WeZDB7Home"
        '
        'BtnMesgBoxHome
        '
        Me.tlpPage1.SetColumnSpan(Me.BtnMesgBoxHome, 2)
        Me.BtnMesgBoxHome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnMesgBoxHome.Location = New System.Drawing.Point(59, 157)
        Me.BtnMesgBoxHome.Name = "BtnMesgBoxHome"
        Me.BtnMesgBoxHome.Size = New System.Drawing.Size(106, 32)
        Me.BtnMesgBoxHome.TabIndex = 8
        Me.BtnMesgBoxHome.Values.Text = "伝書箱Home"
        '
        'BtnResetFolder
        '
        Me.tlpPage1.SetColumnSpan(Me.BtnResetFolder, 2)
        Me.BtnResetFolder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnResetFolder.Location = New System.Drawing.Point(171, 157)
        Me.BtnResetFolder.Name = "BtnResetFolder"
        Me.tlpPage1.SetRowSpan(Me.BtnResetFolder, 2)
        Me.BtnResetFolder.Size = New System.Drawing.Size(106, 94)
        Me.BtnResetFolder.TabIndex = 0
        Me.BtnResetFolder.Values.Text = "リセットフォルダ"
        '
        'BtnOGU00Menu
        '
        Me.tlpPage1.SetColumnSpan(Me.BtnOGU00Menu, 2)
        Me.BtnOGU00Menu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnOGU00Menu.Location = New System.Drawing.Point(59, 87)
        Me.BtnOGU00Menu.Name = "BtnOGU00Menu"
        Me.BtnOGU00Menu.Size = New System.Drawing.Size(106, 56)
        Me.BtnOGU00Menu.TabIndex = 5
        Me.BtnOGU00Menu.Values.Text = "事務システム"
        '
        'BtnWeZDB7
        '
        Me.tlpPage1.SetColumnSpan(Me.BtnWeZDB7, 2)
        Me.BtnWeZDB7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnWeZDB7.Location = New System.Drawing.Point(171, 87)
        Me.BtnWeZDB7.Name = "BtnWeZDB7"
        Me.BtnWeZDB7.Size = New System.Drawing.Size(106, 56)
        Me.BtnWeZDB7.TabIndex = 7
        Me.BtnWeZDB7.Values.Text = "WeZDB7"
        '
        'BtnMesgBox
        '
        Me.tlpPage1.SetColumnSpan(Me.BtnMesgBox, 2)
        Me.BtnMesgBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnMesgBox.Location = New System.Drawing.Point(59, 195)
        Me.BtnMesgBox.Name = "BtnMesgBox"
        Me.BtnMesgBox.Size = New System.Drawing.Size(106, 56)
        Me.BtnMesgBox.TabIndex = 9
        Me.BtnMesgBox.Values.Text = "伝書箱"
        '
        'KryptonPage2
        '
        Me.KryptonPage2.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage2.Controls.Add(Me.tlpPage2)
        Me.KryptonPage2.Flags = 65534
        Me.KryptonPage2.LastVisibleSet = True
        Me.KryptonPage2.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage2.Name = "KryptonPage2"
        Me.KryptonPage2.Size = New System.Drawing.Size(340, 264)
        Me.KryptonPage2.Text = "Jim System"
        Me.KryptonPage2.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage2.UniqueName = "75E3B8AF26BB4EFA608D8B19B7409988"
        '
        'tlpPage2
        '
        Me.tlpPage2.BackColor = System.Drawing.Color.AliceBlue
        Me.tlpPage2.ColumnCount = 6
        Me.tlpPage2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.tlpPage2.Controls.Add(Me.btnAtena, 0, 8)
        Me.tlpPage2.Controls.Add(Me.btnCommon, 0, 0)
        Me.tlpPage2.Controls.Add(Me.btnCommonClient, 2, 0)
        Me.tlpPage2.Controls.Add(Me.btnCommonServer, 4, 0)
        Me.tlpPage2.Controls.Add(Me.btnNyushi, 0, 2)
        Me.tlpPage2.Controls.Add(Me.btnGakuseika, 4, 2)
        Me.tlpPage2.Controls.Add(Me.btnKyomu, 2, 2)
        Me.tlpPage2.Controls.Add(Me.btnSyomu, 0, 3)
        Me.tlpPage2.Controls.Add(Me.btnCarrier, 2, 3)
        Me.tlpPage2.Controls.Add(Me.btnKaikei, 4, 3)
        Me.tlpPage2.Controls.Add(Me.btnDaigakuin, 0, 4)
        Me.tlpPage2.Controls.Add(Me.btnHouka, 2, 4)
        Me.tlpPage2.Controls.Add(Me.btnTsushin, 4, 4)
        Me.tlpPage2.Controls.Add(Me.btnKokusai, 0, 5)
        Me.tlpPage2.Controls.Add(Me.btnExtension, 2, 5)
        Me.tlpPage2.Controls.Add(Me.btnKarte, 0, 7)
        Me.tlpPage2.Controls.Add(Me.btnShisetsu, 2, 7)
        Me.tlpPage2.Controls.Add(Me.btnKyosyokuin, 4, 7)
        Me.tlpPage2.Controls.Add(Me.btnCommonTemplate, 4, 5)
        Me.tlpPage2.Controls.Add(Me.btnKaikeiHugeReports, 4, 8)
        Me.tlpPage2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPage2.Location = New System.Drawing.Point(0, 0)
        Me.tlpPage2.Name = "tlpPage2"
        Me.tlpPage2.RowCount = 9
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.tlpPage2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572!))
        Me.tlpPage2.Size = New System.Drawing.Size(340, 264)
        Me.tlpPage2.TabIndex = 2
        '
        'btnAtena
        '
        Me.tlpPage2.SetColumnSpan(Me.btnAtena, 2)
        Me.btnAtena.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAtena.Location = New System.Drawing.Point(3, 229)
        Me.btnAtena.Name = "btnAtena"
        Me.btnAtena.Size = New System.Drawing.Size(106, 32)
        Me.btnAtena.TabIndex = 19
        Me.btnAtena.Values.Text = "54宛名ﾗﾍﾞﾙDLL"
        '
        'btnCommon
        '
        Me.tlpPage2.SetColumnSpan(Me.btnCommon, 2)
        Me.btnCommon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCommon.Location = New System.Drawing.Point(3, 3)
        Me.btnCommon.Name = "btnCommon"
        Me.btnCommon.Size = New System.Drawing.Size(106, 29)
        Me.btnCommon.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCommon.StateCommon.Back.Color2 = System.Drawing.Color.Lime
        Me.btnCommon.TabIndex = 1
        Me.btnCommon.Values.Text = "Common"
        '
        'btnCommonClient
        '
        Me.tlpPage2.SetColumnSpan(Me.btnCommonClient, 2)
        Me.btnCommonClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCommonClient.Location = New System.Drawing.Point(115, 3)
        Me.btnCommonClient.Name = "btnCommonClient"
        Me.btnCommonClient.Size = New System.Drawing.Size(106, 29)
        Me.btnCommonClient.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCommonClient.StateCommon.Back.Color2 = System.Drawing.Color.Lime
        Me.btnCommonClient.TabIndex = 2
        Me.btnCommonClient.Values.Text = "CommonClient"
        '
        'btnCommonServer
        '
        Me.tlpPage2.SetColumnSpan(Me.btnCommonServer, 2)
        Me.btnCommonServer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCommonServer.Location = New System.Drawing.Point(227, 3)
        Me.btnCommonServer.Name = "btnCommonServer"
        Me.btnCommonServer.Size = New System.Drawing.Size(110, 29)
        Me.btnCommonServer.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCommonServer.StateCommon.Back.Color2 = System.Drawing.Color.Lime
        Me.btnCommonServer.TabIndex = 3
        Me.btnCommonServer.Values.Text = "CommonServer"
        '
        'btnNyushi
        '
        Me.tlpPage2.SetColumnSpan(Me.btnNyushi, 2)
        Me.btnNyushi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNyushi.Location = New System.Drawing.Point(3, 46)
        Me.btnNyushi.Name = "btnNyushi"
        Me.btnNyushi.Size = New System.Drawing.Size(106, 29)
        Me.btnNyushi.TabIndex = 4
        Me.btnNyushi.Values.Text = "01入試DLL"
        '
        'btnGakuseika
        '
        Me.tlpPage2.SetColumnSpan(Me.btnGakuseika, 2)
        Me.btnGakuseika.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGakuseika.Location = New System.Drawing.Point(227, 46)
        Me.btnGakuseika.Name = "btnGakuseika"
        Me.btnGakuseika.Size = New System.Drawing.Size(110, 29)
        Me.btnGakuseika.TabIndex = 6
        Me.btnGakuseika.Values.Text = "03学生課DLL"
        '
        'btnKyomu
        '
        Me.tlpPage2.SetColumnSpan(Me.btnKyomu, 2)
        Me.btnKyomu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKyomu.Location = New System.Drawing.Point(115, 46)
        Me.btnKyomu.Name = "btnKyomu"
        Me.btnKyomu.Size = New System.Drawing.Size(106, 29)
        Me.btnKyomu.TabIndex = 5
        Me.btnKyomu.Values.Text = "02教務課DLL"
        '
        'btnSyomu
        '
        Me.tlpPage2.SetColumnSpan(Me.btnSyomu, 2)
        Me.btnSyomu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSyomu.Location = New System.Drawing.Point(3, 81)
        Me.btnSyomu.Name = "btnSyomu"
        Me.btnSyomu.Size = New System.Drawing.Size(106, 29)
        Me.btnSyomu.TabIndex = 7
        Me.btnSyomu.Values.Text = "04庶務課DLL"
        '
        'btnCarrier
        '
        Me.tlpPage2.SetColumnSpan(Me.btnCarrier, 2)
        Me.btnCarrier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCarrier.Location = New System.Drawing.Point(115, 81)
        Me.btnCarrier.Name = "btnCarrier"
        Me.btnCarrier.Size = New System.Drawing.Size(106, 29)
        Me.btnCarrier.TabIndex = 8
        Me.btnCarrier.Values.Text = "05ｷｬﾘｱｾﾝﾀｰDLL"
        '
        'btnKaikei
        '
        Me.tlpPage2.SetColumnSpan(Me.btnKaikei, 2)
        Me.btnKaikei.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKaikei.Location = New System.Drawing.Point(227, 81)
        Me.btnKaikei.Name = "btnKaikei"
        Me.btnKaikei.Size = New System.Drawing.Size(110, 29)
        Me.btnKaikei.TabIndex = 9
        Me.btnKaikei.Values.Text = "06会計課DLL"
        '
        'btnDaigakuin
        '
        Me.tlpPage2.SetColumnSpan(Me.btnDaigakuin, 2)
        Me.btnDaigakuin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDaigakuin.Location = New System.Drawing.Point(3, 116)
        Me.btnDaigakuin.Name = "btnDaigakuin"
        Me.btnDaigakuin.Size = New System.Drawing.Size(106, 29)
        Me.btnDaigakuin.TabIndex = 10
        Me.btnDaigakuin.Values.Text = "07大学院DLL"
        '
        'btnHouka
        '
        Me.tlpPage2.SetColumnSpan(Me.btnHouka, 2)
        Me.btnHouka.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHouka.Location = New System.Drawing.Point(115, 116)
        Me.btnHouka.Name = "btnHouka"
        Me.btnHouka.Size = New System.Drawing.Size(106, 29)
        Me.btnHouka.TabIndex = 11
        Me.btnHouka.Values.Text = "08法科大学院DLL"
        '
        'btnTsushin
        '
        Me.tlpPage2.SetColumnSpan(Me.btnTsushin, 2)
        Me.btnTsushin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTsushin.Location = New System.Drawing.Point(227, 116)
        Me.btnTsushin.Name = "btnTsushin"
        Me.btnTsushin.Size = New System.Drawing.Size(110, 29)
        Me.btnTsushin.TabIndex = 12
        Me.btnTsushin.Values.Text = "09通信教育部DLL"
        '
        'btnKokusai
        '
        Me.tlpPage2.SetColumnSpan(Me.btnKokusai, 2)
        Me.btnKokusai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKokusai.Location = New System.Drawing.Point(3, 151)
        Me.btnKokusai.Name = "btnKokusai"
        Me.btnKokusai.Size = New System.Drawing.Size(106, 29)
        Me.btnKokusai.TabIndex = 13
        Me.btnKokusai.Values.Text = "10国際ｾﾝﾀｰDLL"
        '
        'btnExtension
        '
        Me.tlpPage2.SetColumnSpan(Me.btnExtension, 2)
        Me.btnExtension.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExtension.Location = New System.Drawing.Point(115, 151)
        Me.btnExtension.Name = "btnExtension"
        Me.btnExtension.Size = New System.Drawing.Size(106, 29)
        Me.btnExtension.TabIndex = 14
        Me.btnExtension.Values.Text = "11ｴｸｽﾃﾝｼｮﾝｾﾝﾀｰDLL"
        '
        'btnKarte
        '
        Me.tlpPage2.SetColumnSpan(Me.btnKarte, 2)
        Me.btnKarte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKarte.Location = New System.Drawing.Point(3, 194)
        Me.btnKarte.Name = "btnKarte"
        Me.btnKarte.Size = New System.Drawing.Size(106, 29)
        Me.btnKarte.TabIndex = 16
        Me.btnKarte.Values.Text = "51学生ｶﾙﾃDLL"
        '
        'btnShisetsu
        '
        Me.tlpPage2.SetColumnSpan(Me.btnShisetsu, 2)
        Me.btnShisetsu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnShisetsu.Location = New System.Drawing.Point(115, 194)
        Me.btnShisetsu.Name = "btnShisetsu"
        Me.btnShisetsu.Size = New System.Drawing.Size(106, 29)
        Me.btnShisetsu.TabIndex = 17
        Me.btnShisetsu.Values.Text = "52施設情報管理DLL"
        '
        'btnKyosyokuin
        '
        Me.tlpPage2.SetColumnSpan(Me.btnKyosyokuin, 2)
        Me.btnKyosyokuin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKyosyokuin.Location = New System.Drawing.Point(227, 194)
        Me.btnKyosyokuin.Name = "btnKyosyokuin"
        Me.btnKyosyokuin.Size = New System.Drawing.Size(110, 29)
        Me.btnKyosyokuin.TabIndex = 18
        Me.btnKyosyokuin.Values.Text = "53教職員情報管理DLL"
        '
        'btnCommonTemplate
        '
        Me.tlpPage2.SetColumnSpan(Me.btnCommonTemplate, 2)
        Me.btnCommonTemplate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCommonTemplate.Location = New System.Drawing.Point(227, 151)
        Me.btnCommonTemplate.Name = "btnCommonTemplate"
        Me.btnCommonTemplate.Size = New System.Drawing.Size(110, 29)
        Me.btnCommonTemplate.StateCommon.Back.Color1 = System.Drawing.Color.Goldenrod
        Me.btnCommonTemplate.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCommonTemplate.TabIndex = 15
        Me.btnCommonTemplate.Values.Text = "Template"
        '
        'btnKaikeiHugeReports
        '
        Me.tlpPage2.SetColumnSpan(Me.btnKaikeiHugeReports, 2)
        Me.btnKaikeiHugeReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKaikeiHugeReports.Location = New System.Drawing.Point(227, 229)
        Me.btnKaikeiHugeReports.Name = "btnKaikeiHugeReports"
        Me.btnKaikeiHugeReports.Size = New System.Drawing.Size(110, 32)
        Me.btnKaikeiHugeReports.StateCommon.Back.Color1 = System.Drawing.Color.Red
        Me.btnKaikeiHugeReports.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnKaikeiHugeReports.TabIndex = 10
        Me.btnKaikeiHugeReports.Values.Text = "会計課専用EXE"
        '
        'KryptonPage3
        '
        Me.KryptonPage3.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage3.Controls.Add(Me.tlpPage3)
        Me.KryptonPage3.Flags = 65534
        Me.KryptonPage3.LastVisibleSet = True
        Me.KryptonPage3.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage3.Name = "KryptonPage3"
        Me.KryptonPage3.Size = New System.Drawing.Size(321, 284)
        Me.KryptonPage3.Text = "Web Service"
        Me.KryptonPage3.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage3.UniqueName = "F907BCE41B304850469AF4402BDE5CA5"
        '
        'tlpPage3
        '
        Me.tlpPage3.BackColor = System.Drawing.Color.AliceBlue
        Me.tlpPage3.ColumnCount = 2
        Me.tlpPage3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPage3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPage3.Controls.Add(Me.btnCommonWebSV, 0, 0)
        Me.tlpPage3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPage3.Location = New System.Drawing.Point(0, 0)
        Me.tlpPage3.Name = "tlpPage3"
        Me.tlpPage3.RowCount = 6
        Me.tlpPage3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPage3.Size = New System.Drawing.Size(321, 284)
        Me.tlpPage3.TabIndex = 3
        '
        'btnCommonWebSV
        '
        Me.tlpPage3.SetColumnSpan(Me.btnCommonWebSV, 2)
        Me.btnCommonWebSV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCommonWebSV.Location = New System.Drawing.Point(3, 3)
        Me.btnCommonWebSV.Name = "btnCommonWebSV"
        Me.btnCommonWebSV.Size = New System.Drawing.Size(315, 49)
        Me.btnCommonWebSV.TabIndex = 1
        Me.btnCommonWebSV.Values.Text = "CommonWebSV"
        '
        'KryptonPage4
        '
        Me.KryptonPage4.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage4.Controls.Add(Me.tlpPage4)
        Me.KryptonPage4.Flags = 65534
        Me.KryptonPage4.LastVisibleSet = True
        Me.KryptonPage4.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage4.Name = "KryptonPage4"
        Me.KryptonPage4.Size = New System.Drawing.Size(321, 284)
        Me.KryptonPage4.Text = "Customized DLL"
        Me.KryptonPage4.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage4.UniqueName = "3EA55B3B9AC247AFD7A4C49F075AD129"
        '
        'tlpPage4
        '
        Me.tlpPage4.BackColor = System.Drawing.Color.AliceBlue
        Me.tlpPage4.ColumnCount = 1
        Me.tlpPage4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpPage4.Controls.Add(Me.btnTextBoxEx, 0, 0)
        Me.tlpPage4.Controls.Add(Me.btnDataGridViewEx, 0, 1)
        Me.tlpPage4.Controls.Add(Me.btnCmExcel, 0, 2)
        Me.tlpPage4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPage4.Location = New System.Drawing.Point(0, 0)
        Me.tlpPage4.Name = "tlpPage4"
        Me.tlpPage4.RowCount = 6
        Me.tlpPage4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpPage4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpPage4.Size = New System.Drawing.Size(321, 284)
        Me.tlpPage4.TabIndex = 4
        '
        'btnTextBoxEx
        '
        Me.btnTextBoxEx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTextBoxEx.Location = New System.Drawing.Point(3, 3)
        Me.btnTextBoxEx.Name = "btnTextBoxEx"
        Me.btnTextBoxEx.Size = New System.Drawing.Size(315, 49)
        Me.btnTextBoxEx.TabIndex = 1
        Me.btnTextBoxEx.Values.Text = "TextBoxEx"
        '
        'btnDataGridViewEx
        '
        Me.btnDataGridViewEx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDataGridViewEx.Location = New System.Drawing.Point(3, 58)
        Me.btnDataGridViewEx.Name = "btnDataGridViewEx"
        Me.btnDataGridViewEx.Size = New System.Drawing.Size(315, 49)
        Me.btnDataGridViewEx.TabIndex = 2
        Me.btnDataGridViewEx.Values.Text = "DataGridViewEx"
        '
        'btnCmExcel
        '
        Me.btnCmExcel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCmExcel.Location = New System.Drawing.Point(3, 113)
        Me.btnCmExcel.Name = "btnCmExcel"
        Me.btnCmExcel.Size = New System.Drawing.Size(315, 49)
        Me.btnCmExcel.TabIndex = 3
        Me.btnCmExcel.Values.Text = "cmExcel"
        '
        'tbMode
        '
        Me.tbMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMode.DrawBackground = True
        Me.tbMode.Location = New System.Drawing.Point(83, 3)
        Me.tbMode.Maximum = 1
        Me.tbMode.Name = "tbMode"
        Me.tbMode.Size = New System.Drawing.Size(182, 36)
        Me.tbMode.TabIndex = 1
        Me.tbMode.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.tbMode.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Large
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.LawnGreen
        Me.Label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl
        Me.Label1.Location = New System.Drawing.Point(15, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.StateCommon.TextColor = System.Drawing.Color.LawnGreen
        Me.Label1.Text = "Local Test"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl
        Me.Label2.Location = New System.Drawing.Point(271, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 10, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.StateCommon.TextColor = System.Drawing.Color.OrangeRed
        Me.Label2.Text = "Release"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tlpRight
        '
        Me.tlpRight.BackColor = System.Drawing.Color.Transparent
        Me.tlpRight.ColumnCount = 3
        Me.tlpRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpRight.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpRight.Controls.Add(Me.btnSend, 1, 1)
        Me.tlpRight.Controls.Add(Me.tbInput, 0, 1)
        Me.tlpRight.Controls.Add(Me.btnClear, 2, 1)
        Me.tlpRight.Controls.Add(Me.dgvConOut, 0, 0)
        Me.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpRight.Location = New System.Drawing.Point(0, 0)
        Me.tlpRight.Name = "tlpRight"
        Me.tlpRight.RowCount = 2
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpRight.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpRight.Size = New System.Drawing.Size(289, 402)
        Me.tlpRight.TabIndex = 1
        '
        'btnSend
        '
        Me.btnSend.AutoSize = True
        Me.btnSend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSend.DropDownOrientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Top
        Me.btnSend.KryptonContextMenu = Me.kcmFace
        Me.btnSend.Location = New System.Drawing.Point(169, 348)
        Me.btnSend.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(66, 54)
        Me.btnSend.StateCommon.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.btnSend.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle
        Me.btnSend.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.btnSend.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnSend.StateCommon.Border.Image = CType(resources.GetObject("btnSend.StateCommon.Border.Image"), System.Drawing.Image)
        Me.btnSend.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle
        Me.btnSend.TabIndex = 2
        Me.btnSend.Values.Image = CType(resources.GetObject("btnSend.Values.Image"), System.Drawing.Image)
        Me.btnSend.Values.ImageStates.ImageCheckedNormal = Nothing
        Me.btnSend.Values.ImageStates.ImageCheckedPressed = Nothing
        Me.btnSend.Values.ImageStates.ImageCheckedTracking = Nothing
        Me.btnSend.Values.ImageStates.ImagePressed = CType(resources.GetObject("btnSend.Values.ImageStates.ImagePressed"), System.Drawing.Image)
        Me.btnSend.Values.Text = ""
        '
        'kcmFace
        '
        Me.kcmFace.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuImageSelect1})
        '
        'KryptonContextMenuImageSelect1
        '
        Me.KryptonContextMenuImageSelect1.ImageIndexEnd = 53
        Me.KryptonContextMenuImageSelect1.ImageIndexStart = 0
        Me.KryptonContextMenuImageSelect1.ImageList = Me.FaceList
        Me.KryptonContextMenuImageSelect1.LineItems = 10
        '
        'FaceList
        '
        Me.FaceList.ImageStream = CType(resources.GetObject("FaceList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.FaceList.TransparentColor = System.Drawing.Color.Transparent
        Me.FaceList.Images.SetKeyName(0, "face01.png")
        Me.FaceList.Images.SetKeyName(1, "face02.png")
        Me.FaceList.Images.SetKeyName(2, "face03.png")
        Me.FaceList.Images.SetKeyName(3, "face04.png")
        Me.FaceList.Images.SetKeyName(4, "face05.png")
        Me.FaceList.Images.SetKeyName(5, "face06.png")
        Me.FaceList.Images.SetKeyName(6, "face07.png")
        Me.FaceList.Images.SetKeyName(7, "face08.png")
        Me.FaceList.Images.SetKeyName(8, "face09.png")
        Me.FaceList.Images.SetKeyName(9, "face10.png")
        Me.FaceList.Images.SetKeyName(10, "face11.png")
        Me.FaceList.Images.SetKeyName(11, "face12.png")
        Me.FaceList.Images.SetKeyName(12, "face13.png")
        Me.FaceList.Images.SetKeyName(13, "face14.png")
        Me.FaceList.Images.SetKeyName(14, "face15.png")
        Me.FaceList.Images.SetKeyName(15, "face16.png")
        Me.FaceList.Images.SetKeyName(16, "face17.png")
        Me.FaceList.Images.SetKeyName(17, "face18.png")
        Me.FaceList.Images.SetKeyName(18, "face19.png")
        Me.FaceList.Images.SetKeyName(19, "face20.png")
        Me.FaceList.Images.SetKeyName(20, "face21.png")
        Me.FaceList.Images.SetKeyName(21, "face22.png")
        Me.FaceList.Images.SetKeyName(22, "face23.png")
        Me.FaceList.Images.SetKeyName(23, "face24.png")
        Me.FaceList.Images.SetKeyName(24, "face25.png")
        Me.FaceList.Images.SetKeyName(25, "face26.png")
        Me.FaceList.Images.SetKeyName(26, "face27.png")
        Me.FaceList.Images.SetKeyName(27, "face28.png")
        Me.FaceList.Images.SetKeyName(28, "face29.png")
        Me.FaceList.Images.SetKeyName(29, "face30.png")
        Me.FaceList.Images.SetKeyName(30, "face31.png")
        Me.FaceList.Images.SetKeyName(31, "face32.png")
        Me.FaceList.Images.SetKeyName(32, "face33.png")
        Me.FaceList.Images.SetKeyName(33, "face34.png")
        Me.FaceList.Images.SetKeyName(34, "face35.png")
        Me.FaceList.Images.SetKeyName(35, "face36.png")
        Me.FaceList.Images.SetKeyName(36, "face37.png")
        Me.FaceList.Images.SetKeyName(37, "face38.png")
        Me.FaceList.Images.SetKeyName(38, "face39.png")
        Me.FaceList.Images.SetKeyName(39, "face40.png")
        Me.FaceList.Images.SetKeyName(40, "face41.png")
        Me.FaceList.Images.SetKeyName(41, "face42.png")
        Me.FaceList.Images.SetKeyName(42, "face43.png")
        Me.FaceList.Images.SetKeyName(43, "face44.png")
        Me.FaceList.Images.SetKeyName(44, "face45.png")
        Me.FaceList.Images.SetKeyName(45, "face46.png")
        Me.FaceList.Images.SetKeyName(46, "face47.png")
        Me.FaceList.Images.SetKeyName(47, "face48.png")
        Me.FaceList.Images.SetKeyName(48, "face49.png")
        Me.FaceList.Images.SetKeyName(49, "face50.png")
        Me.FaceList.Images.SetKeyName(50, "face51.png")
        Me.FaceList.Images.SetKeyName(51, "face52.png")
        Me.FaceList.Images.SetKeyName(52, "face53.png")
        Me.FaceList.Images.SetKeyName(53, "face54.png")
        '
        'tbInput
        '
        Me.tbInput.BackColor = System.Drawing.SystemColors.Window
        Me.tbInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbInput.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.tbInput.Location = New System.Drawing.Point(3, 348)
        Me.tbInput.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.tbInput.Multiline = True
        Me.tbInput.Name = "tbInput"
        Me.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbInput.Size = New System.Drawing.Size(163, 51)
        Me.tbInput.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.AutoSize = True
        Me.btnClear.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClear.Location = New System.Drawing.Point(235, 348)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(54, 54)
        Me.btnClear.StateCommon.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.btnClear.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.[False]
        Me.btnClear.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
            Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Values.Image = CType(resources.GetObject("btnClear.Values.Image"), System.Drawing.Image)
        Me.btnClear.Values.ImageStates.ImageCheckedNormal = Nothing
        Me.btnClear.Values.ImageStates.ImageCheckedPressed = Nothing
        Me.btnClear.Values.ImageStates.ImageCheckedTracking = Nothing
        Me.btnClear.Values.ImageStates.ImagePressed = CType(resources.GetObject("btnClear.Values.ImageStates.ImagePressed"), System.Drawing.Image)
        Me.btnClear.Values.Text = ""
        '
        'dgvConOut
        '
        Me.dgvConOut.AllowUserToAddRows = False
        Me.dgvConOut.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray
        Me.dgvConOut.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvConOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvConOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConOut.ColumnHeadersVisible = False
        Me.dgvConOut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TIME, Me.USER, Me.CONTENT})
        Me.tlpRight.SetColumnSpan(Me.dgvConOut, 3)
        Me.dgvConOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConOut.Location = New System.Drawing.Point(3, 3)
        Me.dgvConOut.MultiSelect = False
        Me.dgvConOut.Name = "dgvConOut"
        Me.dgvConOut.ReadOnly = True
        Me.dgvConOut.RowHeadersVisible = False
        Me.dgvConOut.RowTemplate.Height = 21
        Me.dgvConOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvConOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConOut.Size = New System.Drawing.Size(283, 342)
        Me.dgvConOut.StateCommon.Background.Color1 = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.dgvConOut.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList
        Me.dgvConOut.TabIndex = 0
        Me.dgvConOut.TabStop = False
        '
        'TIME
        '
        Me.TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.TIME.DefaultCellStyle = DataGridViewCellStyle6
        Me.TIME.HeaderText = "TIME"
        Me.TIME.Name = "TIME"
        Me.TIME.ReadOnly = True
        Me.TIME.Width = 60
        '
        'USER
        '
        Me.USER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.USER.DefaultCellStyle = DataGridViewCellStyle7
        Me.USER.HeaderText = "USER"
        Me.USER.Name = "USER"
        Me.USER.ReadOnly = True
        Me.USER.Width = 80
        '
        'CONTENT
        '
        Me.CONTENT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CONTENT.DefaultCellStyle = DataGridViewCellStyle8
        Me.CONTENT.HeaderText = "CONTENT"
        Me.CONTENT.Name = "CONTENT"
        Me.CONTENT.ReadOnly = True
        Me.CONTENT.Width = 142
        '
        'NotifyIcon
        '
        Me.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "S.K.Bくん"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.ToolStripMenuItem2})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(128, 54)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Checked = True
        Me.ToolStripMenuItem1.CheckOnClick = True
        Me.ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(127, 22)
        Me.ToolStripMenuItem1.Text = "Auto Start"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(124, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(127, 22)
        Me.ToolStripMenuItem2.Text = "Close"
        '
        'timRetry
        '
        Me.timRetry.Interval = 300000
        '
        'KryptonContextMenuItem1
        '
        Me.KryptonContextMenuItem1.Text = "Menu Item"
        '
        'KryptonManager
        '
        Me.KryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.SparkleBlue
        '
        'KryptonRibbon1
        '
        Me.KryptonRibbon1.AllowFormIntegrate = False
        Me.KryptonRibbon1.InDesignHelperMode = False
        Me.KryptonRibbon1.MinimizedMode = True
        Me.KryptonRibbon1.Name = "KryptonRibbon1"
        Me.KryptonRibbon1.QATLocation = ComponentFactory.Krypton.Ribbon.QATLocation.Hidden
        Me.KryptonRibbon1.QATUserChange = False
        Me.KryptonRibbon1.RibbonAppButton.AppButtonShowRecentDocs = False
        Me.KryptonRibbon1.RibbonAppButton.AppButtonVisible = False
        Me.KryptonRibbon1.RibbonTabs.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonTab() {Me.KryptonRibbonTab1, Me.KryptonRibbonTab2})
        Me.KryptonRibbon1.SelectedContext = Nothing
        Me.KryptonRibbon1.SelectedTab = Me.KryptonRibbonTab1
        Me.KryptonRibbon1.Size = New System.Drawing.Size(642, 115)
        Me.KryptonRibbon1.TabIndex = 1
        '
        'KryptonRibbonTab1
        '
        Me.KryptonRibbonTab1.Groups.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup() {Me.KryptonRibbonGroup1})
        Me.KryptonRibbonTab1.KeyTip = "設定"
        Me.KryptonRibbonTab1.Text = "Option"
        '
        'KryptonRibbonGroup1
        '
        Me.KryptonRibbonGroup1.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer() {Me.KryptonRibbonGroupLines1})
        Me.KryptonRibbonGroup1.TextLine1 = "Network"
        '
        'KryptonRibbonGroupLines1
        '
        Me.KryptonRibbonGroupLines1.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem() {Me.KryptonRibbonGroupLabel2, Me.txtFileServer, Me.btnFileServerOK, Me.btnFileServerReset, Me.KryptonRibbonGroupLabel1, Me.txtChatServer, Me.btnChatServerOK, Me.btnChatServerReset})
        '
        'KryptonRibbonGroupLabel2
        '
        Me.KryptonRibbonGroupLabel2.TextLine1 = "File Server Name/IP  :"
        '
        'txtFileServer
        '
        Me.txtFileServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFileServer.MaxLength = 100
        Me.txtFileServer.Text = "JIMDB1"
        '
        'btnFileServerOK
        '
        Me.btnFileServerOK.ImageLarge = CType(resources.GetObject("btnFileServerOK.ImageLarge"), System.Drawing.Image)
        Me.btnFileServerOK.ImageSmall = CType(resources.GetObject("btnFileServerOK.ImageSmall"), System.Drawing.Image)
        Me.btnFileServerOK.TextLine1 = "確定"
        '
        'btnFileServerReset
        '
        Me.btnFileServerReset.ImageLarge = CType(resources.GetObject("btnFileServerReset.ImageLarge"), System.Drawing.Image)
        Me.btnFileServerReset.ImageSmall = CType(resources.GetObject("btnFileServerReset.ImageSmall"), System.Drawing.Image)
        Me.btnFileServerReset.TextLine1 = "リセット"
        '
        'KryptonRibbonGroupLabel1
        '
        Me.KryptonRibbonGroupLabel1.TextLine1 = "Chat Server Name/IP:"
        '
        'txtChatServer
        '
        Me.txtChatServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChatServer.MaxLength = 100
        Me.txtChatServer.Text = "192.168.1.30"
        '
        'btnChatServerOK
        '
        Me.btnChatServerOK.ImageLarge = CType(resources.GetObject("btnChatServerOK.ImageLarge"), System.Drawing.Image)
        Me.btnChatServerOK.ImageSmall = CType(resources.GetObject("btnChatServerOK.ImageSmall"), System.Drawing.Image)
        Me.btnChatServerOK.TextLine1 = "確定"
        '
        'btnChatServerReset
        '
        Me.btnChatServerReset.ImageLarge = CType(resources.GetObject("btnChatServerReset.ImageLarge"), System.Drawing.Image)
        Me.btnChatServerReset.ImageSmall = CType(resources.GetObject("btnChatServerReset.ImageSmall"), System.Drawing.Image)
        Me.btnChatServerReset.TextLine1 = "リセット"
        '
        'KryptonRibbonTab2
        '
        Me.KryptonRibbonTab2.Groups.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup() {Me.KryptonRibbonGroup2})
        Me.KryptonRibbonTab2.Text = "Tool"
        '
        'KryptonRibbonGroup2
        '
        Me.KryptonRibbonGroup2.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer() {Me.KryptonRibbonGroupTriple1})
        Me.KryptonRibbonGroup2.MinimumWidth = 120
        Me.KryptonRibbonGroup2.TextLine1 = "高橋さん"
        '
        'KryptonRibbonGroupTriple1
        '
        Me.KryptonRibbonGroupTriple1.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem() {Me.btnSQLConv})
        '
        'btnSQLConv
        '
        Me.btnSQLConv.ImageLarge = CType(resources.GetObject("btnSQLConv.ImageLarge"), System.Drawing.Image)
        Me.btnSQLConv.ImageSmall = CType(resources.GetObject("btnSQLConv.ImageSmall"), System.Drawing.Image)
        Me.btnSQLConv.TextLine1 = "SQLConv"
        '
        'FrmClient
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(642, 517)
        Me.Controls.Add(Me.kscMain)
        Me.Controls.Add(Me.KryptonRibbon1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(330, 240)
        Me.Name = "FrmClient"
        Me.Text = "Ｓ.Ｋ.Ｂ くん"
        Me.TextExtra = ""
        CType(Me.kscMain.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kscMain.Panel1.ResumeLayout(False)
        CType(Me.kscMain.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kscMain.Panel2.ResumeLayout(False)
        CType(Me.kscMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kscMain.ResumeLayout(False)
        Me.tlpLeft.ResumeLayout(False)
        Me.tlpLeft.PerformLayout()
        CType(Me.Navi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage1.ResumeLayout(False)
        Me.tlpPage1.ResumeLayout(False)
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage2.ResumeLayout(False)
        Me.tlpPage2.ResumeLayout(False)
        CType(Me.KryptonPage3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage3.ResumeLayout(False)
        Me.tlpPage3.ResumeLayout(False)
        CType(Me.KryptonPage4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage4.ResumeLayout(False)
        Me.tlpPage4.ResumeLayout(False)
        Me.tlpRight.ResumeLayout(False)
        Me.tlpRight.PerformLayout()
        CType(Me.dgvConOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.KryptonRibbon1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Friend WithEvents kscMain As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents tlpLeft As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Navi As ComponentFactory.Krypton.Navigator.KryptonNavigator
    Friend WithEvents KryptonPage1 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage2 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents tlpPage1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnShortcutStartMenu As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnStartMenu As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnMenu As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents BtnOGU00MenuHome As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents BtnWeZDB7Home As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents BtnMesgBoxHome As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents BtnResetFolder As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents BtnOGU00Menu As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents BtnWeZDB7 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents BtnMesgBox As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPage3 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage4 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents tbMode As ComponentFactory.Krypton.Toolkit.KryptonTrackBar
    Friend WithEvents Label1 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents Label2 As ComponentFactory.Krypton.Toolkit.KryptonWrapLabel
    Friend WithEvents tlpPage2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCommon As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCommonClient As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCommonServer As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnNyushi As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnGakuseika As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCommonTemplate As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents tlpPage3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCommonWebSV As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents tlpPage4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTextBoxEx As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnDataGridViewEx As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents KryptonContextMenuItems1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timRetry As System.Windows.Forms.Timer
    Friend WithEvents FaceList As System.Windows.Forms.ImageList
    Friend WithEvents tlpRight As System.Windows.Forms.TableLayoutPanel
    Private WithEvents btnSend As ComponentFactory.Krypton.Toolkit.KryptonDropButton
    Private WithEvents tbInput As System.Windows.Forms.TextBox
    Private WithEvents btnClear As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents dgvConOut As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents TIME As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
    Friend WithEvents USER As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
    Friend WithEvents CONTENT As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
    Friend WithEvents kcmFace As ComponentFactory.Krypton.Toolkit.KryptonContextMenu
    Friend WithEvents KryptonContextMenuImageSelect1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuImageSelect
    Friend WithEvents KryptonContextMenuItems2 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents btnKyomu As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnSyomu As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCarrier As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnKaikei As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnDaigakuin As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnHouka As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnTsushin As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnKokusai As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnExtension As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnKarte As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnShisetsu As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnKyosyokuin As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnCmExcel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonContextMenuItem1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents KryptonManager As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents KryptonRibbon1 As ComponentFactory.Krypton.Ribbon.KryptonRibbon
    Friend WithEvents KryptonRibbonTab1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonTab
    Friend WithEvents KryptonRibbonGroup1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup
    Friend WithEvents KryptonRibbonGroupLines1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLines
    Friend WithEvents KryptonRibbonGroupLabel2 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel
    Friend WithEvents txtFileServer As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox
    Friend WithEvents KryptonRibbonGroupLabel1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupLabel
    Friend WithEvents txtChatServer As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTextBox
    Friend WithEvents btnFileServerOK As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents btnFileServerReset As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents btnChatServerOK As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents btnChatServerReset As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents btnAtena As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonRibbonTab2 As ComponentFactory.Krypton.Ribbon.KryptonRibbonTab
    Friend WithEvents KryptonRibbonGroup2 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup
    Friend WithEvents KryptonRibbonGroupTriple1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple
    Friend WithEvents btnSQLConv As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents btnKaikeiHugeReports As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class