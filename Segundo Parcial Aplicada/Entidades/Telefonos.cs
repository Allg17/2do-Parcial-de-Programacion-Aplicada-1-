using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Segundo_Parcial_Aplicada.Entidades
{
   public class Telefonos
   {
        [Key]
        public int IdTelefono { get; set; }
        public string TipodeTelefono { get; set; }
        public string Telefono { get; set; }
        public int IdPersonas { get; set; }

        public Telefonos(string telefono, string tipoTelefono, int IdPersonas )
        {

            this.Telefono = telefono;
            this.TipodeTelefono = tipoTelefono;
            this.IdPersonas = IdPersonas;


        }

        public Telefonos()
        {
            this.IdTelefono = 0;
            this.Telefono = string.Empty;
            this.TipodeTelefono = string.Empty;
            this.IdPersonas = 0;
        }
    }
}
