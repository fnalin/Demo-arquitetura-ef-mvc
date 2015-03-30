using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace DemoEFMVC.App.Infra.ORMEF.Contexto
{
    public class DemoEFMVCContexto : DbContext
    {
        static DemoEFMVCContexto()
        {
            //Database.SetInitializer<DemoEFMVCContexto>(null);
            Database.SetInitializer<DemoEFMVCContexto>(new CreateDatabaseIfNotExists<DemoEFMVCContexto>());
            //Database.SetInitializer<DemoEFMVCContexto>(new DropCreateDatabaseIfModelChanges<DemoEFMVCContexto>());
            //Database.SetInitializer<DemoEFMVCContexto>(new DropCreateDatabaseAlways<DemoEFMVCContexto>());
        }

        public DemoEFMVCContexto()
            : base("Name=ContextoLocalDB")
        { }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Obtendo a lista de erros
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // transformando em uma string única
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Juntando ex.Message com os erros de validação.
                var exceptionMessage = string.Concat(ex.Message, " Erros na validação: ", fullErrorMessage);

                // Throw DbEntityValidationException com os erros de validação.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Config.Map.ClienteMap());
            modelBuilder.Configurations.Add(new Config.Map.FotoMap());
        }
    }
}
