using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using TreinoCrudMVC.Domain;
using TreinoCrudMVC.Infra.EntityConfig;

namespace TreinoCrudMVC.Infra.Context
{
    public class TreinoCrudContext : DbContext
    {
        public TreinoCrudContext()
            //Cria o contexto do entity com a string de conexão
            : base("TreinoCrudContext")
        {

        }
        //Adiciona os Dbs Sets das classes
        public DbSet<Livro> Livros { get; set;}
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remover conversões desnecessarias
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Propriedades basicas.
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //Cria configurações proprias para cada Entidade
            modelBuilder.Configurations.Add(new LivroConfiguration());
            modelBuilder.Configurations.Add(new GeneroConfiguration());
            modelBuilder.Configurations.Add(new EditoraConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()//Salvar Mudanças
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
