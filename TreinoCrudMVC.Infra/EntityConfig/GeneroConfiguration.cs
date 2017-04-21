using System.Data.Entity.ModelConfiguration;
using TreinoCrudMVC.Domain;

namespace TreinoCrudMVC.Infra.EntityConfig
{
    public class GeneroConfiguration : EntityTypeConfiguration<Genero>
    {
        public GeneroConfiguration()
        {
            HasKey(p => p.GeneroId);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
