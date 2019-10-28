namespace App_MetroCali
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel panel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label3 = new System.Windows.Forms.Label();
            this.cbZonas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_elegir = new System.Windows.Forms.ComboBox();
            this.Bguardar = new System.Windows.Forms.Button();
            this.gControl = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.LimagenLogo = new System.Windows.Forms.Label();
            this.BEliminar = new System.Windows.Forms.Button();
            this.pbIMAGEN = new System.Windows.Forms.PictureBox();
            this.MostrarMIOS = new System.Windows.Forms.Button();
            this.lTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buscarRutasUsuarios = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pboxFondoDeco = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIMAGEN)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFondoDeco)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            panel1.AutoSize = true;
            panel1.BackColor = System.Drawing.Color.Green;
            panel1.Controls.Add(this.label3);
            panel1.Controls.Add(this.cbZonas);
            panel1.Controls.Add(this.label2);
            panel1.Location = new System.Drawing.Point(740, 312);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(271, 79);
            panel1.TabIndex = 17;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(91, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 27);
            this.label3.TabIndex = 20;
            this.label3.Text = "ZONAS";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // cbZonas
            // 
            this.cbZonas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbZonas.FormattingEnabled = true;
            this.cbZonas.Location = new System.Drawing.Point(11, 49);
            this.cbZonas.Margin = new System.Windows.Forms.Padding(2);
            this.cbZonas.Name = "cbZonas";
            this.cbZonas.Size = new System.Drawing.Size(247, 21);
            this.cbZonas.TabIndex = 9;
            this.cbZonas.SelectedIndexChanged += new System.EventHandler(this.cbZonas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(78, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Visualizar Zonas";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // cb_elegir
            // 
            this.cb_elegir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_elegir.FormattingEnabled = true;
            this.cb_elegir.ItemHeight = 13;
            this.cb_elegir.Location = new System.Drawing.Point(11, 43);
            this.cb_elegir.Margin = new System.Windows.Forms.Padding(2);
            this.cb_elegir.Name = "cb_elegir";
            this.cb_elegir.Size = new System.Drawing.Size(141, 21);
            this.cb_elegir.TabIndex = 1;
            this.cb_elegir.SelectedIndexChanged += new System.EventHandler(this.Cb_elegir_SelectedIndexChanged);
            // 
            // Bguardar
            // 
            this.Bguardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bguardar.BackColor = System.Drawing.Color.SkyBlue;
            this.Bguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Bguardar.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bguardar.Image = ((System.Drawing.Image)(resources.GetObject("Bguardar.Image")));
            this.Bguardar.Location = new System.Drawing.Point(156, 35);
            this.Bguardar.Margin = new System.Windows.Forms.Padding(2);
            this.Bguardar.Name = "Bguardar";
            this.Bguardar.Size = new System.Drawing.Size(100, 31);
            this.Bguardar.TabIndex = 2;
            this.Bguardar.Text = "Buscar";
            this.Bguardar.UseVisualStyleBackColor = false;
            this.Bguardar.Click += new System.EventHandler(this.Bguardar_Click);
            // 
            // gControl
            // 
            this.gControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.gControl.Bearing = 0F;
            this.gControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gControl.CanDragMap = true;
            this.gControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gControl.GrayScaleMode = false;
            this.gControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gControl.LevelsKeepInMemmory = 5;
            this.gControl.Location = new System.Drawing.Point(25, 40);
            this.gControl.Margin = new System.Windows.Forms.Padding(2);
            this.gControl.MarkersEnabled = true;
            this.gControl.MaxZoom = 2;
            this.gControl.MinZoom = 2;
            this.gControl.MouseWheelZoomEnabled = true;
            this.gControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gControl.Name = "gControl";
            this.gControl.NegativeMode = false;
            this.gControl.PolygonsEnabled = true;
            this.gControl.RetryLoadTile = 0;
            this.gControl.RoutesEnabled = true;
            this.gControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gControl.ShowTileGridLines = false;
            this.gControl.Size = new System.Drawing.Size(685, 570);
            this.gControl.TabIndex = 3;
            this.gControl.Zoom = 0D;
            this.gControl.Load += new System.EventHandler(this.GControl_Load_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(723, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // LimagenLogo
            // 
            this.LimagenLogo.AutoSize = true;
            this.LimagenLogo.Location = new System.Drawing.Point(721, 42);
            this.LimagenLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LimagenLogo.Name = "LimagenLogo";
            this.LimagenLogo.Size = new System.Drawing.Size(0, 13);
            this.LimagenLogo.TabIndex = 5;
            // 
            // BEliminar
            // 
            this.BEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BEliminar.BackColor = System.Drawing.Color.Maroon;
            this.BEliminar.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.BEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BEliminar.Image")));
            this.BEliminar.Location = new System.Drawing.Point(830, 578);
            this.BEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(98, 44);
            this.BEliminar.TabIndex = 6;
            this.BEliminar.Text = "Limpiar";
            this.BEliminar.UseVisualStyleBackColor = false;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // pbIMAGEN
            // 
            this.pbIMAGEN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbIMAGEN.Location = new System.Drawing.Point(751, 40);
            this.pbIMAGEN.Margin = new System.Windows.Forms.Padding(2);
            this.pbIMAGEN.Name = "pbIMAGEN";
            this.pbIMAGEN.Size = new System.Drawing.Size(269, 240);
            this.pbIMAGEN.TabIndex = 7;
            this.pbIMAGEN.TabStop = false;
           
            // 
            // MostrarMIOS
            // 
            this.MostrarMIOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MostrarMIOS.BackColor = System.Drawing.Color.PaleVioletRed;
            this.MostrarMIOS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MostrarMIOS.Font = new System.Drawing.Font("Gill Sans MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MostrarMIOS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MostrarMIOS.Image = ((System.Drawing.Image)(resources.GetObject("MostrarMIOS.Image")));
            this.MostrarMIOS.Location = new System.Drawing.Point(158, 36);
            this.MostrarMIOS.Name = "MostrarMIOS";
            this.MostrarMIOS.Size = new System.Drawing.Size(98, 22);
            this.MostrarMIOS.TabIndex = 11;
            this.MostrarMIOS.Text = "Mostrar Buses";
            this.MostrarMIOS.UseVisualStyleBackColor = false;
            this.MostrarMIOS.Click += new System.EventHandler(this.MostrarMIOS_Click);
            // 
            // lTitulo
            // 
            this.lTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lTitulo.AutoSize = true;
            this.lTitulo.Font = new System.Drawing.Font("Gill Sans MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(278, 11);
            this.lTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(216, 30);
            this.lTitulo.TabIndex = 13;
            this.lTitulo.Text = "MAPA DE GOOGLE";
            this.lTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Controls.Add(this.buscarRutasUsuarios);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.MostrarMIOS);
            this.panel2.Location = new System.Drawing.Point(740, 402);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 75);
            this.panel2.TabIndex = 18;
            // 
            // buscarRutasUsuarios
            // 
            this.buscarRutasUsuarios.Location = new System.Drawing.Point(11, 38);
            this.buscarRutasUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.buscarRutasUsuarios.Name = "buscarRutasUsuarios";
            this.buscarRutasUsuarios.Size = new System.Drawing.Size(142, 20);
            this.buscarRutasUsuarios.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FloralWhite;
            this.label6.Location = new System.Drawing.Point(100, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 27);
            this.label6.TabIndex = 22;
            this.label6.Text = "BUSES";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.Bguardar);
            this.panel3.Controls.Add(this.cb_elegir);
            this.panel3.Location = new System.Drawing.Point(740, 488);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(271, 75);
            this.panel3.TabIndex = 18;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Britannic Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FloralWhite;
            this.label5.Location = new System.Drawing.Point(93, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 22);
            this.label5.TabIndex = 21;
            this.label5.Text = "PARADAS";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(822, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Hora del sistema";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // pboxFondoDeco
            // 
            this.pboxFondoDeco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxFondoDeco.BackColor = System.Drawing.Color.White;
            this.pboxFondoDeco.ErrorImage = null;
            this.pboxFondoDeco.InitialImage = null;
            this.pboxFondoDeco.Location = new System.Drawing.Point(740, -11);
            this.pboxFondoDeco.Margin = new System.Windows.Forms.Padding(2);
            this.pboxFondoDeco.Name = "pboxFondoDeco";
            this.pboxFondoDeco.Size = new System.Drawing.Size(291, 726);
            this.pboxFondoDeco.TabIndex = 12;
            this.pboxFondoDeco.TabStop = false;
            this.pboxFondoDeco.Click += new System.EventHandler(this.PboxFondoDeco_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(44, 587);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(646, 23);
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Click += new System.EventHandler(this.ProgressBar1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1027, 656);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(panel1);
            this.Controls.Add(this.pbIMAGEN);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.LimagenLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gControl);
            this.Controls.Add(this.pboxFondoDeco);
            this.Controls.Add(this.lTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "METROCALI";
            this.Load += new System.EventHandler(this.Form1_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIMAGEN)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFondoDeco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_elegir;
        private System.Windows.Forms.Button Bguardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LimagenLogo;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.PictureBox pbIMAGEN;
        private System.Windows.Forms.ComboBox cbZonas;
        private System.Windows.Forms.Button MostrarMIOS;
        private System.Windows.Forms.Label lTitulo;
        public GMap.NET.WindowsForms.GMapControl gControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox buscarRutasUsuarios;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pboxFondoDeco;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

