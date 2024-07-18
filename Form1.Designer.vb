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
        WebviewProfile_CheckedListBox = New CheckedListBox()
        Webview_Edge_Debug_Port_NumericUpDown = New NumericUpDown()
        Activate_WebviewEdge_Button = New Button()
        Quit_EdgeDriver_Button = New Button()
        Navigate_Url_TextBox = New TextBox()
        NavigateTo_Url_Button = New Button()
        UserInfo_GroupBox = New GroupBox()
        Button1 = New Button()
        ProfileFolderName_TextBox = New TextBox()
        CreateProfileFolderButton = New Button()
        DeleteSelectedProfileFolderButton = New Button()
        CType(Main_WebView2, ComponentModel.ISupportInitialize).BeginInit()
        CType(Webview_Edge_Debug_Port_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Main_WebView2
        ' 
        Main_WebView2.AllowExternalDrop = True
        Main_WebView2.CreationProperties = Nothing
        Main_WebView2.DefaultBackgroundColor = Color.White
        Main_WebView2.Location = New Point(243, 12)
        Main_WebView2.Name = "Main_WebView2"
        Main_WebView2.Size = New Size(834, 622)
        Main_WebView2.TabIndex = 0
        Main_WebView2.ZoomFactor = 1R
        ' 
        ' WebviewProfile_CheckedListBox
        ' 
        WebviewProfile_CheckedListBox.FormattingEnabled = True
        WebviewProfile_CheckedListBox.Location = New Point(12, 12)
        WebviewProfile_CheckedListBox.Name = "WebviewProfile_CheckedListBox"
        WebviewProfile_CheckedListBox.Size = New Size(225, 554)
        WebviewProfile_CheckedListBox.TabIndex = 1
        ' 
        ' Webview_Edge_Debug_Port_NumericUpDown
        ' 
        Webview_Edge_Debug_Port_NumericUpDown.Location = New Point(243, 640)
        Webview_Edge_Debug_Port_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Webview_Edge_Debug_Port_NumericUpDown.Minimum = New Decimal(New Integer() {9222, 0, 0, 0})
        Webview_Edge_Debug_Port_NumericUpDown.Name = "Webview_Edge_Debug_Port_NumericUpDown"
        Webview_Edge_Debug_Port_NumericUpDown.Size = New Size(150, 27)
        Webview_Edge_Debug_Port_NumericUpDown.TabIndex = 2
        Webview_Edge_Debug_Port_NumericUpDown.Value = New Decimal(New Integer() {9222, 0, 0, 0})
        ' 
        ' Activate_WebviewEdge_Button
        ' 
        Activate_WebviewEdge_Button.Location = New Point(399, 640)
        Activate_WebviewEdge_Button.Name = "Activate_WebviewEdge_Button"
        Activate_WebviewEdge_Button.Size = New Size(158, 29)
        Activate_WebviewEdge_Button.TabIndex = 3
        Activate_WebviewEdge_Button.Text = "啟動edge"
        Activate_WebviewEdge_Button.UseVisualStyleBackColor = True
        ' 
        ' Quit_EdgeDriver_Button
        ' 
        Quit_EdgeDriver_Button.Location = New Point(399, 675)
        Quit_EdgeDriver_Button.Name = "Quit_EdgeDriver_Button"
        Quit_EdgeDriver_Button.Size = New Size(158, 29)
        Quit_EdgeDriver_Button.TabIndex = 4
        Quit_EdgeDriver_Button.Text = "關閉"
        Quit_EdgeDriver_Button.UseVisualStyleBackColor = True
        ' 
        ' Navigate_Url_TextBox
        ' 
        Navigate_Url_TextBox.Location = New Point(563, 642)
        Navigate_Url_TextBox.Name = "Navigate_Url_TextBox"
        Navigate_Url_TextBox.Size = New Size(414, 27)
        Navigate_Url_TextBox.TabIndex = 5
        ' 
        ' NavigateTo_Url_Button
        ' 
        NavigateTo_Url_Button.Location = New Point(983, 640)
        NavigateTo_Url_Button.Name = "NavigateTo_Url_Button"
        NavigateTo_Url_Button.Size = New Size(94, 29)
        NavigateTo_Url_Button.TabIndex = 6
        NavigateTo_Url_Button.Text = "前往"
        NavigateTo_Url_Button.UseVisualStyleBackColor = True
        ' 
        ' UserInfo_GroupBox
        ' 
        UserInfo_GroupBox.Location = New Point(1083, 12)
        UserInfo_GroupBox.Name = "UserInfo_GroupBox"
        UserInfo_GroupBox.Size = New Size(327, 598)
        UserInfo_GroupBox.TabIndex = 7
        UserInfo_GroupBox.TabStop = False
        UserInfo_GroupBox.Text = "使用者紀錄"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(12, 681)
        Button1.Name = "Button1"
        Button1.Size = New Size(225, 29)
        Button1.TabIndex = 8
        Button1.Text = "更新-測試"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ProfileFolderName_TextBox
        ' 
        ProfileFolderName_TextBox.Location = New Point(12, 570)
        ProfileFolderName_TextBox.Name = "ProfileFolderName_TextBox"
        ProfileFolderName_TextBox.Size = New Size(125, 27)
        ProfileFolderName_TextBox.TabIndex = 9
        ' 
        ' CreateProfileFolderButton
        ' 
        CreateProfileFolderButton.Location = New Point(143, 570)
        CreateProfileFolderButton.Name = "CreateProfileFolderButton"
        CreateProfileFolderButton.Size = New Size(94, 29)
        CreateProfileFolderButton.TabIndex = 10
        CreateProfileFolderButton.Text = "新增"
        CreateProfileFolderButton.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedProfileFolderButton
        ' 
        DeleteSelectedProfileFolderButton.Location = New Point(143, 605)
        DeleteSelectedProfileFolderButton.Name = "DeleteSelectedProfileFolderButton"
        DeleteSelectedProfileFolderButton.Size = New Size(94, 29)
        DeleteSelectedProfileFolderButton.TabIndex = 11
        DeleteSelectedProfileFolderButton.Text = "刪除所選"
        DeleteSelectedProfileFolderButton.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1422, 722)
        Controls.Add(DeleteSelectedProfileFolderButton)
        Controls.Add(CreateProfileFolderButton)
        Controls.Add(ProfileFolderName_TextBox)
        Controls.Add(Button1)
        Controls.Add(UserInfo_GroupBox)
        Controls.Add(NavigateTo_Url_Button)
        Controls.Add(Navigate_Url_TextBox)
        Controls.Add(Quit_EdgeDriver_Button)
        Controls.Add(Activate_WebviewEdge_Button)
        Controls.Add(Webview_Edge_Debug_Port_NumericUpDown)
        Controls.Add(WebviewProfile_CheckedListBox)
        Controls.Add(Main_WebView2)
        Name = "Form1"
        Text = "Form1"
        CType(Main_WebView2, ComponentModel.ISupportInitialize).EndInit()
        CType(Webview_Edge_Debug_Port_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Main_WebView2 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents WebviewProfile_CheckedListBox As CheckedListBox
    Friend WithEvents Webview_Edge_Debug_Port_NumericUpDown As NumericUpDown
    Friend WithEvents Activate_WebviewEdge_Button As Button
    Friend WithEvents Quit_EdgeDriver_Button As Button
    Friend WithEvents Navigate_Url_TextBox As TextBox
    Friend WithEvents NavigateTo_Url_Button As Button
    Friend WithEvents UserInfo_GroupBox As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ProfileFolderName_TextBox As TextBox
    Friend WithEvents CreateProfileFolderButton As Button
    Friend WithEvents DeleteSelectedProfileFolderButton As Button

End Class
