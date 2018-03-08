using Segundo_Parcial_Aplicada.Entidades;
using Segundo_Parcial_Aplicada.Reporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Segundo_Parcial_Aplicada.RPersonas
{
    public partial class CPersona : Form
    {
        Expression<Func<Personas, bool>> filtrar = x => true;
        public CPersona()
        {
            InitializeComponent();
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            int id;

            
          

            switch (TipocomboBox.SelectedIndex)
            {
                //ID
                case 0:
                    id = int.Parse(CriteriotextBox.Text);
                    filtrar = t => t.IdPersonas == id;
                    break;
               //Nombre
                case 1:
                    id = int.Parse(CriteriotextBox.Text);
                    filtrar = t => t.Nombre.Contains(id.ToString());
                    break;
                    //fecha
                case 2:
                    filtrar = t => (t.Fecha >= AHoradateTimePicker1.Value) && (t.Fecha <= FInaldateTimePicker2.Value);
                    break;
            }
          

            ConsultadataGridView.DataSource = BLL.PersonasBLL.GetList(filtrar);
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            Reportes abrir  = new  Reportes(BLL.PersonasBLL.GetList(filtrar));
            abrir.Show();
        }
    }
}
