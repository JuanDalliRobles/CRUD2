using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace CRUD2
{
    internal class ClaseDatos
    {
        dbCrudDataBaseEntities db;
        public void Create(tabla_usuarios nUsuario)
        {
            try
            {
                using (db = new dbCrudDataBaseEntities())
                {
                    db.tabla_usuarios.Add(nUsuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        public List<tabla_usuarios> Read()
        {
            try
            {
                using (db = new dbCrudDataBaseEntities())
                {
                    return db.tabla_usuarios.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void Update(tabla_usuarios nUsuario)
        {
            try
            {
                using(db = new dbCrudDataBaseEntities())
                {
                    db.Entry(nUsuario).State=EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(int nID)
        {
            try
            {
                using (db = new dbCrudDataBaseEntities())
                {
                    db.tabla_usuarios.Remove(db.tabla_usuarios.Single(n => n.ID == nID));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<tabla_usuarios> BuscarID(int nID)
        {
            try
            {
                using (db = new dbCrudDataBaseEntities())
                {
                    return db.tabla_usuarios.Where(n => n.ID == nID).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<tabla_usuarios> BuscarNombre(string nNombre)
        {
            try
            {
                using (db = new dbCrudDataBaseEntities())
                {
                    return db.tabla_usuarios.Where(n => n.Nombre.Contains(nNombre)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
