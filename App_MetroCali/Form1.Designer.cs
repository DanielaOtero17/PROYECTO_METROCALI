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
            this.cb_elegir = new System.Windows.Forms.ComboBox();
            this.Bguardar = new System.Windows.Forms.Button();
            this.gControl = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // cb_elegir
            // 
            this.cb_elegir.FormattingEnabled = true;
            this.cb_elegir.Location = new System.Drawing.Point(62, 11);
            this.cb_elegir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_elegir.Name = "cb_elegir";
            this.cb_elegir.Size = new System.Drawing.Size(176, 24);
            this.cb_elegir.TabIndex = 1;
            this.cb_elegir.SelectedIndexChanged += new System.EventHandler(this.Cb_elegir_SelectedIndexChanged);
            // 
            // Bguardar
            // 
            this.Bguardar.Location = new System.Drawing.Point(269, 12);
            this.Bguardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bguardar.Name = "Bguardar";
            this.Bguardar.Size = new System.Drawing.Size(75, 23);
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
            this.gControl.Location = new System.Drawing.Point(62, 70);
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
            this.gControl.Size = new System.Drawing.Size(1182, 682);
            this.gControl.TabIndex = 3;
            this.gControl.Zoom = 0D;
            this.gControl.Load += new System.EventHandler(this.GControl_Load_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 876);
            this.Controls.Add(this.gControl);
            this.Controls.Add(this.Bguardar);
            this.Controls.Add(this.cb_elegir);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cb_elegir;
        private System.Windows.Forms.Button Bguardar;
        private GMap.NET.WindowsForms.GMapControl gControl;
    }
}

