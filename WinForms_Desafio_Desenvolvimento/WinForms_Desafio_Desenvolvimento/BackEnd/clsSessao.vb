Imports System.Data.SQLite
Public Class clsSessao
    Private Const CONNECTION_STRING As String = "Data Source=Dados\DesafioDB.db;Version=3;"

    Public Shared Function logar(ByVal user As String, ByVal senha As String) As Boolean

        Dim acesso As Boolean = False

        Using dbConnection As New SQLiteConnection(CONNECTION_STRING)

            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()

                dbCommand.CommandText = $"select * from usuarios where user={user}  and senha={senha}"

                Using dbDataAdapter As New SQLiteDataAdapter(dbCommand)

                    acesso = True

                End Using

            End Using

        End Using

        Return acesso




    End Function

End Class
