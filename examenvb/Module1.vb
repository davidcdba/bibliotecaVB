Module Module1
    Public cn As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public rs2 As New ADODB.Recordset ' sirve en el form10 para detectar porke numero va
    Public rsdinamico As New ADODB.Recordset
    Public rs5 As New ADODB.Recordset
    Public rsdinamico1 As New ADODB.Recordset
    Public contador As Integer = 0
    Public buscador As String
    Public sentencia As String
    Public resultado As String
    Public contador2 As Integer = 0


    'Public Sub conectar()



    'End Sub
    Public Sub rs_mover()
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        rs.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
    End Sub


    Public Sub rslogeo_mover()
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs5.LockType = ADODB.LockTypeEnum.adLockOptimistic
        rs5.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
    End Sub
   
    Public Sub ConexionDB()
        cn.ConnectionString = "Driver={MySQL ODBC 5.1 Driver};Server=localhost;DataBase=biblioteca;User=root;Password=root"

        Try
            cn.Open()
        Catch ex As Exception
        End Try

        resultado = cn.Errors.Count
        If resultado <> 0 Then
            MsgBox("Error al conectar la base de datos")
        End If
    End Sub

End Module
