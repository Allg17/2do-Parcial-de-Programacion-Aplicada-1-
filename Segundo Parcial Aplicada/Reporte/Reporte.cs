using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Segundo_Parcial_Aplicada.Reporte
{
    public partial class Reportes : Form
    {
        List<Personas> datos = new List<Personas>();
        public Reportes(List<Personas> data)
        {
            InitializeComponent();
            datos = data;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReportePersonas r = new ReportePersonas();
            
            r.Load("C:/Users/Usuario/Desktop/01 Enero 2028/Aplicada 1/2do Parcial/Segundo Parcial Aplicada/Segundo Parcial Aplicada/Reporte/ReportePersonas.rpt");
            r.SetDataSource(datos);

            PErsonacrystalReportViewer1.ReportSource = r;
            PErsonacrystalReportViewer1.Refresh();
        }
    }
}
