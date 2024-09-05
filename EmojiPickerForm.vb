Public Class EmojiPickerForm
    Public Sub UpdateForm2Position()
        ' 設定 Form2 的新位置，這裡設為在 Form1 右側的10個像素處
        Me.Location = New Point(Form1.Right, Form1.Top)
    End Sub


    Public Sub InitEmojiPickerTableLayoutPanel()
        Dim emojis As String() = {"🙂", "😃", "🙁", "😢", "😛", "😇", "😈", "😳", "😉", "😮", "😑", "😠", "😘", "❤", "😊", "😎", "🦈", "🤖", "😠", "V", "😕", "3", "L", "💩", "🐧",
            "☺️", "☹️", "☠️", "✊", "✌️", "☝️", "✋", "✍️",
            "‍♀️", "‍♂️", "⚕️", "⚖️", "❄️", "⭐️", "✨", "⚡️",
            "☄️", "☀️", "⛅️", "☁️", "⛈", "☃️", "⛄️", "☔️",
            "☂️", "☘️", "☕", "⚽️", "⚾️", "⛳️", "⛸", "⛷️",
            "⛹️", "♟", "✈️", "⛵️", "⛴", "⚓️", "⛽️", "⛲️",
            "⛰", "⛺️", "⛪️", "⛩", "⌚️", "⌨️", "☎️", "⏱",
            "⏲", "⏰", "⌛️", "⏳", "⚒", "⛏", "⚙️", "⛓",
            "⚔️", "⚰️", "⚱️", "⚗️", "✉️", "✂️", "✒️", "✏️",
            "❤️", "❣️", "☮️", "✝️", "☪️", "☸️", "✡️", "☯️",
            "☦️", "⛎", "♈️", "♉️", "♊️", "♋️", "♌️", "♍️",
            "♎️", "♏️", "♐️", "♑️", "♒️", "♓️", "⚛️", "☢️",
            "☣️", "✴️", "㊙️", "㊗️", "❌", "⭕️", "⛔️", "♨️",
            "❗️", "❕", "❓", "❔", "‼️", "⁉️", "〽️", "⚠️",
            "⚜️", "♻️", "✅", "❇️", "✳️", "❎", "Ⓜ️", "♿️",
            "⚧", "ℹ️", "0️⃣", "1️⃣", "2️⃣", "3️⃣", "4️⃣", "5️⃣",
            "6️⃣", "7️⃣", "8️⃣", "9️⃣", "#️⃣", "*️⃣", "⏏️", "▶️",
            "⏸", "⏯", "⏹", "⏺", "⏭", "⏮", "⏩", "⏪", "⏬", "◀️",
            "➡️", "⬅️", "⬆️", "⬇️", "↗️", "↘️", "↙️", "↖️",
            "↕️", "↔️", "↪️", "↩️", "⤴️", "⤵️", "➕", "➖",
            "➗", "✖️", "♾️", "™️", "©️", "®️", "〰️", "➰",
            "➿", "✔️", "☑️", "⚫️", "⚪️", "▪️", "▫️", "◾️",
            "◽️", "◼️", "◻️", "⬛️", "⬜️", "♠️", "♣️", "♥️", "♦️"
        }

        Dim emojiIndex As Integer = 0
        For row As Integer = 0 To 2
            For col As Integer = 0 To 67
                Dim lbl As New Label With {
                    .Name = emojiIndex & "_emoji_Label",
                    .Text = emojis(emojiIndex),
                    .Font = New Font("Segoe UI Emoji", 16),
                    .Dock = DockStyle.Fill,
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Cursor = Cursors.Hand
                }
                AddHandler lbl.Click, AddressOf EmojisLabel_Click


                Me.EmojiPicker_TableLayoutPanel.Controls.Add(lbl, col, row)
                emojiIndex += 1
            Next
        Next

    End Sub

    Public Sub EmojisLabel_Click(sender As Object, e As EventArgs)

        Try
            Dim clickedLabel As Label = CType(sender, Label)
            Dim emojisStr As String() = {":)", ":D", ":(", ":'(", ":P", "O:)", "3:)", "o.O", ";)", ":O", "-_-", ">:O", ":*", "<3", "^_^", "8|", "(^^^)", ":|]", ">:(", ":v", ":/", ":3", "(y)", ":poop:", "<("")"}
            Dim emojiIndex = CInt(Split(clickedLabel.Name, "_")(0))

            Dim myEmoji As String

            Dim target_richTextbox As RichTextBox = Nothing


            Select Case Form1.Action_TabControl.SelectedTab.Name
                Case "FBPost_TabPage"
                    target_richTextbox = Form1.PreviewTextFile_RichTextBox
                Case "FBMarketplace_TabPage"
                    target_richTextbox = Form1.FBMarketplaceProductDescription_RichTextBox
            End Select


            ' 如果點的在轉換清單內，就轉換成文字
            If emojiIndex < emojisStr.Count Then
                myEmoji = emojisStr(emojiIndex)
                target_richTextbox.SelectedText = myEmoji & " "
            Else
                '不轉換，用原本的表情插入
                myEmoji = clickedLabel.Text
                target_richTextbox.SelectedText = myEmoji
            End If


        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

    End Sub

    Private Sub EmojiPickerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Debug.WriteLine("Emo form load")
        InitEmojiPickerTableLayoutPanel()
    End Sub

End Class