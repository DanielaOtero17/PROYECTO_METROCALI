﻿namespace App_MetroCali
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
            this.cb_elegir = new System.Windows.Forms.ComboBox();
            this.Bguardar = new System.Windows.Forms.Button();
            this.gControl = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.LimagenLogo = new System.Windows.Forms.Label();
            this.BEliminar = new System.Windows.Forms.Button();
            this.pbIMAGEN = new System.Windows.Forms.PictureBox();
            this.cbZonas = new System.Windows.Forms.ComboBox();
            this.bPuntosZonas = new System.Windows.Forms.Button();
            this.MostrarMIOS = new System.Windows.Forms.Button();
            this.pboxFondoDeco = new System.Windows.Forms.PictureBox();
            this.lTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.buscarRutaUsuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIMAGEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFondoDeco)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_elegir
            // 
            this.cb_elegir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_elegir.FormattingEnabled = true;
            this.cb_elegir.ItemHeight = 16;
            this.cb_elegir.Location = new System.Drawing.Point(168, 53);
            this.cb_elegir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_elegir.Name = "cb_elegir";
            this.cb_elegir.Size = new System.Drawing.Size(175, 24);
            this.cb_elegir.TabIndex = 1;
            this.cb_elegir.SelectedIndexChanged += new System.EventHandler(this.Cb_elegir_SelectedIndexChanged);
            // 
            // Bguardar
            // 
            this.Bguardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bguardar.BackColor = System.Drawing.Color.SkyBlue;
            this.Bguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Bguardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bguardar.Location = new System.Drawing.Point(15, 53);
            this.Bguardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bguardar.Name = "Bguardar";
            this.Bguardar.Size = new System.Drawing.Size(133, 26);
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
            this.gControl.Location = new System.Drawing.Point(33, 49);
            this.gControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.gControl.Size = new System.Drawing.Size(861, 708);
            this.gControl.TabIndex = 3;
            this.gControl.Zoom = 0D;
            this.gControl.Load += new System.EventHandler(this.GControl_Load_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(964, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 4;
            // 
            // LimagenLogo
            // 
            this.LimagenLogo.AutoSize = true;
            this.LimagenLogo.Location = new System.Drawing.Point(961, 52);
            this.LimagenLogo.Name = "LimagenLogo";
            this.LimagenLogo.Size = new System.Drawing.Size(0, 17);
            this.LimagenLogo.TabIndex = 5;
            // 
            // BEliminar
            // 
            this.BEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BEliminar.BackColor = System.Drawing.Color.Maroon;
            this.BEliminar.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminar.ForeColor = System.Drawing.Color.White;
            this.BEliminar.Location = new System.Drawing.Point(1043, 704);
            this.BEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(131, 54);
            this.BEliminar.TabIndex = 6;
            this.BEliminar.Text = "Limpiar";
            this.BEliminar.UseVisualStyleBackColor = false;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // pbIMAGEN
            // 
            this.pbIMAGEN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbIMAGEN.Location = new System.Drawing.Point(944, 70);
            this.pbIMAGEN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbIMAGEN.Name = "pbIMAGEN";
            this.pbIMAGEN.Size = new System.Drawing.Size(359, 295);
            this.pbIMAGEN.TabIndex = 7;
            this.pbIMAGEN.TabStop = false;
            // 
            // cbZonas
            // 
            this.cbZonas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbZonas.FormattingEnabled = true;
            this.cbZonas.Location = new System.Drawing.Point(15, 60);
            this.cbZonas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbZonas.Name = "cbZonas";
            this.cbZonas.Size = new System.Drawing.Size(149, 24);
            this.cbZonas.TabIndex = 9;
            this.cbZonas.SelectedIndexChanged += new System.EventHandler(this.cbZonas_SelectedIndexChanged);
            // 
            // bPuntosZonas
            // 
            this.bPuntosZonas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bPuntosZonas.BackColor = System.Drawing.Color.LightSeaGreen;
            this.bPuntosZonas.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bPuntosZonas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bPuntosZonas.FlatAppearance.BorderSize = 2;
            this.bPuntosZonas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bPuntosZonas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPuntosZonas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bPuntosZonas.Location = new System.Drawing.Point(183, 59);
            this.bPuntosZonas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bPuntosZonas.Name = "bPuntosZonas";
            this.bPuntosZonas.Size = new System.Drawing.Size(151, 30);
            this.bPuntosZonas.TabIndex = 10;
            this.bPuntosZonas.Text = "Mostrar Puntos zonas";
            this.bPuntosZonas.UseVisualStyleBackColor = false;
            this.bPuntosZonas.Click += new System.EventHandler(this.BPuntosZonas_Click_1);
            // 
            // MostrarMIOS
            // 
            this.MostrarMIOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MostrarMIOS.BackColor = System.Drawing.Color.PaleVioletRed;
            this.MostrarMIOS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MostrarMIOS.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MostrarMIOS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MostrarMIOS.Location = new System.Drawing.Point(99, 61);
            this.MostrarMIOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MostrarMIOS.Name = "MostrarMIOS";
            this.MostrarMIOS.Size = new System.Drawing.Size(131, 27);
            this.MostrarMIOS.TabIndex = 11;
            this.MostrarMIOS.Text = "Mostrar Buses";
            this.MostrarMIOS.UseVisualStyleBackColor = false;
            this.MostrarMIOS.Click += new System.EventHandler(this.MostrarMIOS_Click);
            // 
            // pboxFondoDeco
            // 
            this.pboxFondoDeco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxFondoDeco.BackColor = System.Drawing.Color.White;
            this.pboxFondoDeco.ErrorImage = null;
            this.pboxFondoDeco.InitialImage = null;
            this.pboxFondoDeco.Location = new System.Drawing.Point(923, -25);
            this.pboxFondoDeco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pboxFondoDeco.Name = "pboxFondoDeco";
            this.pboxFondoDeco.Size = new System.Drawing.Size(397, 873);
            this.pboxFondoDeco.TabIndex = 12;
            this.pboxFondoDeco.TabStop = false;
            this.pboxFondoDeco.Click += new System.EventHandler(this.PboxFondoDeco_Click);
            // 
            // lTitulo
            // 
            this.lTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lTitulo.AutoSize = true;
            this.lTitulo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(365, 21);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(232, 26);
            this.lTitulo.TabIndex = 13;
            this.lTitulo.Text = "MAPA DE GOOGLE";
            this.lTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(21, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Visualizar zonas";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbZonas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bPuntosZonas);
            this.panel1.Location = new System.Drawing.Point(935, 384);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 97);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Britannic Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(125, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 27);
            this.label3.TabIndex = 20;
            this.label3.Text = "ZONAS";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Controls.Add(this.buscarRutaUsuario);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.MostrarMIOS);
            this.panel2.Location = new System.Drawing.Point(935, 495);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 92);
            this.panel2.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Britannic Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(127, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 27);
            this.label6.TabIndex = 22;
            this.label6.Text = "BUSES";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.Bguardar);
            this.panel3.Controls.Add(this.cb_elegir);
            this.panel3.Location = new System.Drawing.Point(935, 601);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 92);
            this.panel3.TabIndex = 18;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel3_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Britannic Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(115, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 27);
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
            this.label4.Location = new System.Drawing.Point(1031, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Hora del sistema";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // buscarRutaUsuario
            // 
            this.buscarRutaUsuario.Location = new System.Drawing.Point(99, 32);
            this.buscarRutaUsuario.Name = "buscarRutaUsuario";
            this.buscarRutaUsuario.Size = new System.Drawing.Size(131, 22);
            this.buscarRutaUsuario.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1317, 785);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbIMAGEN);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.LimagenLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gControl);
            this.Controls.Add(this.pboxFondoDeco);
            this.Controls.Add(this.lTitulo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "METROCALI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIMAGEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFondoDeco)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Button bPuntosZonas;
        private System.Windows.Forms.Button MostrarMIOS;
        private System.Windows.Forms.PictureBox pboxFondoDeco;
        private System.Windows.Forms.Label lTitulo;
        public GMap.NET.WindowsForms.GMapControl gControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox buscarRutaUsuario;
    }
}

