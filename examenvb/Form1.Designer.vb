<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.LibrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditorialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LectoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReservasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UbicacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SolicitudDeLibrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ListadoDeCopiasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InformesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DiarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MensualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NoDevueltosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LibrosPorTemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Chocolate
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LibrosToolStripMenuItem, Me.EditorialesToolStripMenuItem, Me.AutoresToolStripMenuItem, Me.LectoresToolStripMenuItem, Me.ReservasToolStripMenuItem, Me.DevolucionesToolStripMenuItem, Me.UbicacionesToolStripMenuItem, Me.SolicitudDeLibrosToolStripMenuItem, Me.ToolStripMenuItem2, Me.ListadoDeCopiasToolStripMenuItem, Me.InformesToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(984, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LibrosToolStripMenuItem
        '
        Me.LibrosToolStripMenuItem.Name = "LibrosToolStripMenuItem"
        Me.LibrosToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.LibrosToolStripMenuItem.Text = "Libros"
        '
        'EditorialesToolStripMenuItem
        '
        Me.EditorialesToolStripMenuItem.Name = "EditorialesToolStripMenuItem"
        Me.EditorialesToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.EditorialesToolStripMenuItem.Text = "Editoriales"
        '
        'AutoresToolStripMenuItem
        '
        Me.AutoresToolStripMenuItem.Name = "AutoresToolStripMenuItem"
        Me.AutoresToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.AutoresToolStripMenuItem.Text = "Autores"
        '
        'LectoresToolStripMenuItem
        '
        Me.LectoresToolStripMenuItem.Name = "LectoresToolStripMenuItem"
        Me.LectoresToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.LectoresToolStripMenuItem.Text = "Lectores"
        '
        'ReservasToolStripMenuItem
        '
        Me.ReservasToolStripMenuItem.Name = "ReservasToolStripMenuItem"
        Me.ReservasToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.ReservasToolStripMenuItem.Text = "Reservas"
        '
        'DevolucionesToolStripMenuItem
        '
        Me.DevolucionesToolStripMenuItem.Name = "DevolucionesToolStripMenuItem"
        Me.DevolucionesToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.DevolucionesToolStripMenuItem.Text = "Devoluciones"
        '
        'UbicacionesToolStripMenuItem
        '
        Me.UbicacionesToolStripMenuItem.Name = "UbicacionesToolStripMenuItem"
        Me.UbicacionesToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.UbicacionesToolStripMenuItem.Text = "Ubicaciones"
        '
        'SolicitudDeLibrosToolStripMenuItem
        '
        Me.SolicitudDeLibrosToolStripMenuItem.Name = "SolicitudDeLibrosToolStripMenuItem"
        Me.SolicitudDeLibrosToolStripMenuItem.Size = New System.Drawing.Size(116, 20)
        Me.SolicitudDeLibrosToolStripMenuItem.Text = "Solicitud de libros "
        '
        'ListadoDeCopiasToolStripMenuItem
        '
        Me.ListadoDeCopiasToolStripMenuItem.Name = "ListadoDeCopiasToolStripMenuItem"
        Me.ListadoDeCopiasToolStripMenuItem.Size = New System.Drawing.Size(110, 20)
        Me.ListadoDeCopiasToolStripMenuItem.Text = "Listado de copias"
        '
        'InformesToolStripMenuItem
        '
        Me.InformesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiarioToolStripMenuItem, Me.MensualToolStripMenuItem, Me.NoDevueltosToolStripMenuItem, Me.LibrosPorTemaToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.InformesToolStripMenuItem.Name = "InformesToolStripMenuItem"
        Me.InformesToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.InformesToolStripMenuItem.Text = "Informes"
        '
        'DiarioToolStripMenuItem
        '
        Me.DiarioToolStripMenuItem.Name = "DiarioToolStripMenuItem"
        Me.DiarioToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DiarioToolStripMenuItem.Text = "Diario"
        '
        'MensualToolStripMenuItem
        '
        Me.MensualToolStripMenuItem.Name = "MensualToolStripMenuItem"
        Me.MensualToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.MensualToolStripMenuItem.Text = "Mensual"
        '
        'NoDevueltosToolStripMenuItem
        '
        Me.NoDevueltosToolStripMenuItem.Name = "NoDevueltosToolStripMenuItem"
        Me.NoDevueltosToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.NoDevueltosToolStripMenuItem.Text = "No devueltos"
        '
        'LibrosPorTemaToolStripMenuItem
        '
        Me.LibrosPorTemaToolStripMenuItem.Name = "LibrosPorTemaToolStripMenuItem"
        Me.LibrosPorTemaToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.LibrosPorTemaToolStripMenuItem.Text = "Libros por tema"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.ToolStripMenuItem1.Text = "Estanterias"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(119, 20)
        Me.ToolStripMenuItem2.Text = "Informe Prestamos"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Chocolate
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 368)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(263, 17)
        Me.ToolStripStatusLabel2.Text = "Examen VB, Realizado por: David García Martínez"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.image016
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(984, 390)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Aplicacion de bibioteca"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents LibrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditorialesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LectoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReservasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UbicacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SolicitudDeLibrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MensualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoDevueltosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LibrosPorTemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DevolucionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListadoDeCopiasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem

End Class
