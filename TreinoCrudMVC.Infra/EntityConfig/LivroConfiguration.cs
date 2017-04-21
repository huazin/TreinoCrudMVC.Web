using System.Data.Entity.ModelConfiguration;
using TreinoCrudMVC.Domain;

namespace TreinoCrudMVC.Infra.EntityConfig
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            HasKey(p => p.LivroId);

            Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(p => p.Editora)
                .WithMany()
                .HasForeignKey(p => p.EditoraId);

            HasRequired(p => p.Genero)
                .WithMany()
                .HasForeignKey(p => p.GeneroId);

        }
    }
}
