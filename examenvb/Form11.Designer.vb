<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form11
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form11))
        Me.Label3 = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Titulo = New System.Windows.Forms.ColumnHeader
        Me.isbn = New System.Windows.Forms.ColumnHeader
        Me.carnet = New System.Windows.Forms.ColumnHeader
        Me.autor = New System.Windows.Forms.ColumnHeader
        Me.nombre = New System.Windows.Forms.ColumnHeader
        Me.dni = New System.Windows.Forms.ColumnHeader
        Me.tlf = New System.Windows.Forms.ColumnHeader
        Me.salida = New System.Windows.Forms.ColumnHeader
        Me.Imprimir = New System.Windows.Forms.Button
        Me.Salir = New System.Windows.Forms.Button
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(109, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(327, 25)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Informe Libros Fuera de plazo"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Titulo, Me.isbn, Me.carnet, Me.autor, Me.nombre, Me.dni, Me.tlf, Me.salida})
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 77)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(563, 286)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Titulo
        '
        Me.Titulo.Text = "Titulo"
        Me.Titulo.Width = 111
        '
        'isbn
        '
        Me.isbn.Text = "ISBN"
        '
        'carnet
        '
        Me.carnet.Text = "Carnet Lector"
        Me.carnet.Width = 79
        '
        'autor
        '
        Me.autor.DisplayIndex = 5
        Me.autor.Text = "Autor"
        '
        'nombre
        '
        Me.nombre.DisplayIndex = 3
        Me.nombre.Text = "Nombre"
        '
        'dni
        '
        Me.dni.DisplayIndex = 4
        Me.dni.Text = "DNI"
        '
        'tlf
        '
        Me.tlf.Text = "Teléfono"
        '
        'salida
        '
        Me.salida.Text = "Fecha de Salida"
        '
        'Imprimir
        '
        Me.Imprimir.Location = New System.Drawing.Point(34, 374)
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.Imprimir.TabIndex = 3
        Me.Imprimir.Text = "Imprimir"
        Me.Imprimir.UseVisualStyleBackColor = True
        '
        'Salir
        '
        Me.Salir.Location = New System.Drawing.Point(137, 374)
        Me.Salir.Name = "Salir"
        Me.Salir.Size = New System.Drawing.Size(75, 23)
        Me.Salir.TabIndex = 4
        Me.Salir.Text = "Salir"
        Me.Salir.UseVisualStyleBackColor = True
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(384, 374)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "*El plazo de devolución es de 10 dias"
        '
        'Form11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(587, 409)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Salir)
        Me.Controls.Add(Me.Imprimir)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Form11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe diario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Imprimir As System.Windows.Forms.Button
    Friend WithEvents Salir As System.Windows.Forms.Button
    Friend WithEvents Titulo As System.Windows.Forms.ColumnHeader
    Friend WithEvents isbn As System.Windows.Forms.ColumnHeader
    Friend WithEvents carnet As System.Windows.Forms.ColumnHeader
    Friend WithEvents nombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents dni As System.Windows.Forms.ColumnHeader
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents autor As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlf As System.Windows.Forms.ColumnHeader
    Friend WithEvents salida As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
