Public Class WinMain
    Private LevelDisplay(9), LevelName(9) As String
    Private LevelLabel(9) As Label
    Private LevelComboBox(9) As ComboBox
    Private LevelButton(9) As Button
    Private onInit, onChange As Boolean
    Private LevelSelected(9), MinCode(9) As Byte
    Private Sub DimLevel()
        LevelDisplay(0) = "篇"
        LevelDisplay(1) = "类"
        LevelDisplay(2) = "章"
        LevelDisplay(3) = "节"
        LevelDisplay(4) = "条"
        LevelDisplay(5) = "款"
        LevelDisplay(6) = "项"
        LevelDisplay(7) = "目"
        LevelDisplay(8) = "子目"
        LevelDisplay(9) = "细目"
        LevelName(0) = "Pian"
        LevelName(1) = "Lei"
        LevelName(2) = "Zhang"
        LevelName(3) = "Jie"
        LevelName(4) = "Tiao"
        LevelName(5) = "Kuan"
        LevelName(6) = "Xiang"
        LevelName(7) = "Mu"
        LevelName(8) = "Zi"
        LevelName(9) = "Xi"
    End Sub
    Public Sub GraphLabel()
        Dim s As New Size(58, 21)
        Dim i As Byte
        For i = 0 To 9 Step 1
            LevelLabel(i) = New Label With {
                .Text = LevelDisplay(i) & "：",
                .Location = New Point(13, 16 + 37 * i),
                .Size = s
            }
            Me.Controls.Add(LevelLabel(i))
            LevelLabel(i).Show()
        Next
    End Sub
    Public Sub GraphComboBox()
        Dim s = New Size(331, 29)
        Dim i As Byte
        For i = 0 To 9 Step 1
            LevelComboBox(i) = New ComboBox With {
                .Location = New Point(79, 13 + 37 * i),
                .Size = s,
                .FormattingEnabled = True,
                .TabIndex = i * 2,
                .Tag = i,
                .ImeMode = ImeMode.Disable,
                .DropDownStyle = ComboBoxStyle.DropDownList
            }
            AddHandler LevelComboBox(i).SelectedValueChanged, AddressOf ComboBoxChanged
            Me.Controls.Add(LevelComboBox(i))
            LevelComboBox(i).Show()
        Next
    End Sub
    Private Sub GraphButton()
        Dim s = New Size(45, 29)
        Dim i As Byte
        For i = 0 To 9 Step 1
            LevelButton(i) = New Button With {
                .Location = New Point(418, 13 + 37 * i),
                .Size = New Size(45, 29),
                .Text = "→",
                .TabIndex = i * 2 + 1,
                .Tag = i,
                .ImeMode = ImeMode.Disable
            }
            AddHandler LevelButton(i).Click, AddressOf ButtonClick
            Me.Controls.Add(LevelButton(i))
            LevelButton(i).Show()
        Next
    End Sub
    Private Sub WinMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        onInit = True
        dsICC.ReadXml(New IO.StringReader(My.Resources.DATA))
        onChange = False
        Call DimLevel()
        Call GraphLabel()
        Call GraphComboBox()
        Call GraphButton()
        Call LoadAllLevel()
        Call LoadText(MaxLevel())
        onInit = False
    End Sub
    Private Sub LoadAllLevel()
        Dim i As Byte
        For i = 0 To 9 Step 1
            LevelSelected(i) = 1
        Next
        For i = 0 To 9 Step 1
            Call LoadLevel(i)
        Next
    End Sub
    Private Sub LoadLevel(id As Byte)
        Dim dtName As String = "dt" & LevelName(id)
        Dim colName As String = "c_" & LevelName(id)
        Dim padString As String = IIf(id = 0, " ", "0")
        Call ResetTable(dtName)
        Dim dr As DataRow
        For Each dricc As DataRow In dsICC.Tables(0).Select(SelectString(id))
            dr = dsCbb.Tables(dtName).NewRow
            dr.Item("c_id") = dricc.Item("c_id")
            dr.Item("c_code") = dricc.Item(colName)
            dr.Item("c_dscp") = dricc.Item("c_dscp")
            dr.Item("c_view") = ViewText(id, dricc.Item(colName), dricc.Item("c_dscp"))
            'dricc.Item(colName).ToString.PadLeft(2, padString) & " - " & dricc.Item("c_dscp")
            dsCbb.Tables(dtName).Rows.Add(dr)
        Next
        Dim existRow As Boolean = IIf(dsCbb.Tables(dtName).Rows.Count = 0, False, True)
        LevelComboBox(id).DataSource = Nothing
        LevelComboBox(id).DisplayMember = Nothing
        LevelComboBox(id).ValueMember = Nothing
        LevelComboBox(id).Text = "无细分编码"
        If existRow Then
            LevelComboBox(id).Text = Nothing
            LevelComboBox(id).DataSource = dsCbb.Tables(dtName)
            LevelComboBox(id).DisplayMember = "c_view"
            LevelComboBox(id).ValueMember = "c_id"
            MinCode(id) = dsCbb.Tables(dtName).Compute("Min(c_code)", True)
            LevelSelected(id) = MinCode(id)
            LevelComboBox(id).SelectedValue = dsCbb.Tables(dtName).Select("c_code = '" & LevelSelected(id).ToString & "'")(0).Item("c_id")
        End If
        LevelComboBox(id).Enabled = existRow
        LevelButton(id).Enabled = existRow
    End Sub
    Private Function ViewText(l As Byte, n As Byte, t As String) As String
        Dim oup As String
        If l = 0 Then
            oup = n.ToString.PadRight(2, " ") & " - " & SplitDscp(t)
        Else
            oup = n.ToString.PadLeft(2, "0") & " - " & SplitDscp(t)
        End If
        Return oup
    End Function
    Private Function SelectString(id As Byte) As String
        Dim oup As String = "c_level = '" & (id + 1).ToString & "'"
        Dim colName As String
        Dim i As Int16
        For i = 0 To id - 1 Step 1
            colName = "c_" & LevelName(i)
            oup += " and " & colName & " = '" & LevelSelected(i) & "'"
        Next
        Return oup
    End Function
    Private Sub ResetTable(TableName As String)
        If dsCbb.Tables.Contains(TableName) Then dsCbb.Tables.Remove(TableName)
        dsCbb.Tables.Add(TableName)
        dsCbb.Tables(TableName).Columns.Add("c_id", Type.GetType("System.Int32"))
        dsCbb.Tables(TableName).Columns.Add("c_code", Type.GetType("System.Byte"))
        dsCbb.Tables(TableName).Columns.Add("c_dscp", Type.GetType("System.String"))
        dsCbb.Tables(TableName).Columns.Add("c_view", Type.GetType("System.String"))
    End Sub
    Private Sub ComboBoxChanged(ByVal sender As ComboBox, ByVal e As EventArgs)
        If onInit Then Exit Sub
        If onChange Then Exit Sub
        onChange = True
        Dim l As Byte = sender.Tag
        Dim colName As String = "c_" & LevelName(l).ToLower
        LevelSelected(l) = dsICC.Tables(0).Select("c_id = '" & sender.SelectedValue.ToString & "'")(0).Item(colName)
        Dim i As Byte
        For i = l + 1 To 9 Step 1
            Call LoadLevel(i)
            If i = 9 Then onChange = False
        Next
        Call LoadText(l)
    End Sub
    Private Function FullCode(dr As DataRow) As String
        Dim oup As String = dr.Item("c_pian").ToString
        For i = 1 To 9 Step 1
            oup += dr.Item("c_" & LevelName(i)).ToString.PadLeft(2, "0")
        Next
        Return oup
    End Function
    Private Sub ButtonClick(ByVal sender As Button, ByVal e As EventArgs)
        Dim l As Byte = sender.Tag
        Call LoadText(l)
    End Sub
    Private Sub LoadText(l As Byte)
        lblLevel.Text = "级别：（" & l.ToString & "）" & LevelDisplay(l) & IIf(l = MaxLevel(), "（可用）", "（不可用）")
        Dim id As Int32 = LevelComboBox(l).SelectedValue
        Dim dr As DataRow = dsICC.Tables(0).Select("c_id = '" & LevelComboBox(l).SelectedValue.ToString & "'")(0)
        lblCode.Text = "编码：" & FullCode(dr)
        LblAbbr.Text = "简称：" & dr.Item("c_abbr")
        lblDscp.Text = "名称：" & SplitDscp(dr.Item("c_dscp"))
        Dim oup As String = lblLevel.Text & vbCrLf & lblCode.Text & vbCrLf & LblAbbr.Text & vbCrLf
        oup += "名称：" & dr.Item("c_dscp") & vbCrLf & "说明：" & FillNote(dr.Item("c_note"))
        txtNote.Text = oup
    End Sub
    Private Function SplitDscp(t As String)
        Dim oup As String = t
        If oup.Length > 15 Then oup = oup.Substring(0, 14) & "…"
        Return oup
    End Function
    Private Function FillNote(t As String)
        If t.Length = 0 Then Return "（无）" Else Return t
    End Function
    Private Function MaxLevel() As Byte
        Dim oup As Byte = 0
        Dim i As Byte
        For i = 0 To 9 Step 1
            If LevelComboBox(i).Enabled Then oup = i
        Next
        Return oup
    End Function
End Class
