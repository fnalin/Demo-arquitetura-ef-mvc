using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoEFMVC.Test.Dominio.Repositorio
{
    [TestClass]
    public class RepositorioClienteTest
    {

        //Dados um IClienteRepositorio

        [TestMethod]
        public void Verificando_o_comportamento_do_método_Adicionar()
        {
            //arrange
            var cliente = new App.Dominio.Entidade.Cliente
            {
                Nome = "Testando da Silva",
                Nascimento = new DateTime(1958, 08, 21),
                Sexo = App.Dominio.Enum.Sexo.Masculino
            };
            var mockRep = new Mock<App.Dominio.Interface.IClienteRepositorio>();

            //act
            mockRep.Object.Adicionar(cliente);

            //assert
            mockRep.Verify(m => m.Adicionar(It.IsAny<App.Dominio.Entidade.Cliente>()), Times.Once());
        }

        [TestMethod]
        public void Verificando_o_comportamento_do_método_Atualizar()
        {
            //arrange
            var cliente = new App.Dominio.Entidade.Cliente
            {
                ID = 10,
                Nome = "Testando da Silva",
                Nascimento = new DateTime(1958, 08, 21),
                Sexo = App.Dominio.Enum.Sexo.Masculino
            };
            var mockRep = new Mock<App.Dominio.Interface.IClienteRepositorio>();

            //act
            mockRep.Object.Atualizar(cliente);

            //assert
            mockRep.Verify(m => m.Atualizar(It.IsAny<App.Dominio.Entidade.Cliente>()), Times.Once());
        }

        [TestMethod]
        public void Verificando_o_comportamento_do_método_Excluir_um_cliente()
        {
            //arrange
            var clienteID = 5;

            var mockRep = new Mock<App.Dominio.Interface.IClienteRepositorio>();

            //act
            mockRep.Object.Excluir(clienteID);

            //assert
            mockRep.Verify(m => m.Excluir(It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        public void Verificando_o_comportamento_do_método_Excluir_lista_de_clientes()
        {
            //arrange
            var clientes = new List<int> { 1, 2, 3, 4 };

            var mockRep = new Mock<App.Dominio.Interface.IClienteRepositorio>();

            //act
            mockRep.Object.Excluir(clientes);

            //assert
            mockRep.Verify(m => m.Excluir(It.IsAny<List<int>>()), Times.Once());
        }

        [TestMethod]
        public void Verificando_o_comportamento_do_método_ObterPorID()
        {
            //arrange
            var _id = 1;
            var mockRep = new Mock<App.Dominio.Interface.IClienteRepositorio>();
            mockRep.Setup(mr => mr.ObterPorID(_id)).Returns(ObterClientesStub().FirstOrDefault(d => d.ID == _id));

            //act
            var dado = mockRep.Object.ObterPorID(_id);

            Assert.AreEqual(dado.ID, _id);
        }

        [TestMethod]
        public void Verificando_o_comportamento_do_método_Todos()
        {
            //arrange
            var mockRep = new Mock<App.Dominio.Interface.IClienteRepositorio>();
            mockRep.Setup(mr => mr.Todos()).Returns(ObterClientesStub);

            //act
            var dados = mockRep.Object.Todos();

            //assert
            Assert.IsNotNull(dados); // testando se tá nulo
            Assert.AreEqual(3, dados.Count()); // comprando o n. de itens

        }

        [TestMethod]
        public void Verificando_o_comportamento_do_método_Salvar()
        {
            //arrange
            var mockRep = new Mock<App.Dominio.Interface.IClienteRepositorio>();

            //act
            mockRep.Object.Salvar();

            //assert
            mockRep.Verify(m => m.Salvar(), Times.Once());

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
