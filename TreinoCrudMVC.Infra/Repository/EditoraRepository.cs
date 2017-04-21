using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinoCrudMVC.Domain;
using TreinoCrudMVC.Infra.Context;

namespace TreinoCrudMVC.Infra.Repository
{
    public class EditoraRepository : IDisposable , ICrud<Editora>
    {
        public TreinoCrudContext Db = new TreinoCrudContext();
        public void Add(Editora editora)
        {
            Db.Editoras.Add(editora);
            Db.SaveChanges();
        }

        public void Edit(Editora editora)
        {
            Db.Entry(editora).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(Editora editora)
        {
            Db.Editoras.Remove(editora);
            Db.SaveChanges();
        }

        public Editora FindById(int id)
        {
            return Db.Editoras.Find(id);
        }

        public IEnumerable<Editora> List()
        {
            return Db.Editoras.ToList();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
