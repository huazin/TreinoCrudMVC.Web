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
    public class GeneroRepository : IDisposable , ICrud<Genero>
    {
        public TreinoCrudContext Db = new TreinoCrudContext();
        public void Add(Genero genero)
        {
            Db.Generos.Add(genero);
            Db.SaveChanges();
        }

        public void Edit(Genero genero)
        {
            Db.Entry(genero).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(Genero genero)
        {
            Db.Generos.Remove(genero);
            Db.SaveChanges();
        }

        public Genero FindById(int id)
        {
            return Db.Generos.Find(id);
        }

        public IEnumerable<Genero> List()
        {
            return Db.Generos.ToList();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
