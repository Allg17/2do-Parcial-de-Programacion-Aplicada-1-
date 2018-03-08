using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Segundo_Parcial_Aplicada.Entidades
{
    public class Personas
    {
        [Key]
        public int IdPersonas { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public virtual List<Telefonos> telefonoDetalle { get; set; }

        public Personas(int id, string nombre, DateTime fecha, List<Telefonos> telefonoDetalle)
        {

            this.Nombre = nombre;
            this.Fecha = fecha;
            this.telefonoDetalle = telefonoDetalle;
        }

        public Personas()
        {
            this.IdPersonas = 0;
            this.Nombre = string.Empty;
            this.Fecha = DateTime.Now;
            telefonoDetalle = new List<Telefonos>();
        }
    }
}
