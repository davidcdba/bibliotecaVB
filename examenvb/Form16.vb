Public Class Form16
    Dim elemento As ListViewItem
    Dim modificar As Integer = 0
    Dim modificar2 As Integer = 0
    Dim compru As String
 
    Dim i As ListViewItem
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        Button1.Visible = False
        button2.Visible = False

        PrintForm1.Print()
        Button1.Visible = True
        button2.Visible = True
    End Sub

    Private Sub Form16_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sentencia = "Select * from prestamos ORDER BY (id_lector)"
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
                If compru = rsdinamico1.Fields(1).Value.ToString Then

                    elemento = New ListViewItem(" ")
                    elemento.SubItems.Add(" ")
                Else

                    compru = rsdinamico1.Fields(1).Value.ToString
                    elemento = New ListViewItem(rsdinamico1.Fields(1).Value.ToString)
                    sentencia = "SELECT nombre_lector FROM lectores WHERE id_lector=" & rsdinamico1.Fields(1).Value.ToString
                    rs = cn.Execute(sentencia)
                    elemento.SubItems.Add(rs.Fields(0).Value.ToString)

                    rs.Close()
                End If
                elemento.SubItems.Add(rsdinamico1.Fields(1).Value.ToString)
                elemento.SubItems.Add(rsdinamico1.Fields(2).Value.ToString)
                elemento.SubItems.Add(rsdinamico1.Fields(3).Value.ToString)
                elemento.SubItems.Add(rsdinamico1.Fields(4).Value.ToString)
                ListView3.Items.Add(elemento)

                rsdinamico1.MoveNext()


            Loop
        End If


        'cierre de rs para depurar errores
        rsdinamico1.Close()
    End Sub
End Class