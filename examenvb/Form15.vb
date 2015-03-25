Public Class Form15
    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim i As ListViewItem
    Private Sub Form15_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sentencia = "Select * from libros "
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
                'Comprubacion de si esta solicitado este libro

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

                ListView1.Items.Add(elemento)
                rsdinamico.MoveNext()


            Loop
        End If


        'cierre de rs para depurar errores
        rsdinamico.Close()
      
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        For Each i As ListViewItem In ListView1.SelectedItems
            ' modificar = 1
            sentencia = "SELECT * FROM copias WHERE id_libro=" & i.Text


            i.BackColor = Color.BlueViolet


        Next
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsdinamico.LockType = ADODB.LockTypeEnum.adLockOptimistic
        rsdinamico.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        rsdinamico = cn.Execute(sentencia)
        '  ListView1.Clear()
        ListView2.Items.Clear()


        ListView2.FullRowSelect = True

        'codigo del items
        If Not rsdinamico.EOF And Not rsdinamico.BOF Then


            rsdinamico.MoveFirst()

            Do While (Not rsdinamico.EOF)


                elemento = New ListViewItem(rsdinamico.Fields(0).Value.ToString)

                sentencia = "SELECT id_estanteria FROM estante_libro WHERE id_libro=" & rsdinamico.Fields(0).Value.ToString
                rsdinamico1 = cn.Execute(sentencia)
                sentencia = "SELECT pasillo,estanteria from estanterias Where id_estanteria=" & rsdinamico1.Fields(0).Value
                rsdinamico1 = cn.Execute(sentencia)



                elemento.SubItems.Add(rsdinamico1.Fields(0).Value.ToString)
                elemento.SubItems.Add(rsdinamico1.Fields(1).Value.ToString)
                
                elemento.SubItems.Add(rsdinamico.Fields(1).Value.ToString)
                ListView2.Items.Add(elemento)
                rsdinamico.MoveNext()
            Loop

            rsdinamico1.Close()
        End If
        rsdinamico.Close()



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        Button1.Visible = False
        button2.Visible = False

        PrintForm1.Print()
        Button1.Visible = True
        button2.Visible = True
    End Sub
End Class