Public Class Form1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = 0 Then
            Exit Sub
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim notas() As Double = {TextBox2.Text, TextBox3.Text, TextBox4.Text}
        Array.Sort(notas)
        Array.Reverse(notas)

        Dim media As Double = (notas(0) * 4 + notas(1) * 3 + notas(2) * 3) / 10
        Dim status As String = If(media >= 6, "APROVADO", "REPROVADO")

        Label2.Text = "Aluno: " & TextBox1.Text
        Label6.Text = "Notas: " & notas(0) & ", " & notas(1) & ", " & notas(2) & "."
        Label7.Text = "Média: " & media
        Label8.Text = "Status: " & status
    End Sub


End Class
