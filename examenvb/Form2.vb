Public Class Form2
    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim i As ListViewItem
    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()

    End Sub

    Private Sub nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nombre.TextChanged
        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from autores Where nombre_autor like '" & nombre.Text & "%'"
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
                modificar = 1
                codigo.Text = i.Text


                nombre.Text = i.SubItems(1).Text

                nacionalidad.Text = i.SubItems(2).Text


                'i.BackColor = Color.BlueViolet


            Next

        End If
    End Sub

    Private Sub guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click
        Dim bandera As Integer = 0
        Dim cadena As String
        cadena = "Falta:" & vbCrLf & vbCrLf
        If nombre.Text = "" Then
            cadena = cadena & "-Nombre" & vbCrLf
            bandera = 1
        End If
        If nacionalidad.Text = "" Then
            cadena = cadena & "-Nacionalidad" & vbCrLf
            bandera = 1
        End If
        If bandera = 1 Then
            MsgBox(cadena, , "Error")
            Exit Sub
        End If


        If codigo.Text = "" Then

            sentencia = "Insert into autores (nombre_autor,nacionalidad_autor) Values('" & nombre.Text & "','" & nacionalidad.Text & "')"
            cn.Execute(sentencia)
            MsgBox("Autor añadido con exito")
        Else
            sentencia = "update autores set nombre_autor='" & nombre.Text & "',nacionalidad_autor='" & nacionalidad.Text & "'where id_autor=" & codigo.Text
            cn.Execute(sentencia)
            MsgBox("Autor modificado con exito")
            nombre.ResetText()
            nacionalidad.ResetText()
            codigo.ResetText()

        End If

    End Sub

    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        nombre.ResetText()
        nacionalidad.ResetText()
        codigo.ResetText()

    End Sub

    
End Class