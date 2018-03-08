using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Segundo_Parcial_Aplicada.DAL
{
    public class Contexto : DbContext 
    {
        public DbSet<Personas> Persona { get; set; }
        public DbSet<Telefonos> Telefono { get; set; }
        public DbSet<TipoTelefonoes> Tipo { get; set; }

        public Contexto() : base("ConStr")
        {
        }
    }
}
