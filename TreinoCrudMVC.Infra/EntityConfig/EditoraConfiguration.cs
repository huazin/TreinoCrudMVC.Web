using System.Data.Entity.ModelConfiguration;
using TreinoCrudMVC.Domain;

namespace TreinoCrudMVC.Infra.EntityConfig
{
    public class EditoraConfiguration : EntityTypeConfiguration<Editora>
    {
        public EditoraConfiguration()
        {
            HasKey(p => p.EditoraId);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

        }
    }
}
