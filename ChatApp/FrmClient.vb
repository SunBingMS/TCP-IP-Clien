Option Strict On
Option Explicit On
Option Compare Binary

Imports System.ComponentModel
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports Microsoft.Win32
Imports NetComm
Imports System.Text.RegularExpressions

''' <summary>
''' クライアント
''' </summary>
''' <remarks></remarks>
Partial Public Class FrmClient
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

#Region "変数"

    Private mstrUserName As String = String.Empty
    Private client As NetComm.Client = New Client()
    Private clientList As New ArrayList()
    Private mstrStartPath As String = String.Empty
    Private mbooOnline As Boolean = False
    Private mstrChatServer As String = "192.168.1.30"
    Private mstrFileServer As String = "JIMDB1"
    Private mstrSep As String = "##Enigma##"
    Private mstrFace As String = "##Face##"
    Private mlngMyVer As Long = 20160325

    ''' <summary>
    ''' 構造関数
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        InitializeComponent()
    End Sub

#End Region

#Region "Load"

    ''' <summary>
    ''' Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmClient_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Using subKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\SKBpowertool", True)
            If subKey Is Nothing Then
                Dim regkey As RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\SKBpowertool")
                regkey.Close()
            Else
                subKey.Close()
            End If
        End Using

        Using subKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\SKBpowertool", True)
            If subKey.GetValue("FileServer") Is Nothing Then
                subKey.SetValue("FileServer", """" & mstrFileServer & """")
            Else
                mstrFileServer = DirectCast(subKey.GetValue("FileServer"), String).Replace("""", "")
            End If
            If subKey.GetValue("ChatServer") Is Nothing Then
                subKey.SetValue("ChatServer", """" & mstrChatServer & """")
            Else
                mstrChatServer = DirectCast(subKey.GetValue("ChatServer"), String).Replace("""", "")
            End If
            subKey.Close()
        End Using

        txtFileServer.Text = mstrFileServer
        txtChatServer.Text = mstrChatServer
        btnFileServerOK.Enabled = False
        btnChatServerOK.Enabled = False

        mstrUserName = Environment.UserName
        mstrStartPath = Application.StartupPath.Replace("\ReleaseTool", "")
        AddHandler client.Connected, AddressOf ClientConnected
        AddHandler client.Disconnected, AddressOf ClientDisconnected
        AddHandler client.DataReceived, AddressOf ClientDataReceived
        AddHandler client.errEncounter, AddressOf ClientErrEncounter
        client.Connect(mstrChatServer, 3330, mstrUserName) ' Port needs to match the Server's port as does the IP Address.
        timRetry.Start()
        Me.Text = mstrUserName
        Me.TextExtra = "Ver:" & mlngMyVer.ToString

#If Not Debug Then
        Using subKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            If subKey.GetValue("SKB_PowerTool") Is Nothing Then
                subKey.SetValue("SKB_PowerTool", """" & Application.ExecutablePath & """")
                subKey.Close()
            End If
        End Using
#End If

    End Sub

#End Region

#Region "Close"

    ''' <summary>
    ''' Close
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmClient_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        client.SendData(ConvertStringToBytes("CLOSING"), "0")
        RemoveHandler client.Disconnected, AddressOf ClientDisconnected
        client.Disconnect()
        timRetry.Stop()

    End Sub

#End Region

#Region "通知アイコン"

    ''' <summary>
    ''' 最小化、最大化
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmClient_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            NotifyIcon.Visible = True
        End If

    End Sub

    ''' <summary>
    ''' 通知アイコンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        NotifyIcon.Visible = False

    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Using subKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            If ToolStripMenuItem1.Checked Then
                subKey.SetValue("SKB_PowerTool", """" & Application.ExecutablePath & """")
                subKey.Close()
            Else
                subKey.DeleteValue("SKB_PowerTool", False)
                subKey.Close()
            End If
        End Using

    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub timRetry_Tick(sender As Object, e As EventArgs) Handles timRetry.Tick

        If Not mbooOnline Then
            client.Connect(mstrChatServer, 3330, mstrUserName)
        End If

    End Sub

#End Region

#Region "通信"

    ''' <summary>
    ''' 接続成功
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClientConnected()
        Call subShowWithStyle("------",
                              "[System]",
                              "Connected ",
                              Color.Red)
        mbooOnline = True
        client.SendData(ConvertStringToBytes("CVer::" & mlngMyVer.ToString), "0")
    End Sub

    ''' <summary>
    ''' 接続失敗
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClientDisconnected()
        Call subShowWithStyle("------",
                              "[System]",
                              "Disconnected (Auto retry after 5m)",
                              Color.Red)
        mbooOnline = False
    End Sub

    ''' <summary>
    ''' 通信エラー
    ''' </summary>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Private Sub ClientErrEncounter(ByVal ex As Exception)
        KryptonMessageBox.Show("Error: " & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' 受信
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="iD"></param>
    ''' <remarks></remarks>
    Private Sub ClientDataReceived(ByVal data() As Byte, ByVal iD As String)

        'CList::
        Dim msg As String = ConvertBytesToString(data)
        If msg.StartsWith("CList::") Then
            msg = msg.Replace("CList::", "")
            Call subShowWithStyle("------",
                                  "[System]",
                                  "Now Online User :" & msg,
                                  Color.Red)
        ElseIf msg.StartsWith("NEWVer::") Then
            Dim lngNewVer As Long = CLng(msg.Replace("NEWVer::", ""))
            If mlngMyVer < lngNewVer Then
                KryptonMessageBox.Show("New version is available", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Dim strArray As String() = Split(msg, mstrSep)
            Call subShowWithStyle(strArray(0),
                                  strArray(1),
                                  strArray(2),
                                  Color.Black)
            If NotifyIcon.Visible Then
                NotifyIcon.ShowBalloonTip(1, "New Message Received", strArray(2), ToolTipIcon.Info)
            Else
                Me.Activate()
            End If
        End If

    End Sub

    ''' <summary>
    ''' 受信データ変換
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertBytesToString(ByVal bytes() As Byte) As String
        Return UnicodeEncoding.Unicode.GetString(bytes)
    End Function

    ''' <summary>
    ''' 送信データ変換
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ConvertStringToBytes(ByVal str As String) As Byte()
        Return UnicodeEncoding.Unicode.GetBytes(str)
    End Function

    ''' <summary>
    ''' チャートエリアkeydown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TbInputKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tbInput.KeyDown
        If (e.Control = True And e.KeyCode = Keys.Enter) Then ' If the user has pressed the enter key
            Call subSendText()
        End If
    End Sub

    ''' <summary>
    ''' 送信ボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSendClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
        Call subSendText()
    End Sub

    ''' <summary>
    ''' クリアボタン
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        dgvConOut.Rows.Clear()
    End Sub

    ''' <summary>
    ''' 送信
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub subSendText()

        Dim strTime As String = DateTime.Now.ToLongTimeString

        If tbInput.Text.Length > 0 Then ' If there is something to send
            client.SendData(ConvertStringToBytes(strTime & mstrSep & mstrUserName & mstrSep & tbInput.Text), "0")
            Call subShowWithStyle(strTime,
                                  "Me",
                                  tbInput.Text,
                                  Color.DodgerBlue)
            tbInput.Text = ""
            tbInput.SelectionStart = 0
        End If

    End Sub

    ''' <summary>
    ''' 操作送信
    ''' </summary>
    ''' <param name="pstrOper"></param>
    ''' <remarks></remarks>
    Private Sub subSendOper(ByVal pstrOper As String)

        Dim strTime As String = DateTime.Now.ToLongTimeString

        client.SendData(ConvertStringToBytes(strTime & mstrSep & mstrUserName & mstrSep & pstrOper), "0")
        Call subShowWithStyle(strTime,
                              "Me",
                              pstrOper,
                              Color.DodgerBlue)

    End Sub

    ''' <summary>
    ''' 絵文字送信
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub KryptonContextMenuImageSelect1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KryptonContextMenuImageSelect1.SelectedIndexChanged

        Dim strTime As String = DateTime.Now.ToLongTimeString
        Dim strFaceCode As String = KryptonContextMenuImageSelect1.SelectedIndex.ToString.PadLeft(2, "0"c) & mstrFace & vbCrLf & vbCrLf

        client.SendData(ConvertStringToBytes(strTime & mstrSep & mstrUserName & mstrSep & strFaceCode), "0")
        Call subShowWithStyle(strTime,
                              "Me",
                              strFaceCode,
                              Color.DodgerBlue)

    End Sub

#End Region

#Region "表示"

    ''' <summary>
    ''' フォーマット
    ''' </summary>
    ''' <param name="pstrTime"></param>
    ''' <param name="pstrName"></param>
    ''' <param name="pstrContent"></param>
    ''' <param name="pColor"></param>
    ''' <remarks></remarks>
    Private Sub subShowWithStyle(ByVal pstrTime As String,
                                 ByVal pstrName As String,
                                 ByVal pstrContent As String,
                                 ByVal pColor As Color)

        dgvConOut.Rows.Add(pstrTime, pstrName, pstrContent)
        Dim intRow As Integer = dgvConOut.Rows.Count - 1
        dgvConOut.Rows(intRow).DefaultCellStyle.ForeColor = pColor
        dgvConOut.FirstDisplayedScrollingRowIndex = intRow

    End Sub

    ''' <summary>
    ''' CellPaintingイベントハンドラ
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs) Handles dgvConOut.CellPainting

        'ヘッダー以外のセルで、背景を描画する時
        If e.ColumnIndex = 2 AndAlso e.RowIndex >= 0 AndAlso _
            e.Value.ToString.EndsWith(mstrFace & vbCrLf & vbCrLf) AndAlso _
            (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            '背景だけを描画する
            Dim backParts As DataGridViewPaintParts = e.PaintParts And (DataGridViewPaintParts.Background Or _
                    DataGridViewPaintParts.SelectionBackground)
            e.Paint(e.ClipBounds, backParts)

            '画像をセルの範囲いっぱいに表示する
            e.Graphics.DrawImage(FaceList.Images(CInt(e.Value.ToString.Substring(0, 2))),
                                 e.CellBounds.Left,
                                 e.CellBounds.Top)

            ''背景以外が描画されるようにする
            'Dim paintParts As DataGridViewPaintParts = e.PaintParts And Not backParts
            ''セルを描画する
            'e.Paint(e.ClipBounds, paintParts)

            '描画が完了したことを知らせる
            e.Handled = True
        End If

    End Sub

    ''' <summary>
    ''' Fileサーバー名変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtFileServer_TextChanged(sender As Object, e As EventArgs) Handles txtFileServer.TextChanged
        btnFileServerOK.Enabled = True
    End Sub

    ''' <summary>
    ''' Chatサーバー名変更
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtChatServer_TextChanged(sender As Object, e As EventArgs) Handles txtChatServer.TextChanged
        btnChatServerOK.Enabled = True
    End Sub

    ''' <summary>
    ''' Fileサーバーの設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnFileServerOK_Click(sender As Object, e As EventArgs) Handles btnFileServerOK.Click
        Using subKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\SKBpowertool", True)
            mstrFileServer = txtFileServer.Text
            subKey.SetValue("FileServer", """" & mstrFileServer & """")
            subKey.Close()
        End Using
        btnFileServerOK.Enabled = False
    End Sub

    ''' <summary>
    ''' Chatサーバーの設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnChatServerOK_Click(sender As Object, e As EventArgs) Handles btnChatServerOK.Click
        Using subKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\SKBpowertool", True)
            mstrChatServer = txtChatServer.Text
            subKey.SetValue("ChatServer", """" & mstrChatServer & """")
            subKey.Close()
        End Using
        btnChatServerOK.Enabled = False
        KryptonMessageBox.Show("プログラムを再起動してください。", "設定完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Fileサーバーのリセット
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnFileServerReset_Click(sender As Object, e As EventArgs) Handles btnFileServerReset.Click
        Using subKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\SKBpowertool", True)
            txtFileServer.Text = "JIMDB1"
            mstrFileServer = txtFileServer.Text
            subKey.SetValue("FileServer", """" & mstrFileServer & """")
            subKey.Close()
        End Using
        btnFileServerOK.Enabled = False
    End Sub

    ''' <summary>
    ''' Chatサーバーのリセット
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnChatServerReset_Click(sender As Object, e As EventArgs) Handles btnChatServerReset.Click
        Using subKey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\SKBpowertool", True)
            txtChatServer.Text = "192.168.1.30"
            mstrChatServer = txtChatServer.Text
            subKey.SetValue("ChatServer", """" & mstrChatServer & """")
            subKey.Close()
        End Using
        btnChatServerOK.Enabled = False
        KryptonMessageBox.Show("プログラムを再起動してください。", "設定完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#Region "COPY"

    Enum COPYMODE
        FILE
        FOLDER
    End Enum

    Private Structure COPYINFO
        Dim MODE As COPYMODE
        Dim SOURSE As String
        Dim TARGET As String
        Dim ONLYLOCALFLG As Boolean

        ' コンストラクタ
        Sub New(ByVal m As COPYMODE, ByVal s As String, ByVal t As String, ByVal o As Boolean)
            MODE = m
            SOURSE = s
            TARGET = t
            ONLYLOCALFLG = o
        End Sub
    End Structure

    ''' <summary>
    ''' 共通コピー処理
    ''' </summary>
    ''' <param name="pFileInfo"></param>
    ''' <param name="plststrFileFormat"></param>
    ''' <param name="pstrName"></param>
    ''' <remarks></remarks>
    Private Sub subCommonCopy(ByVal pFileInfo As List(Of COPYINFO),
                              ByVal plststrFileFormat As String(),
                              ByVal pstrName As String)

        Dim lstFilePath As New List(Of String)
        Dim lstDirPath As New List(Of String)

        Try
            For i As Integer = 0 To pFileInfo.Count - 1
                If pFileInfo(i).ONLYLOCALFLG = False AndAlso tbMode.Value = 0 Then
                    Continue For
                End If

                Select Case pFileInfo(i).MODE
                    Case COPYMODE.FILE
                        For Each strFormat In plststrFileFormat
                            If My.Computer.FileSystem.FileExists(pFileInfo(i).SOURSE & strFormat) Then
                                My.Computer.FileSystem.CopyFile(pFileInfo(i).SOURSE & strFormat,
                                                                pFileInfo(i).TARGET & strFormat,
                                                                True)
                                lstFilePath.Add(pFileInfo(i).TARGET & strFormat)
                            End If
                        Next


                    Case COPYMODE.FOLDER
                        My.Computer.FileSystem.CopyDirectory(pFileInfo(i).SOURSE,
                                                             pFileInfo(i).TARGET,
                                                             True)
                        lstDirPath.Add(pFileInfo(i).TARGET)

                End Select
            Next

            If tbMode.Value = 1 Then
                Call subSendOper("【" & pstrName & "】をサーバー(" & mstrFileServer & ")へ更新しました。")
            End If

            Dim strMessage As New StringBuilder
            With strMessage
                .Length = 0
                .AppendLine("下記のコピー先へコピーしました。↓↓↓")
                .AppendLine("")
                If lstFilePath.Count > 0 Then
                    .AppendLine("File:")
                    For Each strFilePath In lstFilePath
                        .AppendLine("   ●" & strFilePath)
                    Next
                End If
                If lstDirPath.Count > 0 Then
                    .AppendLine("Directory:")
                    For Each strDirPath In lstDirPath
                        .AppendLine("   ●" & strDirPath)
                    Next
                End If
            End With

            KryptonMessageBox.Show(strMessage.ToString, "コピー完了", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Throw

        Finally
        End Try

    End Sub

#End Region

#Region "SKB MAIN"

    ''' <summary>
    ''' ShortcutStartMenu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnShortcutStartMenu_Click(sender As Object, e As EventArgs) Handles btnShortcutStartMenu.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\ShortCutStart\ShortCutStart\bin\Release\Start Menu.",
                                      "C:\Users\" & mstrUserName & "\Desktop\Start Menu.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FOLDER,
                                      mstrStartPath & "\ShortCutStart",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\01.ソース\ShortCutStart\",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\ShortCutStart\ShortCutStart\bin\Release\Start Menu.",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\02.実行ファイル\Start Menu.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' StartMenu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStartMenu_Click(sender As Object, e As EventArgs) Handles btnStartMenu.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\StartMenu\StartMenu\bin\Release\StartMenu.",
                                      "C:\OGU_JimSystem\StartMenu\StartMenu.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FOLDER,
                                      mstrStartPath & "\StartMenu",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\01.ソース\StartMenu\",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\StartMenu\StartMenu\bin\Release\StartMenu.",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\02.実行ファイル\StartMenu.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\StartMenu\StartMenu\bin\Release\StartMenu.",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\04.クライアントCドライブ\OGU_JimSystem\StartMenu\StartMenu.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\StartMenu\StartMenu\bin\Release\StartMenu.",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\05.サーバーCドライブ\OGU_JimSystem$\StartMenu\StartMenu.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\StartMenu\StartMenu\bin\Release\StartMenu.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\StartMenu\StartMenu.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\Menu\Menu\bin\Release\Menu.",
                                      "C:\OGU_JimSystem\StartMenu\Menu.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FOLDER,
                                      mstrStartPath & "\Menu",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\01.ソース\Menu\",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\Menu\Menu\bin\Release\Menu.",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\02.実行ファイル\Menu.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\Menu\Menu\bin\Release\Menu.",
                                      "\\FILE-BOSE\会社用_Area\1_現在作業中フォルダ\◆大阪学院大学\スタートメニュー\05.サーバーCドライブ\OGU_JimSystem$\StartMenu\Menu.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\Menu\Menu\bin\Release\Menu.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\StartMenu\Menu.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' OGU00MenuHome
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOGU00MenuHome_Click(sender As Object, e As EventArgs) Handles BtnOGU00MenuHome.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU_HOME\OGU_HOME\bin\Release\OGU_HOME.",
                                      "C:\OGU_JimSystem\JimSystem\EXE\OGU_HOME.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU_HOME\OGU_HOME\bin\Release\OGU_HOME.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU_HOME.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' OGU00Menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOGU00Menu_Click(sender As Object, e As EventArgs) Handles BtnOGU00Menu.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU00Menu\OGU00Menu\bin\Release\OGU00Menu.",
                                      "C:\OGU_JimSystem\JimSystem\EXE\OGU00Menu.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU00Menu\OGU00Menu\bin\Release\OGU00Menu.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU00Menu.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' WeZDB7Home
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnWeZDB7Home_Click(sender As Object, e As EventArgs) Handles BtnWeZDB7Home.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\WeZDB7_HOME\WeZDB7_HOME\bin\Release\WeZDB7_HOME.",
                                      "C:\OGU_JimSystem\WeZDB7\WeZDB7_HOME.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\WeZDB7_HOME\WeZDB7_HOME\bin\Release\WeZDB7_HOME.",
                                      mstrStartPath & "\WeZDB7\WeZDB7_HOME.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\WeZDB7_HOME\WeZDB7_HOME\bin\Release\WeZDB7_HOME.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\WeZDB7\WeZDB7_HOME.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' WeZDB7
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnWeZDB7_Click(sender As Object, e As EventArgs) Handles BtnWeZDB7.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\Source_SQLServer\WeZDB\WeZDB\bin\Release\WeZDB7.",
                                      "C:\OGU_JimSystem\WeZDB7\WeZDB7.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\Source_SQLServer\WeZDB\WeZDB\bin\Release\WeZDB7.",
                                      mstrStartPath & "\WeZDB7\WeZDB7.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\Source_SQLServer\WeZDB\WeZDB\bin\Release\WeZDB7.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\WeZDB7\WeZDB7.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' MesgBoxHome
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMesgBoxHome_Click(sender As Object, e As EventArgs) Handles BtnMesgBoxHome.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\MessengerBox_HOME\MessengerBox_HOME\bin\Release\MessengerBox_HOME.",
                                      "C:\OGU_JimSystem\DensyoBako\MessengerBox_HOME.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\MessengerBox_HOME\MessengerBox_HOME\bin\Release\MessengerBox_HOME.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\DensyoBako\MessengerBox_HOME.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' MesgBox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnMesgBox_Click(sender As Object, e As EventArgs) Handles BtnMesgBox.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\MessengerBox\SOURCE\MessengerBox\bin\Release\MessengerBox.",
                                      "C:\OGU_JimSystem\DensyoBako\MessengerBox.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\MessengerBox\SOURCE\MessengerBox\bin\Release\MessengerBox.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\DensyoBako\MessengerBox.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' ResetFolder
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnResetFolder_Click(sender As Object, e As EventArgs) Handles BtnResetFolder.Click

        Try
            If System.IO.Directory.Exists("C:\OGU_JimSystem") Then
                System.IO.Directory.Delete("C:\OGU_JimSystem", True)
            End If

            System.IO.Directory.CreateDirectory("C:\OGU_JimSystem").Attributes = IO.FileAttributes.Hidden
            System.IO.Directory.CreateDirectory("C:\OGU_JimSystem\CampusPlan")
            System.IO.Directory.CreateDirectory("C:\OGU_JimSystem\DensyoBako")
            System.IO.Directory.CreateDirectory("C:\OGU_JimSystem\JimSystem")
            System.IO.Directory.CreateDirectory("C:\OGU_JimSystem\WeZDB7")
            System.IO.Directory.CreateDirectory("C:\OGU_JimSystem\StartMenu\INI")

            My.Computer.FileSystem.CopyFile("\\" & mstrFileServer & "\OGU_jimsystem$\StartMenu\StartMenu.exe",
                                            "C:\OGU_JimSystem\StartMenu\StartMenu.exe",
                                            True)

            KryptonMessageBox.Show("Complete.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

#End Region

#Region "Jimsystem"

    ''' <summary>
    ''' Common
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCommon_Click(sender As Object, e As EventArgs) Handles btnCommon.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU99Common\OGU99Common\bin\Release\OGU99Common.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU99Common.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU99Common\OGU99Common\bin\Release\OGU99Common.",
                                      mstrStartPath & "\JimSystem\SOURCE\Common\OGU99Common.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU99Common\OGU99Common\bin\Release\OGU99Common.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU99Common.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU99Common\OGU99Common\bin\Release\OGU99Common.",
                                      "\\" & mstrFileServer & "\skb\Common\SV\bin\OGU99Common.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU99Common\OGU99Common\bin\Release\OGU99Common.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU99Common.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' CommonClient
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCommonClient_Click(sender As Object, e As EventArgs) Handles btnCommonClient.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU98Common_Client\OGU98Common_Client\bin\Release\OGU98Common_Client.",
                                      mstrStartPath & "\JimSystem\SOURCE\Common\OGU98Common_Client.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU98Common_Client\OGU98Common_Client\bin\Release\OGU98Common_Client.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU98Common_Client.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU98Common_Client\OGU98Common_Client\bin\Release\OGU98Common_Client.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU98Common_Client.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU98Common_Client\OGU98Common_Client\bin\Release\OGU98Common_Client.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU98Common_Client.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' CommonServer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCommonServer_Click(sender As Object, e As EventArgs) Handles btnCommonServer.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU97Common_Server\OGU97Common_Server\bin\Release\OGU97Common_Server.",
                                      mstrStartPath & "\JimSystem\SOURCE\Common\OGU97Common_Server.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU97Common_Server\OGU97Common_Server\bin\Release\OGU97Common_Server.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU97Common_Server.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU97Common_Server\OGU97Common_Server\bin\Release\OGU97Common_Server.",
                                      "\\" & mstrFileServer & "\skb\Common\SV\bin\OGU97Common_Server.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' CommonTemplate
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCommonTemplate_Click(sender As Object, e As EventArgs) Handles btnCommonTemplate.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\JimSystemTemplate\JimSystemTemplate\bin\Release\JimSystemTemplate.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\JimSystemTemplate.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\JimSystemTemplate\JimSystemTemplate\bin\Release\JimSystemTemplate.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\JimSystemTemplate.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\JimSystemTemplate\JimSystemTemplate\bin\Release\JimSystemTemplate.",
                                      "\\" & mstrFileServer & "\cplan_addon\JimSystemTemplate.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Nyushi
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNyushi_Click(sender As Object, e As EventArgs) Handles btnNyushi.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU01Nyushi\OGU01Nyushi\bin\Release\OGU01Nyushi.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU01Nyushi.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU01Nyushi\OGU01Nyushi\bin\Release\OGU01Nyushi.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU01Nyushi.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU01Nyushi\OGU01Nyushi\bin\Release\OGU01Nyushi.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU01Nyushi.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Kyomu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKyomu_Click(sender As Object, e As EventArgs) Handles btnKyomu.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU02Kyomu\OGU02Kyomu\bin\Release\OGU02Kyomu.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU02Kyomu.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU02Kyomu\OGU02Kyomu\bin\Release\OGU02Kyomu.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU02Kyomu.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU02Kyomu\OGU02Kyomu\bin\Release\OGU02Kyomu.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU02Kyomu.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Gakuseika
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGakuseika_Click(sender As Object, e As EventArgs) Handles btnGakuseika.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU03Gakusei\OGU03Gakusei\bin\Release\OGU03Gakusei.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU03Gakusei.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU03Gakusei\OGU03Gakusei\bin\Release\OGU03Gakusei.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU03Gakusei.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU03Gakusei\OGU03Gakusei\bin\Release\OGU03Gakusei.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU03Gakusei.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Syomu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSyomu_Click(sender As Object, e As EventArgs) Handles btnSyomu.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU04Syomu\OGU04Syomu\bin\Release\OGU04Syomu.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU04Syomu.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU04Syomu\OGU04Syomu\bin\Release\OGU04Syomu.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU04Syomu.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU04Syomu\OGU04Syomu\bin\Release\OGU04Syomu.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU04Syomu.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Carrier
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCarrier_Click(sender As Object, e As EventArgs) Handles btnCarrier.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU05Carrier\OGU05Carrier\bin\Release\OGU05Carrier.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU05Carrier.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU05Carrier\OGU05Carrier\bin\Release\OGU05Carrier.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU05Carrier.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU05Carrier\OGU05Carrier\bin\Release\OGU05Carrier.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU05Carrier.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Kaikei
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKaikei_Click(sender As Object, e As EventArgs) Handles btnKaikei.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU06Kaikei\OGU06Kaikei\bin\Release\OGU06Kaikei.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU06Kaikei.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU06Kaikei\OGU06Kaikei\bin\Release\OGU06Kaikei.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU06Kaikei.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU06Kaikei\OGU06Kaikei\bin\Release\OGU06Kaikei.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU06Kaikei.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' KaikeiHugeReports
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKaikeiHugeReports_Click(sender As Object, e As EventArgs) Handles btnKaikeiHugeReports.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU06KaikeiHugeReports\OGU06KaikeiHugeReports\bin\Release\OGU06KaikeiHugeReports.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU06KaikeiHugeReports.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU06KaikeiHugeReports\OGU06KaikeiHugeReports\bin\Release\OGU06KaikeiHugeReports.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU06KaikeiHugeReports.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU06KaikeiHugeReports\OGU06KaikeiHugeReports\bin\Release\OGU06KaikeiHugeReports.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU06KaikeiHugeReports.",
                                      False))

            subCommonCopy(fileInfo,
                          {"exe", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Daigakuin
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDaigakuin_Click(sender As Object, e As EventArgs) Handles btnDaigakuin.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU07Daigakuin\OGU07Daigakuin\bin\Release\OGU07Daigakuin.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU07Daigakuin.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU07Daigakuin\OGU07Daigakuin\bin\Release\OGU07Daigakuin.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU07Daigakuin.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU07Daigakuin\OGU07Daigakuin\bin\Release\OGU07Daigakuin.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU07Daigakuin.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Houka
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnHouka_Click(sender As Object, e As EventArgs) Handles btnHouka.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU08Houka\OGU08Houka\bin\Release\OGU08Houka.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU08Houka.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU08Houka\OGU08Houka\bin\Release\OGU08Houka.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU08Houka.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU08Houka\OGU08Houka\bin\Release\OGU08Houka.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU08Houka.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Tsushin
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTsushin_Click(sender As Object, e As EventArgs) Handles btnTsushin.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU09Tsushin\OGU09Tsushin\bin\Release\OGU09Tsushin.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU09Tsushin.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU09Tsushin\OGU09Tsushin\bin\Release\OGU09Tsushin.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU09Tsushin.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU09Tsushin\OGU09Tsushin\bin\Release\OGU09Tsushin.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU09Tsushin.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Kokusai
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKokusai_Click(sender As Object, e As EventArgs) Handles btnKokusai.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU10Kokusai\OGU10Kokusai\bin\Release\OGU10Kokusai.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU10Kokusai.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU10Kokusai\OGU10Kokusai\bin\Release\OGU10Kokusai.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU10Kokusai.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU10Kokusai\OGU10Kokusai\bin\Release\OGU10Kokusai.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU10Kokusai.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Extension
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExtension_Click(sender As Object, e As EventArgs) Handles btnExtension.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU11Extension\OGU11Extension\bin\Release\OGU11Extension.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU11Extension.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU11Extension\OGU11Extension\bin\Release\OGU11Extension.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU11Extension.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU11Extension\OGU11Extension\bin\Release\OGU11Extension.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU11Extension.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Karte
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKarte_Click(sender As Object, e As EventArgs) Handles btnKarte.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU51Karte\OGU51Karte\bin\Release\OGU51Karte.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU51Karte.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU51Karte\OGU51Karte\bin\Release\Calendar.DayView.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\Calendar.DayView.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU51Karte\OGU51Karte\bin\Release\OGU51Karte.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU51Karte.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU51Karte\OGU51Karte\bin\Release\Calendar.DayView.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\Calendar.DayView.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU51Karte\OGU51Karte\bin\Release\OGU51Karte.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU51Karte.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU51Karte\OGU51Karte\bin\Release\Calendar.DayView.",
                                      "\\" & mstrFileServer & "\cplan_addon\Calendar.DayView.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Shisetsu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnShisetsu_Click(sender As Object, e As EventArgs) Handles btnShisetsu.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU52Shisetsu\OGU52Shisetsu\bin\Release\OGU52Shisetsu.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU52Shisetsu.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU52Shisetsu\OGU52Shisetsu\bin\Release\OGU52Shisetsu.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU52Shisetsu.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU52Shisetsu\OGU52Shisetsu\bin\Release\OGU52Shisetsu.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU52Shisetsu.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Kyosyokuin
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnKyosyokuin_Click(sender As Object, e As EventArgs) Handles btnKyosyokuin.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU53Kyosyokuin\OGU53Kyosyokuin\bin\Release\OGU53Kyosyokuin.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU53Kyosyokuin.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU53Kyosyokuin\OGU53Kyosyokuin\bin\Release\OGU53Kyosyokuin.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU53Kyosyokuin.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU53Kyosyokuin\OGU53Kyosyokuin\bin\Release\OGU53Kyosyokuin.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU53Kyosyokuin.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' Atena
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAtena_Click(sender As Object, e As EventArgs) Handles btnAtena.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU54Atena\OGU54Atena\bin\Release\OGU54Atena.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\OGU54Atena.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU54Atena\OGU54Atena\bin\Release\OGU54Atena.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\OGU54Atena.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\OGU54Atena\OGU54Atena\bin\Release\OGU54Atena.",
                                      "\\" & mstrFileServer & "\cplan_addon\OGU54Atena.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

#End Region

#Region "Web Service"

    ''' <summary>
    ''' CommonWebSV
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCommonWebSV_Click(sender As Object, e As EventArgs) Handles btnCommonWebSV.Click

        Try
            My.Computer.FileSystem.CopyFile(mstrStartPath & "\JimSystem\SOURCE\CommonWebSV\SV\CommonWebSV.asmx",
                                        "\\" & mstrFileServer & "\skb\Common\SV\CommonWebSV.asmx",
                                        True)

            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\CommonWebSV\SV\bin\CommonWebSV.",
                                      "\\" & mstrFileServer & "\skb\Common\SV\bin\CommonWebSV.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\CommonWebSV\SV\bin\CommLibrary.",
                                      "\\" & mstrFileServer & "\skb\Common\SV\bin\CommLibrary.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\CommonWebSV\SV\bin\CommonBiz.",
                                      "\\" & mstrFileServer & "\skb\Common\SV\bin\CommonBiz.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\JimSystem\SOURCE\CommonWebSV\SV\bin\Microsoft.Japan.Mcs.Utilities.Trace.",
                                      "\\" & mstrFileServer & "\skb\Common\SV\bin\Microsoft.Japan.Mcs.Utilities.Trace.",
                                      True))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

#End Region

#Region "Customize"

    ''' <summary>
    ''' TextBoxEx
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTextBoxEx_Click(sender As Object, e As EventArgs) Handles btnTextBoxEx.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\TextBoxEx\TextBoxEx\TextBoxEx\bin\Release\TextBoxEx.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\TextBoxEx.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\TextBoxEx\TextBoxEx\TextBoxEx\bin\Release\TextBoxEx.",
                                      mstrStartPath & "\JimSystem\SOURCE\Common\TextBoxEx.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\TextBoxEx\TextBoxEx\TextBoxEx\bin\Release\TextBoxEx.",
                                      "\\" & mstrFileServer & "\cplan_addon\TextBoxEx.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\TextBoxEx\TextBoxEx\TextBoxEx\bin\Release\TextBoxEx.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\TextBoxEx.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\TextBoxEx\TextBoxEx\TextBoxEx\bin\Release\TextBoxEx.",
                                      "\\" & mstrFileServer & "\skb\Common\SV\bin\TextBoxEx.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' DataGridViewEx
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDataGridViewEx_Click(sender As Object, e As EventArgs) Handles btnDataGridViewEx.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\DataGridViewEx v1.0\DataGridView\DataGridView\bin\Release\DataGridViewEx.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\DataGridViewEx.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\DataGridViewEx v1.0\DataGridView\DataGridView\bin\Release\DataGridViewEx.",
                                      mstrStartPath & "\JimSystem\SOURCE\Common\DataGridViewEx.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\DataGridViewEx v1.0\DataGridView\DataGridView\bin\Release\DataGridViewEx.",
                                      "\\" & mstrFileServer & "\cplan_addon\DataGridViewEx.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\DataGridViewEx v1.0\DataGridView\DataGridView\bin\Release\DataGridViewEx.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\DataGridViewEx.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\DGVEx&TextBoxEx\DataGridViewEx v1.0\DataGridView\DataGridView\bin\Release\DataGridViewEx.",
                                      "\\" & mstrFileServer & "\skb\Common\SV\bin\DataGridViewEx.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

    ''' <summary>
    ''' CmExcel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCmExcel_Click(sender As Object, e As EventArgs) Handles btnCmExcel.Click

        Try
            Dim fileInfo As New List(Of COPYINFO)
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\cmExcel v1.29\cmExcel\cmExcel\bin\Release\cmExcel.",
                                      "C:\OGU_jimsystem\JimSystem\EXE\cmExcel.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\cmExcel v1.29\cmExcel\cmExcel\bin\Release\cmExcel.",
                                      mstrStartPath & "\JimSystem\SOURCE\Common\cmExcel.",
                                      True))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\cmExcel v1.29\cmExcel\cmExcel\bin\Release\cmExcel.",
                                      "\\" & mstrFileServer & "\cplan_addon\cmExcel.",
                                      False))
            fileInfo.Add(New COPYINFO(COPYMODE.FILE,
                                      mstrStartPath & "\cmExcel v1.29\cmExcel\cmExcel\bin\Release\cmExcel.",
                                      "\\" & mstrFileServer & "\OGU_jimsystem$\JimSystem\EXE\cmExcel.",
                                      False))

            subCommonCopy(fileInfo,
                          {"dll", "pdb"},
                          CType(sender, KryptonButton).Text)

        Catch ex As Exception
            KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
        End Try

    End Sub

#End Region

#Region "右クリックメニュー"

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If DialogResult.Yes = KryptonMessageBox.Show("SKB Power Tool will be closed. Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            Close()
        End If
    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        Using subKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            If subKey.GetValue("SKB_PowerTool") Is Nothing Then
                ToolStripMenuItem1.Checked = False
            Else
                ToolStripMenuItem1.Checked = True
            End If
        End Using
    End Sub

#End Region

#Region "開発ツール"

    ''' <summary>
    ''' SQLConv
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSQLConv_Click(sender As Object, e As EventArgs) Handles btnSQLConv.Click

        Try
            System.Diagnostics.Process.Start(mstrStartPath & "\Tool\SQLConv.exe")

        Catch ex As Exception
        Finally
        End Try

    End Sub

#End Region

End Class