Public Class Form6
    Dim actuales As Integer

    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim modificar2 As Integer = 0
    Dim modificar3 As Integer = 0
    Dim i As ListViewItem
    Dim norepe As Integer = 0


    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()

    End Sub

    Private Sub nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles titulo.TextChanged

        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from libros Where titulo_libro like '" & titulo.Text & "%' ORDER BY (titulo_libro)"
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
                    elemento.SubItems.Add(rsdinamico.Fields(7).Value.ToString)
                    ListView1.Items.Add(elemento)
                    rsdinamico.MoveNext()


                Loop
            End If


            'cierre de rs para depurar errores
            rsdinamico.Close()
        End If
        'cierre if de la comprobacion de si estaba selecionado si ya 
        Call compruebarepe()
    End Sub



    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If ListView1.Items.Count > 0 Then


            For Each i As ListViewItem In ListView1.SelectedItems
                modificar = 1
                norepe = 1
                codigo.Text = i.Text


                titulo.Text = i.SubItems(1).Text
                estado.Text = i.SubItems(3).Text
                tema.Text = i.SubItems(2).Text
                autor.Text = i.SubItems(6).Text
                Editorial.Text = i.SubItems(5).Text
                ubicacion.Text = i.SubItems(7).Text
                isbn.Text = i.SubItems(8).Text
                copias.Text = i.SubItems(9).Text
                actuales = i.SubItems(9).Text
                'i.BackColor = Color.BlueViolet


            Next

        End If
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click
        Dim bandera As Integer = 0
        Dim cadena As String
        cadena = "Falta:" & vbCrLf & vbCrLf
        If titulo.Text = "" Then
            cadena = cadena & "-Titulo" & vbCrLf
            bandera = 1
        End If
        If autor.Text = "" Then
            cadena = cadena & "-Autor" & vbCrLf
            bandera = 1
        End If
        If ubicacion.Text = "" Then
            cadena = cadena & "-Ubicacion" & vbCrLf
            bandera = 1
        End If
        If Editorial.Text = "" Then
            cadena = cadena & "-Editorial" & vbCrLf
            bandera = 1
        End If
        If estado.Text = "" Then
            cadena = cadena & "-Estado" & vbCrLf
            bandera = 1
        End If
        If isbn.Text = "" Then
            cadena = cadena & "-ISBN" & vbCrLf
            bandera = 1
        End If
        If copias.Text = "" Then
            cadena = cadena & "-Copias" & vbCrLf
            bandera = 1
        End If

        If bandera = 1 Then
            MsgBox(cadena, , "Error")
            Exit Sub
        End If

        norepe = 1
        modificar = 1
        modificar2 = 1
        If codigo.Text = "" Then

            sentencia = "Insert into libros (titulo_libro,tema_libro,estado,autor_libro,editorial_libro,isbn,copias) Values('" & titulo.Text & "','" & tema.Text & "','" & estado.Text & "','" & autor.Text & "','" & Editorial.Text & "','" & isbn.Text & "'," & copias.Text & ")"
            cn.Execute(sentencia)
            sentencia = "Select MAX(id_libro) From libros"
            rs = cn.Execute(sentencia)
            codigo.Text = rs.Fields(0).Value
            rs.Close()

            MsgBox("Libro añadido con exito")
        Else
            sentencia = "update Libros  set titulo_libro='" & titulo.Text & "',tema_libro='" & tema.Text & "',estado='" & estado.Text & "',autor_libro='" & autor.Text & "',editorial_libro='" & Editorial.Text & "',isbn='" & isbn.Text & "',copias=" & copias.Text & " where id_libro= " & codigo.Text
            cn.Execute(sentencia)
            ' sentencia = "DElETE FROM estante_libro where id_libro=" & codigo.Text
            ' cn.Execute(sentencia)
            MsgBox("Libro modificado con exito")


        End If
        contador = 0
        If actuales < copias.Text Then
            sentencia = "SELECT max(id_copia) from copias"
            rs = cn.Execute(sentencia)
            contador = rs.Fields(0).Value


            If copias.Text = actuales Then
                Exit Sub
            End If
            actuales = Val(copias.Text) - actuales
            contador2 = contador + actuales
            Do While (contador < contador2)
                contador = contador + 1
                sentencia = " Select * From estanterias WHERE id_estanteria=" & ubicacion.Text
                Try
                    rs = cn.Execute(sentencia)
                Catch ex As Exception
                    MsgBox("No hay sitio en la biblioteca porfabor instale mas estanterias se detuvo por la copia: " & contador)
                    Exit Do
                End Try
                sentencia = "Insert into copias (id_copia,id_libro,estado) VALUES(" & contador & "," & codigo.Text & ",'Disponible')"
                cn.Execute(sentencia)
                sentencia = "SELECT COUNT(id_estanteria) From estante_libro WHERE id_estanteria=" & ubicacion.Text
                rs = cn.Execute(sentencia)
                If rs.Fields(0).Value = 100 Then
                    ubicacion.Text = Val(ubicacion.Text) + 1
                    sentencia = " Select * From estanterias WHERE id_estanteria=" & ubicacion.Text
                    Try
                        rs = cn.Execute(sentencia)
                    Catch ex As Exception
                        MsgBox("No hay sitio en la biblioteca porfabor instale mas estanterias se detuvo por la copia: " & contador)
                        Exit Do
                    End Try
                End If
                sentencia = "Insert into estante_libro (id_libro,id_estanteria) VALUES(" & contador & "," & ubicacion.Text & ")"
                cn.Execute(sentencia)

            Loop




            rs.Close()
        End If

        titulo.ResetText()
        tema.ResetText()
        codigo.ResetText()
        autor.ResetText()
        Editorial.ResetText()
        ubicacion.ResetText()
        copias.ResetText()

        isbn.ResetText()
    End Sub

    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        modificar2 = 1
        modificar = 1
        contador = 0
        contador2 = 0
        actuales = 0


        copias.ResetText()
        ubicacion.ResetText()
        titulo.ResetText()
        tema.ResetText()
        codigo.ResetText()
        autor.ResetText()
        Editorial.ResetText()
        isbn.ResetText()
        norepe = 0
    End Sub

    Private Sub compruebarepe()
        Dim titulo1 As String
        Dim autor1 As String
        Dim editorial1 As String
        Dim umbral As String

        If norepe = 1 Then
            Exit Sub
        End If

        If ListView1.Items.Count > 0 Then


            For Each i As ListViewItem In ListView1.Items
                If isbn.Text = i.SubItems(8).Text.ToString Then
                    umbral = InputBox("Especifique Cuantas unidades de este libro desea de existencias a mostrar")
                    copias.Text = umbral
                    modificar = 1
                    norepe = 1
                    codigo.Text = i.Text


                    titulo.Text = i.SubItems(1).Text
                    estado.Text = i.SubItems(3).Text
                    tema.Text = i.SubItems(2).Text
                    autor.Text = i.SubItems(6).Text
                    Editorial.Text = i.SubItems(5).Text
                    ubicacion.Text = i.SubItems(7).Text
                    isbn.Text = i.SubItems(8).Text
                    Exit Sub


                End If
                '  modificar = 1
                titulo1 = i.SubItems(1).Text.ToString
                autor1 = i.SubItems(6).Text.ToString
                editorial1 = i.SubItems(5).Text.ToString
                If titulo.Text = titulo1 Then
                    If autor.Text = autor1 Then
                        If Editorial.Text = editorial1 Then
                           
                            umbral = InputBox("Tienes un mismo libro con ese titulo ,misma editorial y mismo Autor, deceas añadirle nuevas copias (S/N)")
                            If umbral = "S" Then
                                umbral = InputBox("Especifique Cuantas unidades de este libro desea de existencias")

                                modificar = 1
                                norepe = 1
                                codigo.Text = i.Text


                                titulo.Text = i.SubItems(1).Text
                                estado.Text = i.SubItems(3).Text
                                tema.Text = i.SubItems(2).Text
                                autor.Text = i.SubItems(6).Text
                                Editorial.Text = i.SubItems(5).Text
                                ubicacion.Text = i.SubItems(7).Text
                                isbn.Text = i.SubItems(8).Text
                                copias.Text = umbral
                            Else
                                MsgBox("Introduce datos nuevos")


                            End If

                        End If

                    End If
                End If



                'i.BackColor = Color.BlueViolet


            Next

        End If
    End Sub
  

    
    Private Sub buscautor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles buscautor.TextChanged
        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from autores Where nombre_autor like '" & buscautor.Text & "%'"
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
                    elemento.SubItems.Add(rsdinamico.Fields(1).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(2).Value.ToString)

                    ListView2.Items.Add(elemento)
                    rsdinamico.MoveNext()


                Loop
            End If


            'cierre de rs para depurar errores
            rsdinamico.Close()
        End If
        'cierre if de la comprobacion de si estaba selecionado si ya
    End Sub

    Private Sub pasillo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pasillo.TextChanged
        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from estanterias Where pasillo like '" & pasillo.Text & "%'"
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
                    sentencia = "SELECT COUNT(id_estanteria) From estante_libro WHERE id_estanteria=" & rsdinamico.Fields(2).Value
                    rs = cn.Execute(sentencia)
                    If rs.Fields(0).Value < 100 Then

                        elemento = New ListViewItem(rsdinamico.Fields(2).Value.ToString)
                        elemento.SubItems.Add(rsdinamico.Fields(0).Value.ToString)
                        elemento.SubItems.Add(rsdinamico.Fields(1).Value.ToString)

                        ListView4.Items.Add(elemento)

                    End If
                    rsdinamico.MoveNext()
                    rs.Close()


                Loop
            End If


            'cierre de rs para depurar errores
            rsdinamico.Close()
        End If
    End Sub

    Private Sub nombre_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles nombre.TextChanged
        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from editorial Where nombre_editorial like '" & nombre.Text & "%'"
            cn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rsdinamico.LockType = ADODB.LockTypeEnum.adLockOptimistic
            rsdinamico.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
            rsdinamico = cn.Execute(sentencia)
            '  ListView1.Clear()
            ListView3.Items.Clear()


            ListView3.FullRowSelect = True

            'codigo del items
            If Not rsdinamico.EOF And Not rsdinamico.BOF Then


                rsdinamico.MoveFirst()

                Do While (Not rsdinamico.EOF)


                    elemento = New ListViewItem(rsdinamico.Fields(0).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(1).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(2).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(3).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(4).Value.ToString)
                    ListView3.Items.Add(elemento)
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
                '  modificar = 1
                autor.Text = i.Text



                'i.BackColor = Color.BlueViolet


            Next

        End If
    End Sub

    Private Sub ListView4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView4.Click
        If ListView4.Items.Count > 0 Then


            For Each i As ListViewItem In ListView4.SelectedItems
                ' modificar = 1
                ubicacion.Text = i.Text


                'i.BackColor = Color.BlueViolet


            Next
        End If

    End Sub

    Private Sub ListView3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView3.Click
        If ListView3.Items.Count > 0 Then


            For Each i As ListViewItem In ListView3.SelectedItems
                ' modificar = 1
                Editorial.Text = i.Text


                'i.BackColor = Color.BlueViolet


            Next
        End If
    End Sub

   

    Private Sub autor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autor.TextChanged
        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar2 = 1 Then
            modificar2 = 0
        Else
            sentencia = "Select * from libros Where autor_libro=" & autor.Text & " ORDER BY (titulo_libro)"
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
        Call compruebarepe()
    End Sub

    Private Sub Editorial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Editorial.TextChanged
        Call compruebarepe()
    End Sub

    Private Sub tema_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tema.KeyPress
        Select Case e.KeyChar
            Case ""
            Case Else
                ' e.KeyChar = ChrW(0)
                e.Handled = True


        End Select
    End Sub

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
                    elemento.SubItems.Add(rsdinamico.Fields(7).Value.ToString)
                    ListView1.Items.Add(elemento)
                    rsdinamico.MoveNext()


                Loop
            End If


            'cierre de rs para depurar errores
            rsdinamico.Close()
        End If
        'cierre if de la comprobacion de si estaba selecionado si ya 
    End Sub

    Private Sub isbn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles isbn.KeyPress
        Select Case e.KeyChar
            Case ChrW(48) To ChrW(57), ChrW(8)
            Case Else
                ' e.KeyChar = ChrW(0)
                e.Handled = True


        End Select
    End Sub

    Private Sub isbn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles isbn.TextChanged
     
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from libros Where isbn like '" & isbn.Text & "%' ORDER BY (titulo_libro)"
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
                    elemento.SubItems.Add(rsdinamico.Fields(7).Value.ToString)
                    ListView1.Items.Add(elemento)
                    rsdinamico.MoveNext()


                Loop
            End If


            'cierre de rs para depurar errores
            rsdinamico.Close()
        End If
        'cierre if de la comprobacion de si estaba selecionado si ya 
        Call compruebarepe()
    End Sub

    Private Sub copias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles copias.KeyPress
        Select Case e.KeyChar
            Case ChrW(48) To ChrW(57), ChrW(8)
            Case Else
                ' e.KeyChar = ChrW(0)
                e.Handled = True


        End Select
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles estado.KeyPress
        Select Case e.KeyChar
            Case ""
            Case Else
                ' e.KeyChar = ChrW(0)
                e.Handled = True


        End Select
    End Sub
End Class