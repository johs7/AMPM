using AMPM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace AMPM.clases
{
    public class ClassProduct
    {

        AMPMEntities db = new AMPMEntities();
        public bool Guardar(products prod)
        {
            db.products.Add(prod);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Eliminar(products prod)
        {
            db.products.Remove(prod);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Modificar(products prod)
        {
            db.Entry(prod).State = EntityState.Modified;
            return (db.SaveChanges() > 0 ? true : false);
        }

        public products Buscar(int prod)
        {
            products admin;
           admin = db.products.DefaultIfEmpty(null).FirstOrDefault(c => c.code == prod);
            return admin;
        }
        public List<products> Listar()
        {
            return db.products.ToList();
        }
        public List<int> ObtenerIdProductos()
        {
            var productos = from prod in db.products
                            select prod.code;
            List<int> productIds = productos.ToList();
            return productIds;
        }
        public string ObtenerNomFab(int fabId)
        {
            var fabricante = db.products.FirstOrDefault(f => f.code== fabId);
            return fabricante?.nombre;
        }
       
    }
}