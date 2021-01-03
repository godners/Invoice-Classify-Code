<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WinMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinMain))
        Me.dsCbb = New System.Data.DataSet()
        Me.dsICC = New System.Data.DataSet()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblDscp = New System.Windows.Forms.Label()
        Me.LblAbbr = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        CType(Me.dsCbb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsICC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dsCbb
        '
        Me.dsCbb.DataSetName = "dsICC"
        '
        'dsICC
        '
        Me.dsICC.DataSetName = "dsICC"
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Location = New System.Drawing.Point(471, 16)
        Me.lblLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(58, 21)
        Me.lblLevel.TabIndex = 2
        Me.lblLevel.Text = "级别："
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Location = New System.Drawing.Point(471, 54)
        Me.lblCode.Margin = New System.Windows.Forms.Padding(4)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(58, 21)
        Me.lblCode.TabIndex = 4
        Me.lblCode.Text = "编码："
        '
        'lblDscp
        '
        Me.lblDscp.AutoSize = True
        Me.lblDscp.Location = New System.Drawing.Point(471, 128)
        Me.lblDscp.Margin = New System.Windows.Forms.Padding(4)
        Me.lblDscp.Name = "lblDscp"
        Me.lblDscp.Size = New System.Drawing.Size(58, 21)
        Me.lblDscp.TabIndex = 5
        Me.lblDscp.Text = "名称："
        '
        'LblAbbr
        '
        Me.LblAbbr.AutoSize = True
        Me.LblAbbr.Location = New System.Drawing.Point(471, 91)
        Me.LblAbbr.Margin = New System.Windows.Forms.Padding(4)
        Me.LblAbbr.Name = "LblAbbr"
        Me.LblAbbr.Size = New System.Drawing.Size(58, 21)
        Me.LblAbbr.TabIndex = 9
        Me.LblAbbr.Text = "简称："
        '
        'txtNote
        '
        Me.txtNote.Location = New System.Drawing.Point(475, 161)
        Me.txtNote.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ReadOnly = True
        Me.txtNote.Size = New System.Drawing.Size(331, 214)
        Me.txtNote.TabIndex = 10
        '
        'WinMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 388)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.LblAbbr)
        Me.Controls.Add(Me.lblDscp)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.lblLevel)
        Me.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "WinMain"
        Me.Text = "发票商品和服务税收分类编码"
        CType(Me.dsCbb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsICC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dsCbb As DataSet
    Friend WithEvents dsICC As DataSet
    Friend WithEvents lblLevel As Label
    Friend WithEvents lblCode As Label
    Friend WithEvents lblDscp As Label
    Friend WithEvents LblAbbr As Label
    Friend WithEvents txtNote As TextBox
End Class
