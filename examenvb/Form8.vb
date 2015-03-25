Public Class Form8
    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim i As ListViewItem
    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()

    End Sub

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Comprueba si se ha se lecionado anterior mente para evitar el que se recarge sin control
        If modificar = 1 Then
            modificar = 0
        Else
            sentencia = "Select * from editorial "
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



                nombre.Text = i.SubItems(1).Text

                direccion.Text = i.SubItems(2).Text
                Localidad.Text = i.SubItems(3).Text
                cp.Text = i.SubItems(4).Text


                'i.BackColor = Color.BlueViolet


            Next

        End If
    End Sub

    Private Sub iprimirC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iprimirC.Click
        salir.Visible = False
        imprimirS.Visible = False
        iprimirC.Visible = False
        ListView1.Visible = False
        TextBox1.BorderStyle = BorderStyle.None
        PrintForm1.Print()
        salir.Visible = True
        imprimirS.Visible = True
        iprimirC.Visible = True
        ListView1.Visible = True
        TextBox1.BorderStyle = BorderStyle.Fixed3D

    End Sub

    Private Sub imprimirS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imprimirS.Click
        salir.Visible = False
        imprimirS.Visible = False
        iprimirC.Visible = False
        ListView1.Visible = False
        TextBox1.Visible = False

        PrintForm1.Print()
        salir.Visible = True
        imprimirS.Visible = True
        iprimirC.Visible = True
        ListView1.Visible = True
        TextBox1.Visible = True

    End Sub
End Class