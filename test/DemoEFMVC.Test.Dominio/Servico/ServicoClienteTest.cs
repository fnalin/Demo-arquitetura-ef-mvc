using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoEFMVC.Test.Dominio.Servico
{
    [TestClass]
    public class ServicoClienteTest
    {
         //Dado ClienteServico

        [TestMethod]
        public void Verificando_o_método_Clientes()
        {
            //arrange
            var mockRep = new Mock<App.Dominio.Interface.IClienteRepositorio>();
            mockRep.Setup(mr => mr.Todos()).Returns(ObterClientesStub);

            var _cliServ = new App.Dominio.Servico.ClienteServico(mockRep.Object);

            //act
            var clientes = _cliServ.Clientes();

            //assert
            Assert.IsNotNull(clientes);
            Assert.AreEqual(3, clientes.Count());
        }

        private IList<App.Dominio.Entidade.Cliente> ObterClientesStub()
        {
            return new List<App.Dominio.Entidade.Cliente> { 
                new App.Dominio.Entidade.Cliente{ID=1,Nome="ID 1",Nascimento=new DateTime(1979,01,01),Sexo=App.Dominio.Enum.Sexo.Feminino},
                new App.Dominio.Entidade.Cliente{ID=2,Nome="ID 2",Nascimento=new DateTime(1966,10,11),Sexo=App.Dominio.Enum.Sexo.Feminino},
                new App.Dominio.Entidade.Cliente{ID=3,Nome="ID 3",Nascimento=new DateTime(1978,3,10),Sexo=App.Dominio.Enum.Sexo.Masculino},
            };
        }
    }
}
