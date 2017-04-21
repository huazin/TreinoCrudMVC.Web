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
    public class LivroRepository : IDisposable, ICrud<Livro>
    {
        public TreinoCrudContext Db = new TreinoCrudContext();
        public void Add(Livro livro)
        {
            Db.Livros.Add(livro);
            Db.SaveChanges();
        }

        public void Edit(Livro livro)
        {
            Db.Entry(livro).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(Livro livro)
        {
            Db.Livros.Remove(livro);
            Db.SaveChanges();
        }

        public Livro FindById(int id)
        {
            return Db.Livros.Find(id);
        }

        public IEnumerable<Livro> List()
        {
            return Db.Livros.ToList();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
