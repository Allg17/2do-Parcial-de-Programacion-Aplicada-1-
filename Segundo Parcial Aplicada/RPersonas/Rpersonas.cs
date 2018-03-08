using Segundo_Parcial_Aplicada.Entidades;
using Segundo_Parcial_Aplicada.RPersonas;
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
        bool paso = false;
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
            if (num == 3 && TipocomboBox.SelectedItem == null && TipocomboBox.Text ==string.Empty)
            {
                TipoErrorProvider.SetError(TipocomboBox, "Campo Vacio");
                mensage = true;
              

            }
            if (num == 3 && TelefonomaskedTextBox.TextLength<13)
            {
                TipoErrorProvider.SetError(TipocomboBox, "Campo Vacio");
                TelefonoErrorProvider.SetError(TelefonomaskedTextBox, "Campo Vacio");
                mensage = true;
            }
            if(num==4 && ModificarnumericUpDown1.Value == 0)
            {
                IdNumeroerrorProvider1.SetError(ModificarnumericUpDown1,"Campo Vacio");
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
            IdNumeroerrorProvider1.Clear();
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
            LimpiarError();
            if (SetError(3))
            {
                MessageBox.Show("Campos Vacios");
                return;
            }
            if(IDnumericUpDown1.Value==0)
            {
                gente.telefonoDetalle.Add(new Telefonos(TelefonomaskedTextBox.Text, TipocomboBox.SelectedItem.ToString(), gente.IdPersonas));
            }
            else
            {
                if(gente.telefonoDetalle.Exists(t =>t.Telefono== TelefonomaskedTextBox.Text)==false)
                {
                    Expression<Func<Telefonos, bool>> filtrar = x => true;
                    filtrar = t => t.IdPersonas == IDnumericUpDown1.Value;
                    gente.telefonoDetalle = BLL.TelefonosBLL.GetList(filtrar);
                    gente.telefonoDetalle.Add(new Telefonos(TelefonomaskedTextBox.Text, TipocomboBox.SelectedItem.ToString(), Convert.ToInt32(IDnumericUpDown1.Value)));
                    paso = true;
                }
                if(ModificarnumericUpDown1.Value!=0)
                {
                    Modificar();
                }
                
            }
           
            

            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = gente.telefonoDetalle;
        }

        private void NuevoButtton_Click_1(object sender, EventArgs e)
        {
            IDnumericUpDown1.Value = 0;
            ModificarnumericUpDown1.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            NombreTextBox.Clear();
            TipocomboBox.DataSource = null;
            TelefonomaskedTextBox.Clear();
            DetalledataGridView.DataSource = null;
            LimpiarError();
            gente = new Personas();
            TipocomboBox.Refresh();
            TipocomboBox.Text = string.Empty;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Personas persona = LlenaCampos();
            if (IDnumericUpDown1.Value == 0)
            {
                LimpiarError();
                if (SetError(2))
                {
                    MessageBox.Show("Llenar los campos marcados");
                    return;
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
                if(paso ==true)
                {
                    BLL.TelefonosBLL.Guardar(gente.telefonoDetalle);
                    paso = false;
                    
                }
                if (BLL.PersonasBLL.Modificar(LlenaCampos()))
                {
                    MessageBox.Show("Modificado!");
                }
                else
                {
                    MessageBox.Show("No se pudo Modificar!");
                }
            }
        }

        private Personas LlenaCampos()
        {
            Personas persona = new Personas();
            persona.IdPersonas = Convert.ToInt32(IDnumericUpDown1.Value);
            persona.Nombre = NombreTextBox.Text;
            persona.Fecha = FechadateTimePicker.Value;
            persona.telefonoDetalle = gente.telefonoDetalle;
            return persona;
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            var persona = BLL.PersonasBLL.Buscar(Convert.ToInt32(IDnumericUpDown1.Value));
            int id=0;
            LimpiarError();
            if(SetError(1))
            {
                MessageBox.Show("Llenar campos Vacios");
                return;
            }
            foreach (var item in persona.telefonoDetalle)
            {
                id = item.IdTelefono;
            }
            if (SetError(1))
            {
                MessageBox.Show("Llenar el campo marcado");
                return;
            }
            if(BLL.TelefonosBLL.Eliminar(id)&&BLL.PersonasBLL.Eliminar(Convert.ToInt32(IDnumericUpDown1.Value)))
            {
                MessageBox.Show("Eliminado");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            LimpiarError();
            if (SetError(1))
            {
                MessageBox.Show("Campos Vacios");
                return;
            }
            var persona = BLL.PersonasBLL.Buscar(Convert.ToInt32(IDnumericUpDown1.Value));
            if(persona!=null)
            {
                NombreTextBox.Text = persona.Nombre;
                FechadateTimePicker.Value = persona.Fecha;
              
                DetalledataGridView.DataSource = persona.telefonoDetalle;
                TraerNumeroButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Persona No encontrada");
            }
           
        }

        private void TraerNumeroButton_Click(object sender, EventArgs e)
        {
            LimpiarError();
            if(SetError(4))
            {
                MessageBox.Show("Llenar campo vacio");
                return;
            }
            var numero = BLL.TelefonosBLL.Buscar(Convert.ToInt32(ModificarnumericUpDown1.Value));
            if(numero !=null)
            {
                TelefonomaskedTextBox.Text = numero.Telefono;
                TipocomboBox.Text = numero.TipodeTelefono;

            }
            else
            {
                MessageBox.Show("No encontrado");
            }

        }

        private void Modificar()
        {
            var numero = BLL.TelefonosBLL.Buscar(Convert.ToInt32(ModificarnumericUpDown1.Value));
            if (numero != null)
            {
                Expression<Func<Telefonos, bool>> filtrar = x => true;
                filtrar = t => t.IdPersonas == IDnumericUpDown1.Value;
                gente.telefonoDetalle = BLL.TelefonosBLL.GetList(filtrar);
                foreach (var persona in gente.telefonoDetalle)
                {
                    if(persona.IdTelefono == Convert.ToInt32(ModificarnumericUpDown1.Value))
                    {
                        persona.TipodeTelefono = TipocomboBox.SelectedItem.ToString();
                        persona.Telefono = TelefonomaskedTextBox.Text;
                        persona.IdPersonas = numero.IdPersonas;
                    }

                    
                }
              


            }
          
        }

        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            CPersona abrir = new CPersona();
            abrir.Show();
        }

        
    }
}
