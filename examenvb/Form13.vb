Public Class Form13
    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim modificar2 As Integer = 0
    Dim estan As Integer = 0
    Dim cuenta As Integer = 0
    Dim i As ListViewItem
    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        Me.Close()

    End Sub

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sentencia = "Select * from estanterias "
        cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rsdinamico.LockType = ADODB.LockTypeEnum.adLockOptimistic
        rsdinamico.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
        rsdinamico = cn.Execute(sentencia)
        '  ListView1.Clear()
        ListView4.Items.Clear()


        ListView4.FullRowSelect = True

        'codigo del items
        If Not rsdinamico.EOF And Not rsdinamico.BOF Then


            rsdinamico.MoveFirst()

            Do While (Not rsdinamico.EOF)
                'Permite controlar cuantos libros hay en cada estante
                'sentencia = "SELECT COUNT(pasillo) From estanterias WHERE id_estanteria=" & rsdinamico.Fields(2).Value
                'rs = cn.Execute(sentencia)
                'If rs.Fields(0).Value < 100 Then

                elemento = New ListViewItem(rsdinamico.Fields(2).Value.ToString)
                elemento.SubItems.Add(rsdinamico.Fields(0).Value.ToString)
                elemento.SubItems.Add(rsdinamico.Fields(1).Value.ToString)

                ListView4.Items.Add(elemento)
                rsdinamico.MoveNext()
                'End If
                'rs.Close()


            Loop
        End If


        'cierre de rs para depurar errores
        rsdinamico.Close()
    End Sub

    Private Sub ListView4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView4.Click
        If ListView4.Items.Count > 0 Then


            For Each i As ListViewItem In ListView4.SelectedItems
                modificar = 1



                estan = i.SubItems(0).Text




                'i.BackColor = Color.BlueViolet


            Next

        End If
        sentencia = "SELECT id_libro from estante_libro WHERE id_estanteria=" & estan
        rs5 = cn.Execute(sentencia)
        'codigo del items
        If Not rs5.EOF And Not rs5.BOF Then


            rs5.MoveFirst()

            Do While (Not rs5.EOF)
                'rs5.MoveNext()


                sentencia = "Select * from libros WHERE id_libro=" & rs5.Fields(0).Value

                cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
               
                rsdinamico = cn.Execute(sentencia)
                '  ListView1.Clear()
                'ListView1.Items.Clear()


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
                rs5.MoveNext()

            Loop
            rsdinamico.Close()
            rs.Close()
            rs2.Close()
        End If


        'Ahora se cororearan los prestados
        If ListView1.Items.Count > 0 Then


            For Each i As ListViewItem In ListView1.Items

                cuenta = cuenta + 1


                If "Prestado" = i.SubItems(3).Text Then
                    i.BackColor = Color.Red

                Else
                    i.BackColor = Color.Cyan


                End If




                'i.BackColor = Color.BlueViolet


            Next

        End If
        cuenta = 100 - cuenta
        Label1.Text = "Hay libres " & cuenta

    End Sub

    Private Sub imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imprimir.Click
        imprimir.Visible = False
        Salir.Visible = False
        ListView4.Visible = False
        PrintForm1.Print()
        imprimir.Visible = True
        Salir.Visible = True
        ListView4.Visible = True
    End Sub
End Class