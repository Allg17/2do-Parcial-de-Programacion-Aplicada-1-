using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Segundo_Parcial_Aplicada.Entidades
{
   public  class TipoTelefonoes
    {
        [Key]
        public int IdTipoTelefono { get; set; }
        public string TipoTelefonos { get; set; }

        public TipoTelefonoes(string tipoTelefonos)
        {
            this.TipoTelefonos = tipoTelefonos;

        }

        public TipoTelefonoes()
        {
            this.TipoTelefonos = string.Empty;
        }
    }
}
