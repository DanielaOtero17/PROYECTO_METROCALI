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
            this.BmostrarZonas = new System.Windows.Forms.Button();
            this.cbZonas = new System.Windows.Forms.ComboBox();
            this.bPuntosZonas = new System.Windows.Forms.Button();
            this.MostrarMIOS = new System.Windows.Forms.Button();
            this.pboxFondoDeco = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbIMAGEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFondoDeco)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_elegir
            // 
            this.cb_elegir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_elegir.FormattingEnabled = true;
            this.cb_elegir.ItemHeight = 13;
            this.cb_elegir.Location = new System.Drawing.Point(688, 343);
            this.cb_elegir.Margin = new System.Windows.Forms.Padding(2);
            this.cb_elegir.Name = "cb_elegir";
            this.cb_elegir.Size = new System.Drawing.Size(133, 21);
            this.cb_elegir.TabIndex = 1;
            this.cb_elegir.SelectedIndexChanged += new System.EventHandler(this.Cb_elegir_SelectedIndexChanged);
            // 
            // Bguardar
            // 
            this.Bguardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bguardar.Location = new System.Drawing.Point(688, 378);
            this.Bguardar.Margin = new System.Windows.Forms.Padding(2);
            this.Bguardar.Name = "Bguardar";
            this.Bguardar.Size = new System.Drawing.Size(132, 41);
            this.Bguardar.TabIndex = 2;
            this.Bguardar.Text = "Buscar Paradas";
            this.Bguardar.UseVisualStyleBackColor = true;
            this.Bguardar.Click += new System.EventHandler(this.Bguardar_Click);
            // 
            // gControl
            // 
            this.gControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gControl.Bearing = 0F;
            this.gControl.CanDragMap = true;
            this.gControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gControl.GrayScaleMode = false;
            this.gControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gControl.LevelsKeepInMemmory = 5;
            this.gControl.Location = new System.Drawing.Point(25, 17);
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
            this.gControl.Size = new System.Drawing.Size(640, 623);
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
            this.BEliminar.Location = new System.Drawing.Point(762, 462);
            this.BEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(126, 44);
            this.BEliminar.TabIndex = 6;
            this.BEliminar.Text = "Limpiar";
            this.BEliminar.UseVisualStyleBackColor = true;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // pbIMAGEN
            // 
            this.pbIMAGEN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbIMAGEN.Location = new System.Drawing.Point(688, 17);
            this.pbIMAGEN.Margin = new System.Windows.Forms.Padding(2);
            this.pbIMAGEN.Name = "pbIMAGEN";
            this.pbIMAGEN.Size = new System.Drawing.Size(269, 240);
            this.pbIMAGEN.TabIndex = 7;
            this.pbIMAGEN.TabStop = false;
            // 
            // BmostrarZonas
            // 
            this.BmostrarZonas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BmostrarZonas.Location = new System.Drawing.Point(833, 378);
            this.BmostrarZonas.Margin = new System.Windows.Forms.Padding(2);
            this.BmostrarZonas.Name = "BmostrarZonas";
            this.BmostrarZonas.Size = new System.Drawing.Size(124, 41);
            this.BmostrarZonas.TabIndex = 8;
            this.BmostrarZonas.Text = "Mostrar zonas";
            this.BmostrarZonas.UseVisualStyleBackColor = true;
            this.BmostrarZonas.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cbZonas
            // 
            this.cbZonas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbZonas.FormattingEnabled = true;
            this.cbZonas.Location = new System.Drawing.Point(832, 343);
            this.cbZonas.Margin = new System.Windows.Forms.Padding(2);
            this.cbZonas.Name = "cbZonas";
            this.cbZonas.Size = new System.Drawing.Size(133, 21);
            this.cbZonas.TabIndex = 9;
            // 
            // bPuntosZonas
            // 
            this.bPuntosZonas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bPuntosZonas.Location = new System.Drawing.Point(825, 271);
            this.bPuntosZonas.Margin = new System.Windows.Forms.Padding(2);
            this.bPuntosZonas.Name = "bPuntosZonas";
            this.bPuntosZonas.Size = new System.Drawing.Size(132, 46);
            this.bPuntosZonas.TabIndex = 10;
            this.bPuntosZonas.Text = "Mostrar Puntos zonas";
            this.bPuntosZonas.UseVisualStyleBackColor = true;
            this.bPuntosZonas.Click += new System.EventHandler(this.BPuntosZonas_Click_1);
            // 
            // MostrarMIOS
            // 
            this.MostrarMIOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MostrarMIOS.Location = new System.Drawing.Point(688, 272);
            this.MostrarMIOS.Name = "MostrarMIOS";
            this.MostrarMIOS.Size = new System.Drawing.Size(132, 44);
            this.MostrarMIOS.TabIndex = 11;
            this.MostrarMIOS.Text = "Mostrar MIOs";
            this.MostrarMIOS.UseVisualStyleBackColor = true;
            this.MostrarMIOS.Click += new System.EventHandler(this.MostrarMIOS_Click);
            // 
            // pboxFondoDeco
            // 
            this.pboxFondoDeco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxFondoDeco.Location = new System.Drawing.Point(680, 10);
            this.pboxFondoDeco.Margin = new System.Windows.Forms.Padding(2);
            this.pboxFondoDeco.Name = "pboxFondoDeco";
            this.pboxFondoDeco.Size = new System.Drawing.Size(292, 618);
            this.pboxFondoDeco.TabIndex = 12;
            this.pboxFondoDeco.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 602);
            this.Controls.Add(this.pbIMAGEN);
            this.Controls.Add(this.MostrarMIOS);
            this.Controls.Add(this.bPuntosZonas);
            this.Controls.Add(this.cbZonas);
            this.Controls.Add(this.BmostrarZonas);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.LimagenLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gControl);
            this.Controls.Add(this.Bguardar);
            this.Controls.Add(this.cb_elegir);
            this.Controls.Add(this.pboxFondoDeco);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "METROCALI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIMAGEN)).EndInit();
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
        private System.Windows.Forms.Button BmostrarZonas;
        private System.Windows.Forms.ComboBox cbZonas;
        private System.Windows.Forms.Button bPuntosZonas;
        private System.Windows.Forms.Button MostrarMIOS;
        private System.Windows.Forms.PictureBox pboxFondoDeco;
        private System.Windows.Forms.Timer timer1;
        public GMap.NET.WindowsForms.GMapControl gControl;
    }
}

