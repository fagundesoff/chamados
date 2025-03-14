Public Class frmLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim erro As Boolean
        erro = clsSessao.logar(txtLogin.Text, txtSenha.Text)
        If erro <> False Then
            frmPrincipal.Show()
            Me.Hide()
        End If
    End Sub
End Class