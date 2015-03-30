using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace DemoEFMVC.Test.Apresentacao.Web.Controllers
{
    [TestClass]
    public class ClientesControllerTest
    {
        //Dado o ClientesController

        [TestMethod]
        public void Verificando_a_action_Index()
        {
            //arrange
            //Dominio.Interface.IClienteServico
            var mockClienteServico = new Mock<App.Dominio.Interface.IClienteServico>();
            var controller = new App.Apresentacao.Web.Controllers.ClientesController(mockClienteServico.Object);

            //act
            var result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(controller);
        }
    }
}
