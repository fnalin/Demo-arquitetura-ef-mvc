
namespace DemoEFMVC.App.Dominio.Entidade
{
    public class Foto
    {
        public int ID { get; set; }
        public string NomeArquivo { get; set; }
        public string ExtensaoArquivo { get; set; }
        public string TipoArquivo { get; set; }
        public byte[] Binario { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
