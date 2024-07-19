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
        WebviewUserDataFolder_CheckedListBox = New CheckedListBox()
        Webview_Edge_Debug_Port_NumericUpDown = New NumericUpDown()
        Activate_WebviewEdge_Button = New Button()
        Quit_EdgeDriver_Button = New Button()
        Navigate_Url_TextBox = New TextBox()
        NavigateTo_Url_Button = New Button()
        UserInfo_GroupBox = New GroupBox()
        Button1 = New Button()
        UserDataFolderName_TextBox = New TextBox()
        CreateUserDataFolderButton = New Button()
        DeleteSelectedUserDataFolderButton = New Button()
        RestartWebview_Button = New Button()
        UserDataFoldListFilter_GroupBox = New GroupBox()
        CheckBox2 = New CheckBox()
        CheckBox1 = New CheckBox()
        CType(Main_WebView2, ComponentModel.ISupportInitialize).BeginInit()
        CType(Webview_Edge_Debug_Port_NumericUpDown, ComponentModel.ISupportInitialize).BeginInit()
        UserDataFoldListFilter_GroupBox.SuspendLayout()
        SuspendLayout()
        ' 
        ' Main_WebView2
        ' 
        Main_WebView2.AllowExternalDrop = True
        Main_WebView2.BackColor = Color.White
        Main_WebView2.CreationProperties = Nothing
        Main_WebView2.DefaultBackgroundColor = Color.White
        Main_WebView2.ForeColor = Color.Black
        Main_WebView2.Location = New Point(226, 12)
        Main_WebView2.Name = "Main_WebView2"
        Main_WebView2.Size = New Size(851, 613)
        Main_WebView2.TabIndex = 0
        Main_WebView2.ZoomFactor = 1R
        ' 
        ' WebviewUserDataFolder_CheckedListBox
        ' 
        WebviewUserDataFolder_CheckedListBox.FormattingEnabled = True
        WebviewUserDataFolder_CheckedListBox.Location = New Point(12, 12)
        WebviewUserDataFolder_CheckedListBox.Name = "WebviewUserDataFolder_CheckedListBox"
        WebviewUserDataFolder_CheckedListBox.Size = New Size(208, 444)
        WebviewUserDataFolder_CheckedListBox.TabIndex = 1
        ' 
        ' Webview_Edge_Debug_Port_NumericUpDown
        ' 
        Webview_Edge_Debug_Port_NumericUpDown.Location = New Point(226, 631)
        Webview_Edge_Debug_Port_NumericUpDown.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Webview_Edge_Debug_Port_NumericUpDown.Minimum = New Decimal(New Integer() {9222, 0, 0, 0})
        Webview_Edge_Debug_Port_NumericUpDown.Name = "Webview_Edge_Debug_Port_NumericUpDown"
        Webview_Edge_Debug_Port_NumericUpDown.Size = New Size(150, 27)
        Webview_Edge_Debug_Port_NumericUpDown.TabIndex = 2
        Webview_Edge_Debug_Port_NumericUpDown.Value = New Decimal(New Integer() {9222, 0, 0, 0})
        ' 
        ' Activate_WebviewEdge_Button
        ' 
        Activate_WebviewEdge_Button.Location = New Point(382, 631)
        Activate_WebviewEdge_Button.Name = "Activate_WebviewEdge_Button"
        Activate_WebviewEdge_Button.Size = New Size(158, 29)
        Activate_WebviewEdge_Button.TabIndex = 3
        Activate_WebviewEdge_Button.Text = "啟動edge - 測試用"
        Activate_WebviewEdge_Button.UseVisualStyleBackColor = True
        ' 
        ' Quit_EdgeDriver_Button
        ' 
        Quit_EdgeDriver_Button.Location = New Point(382, 666)
        Quit_EdgeDriver_Button.Name = "Quit_EdgeDriver_Button"
        Quit_EdgeDriver_Button.Size = New Size(158, 29)
        Quit_EdgeDriver_Button.TabIndex = 4
        Quit_EdgeDriver_Button.Text = "關閉 - 測試用"
        Quit_EdgeDriver_Button.UseVisualStyleBackColor = True
        ' 
        ' Navigate_Url_TextBox
        ' 
        Navigate_Url_TextBox.Location = New Point(546, 633)
        Navigate_Url_TextBox.Name = "Navigate_Url_TextBox"
        Navigate_Url_TextBox.Size = New Size(431, 27)
        Navigate_Url_TextBox.TabIndex = 5
        ' 
        ' NavigateTo_Url_Button
        ' 
        NavigateTo_Url_Button.Location = New Point(983, 633)
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
        UserInfo_GroupBox.Size = New Size(249, 613)
        UserInfo_GroupBox.TabIndex = 7
        UserInfo_GroupBox.TabStop = False
        UserInfo_GroupBox.Text = "使用者紀錄"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(226, 666)
        Button1.Name = "Button1"
        Button1.Size = New Size(150, 29)
        Button1.TabIndex = 8
        Button1.Text = "更新-測試用"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' UserDataFolderName_TextBox
        ' 
        UserDataFolderName_TextBox.Location = New Point(12, 561)
        UserDataFolderName_TextBox.Name = "UserDataFolderName_TextBox"
        UserDataFolderName_TextBox.Size = New Size(108, 27)
        UserDataFolderName_TextBox.TabIndex = 9
        ' 
        ' CreateUserDataFolderButton
        ' 
        CreateUserDataFolderButton.Location = New Point(126, 561)
        CreateUserDataFolderButton.Name = "CreateUserDataFolderButton"
        CreateUserDataFolderButton.Size = New Size(94, 29)
        CreateUserDataFolderButton.TabIndex = 10
        CreateUserDataFolderButton.Text = "新增"
        CreateUserDataFolderButton.UseVisualStyleBackColor = True
        ' 
        ' DeleteSelectedUserDataFolderButton
        ' 
        DeleteSelectedUserDataFolderButton.Location = New Point(126, 596)
        DeleteSelectedUserDataFolderButton.Name = "DeleteSelectedUserDataFolderButton"
        DeleteSelectedUserDataFolderButton.Size = New Size(94, 29)
        DeleteSelectedUserDataFolderButton.TabIndex = 11
        DeleteSelectedUserDataFolderButton.Text = "刪除所選"
        DeleteSelectedUserDataFolderButton.UseVisualStyleBackColor = True
        ' 
        ' RestartWebview_Button
        ' 
        RestartWebview_Button.Location = New Point(546, 666)
        RestartWebview_Button.Name = "RestartWebview_Button"
        RestartWebview_Button.Size = New Size(118, 29)
        RestartWebview_Button.TabIndex = 12
        RestartWebview_Button.Text = "重啟 - 測試用"
        RestartWebview_Button.UseVisualStyleBackColor = True
        ' 
        ' UserDataFoldListFilter_GroupBox
        ' 
        UserDataFoldListFilter_GroupBox.Controls.Add(CheckBox2)
        UserDataFoldListFilter_GroupBox.Controls.Add(CheckBox1)
        UserDataFoldListFilter_GroupBox.Location = New Point(12, 462)
        UserDataFoldListFilter_GroupBox.Name = "UserDataFoldListFilter_GroupBox"
        UserDataFoldListFilter_GroupBox.Size = New Size(208, 93)
        UserDataFoldListFilter_GroupBox.TabIndex = 13
        UserDataFoldListFilter_GroupBox.TabStop = False
        UserDataFoldListFilter_GroupBox.Text = "顯示"
        ' 
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        CheckBox2.Location = New Point(6, 55)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(61, 23)
        CheckBox2.TabIndex = 1
        CheckBox2.Text = "無效"
        CheckBox2.UseVisualStyleBackColor = True
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(6, 26)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(61, 23)
        CheckBox1.TabIndex = 0
        CheckBox1.Text = "可用"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(9F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1353, 722)
        Controls.Add(UserDataFoldListFilter_GroupBox)
        Controls.Add(RestartWebview_Button)
        Controls.Add(DeleteSelectedUserDataFolderButton)
        Controls.Add(CreateUserDataFolderButton)
        Controls.Add(UserDataFolderName_TextBox)
        Controls.Add(Button1)
        Controls.Add(UserInfo_GroupBox)
        Controls.Add(NavigateTo_Url_Button)
        Controls.Add(Navigate_Url_TextBox)
        Controls.Add(Quit_EdgeDriver_Button)
        Controls.Add(Activate_WebviewEdge_Button)
        Controls.Add(Webview_Edge_Debug_Port_NumericUpDown)
        Controls.Add(WebviewUserDataFolder_CheckedListBox)
        Controls.Add(Main_WebView2)
        Name = "Form1"
        Text = "Form1"
        CType(Main_WebView2, ComponentModel.ISupportInitialize).EndInit()
        CType(Webview_Edge_Debug_Port_NumericUpDown, ComponentModel.ISupportInitialize).EndInit()
        UserDataFoldListFilter_GroupBox.ResumeLayout(False)
        UserDataFoldListFilter_GroupBox.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Main_WebView2 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents WebviewUserDataFolder_CheckedListBox As CheckedListBox
    Friend WithEvents Webview_Edge_Debug_Port_NumericUpDown As NumericUpDown
    Friend WithEvents Activate_WebviewEdge_Button As Button
    Friend WithEvents Quit_EdgeDriver_Button As Button
    Friend WithEvents Navigate_Url_TextBox As TextBox
    Friend WithEvents NavigateTo_Url_Button As Button
    Friend WithEvents UserInfo_GroupBox As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents UserDataFolderName_TextBox As TextBox
    Friend WithEvents CreateUserDataFolderButton As Button
    Friend WithEvents DeleteSelectedUserDataFolderButton As Button
    Friend WithEvents RestartWebview_Button As Button
    Friend WithEvents UserDataFoldListFilter_GroupBox As GroupBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox

End Class
