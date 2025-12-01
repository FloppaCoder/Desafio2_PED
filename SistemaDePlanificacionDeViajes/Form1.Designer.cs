namespace SistemaDePlanificacionDeViajes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtResultados = new TextBox();
            label6 = new Label();
            txtNuevoPeso = new TextBox();
            label5 = new Label();
            txtPeso = new TextBox();
            label4 = new Label();
            txtTiempoTotal = new TextBox();
            label3 = new Label();
            btnRutaCorta = new Button();
            btnBusquedaProfundidad = new Button();
            btnBusquedaAmplitud = new Button();
            cmbDestino = new ComboBox();
            label2 = new Label();
            cmbOrigen = new ComboBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtResultados);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtNuevoPeso);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtPeso);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtTiempoTotal);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnRutaCorta);
            groupBox1.Controls.Add(btnBusquedaProfundidad);
            groupBox1.Controls.Add(btnBusquedaAmplitud);
            groupBox1.Controls.Add(cmbDestino);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbOrigen);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 13F);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(888, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(349, 738);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Controles";
            // 
            // txtResultados
            // 
            txtResultados.BackColor = Color.FromArgb(0, 25, 38);
            txtResultados.Font = new Font("Segoe UI", 11F);
            txtResultados.ForeColor = Color.White;
            txtResultados.Location = new Point(27, 488);
            txtResultados.Multiline = true;
            txtResultados.Name = "txtResultados";
            txtResultados.Size = new Size(294, 230);
            txtResultados.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(27, 457);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 13;
            label6.Text = "Resultados:";
            // 
            // txtNuevoPeso
            // 
            txtNuevoPeso.BackColor = Color.FromArgb(0, 25, 38);
            txtNuevoPeso.Font = new Font("Segoe UI", 11F);
            txtNuevoPeso.ForeColor = Color.White;
            txtNuevoPeso.Location = new Point(146, 405);
            txtNuevoPeso.Name = "txtNuevoPeso";
            txtNuevoPeso.Size = new Size(175, 27);
            txtNuevoPeso.TabIndex = 12;
            txtNuevoPeso.KeyPress += txtNuevoPeso_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(27, 412);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 11;
            label5.Text = "Nuevo Peso:";
            // 
            // txtPeso
            // 
            txtPeso.BackColor = Color.FromArgb(0, 25, 38);
            txtPeso.Font = new Font("Segoe UI", 11F);
            txtPeso.ForeColor = Color.White;
            txtPeso.Location = new Point(146, 357);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(175, 27);
            txtPeso.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(27, 364);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 9;
            label4.Text = "Peso:";
            // 
            // txtTiempoTotal
            // 
            txtTiempoTotal.BackColor = Color.FromArgb(0, 25, 38);
            txtTiempoTotal.Font = new Font("Segoe UI", 11F);
            txtTiempoTotal.ForeColor = Color.White;
            txtTiempoTotal.Location = new Point(146, 312);
            txtTiempoTotal.Name = "txtTiempoTotal";
            txtTiempoTotal.Size = new Size(175, 27);
            txtTiempoTotal.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(27, 319);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 7;
            label3.Text = "Tiempo Total:";
            // 
            // btnRutaCorta
            // 
            btnRutaCorta.BackColor = Color.FromArgb(0, 25, 38);
            btnRutaCorta.BackgroundImageLayout = ImageLayout.None;
            btnRutaCorta.FlatStyle = FlatStyle.Flat;
            btnRutaCorta.Font = new Font("Segoe UI", 10F);
            btnRutaCorta.ForeColor = Color.White;
            btnRutaCorta.Location = new Point(27, 266);
            btnRutaCorta.Name = "btnRutaCorta";
            btnRutaCorta.Size = new Size(294, 30);
            btnRutaCorta.TabIndex = 6;
            btnRutaCorta.Text = "Ruta mas Corta";
            btnRutaCorta.UseVisualStyleBackColor = false;
            btnRutaCorta.Click += btnRutaCorta_Click;
            // 
            // btnBusquedaProfundidad
            // 
            btnBusquedaProfundidad.BackColor = Color.FromArgb(0, 25, 38);
            btnBusquedaProfundidad.BackgroundImageLayout = ImageLayout.None;
            btnBusquedaProfundidad.FlatStyle = FlatStyle.Flat;
            btnBusquedaProfundidad.Font = new Font("Segoe UI", 10F);
            btnBusquedaProfundidad.ForeColor = Color.White;
            btnBusquedaProfundidad.Location = new Point(27, 221);
            btnBusquedaProfundidad.Name = "btnBusquedaProfundidad";
            btnBusquedaProfundidad.Size = new Size(294, 30);
            btnBusquedaProfundidad.TabIndex = 5;
            btnBusquedaProfundidad.Text = "Busqueda en Profundidad";
            btnBusquedaProfundidad.UseVisualStyleBackColor = false;
            btnBusquedaProfundidad.Click += btnBusquedaProfundidad_Click;
            // 
            // btnBusquedaAmplitud
            // 
            btnBusquedaAmplitud.BackColor = Color.FromArgb(0, 25, 38);
            btnBusquedaAmplitud.BackgroundImageLayout = ImageLayout.None;
            btnBusquedaAmplitud.FlatStyle = FlatStyle.Flat;
            btnBusquedaAmplitud.Font = new Font("Segoe UI", 10F);
            btnBusquedaAmplitud.ForeColor = Color.White;
            btnBusquedaAmplitud.Location = new Point(27, 185);
            btnBusquedaAmplitud.Name = "btnBusquedaAmplitud";
            btnBusquedaAmplitud.Size = new Size(294, 30);
            btnBusquedaAmplitud.TabIndex = 4;
            btnBusquedaAmplitud.Text = "Busqueda en Amplitud";
            btnBusquedaAmplitud.UseVisualStyleBackColor = false;
            btnBusquedaAmplitud.Click += btnBusquedaAmplitud_Click;
            // 
            // cmbDestino
            // 
            cmbDestino.BackColor = Color.FromArgb(0, 25, 38);
            cmbDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestino.FlatStyle = FlatStyle.Flat;
            cmbDestino.Font = new Font("Segoe UI", 11F);
            cmbDestino.ForeColor = Color.White;
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(27, 144);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(294, 28);
            cmbDestino.TabIndex = 3;
            cmbDestino.SelectedIndexChanged += cmbDestino_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(18, 116);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 2;
            label2.Text = "Estacion de Destino:";
            // 
            // cmbOrigen
            // 
            cmbOrigen.BackColor = Color.FromArgb(0, 25, 38);
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigen.FlatStyle = FlatStyle.Flat;
            cmbOrigen.Font = new Font("Segoe UI", 11F);
            cmbOrigen.ForeColor = Color.White;
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(27, 67);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(294, 28);
            cmbOrigen.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(18, 39);
            label1.Name = "label1";
            label1.Size = new Size(137, 20);
            label1.TabIndex = 0;
            label1.Text = "Estacion de Origen:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.map;
            pictureBox1.InitialImage = Properties.Resources.map;
            pictureBox1.Location = new Point(25, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(831, 725);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 25, 38);
            ClientSize = new Size(1247, 768);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            ForeColor = Color.FromArgb(0, 25, 38);
            Name = "Form1";
            Text = "Sistema de Transporte";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private ComboBox cmbOrigen;
        private Label label1;
        private ComboBox cmbDestino;
        private Label label2;
        private Button btnBusquedaAmplitud;
        private Button btnBusquedaProfundidad;
        private TextBox txtTiempoTotal;
        private Label label3;
        private Button btnRutaCorta;
        private TextBox txtResultados;
        private Label label6;
        private TextBox txtNuevoPeso;
        private Label label5;
        private TextBox txtPeso;
        private Label label4;
    }
}
