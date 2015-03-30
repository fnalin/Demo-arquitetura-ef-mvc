using System;
using System.Collections.Generic;

namespace DemoEFMVC.App.Dominio.Entidade
{
    public class Cliente
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public Enum.Sexo Sexo { get; set; }
        public virtual Foto Foto { get; set; }

        public void ChecarCliente()
        {
            var mensagem = new List<string>();

            if (string.IsNullOrEmpty(Nome) || Nome.Trim().Length == 0)
                mensagem.Add("Nome inválido");

            if (Nascimento == new DateTime())
                mensagem.Add("Nascimento inválido");

            if (mensagem.Count > 0)
                throw new Exception(string.Join(" | ", mensagem));
        }
    }
}
