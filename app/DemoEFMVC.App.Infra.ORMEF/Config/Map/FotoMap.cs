using System.Data.Entity.ModelConfiguration;

namespace DemoEFMVC.App.Infra.ORMEF.Config.Map
{
    public class FotoMap:EntityTypeConfiguration<Dominio.Entidade.Foto>
    {
        public FotoMap()
        {
            //tabela
            this.ToTable("FotoCliente");

            //pk
            this.HasKey(k => k.ID);

            //campos
            this.Property(c => c.ID).HasColumnName("ID").HasColumnType("int");
            this.Property(c => c.NomeArquivo).HasColumnName("NomeArquivo").HasColumnType("varchar").HasMaxLength(250).IsRequired();
            this.Property(c => c.ExtensaoArquivo).HasColumnName("ExtensaoArquivo").HasColumnType("char").HasMaxLength(5).IsRequired();
            this.Property(c => c.TipoArquivo).HasColumnName("TipoArquivo").HasColumnType("varchar").HasMaxLength(250).IsRequired();
            this.Property(c => c.Binario).HasColumnName("Binario").HasColumnType("varbinary(max)").IsRequired();

            //relacionamentos
            this.HasRequired(t => t.Cliente)
                .WithRequiredDependent(d => d.Foto)
                .WillCascadeOnDelete(true);
        }
    }
}
