using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DemoEFMVC.App.Infra.ORMEF.Config.Map
{
    public class ClienteMap : EntityTypeConfiguration<Dominio.Entidade.Cliente>
    {
        public ClienteMap()
        {
            //Tabela
            this.ToTable("Cliente");

            //PK
            this.HasKey(k => k.ID);

            //Campos
            this.Property(c => c.ID).HasColumnName("ID").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(100).IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_dbo.Cliente.Nome-Nascimento", 0) { IsUnique = true }));

            this.Property(c => c.Nascimento).HasColumnName("Nascimento").HasColumnType("date").IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_dbo.Cliente.Nome-Nascimento", 1) { IsUnique = true }));

            this.Property(c => c.Sexo).HasColumnName("Sexo").HasColumnType("int").IsRequired();
        }
    }
}
