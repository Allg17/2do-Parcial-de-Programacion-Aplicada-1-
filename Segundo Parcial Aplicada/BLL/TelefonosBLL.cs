using Segundo_Parcial_Aplicada.DAL;
using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Segundo_Parcial_Aplicada.BLL
{
   public class TelefonosBLL
    {
        public static bool Guardar(Telefonos telefono)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Telefono.Add(telefono) != null)
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

        public static bool Guardar(List<Telefonos> telefono)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                foreach (var item in telefono)
                {
                    if(item.IdTelefono==0)
                    {
                        if (db.Telefono.Add(item) != null)
                        {
                            db.SaveChanges();
                            paso = true;
                        }
                    }
                   
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
                var eliminar = db.Telefono.Find(id);
                db.Telefono.RemoveRange(db.Telefono.Where(x => x.IdPersonas == eliminar.IdPersonas));
                if (db.SaveChanges()>0)
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

        public static bool Modificar(List<Telefonos> telefono)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                foreach (var item in telefono)
                {
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        paso = true;
                    }
                }
                
               

            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public static Telefonos Buscar(int id)
        {
            Contexto db = new Contexto();
            Telefonos telefono = new Telefonos();
            try
            {
                telefono = db.Telefono.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return telefono;
        }

        public static List<Telefonos> GetList(Expression<Func<Telefonos, bool>> numero)
        {
            List<Telefonos> persona = new List<Telefonos>();

            try
            {
                Contexto db = new Contexto();
                persona = db.Telefono.Where(numero).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return persona;

        }
    }
}
