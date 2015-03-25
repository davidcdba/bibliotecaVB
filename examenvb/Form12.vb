Public Class Form12
    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim modificar2 As Integer = 0
    Dim modificar3 As Integer = 0
    Dim i As ListViewItem
    Private Sub tema_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tema.SelectedIndexChanged
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from libros Where tema_libro like '" & tema.Text & "%' ORDER BY (titulo_libro)"
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


                    elemento.SubItems.Add(rsdinamico.Fields(5).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(4).Value.ToString)

                    'ubicacion 
                    sentencia = "SELECT id_estanteria from estante_libro WHERE id_libro=" & rsdinamico.Fields(0).Value
                    rs = cn.Execute(sentencia)
                    elemento.SubItems.Add(rs.Fields(0).Value.ToString)
                    rs.Close()
                    elemento.SubItems.Add(rsdinamico.Fields(6).Value.ToString)
                    ListView1.Items.Add(elemento)
                    rsdinamico.MoveNext()


                Loop
            End If


            'cierre de rs para depurar errores
            rsdinamico.Close()
        End If
        'cierre if de la comprobacion de si estaba selecionado si ya 
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        Me.Close()

    End Sub

    Private Sub imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imprimir.Click
        Label2.Visible = False
        tema.Visible = False
        Salir.Visible = False
        imprimir.Visible = False
        PrintForm1.Print()
        Label2.Visible = True
        tema.Visible = True
        Salir.Visible = True
        imprimir.Visible = True
    End Sub
End Class