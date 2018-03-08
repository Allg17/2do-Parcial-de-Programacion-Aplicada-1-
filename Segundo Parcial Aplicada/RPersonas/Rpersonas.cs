using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace Segundo_Parcial_Aplicada
{
    public partial class Rpersonas : Form
    {
        Personas gente = new Personas();
        public Rpersonas()
        {
            InitializeComponent();
            AgregarAComboBox();

        }

        private bool SetError(int num)
        {
            bool mensage = false;
            if (num == 1 && IDnumericUpDown1.Value == 0)
            {
                IDerrorProvider.SetError(IDnumericUpDown1, "Campo Vacio");
                mensage = true;

            }
            if (num == 2 && NombreTextBox.Text == string.Empty)
            {
                NombreErrorProvider.SetError(NombreTextBox, "Campo Vacio");
                mensage = true;

            }
            if (num == 3 && TipocomboBox.SelectedItem == null && TelefonomaskedTextBox.Text == string.Empty)
            {
                TipoErrorProvider.SetError(TipocomboBox, "Campo Vacio");
                TelefonoErrorProvider.SetError(TelefonomaskedTextBox, "Campo Vacio");
                mensage = true;


            }
            return mensage;
        }

        private void LimpiarError()
        {
            IDerrorProvider.Clear();
            TipoErrorProvider.Clear();
            NombreErrorProvider.Clear();
            TelefonoErrorProvider.Clear();
        }

      
        private Personas LlenaClase()
        {
            gente.IdPersonas = 0;
            gente.Nombre = NombreTextBox.Text;
            gente.Fecha = FechadateTimePicker.Value;
            

            return gente;
        }

       

      
       

        private void AgregarAComboBox()
        {
            Expression<Func<TipoTelefonoes, bool>> filtrar = x => true;
            List<TipoTelefonoes> tipo = new List<TipoTelefonoes>();
            tipo = BLL.TipotelefonoesBLL.GetList(filtrar);

            foreach (var tel in tipo)
            {
                TipocomboBox.Items.Add(tel.TipoTelefonos);

            }



        }

        private void AgregarButton_Click_1(object sender, EventArgs e)
        {
            DetalledataGridView.DataSource = null;
            gente.telefonoDetalle.Add(new Telefonos(textBox.Text, TipocomboBox.SelectedItem.ToString(), gente.IdPersonas));
            DetalledataGridView.DataSource = gente.telefonoDetalle;
        }

        private void NuevoButtton_Click_1(object sender, EventArgs e)
        {
            IDnumericUpDown1.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            NombreTextBox.Clear();
            TipocomboBox.DataSource = null;
            TelefonomaskedTextBox.Clear();
            DetalledataGridView.DataSource = null;
            LimpiarError();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Personas persona = LlenaClase();
            if (IDnumericUpDown1.Value == 0)
            {
                LimpiarError();
                if (SetError(2))
                {
                    MessageBox.Show("Llenar los campos marcados");
                }

                if (BLL.PersonasBLL.Guardar(persona))
                {
                    MessageBox.Show("Guardado!");
                }
                else
                {
                    MessageBox.Show("No se pudo Guardar!");
                }
            }
            else
            {
                if (BLL.PersonasBLL.Modificar(LlenaClase()))
                {
                    MessageBox.Show("Modificado!");
                }
                else
                {
                    MessageBox.Show("No se pudo Modificar!");
                }
            }
        }
    }
}
