Public Class Form9
    Dim fecha As String
    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim i As ListViewItem

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fecha = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        sentencia = "SELECT * FROM prestamos where fecha_salida='" & fecha & "'"
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsdinamico.LockType = ADODB.LockTypeEnum.adLockOptimistic
        rsdinamico.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        rsdinamico = cn.Execute(sentencia)
        '  ListView1.Clear()
        ListView1.Items.Clear()


        ListView1.FullRowSelect = True

        'codigo del items
        If Not rsdinamico.EOF And Not rsdinamico.BOF Then


            rsdinamico.MoveFirst()

            Do While (Not rsdinamico.EOF)
                'examinamos la tabla libros
                sentencia = "select titulo_libro,isbn,autor_libro FROM libros WHERE id_libro=" & rsdinamico.Fields(0).Value.ToString
                rs = cn.Execute(sentencia)
                elemento = New ListViewItem(rs.Fields(0).Value.ToString)
                elemento.SubItems.Add(rs.Fields(1).Value.ToString)
                sentencia = "SElECT nombre_autor FROM autores WHERE id_autor=" & rs.Fields(2).Value.ToString
                rs2 = cn.Execute(sentencia)
                elemento.SubItems.Add(rs2.Fields(0).Value.ToString)

                'ahora examina la tabla lectores
                sentencia = "select id_lector,nombre_lector,dni_lector FROM lectores WHERE id_lector=" & rsdinamico.Fields(1).Value.ToString
                rs = cn.Execute(sentencia)
                elemento.SubItems.Add(rs.Fields(0).Value.ToString)
                elemento.SubItems.Add(rs.Fields(1).Value.ToString)
                elemento.SubItems.Add(rs.Fields(2).Value.ToString)


                ListView1.Items.Add(elemento)
                rsdinamico.MoveNext()


            Loop
        End If


        'cierre de rs para depurar errores
        rsdinamico.Close()
        rs.Close()
        rs2.Close()

    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        Me.Close()

    End Sub

    Private Sub Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimir.Click
        Imprimir.Visible = False
        Salir.Visible = False
        PrintForm1.Print()
        Imprimir.Visible = True
        Salir.Visible = True
    End Sub
End Class