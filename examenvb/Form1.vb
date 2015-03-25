Public Class Form1
    Dim hora As String
    Dim dia As String



    Private Sub LibrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibrosToolStripMenuItem.Click
        Form6.MdiParent = Me
        Form6.Show()

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        End

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConexionDB()
        ToolStripStatusLabel1.Text = TimeOfDay
        'Lanza el listado mensual
        dia = Format(Now, "dd")
        If dia = "01" Then
            Form10.Show()


        End If
    End Sub

    Private Sub AutoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoresToolStripMenuItem.Click
        Form2.MdiParent = Me
        Form2.Show()

    End Sub

    Private Sub EditorialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditorialesToolStripMenuItem.Click
        Form3.MdiParent = Me
        Form3.Show()

    End Sub

    Private Sub LectoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LectoresToolStripMenuItem.Click
        Form4.MdiParent = Me
        Form4.Show()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = TimeOfDay
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        hora = TimeOfDay
        If hora = "19:30:00" Then
            Form9.MdiParent = Me
            Form9.Show()


        End If

    End Sub

    Private Sub UbicacionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbicacionesToolStripMenuItem.Click
        Form5.MdiParent = Me
        Form5.Show()

    End Sub

    Private Sub ReservasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservasToolStripMenuItem.Click

        Form7.MdiParent = Me
        Form7.Show()

    End Sub

    Private Sub SolicitudDeLibrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SolicitudDeLibrosToolStripMenuItem.Click
        Form8.MdiParent = Me
        Form8.Show()

    End Sub

    Private Sub DiarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiarioToolStripMenuItem.Click
        Form9.MdiParent = Me
        Form9.Show()

    End Sub

    Private Sub MensualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MensualToolStripMenuItem.Click
        Form10.MdiParent = Me
        Form10.Show()

    End Sub

    Private Sub NoDevueltosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoDevueltosToolStripMenuItem.Click
        Form11.MdiParent = Me
        Form11.Show()

    End Sub

    Private Sub LibrosPorTemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibrosPorTemaToolStripMenuItem.Click
        Form12.MdiParent = Me
        Form12.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Form13.MdiParent = Me
        Form13.Show()
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevolucionesToolStripMenuItem.Click

        Form14.MdiParent = Me
        Form14.Show()


    End Sub

    Private Sub ListadoDeCopiasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoDeCopiasToolStripMenuItem.Click

        Form15.MdiParent = Me
        Form15.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Form16.MdiParent = Me
        Form16.Show()
    End Sub
End Class
