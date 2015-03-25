Public Class Form3
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
            sentencia = "Select * from editorial Where nombre_editorial like '" & nombre.Text & "%'"
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
                    elemento.SubItems.Add(rsdinamico.Fields(4).Value.ToString)
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

                direccion.Text = i.SubItems(2).Text
                localidad.Text = i.SubItems(3).Text
                cp.Text = i.SubItems(4).Text


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
        If direccion.Text = "" Then
            cadena = cadena & "-Dirección " & vbCrLf
            bandera = 1
        End If
        If localidad.Text = "" Then
            cadena = cadena & "-Localidad" & vbCrLf
            bandera = 1
        End If

        If cp.Text = "" Then
            cadena = cadena & "-Código Postal" & vbCrLf
            bandera = 1
        End If
        If bandera = 1 Then
            MsgBox(cadena, , "Error")
            Exit Sub
        End If

        If codigo.Text = "" Then

            sentencia = "Insert into editorial (nombre_editorial,direccion_editorial,localidad_editorial,CP_editorial) Values('" & nombre.Text & "','" & direccion.Text & "','" & localidad.Text & "','" & cp.Text & "')"
            cn.Execute(sentencia)
            MsgBox("Editorial añadido con exito")
        Else
            sentencia = "update editorial  set nombre_editorial='" & nombre.Text & "',direccion_editorial='" & direccion.Text & "',localidad_editorial='" & localidad.Text & "',CP_editorial='" & cp.Text & "' where id_editorial= " & codigo.Text
            cn.Execute(sentencia)
            MsgBox("Editorial modificado con exito")
            nombre.ResetText()
            direccion.ResetText()
            codigo.ResetText()
            localidad.ResetText()
            cp.ResetText()


        End If

    End Sub

    Private Sub nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nuevo.Click
        nombre.ResetText()
        direccion.ResetText()
        codigo.ResetText()
        localidad.ResetText()
        cp.ResetText()
    End Sub

   
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class