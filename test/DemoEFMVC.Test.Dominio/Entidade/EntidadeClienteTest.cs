using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoEFMVC.Test.Dominio.Entidade
{
    [TestClass]
    public class EntidadeClienteTest
    {
        
        //Dados um cliente


        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Deverá_ser_disparado_uma_exceção_em_caso_de_nome_nulo()
        {
            //arrange
            var cliente = new App.Dominio.Entidade.Cliente { 
                ID=1,
                Nome=null,
                Nascimento = new DateTime(1999,08,20),
                Sexo = App.Dominio.Enum.Sexo.Masculino
            };

            //act
            cliente.ChecarCliente();

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Deverá_ser_disparado_uma_exceção_em_caso_de_nome_vazio()
        {
            //arrange
            var cliente = new App.Dominio.Entidade.Cliente
            {
                ID = 1,
                Nome = string.Empty,
                Nascimento = new DateTime(1999, 08, 20),
                Sexo = App.Dominio.Enum.Sexo.Masculino
            };

            //act
            cliente.ChecarCliente();

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Deverá_ser_disparado_uma_exceção_em_caso_de_nascimento_nao_informado()
        {
            //arrange
            var cliente = new App.Dominio.Entidade.Cliente
            {
                ID = 1,
                Nome = "Teste da Silva",
                Sexo = App.Dominio.Enum.Sexo.Masculino
            };

            //act
            cliente.ChecarCliente();

            //assert
        }

    }
}
