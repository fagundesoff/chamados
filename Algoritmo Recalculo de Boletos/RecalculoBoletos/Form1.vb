Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dataVencimento As Date = (Convert.ToDateTime(DateTimePicker1.Value).ToString("yyyy-MM-dd"))
        Dim dataPagamento As Date = (Convert.ToDateTime(DateTimePicker2.Value).ToString("yyyy-MM-dd"))
        Dim valorBoleto As Decimal = Val(TextBox1.Text)

        Dim jurosPorDia As Decimal = 0.03
        Dim multa As Decimal = 2
        Dim totalJuros As Decimal = 0
        Dim totalMulta As Decimal = 0

        If dataPagamento > dataVencimento Then
            Dim diasAtraso As Integer = (dataPagamento - dataVencimento).Days

            If (VerificaFinalDeSemana(dataVencimento) Or VerificaFeriado(dataVencimento)) AndAlso (dataPagamento = dataVencimento.AddDays(1) OrElse dataPagamento = dataVencimento.AddDays(2) And VerificaFinalDeSemana(dataVencimento.AddDays(1))) Then
                diasAtraso = 0
            ElseIf (VerificaFinalDeSemana(dataVencimento) Or VerificaFeriado(dataVencimento)) AndAlso dataPagamento > dataVencimento.AddDays(1) Then
                diasAtraso = (dataPagamento - dataVencimento).Days
                totalMulta = multa
            ElseIf Not VerificaFinalDeSemana(dataVencimento) AndAlso Not VerificaFeriado(dataVencimento) Then
                diasAtraso = (dataPagamento - dataVencimento).Days
                totalMulta = multa
            End If

            totalJuros = diasAtraso * jurosPorDia
        End If

        Dim valorTotal As Decimal = valorBoleto + totalJuros + totalMulta

        Label4.Text = "Valor do boleto recalculado: " & FormatCurrency(valorTotal)
        Label5.Text = "Total de juros:" & FormatCurrency(totalJuros)
        Label6.Text = "Total de multa:" & FormatCurrency(totalMulta)
    End Sub


    Function VerificaFeriado(data As Date) As Boolean
        Dim feriados As Date() = {New Date(data.Year, 1, 1), New Date(data.Year, 4, 21), New Date(data.Year, 5, 1), New Date(data.Year, 9, 7), New Date(data.Year, 10, 12), New Date(data.Year, 11, 2), New Date(data.Year, 11, 15), New Date(data.Year, 12, 25)}
        Return feriados.Contains(data)
    End Function

    Function VerificaFinalDeSemana(data As Date) As Boolean
        Return data.DayOfWeek = DayOfWeek.Saturday Or data.DayOfWeek = DayOfWeek.Sunday
    End Function


End Class
