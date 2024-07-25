<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebugForm
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        RestartWebview_Button = New Button()
        Quit_EdgeDriver_Button = New Button()
        Activate_WebviewEdge_Button = New Button()
        Webview_Edge_Debug_Port_NumericUpDown = New NumericUpDown()
        UpdateCheckedListBox_Button = New Button()
        Label1 = New Label()
        ResetWebview2_Button = New Button()
        CType(Webview_Edge_Debug_Port_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' RestartWebview_Button
        ' 
        RestartWebview_Button.Location = New Point(12, 40)
        RestartWebview_Button.Name = "RestartWebview_Button"
        RestartWebview_Button.Size = New Size(248, 29)
        RestartWebview_Button.TabIndex = 15
        RestartWebview_Button.Text = "重啟webview跟driver"
        RestartWebview_Button.UseVisualStyleBackColor = True
        ' 
        ' Quit_EdgeDriver_Button
        ' 
        Quit_EdgeDriver_Button.Location = New Point(266, 40)
        Quit_EdgeDriver_Button.Name = "Quit_EdgeDriver_Button"
        Quit_EdgeDriver_Button.Size = New Size(220, 29)
        Quit_EdgeDriver_Button.TabIndex = 13
        Quit_EdgeDriver_Button.Text = "關閉Driver"
        Quit_EdgeDriver_Button.UseVisualStyleBackColor = True
        ' 
        ' Activate_WebviewEdge_Button
        ' 
        Activate_WebviewEdge_Button.Location = New Point(266, 5)
        Activate_WebviewEdge_Button.Name = "Activate_WebviewEdge_Button"
        Activate_WebviewEdge_Button.Size = New Size(220, 29)
        Activate_WebviewEdge_Button.TabIndex = 17
        Activate_WebviewEdge_Button.Text = "啟動Webview跟Driver"
        Activate_WebviewEdge_Button.UseVisualStyleBackColor = True
        ' 
        ' Webview_Edge_Debug_Port_NumericUpDown
        ' 
        Webview_Edge_Debug_Port_NumericUpDown.Location = New Point(110, 7)
        Webview_Edge_Debug_Port_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Webview_Edge_Debug_Port_NumericUpDown.Minimum = New Decimal(New Integer() {9222, 0, 0, 0})
        Webview_Edge_Debug_Port_NumericUpDown.Name = "Webview_Edge_Debug_Port_NumericUpDown"
        Webview_Edge_Debug_Port_NumericUpDown.Size = New Size(150, 27)
        Webview_Edge_Debug_Port_NumericUpDown.TabIndex = 16
        Webview_Edge_Debug_Port_NumericUpDown.Value = New Decimal(New Integer() {9222, 0, 0, 0})
        ' 
        ' UpdateCheckedListBox_Button
        ' 
        UpdateCheckedListBox_Button.Location = New Point(12, 75)
        UpdateCheckedListBox_Button.Name = "UpdateCheckedListBox_Button"
        UpdateCheckedListBox_Button.Size = New Size(248, 29)
        UpdateCheckedListBox_Button.TabIndex = 18
        UpdateCheckedListBox_Button.Text = "更新UserDataList"
        UpdateCheckedListBox_Button.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 19)
        Label1.TabIndex = 19
        Label1.Text = "DebugPort :"
        ' 
        ' ResetWebview2_Button
        ' 
        ResetWebview2_Button.Location = New Point(266, 75)
        ResetWebview2_Button.Name = "ResetWebview2_Button"
        ResetWebview2_Button.Size = New Size(220, 29)
        ResetWebview2_Button.TabIndex = 20
        ResetWebview2_Button.Text = "Reset Weview2"
        ResetWebview2_Button.UseVisualStyleBackColor = True
        ' 
        ' DebugForm
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(498, 186)
        Controls.Add(ResetWebview2_Button)
        Controls.Add(Label1)
        Controls.Add(UpdateCheckedListBox_Button)
        Controls.Add(Activate_WebviewEdge_Button)
        Controls.Add(Webview_Edge_Debug_Port_NumericUpDown)
        Controls.Add(RestartWebview_Button)
        Controls.Add(Quit_EdgeDriver_Button)
        Name = "DebugForm"
        Text = "Debug Panel"
        CType(Webview_Edge_Debug_Port_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents RestartWebview_Button As Button
    Friend WithEvents Quit_EdgeDriver_Button As Button
    Friend WithEvents Activate_WebviewEdge_Button As Button
    Friend WithEvents Webview_Edge_Debug_Port_NumericUpDown As NumericUpDown
    Friend WithEvents UpdateCheckedListBox_Button As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ResetWebview2_Button As Button
End Class
