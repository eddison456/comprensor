namespace CompresorHuffman
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comprimirBtn = new System.Windows.Forms.Button();
            this.abrirRecuadro = new System.Windows.Forms.OpenFileDialog();
            this.abrirArchivo = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.textoArchivoSelec = new System.Windows.Forms.Label();
            this.descomprimirBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.archivoGeneradoLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.archivoGeneradoTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.abrirArchivoGenerado = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textoEntradaInput = new System.Windows.Forms.RichTextBox();
            this.textoSalidaInput = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comprimirBtn
            // 
            this.comprimirBtn.BackColor = System.Drawing.SystemColors.Control;
            this.comprimirBtn.Enabled = false;
            this.comprimirBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comprimirBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comprimirBtn.Location = new System.Drawing.Point(162, 73);
            this.comprimirBtn.Margin = new System.Windows.Forms.Padding(0);
            this.comprimirBtn.Name = "comprimirBtn";
            this.comprimirBtn.Size = new System.Drawing.Size(98, 29);
            this.comprimirBtn.TabIndex = 1;
            this.comprimirBtn.Text = "Comprimir";
            this.comprimirBtn.UseVisualStyleBackColor = false;
            this.comprimirBtn.Click += new System.EventHandler(this.comprimirBtn_Click);
            // 
            // abrirRecuadro
            // 
            this.abrirRecuadro.FileName = "archivoSeleccionado";
            this.abrirRecuadro.Filter = "Archivo (*.txt;*.cositas)|*.txt;*.cositas|Archivo txt (*.txt)|*.txt|Archivo compr" +
    "imido (*.cositas)|*.cositas|All files (*.*)|*.*";
            this.abrirRecuadro.FileOk += new System.ComponentModel.CancelEventHandler(this.seleccionarArchivo_FileOk);
            // 
            // abrirArchivo
            // 
            this.abrirArchivo.Location = new System.Drawing.Point(19, 36);
            this.abrirArchivo.Name = "abrirArchivo";
            this.abrirArchivo.Size = new System.Drawing.Size(137, 23);
            this.abrirArchivo.TabIndex = 0;
            this.abrirArchivo.Text = "Seleccionar arhivo";
            this.abrirArchivo.UseVisualStyleBackColor = true;
            this.abrirArchivo.Click += new System.EventHandler(this.seleccionarArchivo_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(25, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(129, 26);
            this.title.TabIndex = 4;
            this.title.Text = "Compresor";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textoArchivoSelec
            // 
            this.textoArchivoSelec.AutoSize = true;
            this.textoArchivoSelec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoArchivoSelec.Location = new System.Drawing.Point(0, 3);
            this.textoArchivoSelec.Name = "textoArchivoSelec";
            this.textoArchivoSelec.Size = new System.Drawing.Size(0, 17);
            this.textoArchivoSelec.TabIndex = 5;
            this.textoArchivoSelec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descomprimirBtn
            // 
            this.descomprimirBtn.BackColor = System.Drawing.SystemColors.Control;
            this.descomprimirBtn.Enabled = false;
            this.descomprimirBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descomprimirBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.descomprimirBtn.Location = new System.Drawing.Point(301, 73);
            this.descomprimirBtn.Margin = new System.Windows.Forms.Padding(0);
            this.descomprimirBtn.Name = "descomprimirBtn";
            this.descomprimirBtn.Size = new System.Drawing.Size(123, 29);
            this.descomprimirBtn.TabIndex = 6;
            this.descomprimirBtn.Text = "Descomprimir";
            this.descomprimirBtn.UseVisualStyleBackColor = false;
            this.descomprimirBtn.Click += new System.EventHandler(this.descomprimirBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.archivoGeneradoTitle);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.descomprimirBtn);
            this.groupBox1.Controls.Add(this.abrirArchivo);
            this.groupBox1.Controls.Add(this.comprimirBtn);
            this.groupBox1.Location = new System.Drawing.Point(30, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 155);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.archivoGeneradoLbl);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(162, 113);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(547, 23);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // archivoGeneradoLbl
            // 
            this.archivoGeneradoLbl.AutoSize = true;
            this.archivoGeneradoLbl.Location = new System.Drawing.Point(0, 7);
            this.archivoGeneradoLbl.Name = "archivoGeneradoLbl";
            this.archivoGeneradoLbl.Size = new System.Drawing.Size(0, 13);
            this.archivoGeneradoLbl.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 5;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // archivoGeneradoTitle
            // 
            this.archivoGeneradoTitle.AutoSize = true;
            this.archivoGeneradoTitle.Location = new System.Drawing.Point(63, 120);
            this.archivoGeneradoTitle.Name = "archivoGeneradoTitle";
            this.archivoGeneradoTitle.Size = new System.Drawing.Size(97, 13);
            this.archivoGeneradoTitle.TabIndex = 8;
            this.archivoGeneradoTitle.Text = "Archivo generado: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textoArchivoSelec);
            this.groupBox2.Location = new System.Drawing.Point(162, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 23);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // abrirArchivoGenerado
            // 
            this.abrirArchivoGenerado.BackColor = System.Drawing.SystemColors.Control;
            this.abrirArchivoGenerado.Enabled = false;
            this.abrirArchivoGenerado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirArchivoGenerado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.abrirArchivoGenerado.Location = new System.Drawing.Point(297, 412);
            this.abrirArchivoGenerado.Margin = new System.Windows.Forms.Padding(0);
            this.abrirArchivoGenerado.Name = "abrirArchivoGenerado";
            this.abrirArchivoGenerado.Size = new System.Drawing.Size(199, 29);
            this.abrirArchivoGenerado.TabIndex = 9;
            this.abrirArchivoGenerado.Text = "Abrir archivo generado";
            this.abrirArchivoGenerado.UseVisualStyleBackColor = false;
            this.abrirArchivoGenerado.Click += new System.EventHandler(this.abrirArchivoGenerado_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textoSalidaInput);
            this.groupBox3.Controls.Add(this.textoEntradaInput);
            this.groupBox3.Location = new System.Drawing.Point(30, 233);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(735, 170);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Salida";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(30, 210);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(735, 17);
            this.progressBar.TabIndex = 2;
            // 
            // textoEntradaInput
            // 
            this.textoEntradaInput.Location = new System.Drawing.Point(19, 19);
            this.textoEntradaInput.Name = "textoEntradaInput";
            this.textoEntradaInput.ReadOnly = true;
            this.textoEntradaInput.Size = new System.Drawing.Size(326, 135);
            this.textoEntradaInput.TabIndex = 0;
            this.textoEntradaInput.Text = "";
            // 
            // textoSalidaInput
            // 
            this.textoSalidaInput.Location = new System.Drawing.Point(383, 19);
            this.textoSalidaInput.Name = "textoSalidaInput";
            this.textoSalidaInput.ReadOnly = true;
            this.textoSalidaInput.Size = new System.Drawing.Size(326, 135);
            this.textoSalidaInput.TabIndex = 1;
            this.textoSalidaInput.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = ">>";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.abrirArchivoGenerado);
            this.Controls.Add(this.title);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Compresor de cositas";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button comprimirBtn;
        private System.Windows.Forms.OpenFileDialog abrirRecuadro;
        private System.Windows.Forms.Button abrirArchivo;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label textoArchivoSelec;
        private System.Windows.Forms.Button descomprimirBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label archivoGeneradoLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label archivoGeneradoTitle;
        private System.Windows.Forms.Button abrirArchivoGenerado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textoSalidaInput;
        private System.Windows.Forms.RichTextBox textoEntradaInput;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

