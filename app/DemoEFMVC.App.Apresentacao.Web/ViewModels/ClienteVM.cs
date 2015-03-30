using System;
using System.ComponentModel.DataAnnotations;

namespace DemoEFMVC.App.Apresentacao.Web.ViewModels
{
    public class ClienteVM
    {
        public ClienteVM()
        {
            //this.Foto = new FotoVM();
        }
        public int ID { get; set; }
        [Required]
        [MaxLength(100), MinLength(5)]
        public string Nome { get; set; }
        [Required]
        public DateTime? Nascimento { get; set; }
        [Required]
        public Dominio.Enum.Sexo? Sexo { get; set; }
        public FotoVM Foto { get; set; }

    }
}