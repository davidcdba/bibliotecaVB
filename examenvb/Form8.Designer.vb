<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Me.iprimirC = New System.Windows.Forms.Button
        Me.imprimirS = New System.Windows.Forms.Button
        Me.salir = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.nombre = New System.Windows.Forms.Label
        Me.direccion = New System.Windows.Forms.Label
        Me.Localidad = New System.Windows.Forms.Label
        Me.cp = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.SuspendLayout()
        '
        'iprimirC
        '
        Me.iprimirC.Location = New System.Drawing.Point(466, 131)
        Me.iprimirC.Name = "iprimirC"
        Me.iprimirC.Size = New System.Drawing.Size(93, 23)
        Me.iprimirC.TabIndex = 0
        Me.iprimirC.Text = "Imprimir Carta"
        Me.iprimirC.UseVisualStyleBackColor = True
        '
        'imprimirS
        '
        Me.imprimirS.Location = New System.Drawing.Point(565, 131)
        Me.imprimirS.Name = "imprimirS"
        Me.imprimirS.Size = New System.Drawing.Size(116, 23)
        Me.imprimirS.TabIndex = 1
        Me.imprimirS.Text = "Imprimir Sobre"
        Me.imprimirS.UseVisualStyleBackColor = True
        '
        'salir
        '
        Me.salir.Location = New System.Drawing.Point(687, 131)
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(75, 23)
        Me.salir.TabIndex = 2
        Me.salir.Text = "Salir"
        Me.salir.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(460, 12)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(302, 116)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Id Editor"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Editorial"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Dirección"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Localidad"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "CP"
        '
        'nombre
        '
        Me.nombre.AutoSize = True
        Me.nombre.Location = New System.Drawing.Point(160, 61)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(42, 13)
        Me.nombre.TabIndex = 4
        Me.nombre.Text = "nombre"
        '
        'direccion
        '
        Me.direccion.AutoSize = True
        Me.direccion.Location = New System.Drawing.Point(160, 85)
        Me.direccion.Name = "direccion"
        Me.direccion.Size = New System.Drawing.Size(50, 13)
        Me.direccion.TabIndex = 4
        Me.direccion.Text = "direccion"
        '
        'Localidad
        '
        Me.Localidad.AutoSize = True
        Me.Localidad.Location = New System.Drawing.Point(160, 109)
        Me.Localidad.Name = "Localidad"
        Me.Localidad.Size = New System.Drawing.Size(49, 13)
        Me.Localidad.TabIndex = 4
        Me.Localidad.Text = "localidad"
        '
        'cp
        '
        Me.cp.AutoSize = True
        Me.cp.Location = New System.Drawing.Point(221, 109)
        Me.cp.Name = "cp"
        Me.cp.Size = New System.Drawing.Size(19, 13)
        Me.cp.TabIndex = 4
        Me.cp.Text = "cp"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(51, 205)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(596, 282)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Text = "Estimado..."
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(761, 512)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cp)
        Me.Controls.Add(Me.Localidad)
        Me.Controls.Add(Me.direccion)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.salir)
        Me.Controls.Add(Me.imprimirS)
        Me.Controls.Add(Me.iprimirC)
        Me.Name = "Form8"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SOlicitud a editoriares"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents iprimirC As System.Windows.Forms.Button
    Friend WithEvents imprimirS As System.Windows.Forms.Button
    Friend WithEvents salir As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents nombre As System.Windows.Forms.Label
    Friend WithEvents direccion As System.Windows.Forms.Label
    Friend WithEvents Localidad As System.Windows.Forms.Label
    Friend WithEvents cp As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
End Class
