<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Main_WebView2 = New Microsoft.Web.WebView2.WinForms.WebView2()
        CheckedListBox1 = New CheckedListBox()
        Webview_Edge_Debug_Port_NumericUpDown = New NumericUpDown()
        Activate_WebviewEdge_Button = New Button()
        Quit_EdgeDriver_Button = New Button()
        Navigate_Url_TextBox = New TextBox()
        NavigateTo_Url_Button = New Button()
        CType(Main_WebView2, ComponentModel.ISupportInitialize).BeginInit()
        CType(Webview_Edge_Debug_Port_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Main_WebView2
        ' 
        Main_WebView2.AllowExternalDrop = True
        Main_WebView2.CreationProperties = Nothing
        Main_WebView2.DefaultBackgroundColor = Color.White
        Main_WebView2.Location = New Point(292, 12)
        Main_WebView2.Name = "Main_WebView2"
        Main_WebView2.Size = New Size(903, 598)
        Main_WebView2.TabIndex = 0
        Main_WebView2.ZoomFactor = 1R
        ' 
        ' CheckedListBox1
        ' 
        CheckedListBox1.FormattingEnabled = True
        CheckedListBox1.Location = New Point(12, 12)
        CheckedListBox1.Name = "CheckedListBox1"
        CheckedListBox1.Size = New Size(274, 598)
        CheckedListBox1.TabIndex = 1
        ' 
        ' Webview_Edge_Debug_Port_NumericUpDown
        ' 
        Webview_Edge_Debug_Port_NumericUpDown.Location = New Point(292, 616)
        Webview_Edge_Debug_Port_NumericUpDown.Name = "Webview_Edge_Debug_Port_NumericUpDown"
        Webview_Edge_Debug_Port_NumericUpDown.Size = New Size(150, 27)
        Webview_Edge_Debug_Port_NumericUpDown.TabIndex = 2
        ' 
        ' Activate_WebviewEdge_Button
        ' 
        Activate_WebviewEdge_Button.Location = New Point(448, 616)
        Activate_WebviewEdge_Button.Name = "Activate_WebviewEdge_Button"
        Activate_WebviewEdge_Button.Size = New Size(158, 29)
        Activate_WebviewEdge_Button.TabIndex = 3
        Activate_WebviewEdge_Button.Text = "啟動edge"
        Activate_WebviewEdge_Button.UseVisualStyleBackColor = True
        ' 
        ' Quit_EdgeDriver_Button
        ' 
        Quit_EdgeDriver_Button.Location = New Point(448, 651)
        Quit_EdgeDriver_Button.Name = "Quit_EdgeDriver_Button"
        Quit_EdgeDriver_Button.Size = New Size(158, 29)
        Quit_EdgeDriver_Button.TabIndex = 4
        Quit_EdgeDriver_Button.Text = "關閉"
        Quit_EdgeDriver_Button.UseVisualStyleBackColor = True
        ' 
        ' Navigate_Url_TextBox
        ' 
        Navigate_Url_TextBox.Location = New Point(612, 618)
        Navigate_Url_TextBox.Name = "Navigate_Url_TextBox"
        Navigate_Url_TextBox.Size = New Size(483, 27)
        Navigate_Url_TextBox.TabIndex = 5
        ' 
        ' NavigateTo_Url_Button
        ' 
        NavigateTo_Url_Button.Location = New Point(1101, 618)
        NavigateTo_Url_Button.Name = "NavigateTo_Url_Button"
        NavigateTo_Url_Button.Size = New Size(94, 29)
        NavigateTo_Url_Button.TabIndex = 6
        NavigateTo_Url_Button.Text = "前往"
        NavigateTo_Url_Button.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1207, 722)
        Controls.Add(NavigateTo_Url_Button)
        Controls.Add(Navigate_Url_TextBox)
        Controls.Add(Quit_EdgeDriver_Button)
        Controls.Add(Activate_WebviewEdge_Button)
        Controls.Add(Webview_Edge_Debug_Port_NumericUpDown)
        Controls.Add(CheckedListBox1)
        Controls.Add(Main_WebView2)
        Name = "Form1"
        Text = "Form1"
        CType(Main_WebView2, ComponentModel.ISupportInitialize).EndInit()
        CType(Webview_Edge_Debug_Port_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Main_WebView2 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents Webview_Edge_Debug_Port_NumericUpDown As NumericUpDown
    Friend WithEvents Activate_WebviewEdge_Button As Button
    Friend WithEvents Quit_EdgeDriver_Button As Button
    Friend WithEvents Navigate_Url_TextBox As TextBox
    Friend WithEvents NavigateTo_Url_Button As Button

End Class
