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
            this.cb_elegir = new System.Windows.Forms.ComboBox();
            this.Bguardar = new System.Windows.Forms.Button();
            this.gControl = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.LimagenLogo = new System.Windows.Forms.Label();
            this.BEliminar = new System.Windows.Forms.Button();
            this.pbIMAGEN = new System.Windows.Forms.PictureBox();
            this.BmostrarZonas = new System.Windows.Forms.Button();
            this.cbZonas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIMAGEN)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_elegir
            // 
            this.cb_elegir.FormattingEnabled = true;
            this.cb_elegir.Location = new System.Drawing.Point(917, 357);
            this.cb_elegir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_elegir.Name = "cb_elegir";
            this.cb_elegir.Size = new System.Drawing.Size(176, 24);
            this.cb_elegir.TabIndex = 1;
            this.cb_elegir.SelectedIndexChanged += new System.EventHandler(this.Cb_elegir_SelectedIndexChanged);
            // 
            // Bguardar
            // 
            this.Bguardar.Location = new System.Drawing.Point(1121, 350);
            this.Bguardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bguardar.Name = "Bguardar";
            this.Bguardar.Size = new System.Drawing.Size(115, 36);
            this.Bguardar.TabIndex = 2;
            this.Bguardar.Text = "Buscar";
            this.Bguardar.UseVisualStyleBackColor = true;
            this.Bguardar.Click += new System.EventHandler(this.Bguardar_Click);
            // 
            // gControl
            // 
            this.gControl.Bearing = 0F;
            this.gControl.CanDragMap = true;
            this.gControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gControl.GrayScaleMode = false;
            this.gControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gControl.LevelsKeepInMemmory = 5;
            this.gControl.Location = new System.Drawing.Point(37, 35);
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
            this.gControl.Size = new System.Drawing.Size(854, 778);
            this.gControl.TabIndex = 3;
            this.gControl.Zoom = 0D;
            this.gControl.Load += new System.EventHandler(this.GControl_Load_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(964, 35);
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
            this.BEliminar.Location = new System.Drawing.Point(1121, 485);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(120, 37);
            this.BEliminar.TabIndex = 6;
            this.BEliminar.Text = "Eliminar";
            this.BEliminar.UseVisualStyleBackColor = true;
            // 
            // pbIMAGEN
            // 
            this.pbIMAGEN.Location = new System.Drawing.Point(917, 35);
            this.pbIMAGEN.Name = "pbIMAGEN";
            this.pbIMAGEN.Size = new System.Drawing.Size(351, 295);
            this.pbIMAGEN.TabIndex = 7;
            this.pbIMAGEN.TabStop = false;
            // 
            // BmostrarZonas
            // 
            this.BmostrarZonas.Location = new System.Drawing.Point(1121, 417);
            this.BmostrarZonas.Name = "BmostrarZonas";
            this.BmostrarZonas.Size = new System.Drawing.Size(120, 40);
            this.BmostrarZonas.TabIndex = 8;
            this.BmostrarZonas.Text = "Mostrar zonas";
            this.BmostrarZonas.UseVisualStyleBackColor = true;
            this.BmostrarZonas.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cbZonas
            // 
            this.cbZonas.FormattingEnabled = true;
            this.cbZonas.Location = new System.Drawing.Point(917, 417);
            this.cbZonas.Name = "cbZonas";
            this.cbZonas.Size = new System.Drawing.Size(176, 24);
            this.cbZonas.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 876);
            this.Controls.Add(this.cbZonas);
            this.Controls.Add(this.BmostrarZonas);
            this.Controls.Add(this.pbIMAGEN);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.LimagenLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gControl);
            this.Controls.Add(this.Bguardar);
            this.Controls.Add(this.cb_elegir);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIMAGEN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_elegir;
        private System.Windows.Forms.Button Bguardar;
        private GMap.NET.WindowsForms.GMapControl gControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LimagenLogo;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.PictureBox pbIMAGEN;
        private System.Windows.Forms.Button BmostrarZonas;
        private System.Windows.Forms.ComboBox cbZonas;
    }
}

