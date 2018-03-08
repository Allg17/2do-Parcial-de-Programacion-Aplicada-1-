using Segundo_Parcial_Aplicada.DAL;
using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Segundo_Parcial_Aplicada.BLL
{
    public class PersonasBLL
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                //foreach (var telefono in persona.telefonoDetalle)
                //{
                //    BLL.TelefonosBLL.Guardar(telefono);
                //}

                if (db.Persona.Add(persona) != null)
                {
                    db.SaveChanges();
                    paso = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Persona.Find(id);
                if (db.Persona.Remove(eliminar) != null)
                {
                    db.SaveChanges();
                    paso = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;

        }

        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                BLL.TelefonosBLL.Modificar(persona.telefonoDetalle);
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    paso = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {

            Contexto db = new Contexto();
            Personas gente = new Personas();
            try
            {
                gente = db.Persona.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return gente;
        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> gente)
        {
            List<Personas> persona = new List<Personas>();
            Contexto db = new Contexto();
            try
            {
                persona = db.Persona.Where(gente).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return persona;

        }
    }
}
