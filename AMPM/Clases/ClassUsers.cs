using AMPM;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace AMPM.clases
{
    public class ClassUsers
    {

        AMPMEntities db = new AMPMEntities();
        public bool Guardar(users usuarios)
        {
            db.users.Add(usuarios);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Eliminar(users usuarios)
        {
            db.users.Remove(usuarios);
            return (db.SaveChanges() > 0 ? true : false);
        }

        public bool Modificar(users usuarios)
        {
            db.Entry(usuarios).State = EntityState.Modified;
            return (db.SaveChanges() > 0 ? true : false);
        }

        public users Buscar(string Cod)
        {
            users usuario = db.users.DefaultIfEmpty(null).FirstOrDefault(u => u.username ==Cod );
            return usuario;
        }
        public List<users> Listar()
        {
            return db.users.ToList();
        }
        public bool Verificar(string name, string pass)
        {
            users adm;
            adm = db.users.DefaultIfEmpty(null).FirstOrDefault
                (ad => ad.username == name && ad.password == pass);
            if (adm.username == name && adm.password == pass)
                return true;
            else
                return false;

        }


    }
}