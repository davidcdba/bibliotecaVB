Public Class Form7

    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim i As ListViewItem
    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()

    End Sub

    Private Sub nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles titulo.TextChanged

        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from libros Where titulo_libro like '" & titulo.Text & "%'"
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
        End If
        'cierre if de la comprobacion de si estaba selecionado si ya 
    End Sub



    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If ListView1.Items.Count > 0 Then


            For Each i As ListViewItem In ListView1.SelectedItems
                'sentencia = i.SubItems(3).Text
                If i.SubItems(3).Text = "Disponible" Then

                    ' modificar = 1
                    libro.Text = i.Text
                    sentencia = "SELECT id_copia FROM copias WHERE id_libro=" & i.Text & " and estado='Disponible'"

                    Try
                        rs = cn.Execute(sentencia)
                        libro.Text = rs.Fields(0).Value
                        rs.Close()

                    Catch ex As Exception
                        MsgBox("No hay disponibles copias ")
                    End Try



                    i.BackColor = Color.BlueViolet
                Else
                    MsgBox("Este libro Se encuentra prestado o no disponible")

                End If

            Next

        End If
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click
        Dim bandera As Integer = 0
        Dim cadena As String
        cadena = "Falta:" & vbCrLf & vbCrLf
        If libro.Text = "" Then
            cadena = cadena & "-Libro" & vbCrLf
            bandera = 1
        End If
        If lector.Text = "" Then
            cadena = cadena & "-Lector" & vbCrLf
            bandera = 1
        End If
        If retirada.Text = "" Then
            cadena = cadena & "-Fecha retirada" & vbCrLf
            bandera = 1
        End If
      
        If bandera = 1 Then
            MsgBox(cadena, , "Error")
            Exit Sub
        End If
        If codigo.Text = "" Then

            sentencia = "Insert into prestamos (id_libro,id_lector,fecha_salida,limite_devolucion) Values(" & libro.Text & "," & lector.Text & ",'" & retirada.Text & "','" & entrega.Text & "')"
            cn.Execute(sentencia)
            sentencia = "update copias set estado='Prestado' WHERE id_copia=" & libro.Text
            cn.Execute(sentencia)


            MsgBox("Reseva añadida con exito")
        Else
            If entrega.Text = "" Then
                MsgBox("Introduce la fecha de devolucion")
            Else

                sentencia = "update prestamos  set fecha_entrega='" & entrega.Text & "' where id_prestamo= " & codigo.Text
                cn.Execute(sentencia)
                sentencia = "update copias set estado='Disponible' WHERE id_copia=" & libro.Text
                cn.Execute(sentencia)
                MsgBox("Prestamo modificado con exito")
            End If

        End If
        modificar = 1
            entrega.ResetText()
            lector.ResetText()
        titulo.ReadOnly = False
        pasillo.ReadOnly = False
        ListView3.Items.Clear()


        codigo.ResetText()
        libro.ResetText()
        retirada.ResetText()

    End Sub

    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        titulo.ResetText()
        entrega.ResetText()
        lector.ResetText()
        titulo.ReadOnly = False
        pasillo.ReadOnly = False
        pasillo.ResetText()



        codigo.ResetText()
        libro.ResetText()
        retirada.ResetText()
    End Sub


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        retirada.Text = DateTimePicker1.Value.ToString("yyyy/MM/dd")

    End Sub


   

    Private Sub pasillo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pasillo.TextChanged
        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from lectores Where dni_lector like '" & pasillo.Text & "%'"
            cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rsdinamico.LockType = ADODB.LockTypeEnum.adLockOptimistic
            rsdinamico.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
            rsdinamico = cn.Execute(sentencia)
            '  ListView1.Clear()
            ListView2.Items.Clear()


            ListView2.FullRowSelect = True
            modificar = 1
            'codigo del items
            If Not rsdinamico.EOF And Not rsdinamico.BOF Then


                rsdinamico.MoveFirst()

                Do While (Not rsdinamico.EOF)


                    elemento = New ListViewItem(rsdinamico.Fields(0).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(2).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(1).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(3).Value.ToString)

                    ListView2.Items.Add(elemento)
                    rsdinamico.MoveNext()


                Loop
            End If


            'cierre de rs para depurar errores
            rsdinamico.Close()
        End If
        'cierre if de la comprobacion de si estaba selecionado si ya 
    End Sub

   

    
    Private Sub ListView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.Click
        If ListView2.Items.Count > 0 Then


            For Each i As ListViewItem In ListView2.SelectedItems
                ' modificar = 1
                lector.Text = i.Text


                i.BackColor = Color.BlueViolet


            Next
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        retirada.Text = DateTimePicker1.Value.ToString("yyyy/MM/dd")
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' entrega.Text = DateTimePicker2.Value.ToString("yyyy/MM/dd")
    End Sub

  
    Private Sub lector_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lector.TextChanged
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from prestamos Where id_lector like '" & lector.Text & "%'"
            cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            'rsdinamico1.LockType = ADODB.LockTypeEnum.adLockOptimistic
            'rsdinamico1.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
            rsdinamico1 = cn.Execute(sentencia)
            '  ListView1.Clear()
            ListView3.Items.Clear()


            ListView3.FullRowSelect = True

            'codigo del items
            If Not rsdinamico1.EOF And Not rsdinamico1.BOF Then


                rsdinamico1.MoveFirst()


                Do While (Not rsdinamico1.EOF)


                    elemento = New ListViewItem(rsdinamico1.Fields(4).Value.ToString)
                    elemento.SubItems.Add(rsdinamico1.Fields(0).Value.ToString)
                    elemento.SubItems.Add(rsdinamico1.Fields(1).Value.ToString)
                    elemento.SubItems.Add(rsdinamico1.Fields(2).Value.ToString)
                    elemento.SubItems.Add(rsdinamico1.Fields(3).Value.ToString)
                    elemento.SubItems.Add(rsdinamico1.Fields(4).Value.ToString)
                    ListView3.Items.Add(elemento)
                    If rsdinamico1.Fields(3).Value.ToString = "" Then
                        modificar = 1
                        codigo.Text = rsdinamico1.Fields(4).Value.ToString
                        ' lector.Text = rsdinamico1.Fields(0).Value.ToString
                        libro.Text = rsdinamico1.Fields(0).Value.ToString
                        retirada.Text = rsdinamico1.Fields(2).Value.ToString
                        entrega.Text = rsdinamico1.Fields(3).Value.ToString
                        '   titulo.ReadOnly = True
                        pasillo.ReadOnly = True
                        ListView2.Items.Clear()
                        'ListView1.Items.Clear()
                        MsgBox("Este Lector ya tiene un libro debe devolverlo antes de crear uno nuevo")

                        Exit Sub

                    End If
                    rsdinamico1.MoveNext()


                Loop
            End If


            'cierre de rs para depurar errores
            rsdinamico1.Close()
        End If
        'cierre if de la comprobacion de si estaba selecionado si ya 
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub retirada_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retirada.TextChanged
        entrega.Text = DateTime.Today.AddDays(+10).ToString("yyyy/MM/dd")

    End Sub
End Class