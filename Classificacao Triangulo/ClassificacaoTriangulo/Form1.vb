Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Integer = TextBox1.Text, b As Integer = TextBox2.Text, c As Integer = TextBox3.Text

        If (a < b + c) And (b < a + c) And (c < a + b) Then
            If (a = b) And (b = c) Then
                Label4.Text = "Triângulo Equilátero"
            ElseIf (a = b) Or (b = c) Or (a = c) Then
                Label4.Text = "Triângulo Isósceles"
            Else
                Label4.Text = "Triângulo Escaleno"
            End If
        Else
            Label4.Text = "Não é possível formar um triângulo"
        End If
    End Sub
End Class
