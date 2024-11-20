Imports AngleSharp.Dom
Imports OpenQA.Selenium

Public Class DevToolEventHandlers

    Public Sub DevTool_FindElementByCssSelector_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim cssSelector As String = Form1.DevTool_CssSelectorInput_TextBox.Text

            If String.IsNullOrWhiteSpace(cssSelector) Then
                Form1.DevTool_ResultOutput_RichTextBox.AppendText("# CssSelector input is empty" & Environment.NewLine)
                Return
            End If

            Dim elm As IWebElement = edgeDriver.FindElement(By.CssSelector(cssSelector))

            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# Element Found " & elm.Text & Environment.NewLine)

        Catch ex As NoSuchElementException
            ' 沒找到元素
            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# NoSuchElementException" & Environment.NewLine)

        Catch ex As WebDriverException
            ' webdriver錯誤，通常是沒開或者沒偵測到
            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# WebDriverException：" & ex.Message & Environment.NewLine)

        Catch ex As Exception
            ' 其他錯誤
            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# Exception：" & ex.Message & Environment.NewLine)
        End Try

    End Sub


    Public Sub DevTool_ClickElementByCssSelector_Button_Click(sender As Object, e As EventArgs)
        Try
            Dim cssSelector As String = Form1.DevTool_CssSelectorInput_TextBox.Text

            If String.IsNullOrWhiteSpace(cssSelector) Then
                Form1.DevTool_ResultOutput_RichTextBox.AppendText("# CssSelector input is empty" & Environment.NewLine)
                Return
            End If
            Dim elm As IWebElement = edgeDriver.FindElement(By.CssSelector(cssSelector))
            elm.Click()
            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# Click Element : " & elm.Text & Environment.NewLine)

        Catch ex As NoSuchElementException
            ' 沒找到元素
            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# NoSuchElementException" & Environment.NewLine)
        Catch ex As ElementNotInteractableException
            ' 元素無法互動，通常是不在視野範圍，或者是被其他元素遮擋，或者是被鎖住
            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# ElementNotInteractableException" & Environment.NewLine)
        Catch ex As WebDriverException
            ' webdriver錯誤，通常是沒開或者沒偵測到
            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# WebDriverException：" & ex.Message & Environment.NewLine)
        Catch ex As Exception
            ' 其他錯誤
            Form1.DevTool_ResultOutput_RichTextBox.AppendText("# Exception：" & ex.Message & Environment.NewLine)
        End Try
    End Sub




    Public Sub DevTool_ClearOutputRichTextBox_Button_Click(sender As Object, e As EventArgs)
        Form1.DevTool_ResultOutput_RichTextBox.Clear()
    End Sub


End Class
