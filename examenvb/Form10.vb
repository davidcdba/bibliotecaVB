Public Class Form10
    Dim fecha As String
    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim i As ListViewItem

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sentencia = "Select * from libros"
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


                elemento = New ListViewItem(rsdinamico.Fields(0).Value.ToString)
                elemento.SubItems.Add(rsdinamico.Fields(1).Value.ToString)
                elemento.SubItems.Add(rsdinamico.Fields(2).Value.ToString)
                elemento.SubItems.Add(rsdinamico.Fields(3).Value.ToString)
                'autor
                sentencia = "SElECT nombre_autor FROM autores WHERE id_autor=" & rsdinamico.Fields(4).Value
                rs = cn.Execute(sentencia)
                elemento.SubItems.Add(rs.Fields(0).Value.ToString)
                rs.Close()


                ' elemento.SubItems.Add(rsdinamico.Fields(5).Value.ToString)
                'elemento.SubItems.Add(rsdinamico.Fields(4).Value.ToString)

                'ubicacion 
                sentencia = "SELECT id_estanteria from estante_libro WHERE id_libro=" & rsdinamico.Fields(0).Value
                rs = cn.Execute(sentencia)
                sentencia = "SELECT pasillo,estanteria From estanterias WHERE id_estanteria=" & rs.Fields(0).Value.ToString
                rs2 = cn.Execute(sentencia)
                elemento.SubItems.Add(rs2.Fields(0).Value.ToString)
                elemento.SubItems.Add(rs2.Fields(1).Value.ToString)

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