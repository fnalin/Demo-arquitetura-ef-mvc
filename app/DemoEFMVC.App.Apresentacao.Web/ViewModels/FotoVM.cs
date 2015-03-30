
namespace DemoEFMVC.App.Apresentacao.Web.ViewModels
{
    public class FotoVM
    {
        public int ID { get; set; }
        public string NomeArquivo { get; set; }
        public string ExtensaoArquivo { get; set; }
        public string TipoArquivo { get; set; }
        public byte[] Binario { get; set; }
    }
}