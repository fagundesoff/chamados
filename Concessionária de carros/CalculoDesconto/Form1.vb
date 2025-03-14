Public Class Form1
    Dim Desconto As Double = 0
    Dim Valor As Double = 0
    Dim Total As Integer = 0, Total2000 As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Desconto = 0 Then
            If (Convert.ToDateTime(DateTimePicker1.Value).ToString("yyyy")) <= "2000" Then
                Desconto = TextBox1.Text * 0.12
                Valor = TextBox1.Text - Desconto
                Total2000 += 1
            Else
                Desconto = TextBox1.Text * 0.07
                Valor = TextBox1.Text - Desconto
            End If
            Total += 1
        Else
            Dim result As Integer = MessageBox.Show("Deseja continuar??", "Calculadora de Desconto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If result = DialogResult.Yes Then
                If (Convert.ToDateTime(DateTimePicker1.Value).ToString("yyyy")) <= "2000" Then
                    Desconto = Valor * 0.12
                    Valor = Desconto - Desconto
                    Total2000 += 1
                Else
                    Desconto = Valor * 0.07
                    Valor = Desconto - Desconto
                End If
                Total += 1
            Else
                Exit Sub
            End If
        End If
        Label1.Text = "Desconto: " & FormatCurrency(Desconto)
        Label2.Text = "Valor a pagar: " & FormatCurrency(Valor)
        Label8.Text = "Total de carros até 2000: " & Total2000
        Label5.Text = "Total de carros no geral: " & Total
    End Sub
End Class
