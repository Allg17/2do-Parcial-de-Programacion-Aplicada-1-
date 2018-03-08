using Segundo_Parcial_Aplicada.DAL;
using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Segundo_Parcial_Aplicada.BLL
{
    public class TipotelefonoesBLL
    {
        public static bool Guardar(TipoTelefonoes telefono)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Tipo.Add(telefono) != null)
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
                var eliminar = db.Tipo.Find(id);
                if (db.Tipo.Remove(eliminar) != null)
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

        public static bool Modificar(TipoTelefonoes telefono)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Entry(telefono).State = System.Data.Entity.EntityState.Modified;
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

        public static TipoTelefonoes Buscar(int id)
        {
            Contexto db = new Contexto();
            TipoTelefonoes telefono = new TipoTelefonoes();
            try
            {
                telefono = db.Tipo.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return telefono;
        }

        public static List<TipoTelefonoes> GetList(Expression<Func<TipoTelefonoes, bool>> tipos)
        {
            List<TipoTelefonoes> telefono = new List<TipoTelefonoes>();
            Contexto db = new Contexto();
            try
            {
                telefono = db.Tipo.Where(tipos).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return telefono;

        }
    }
}
