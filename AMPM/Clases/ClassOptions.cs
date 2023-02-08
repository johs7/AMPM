using AMPM;
using AMPM.Clases;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace AMPM.clases
{
    public class ClassOptions
    {
    
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int codigo { get; set; }

        AMPMEntities db = new AMPMEntities();
    

        public bool Guardar(options opt)
        {
            db.options.Add(opt);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Eliminar(options opt)
        {
            db.options.Remove(opt);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Modificar(options opt)
        {
            db.Entry(opt).State = EntityState.Modified;
            return (db.SaveChanges() > 0 ? true : false);
        }

        public options Buscar(int Cod)
        {
            options id = db.options.DefaultIfEmpty(null).FirstOrDefault(o => o.id == Cod);
            return id;
        }
        public List<users> Listar()
        {
            return db.users.ToList();
        }
        public List<options> ListarOpcionesProducto(int codigoProducto)
        {
            return db.options.Where(o => o.product_code == codigoProducto).ToList();
        }
        public string ObtenerIdsFabricantes()
        {
            var fabricantes = from fab in db.products
                              select fab.code;
            string fabId = string.Join("\n", fabricantes);
            return fabId;
        }
        public string ObtenerNomFab(int fabId)
        {
            var fabricante = db.products.FirstOrDefault(f => f.code == fabId);
            return fabricante?.estado;
        }

    }
}