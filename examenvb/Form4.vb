Public Class Form4
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
            sentencia = "Select * from lectores Where nombre_lector like '" & nombre.Text & "%'"
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
                    elemento.SubItems.Add(rsdinamico.Fields(2).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(1).Value.ToString)
                    elemento.SubItems.Add(rsdinamico.Fields(3).Value.ToString)

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

                telefono.Text = i.SubItems(2).Text
                dni.Text = i.SubItems(3).Text



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
        If telefono.Text = "" Then
            cadena = cadena & "-Teléfono " & vbCrLf
            bandera = 1
        End If
        If dni.Text = "" Then
            cadena = cadena & "-DNI" & vbCrLf
            bandera = 1
        End If

        
        If bandera = 1 Then
            MsgBox(cadena, , "Error")
            Exit Sub
        End If

        If codigo.Text = "" Then

            sentencia = "Insert into lectores (nombre_lector,tlf_lector,dni_lector) Values('" & nombre.Text & "','" & telefono.Text & "','" & dni.Text & "')"
            cn.Execute(sentencia)
            MsgBox("Lector añadido con exito")
        Else
            sentencia = "update lectores  set nombre_lector='" & nombre.Text & "',tlf_lector='" & telefono.Text & "',dni_lector='" & dni.Text & "'where id_lector= " & codigo.Text
            cn.Execute(sentencia)
            MsgBox("Lector modificado con exito")
            nombre.ResetText()
            telefono.ResetText()
            codigo.ResetText()
            dni.ResetText()


        End If

    End Sub

    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        nombre.ResetText()
        telefono.ResetText()
        codigo.ResetText()
        dni.ResetText()

    End Sub


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class