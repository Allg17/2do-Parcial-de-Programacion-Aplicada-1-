namespace Segundo_Parcial_Aplicada.Reporte
{
    partial class Reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PErsonacrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // PErsonacrystalReportViewer1
            // 
            this.PErsonacrystalReportViewer1.ActiveViewIndex = -1;
            this.PErsonacrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PErsonacrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.PErsonacrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PErsonacrystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.PErsonacrystalReportViewer1.Name = "PErsonacrystalReportViewer1";
            this.PErsonacrystalReportViewer1.Size = new System.Drawing.Size(610, 451);
            this.PErsonacrystalReportViewer1.TabIndex = 0;
            this.PErsonacrystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 451);
            this.Controls.Add(this.PErsonacrystalReportViewer1);
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer PErsonacrystalReportViewer1;
    }
}