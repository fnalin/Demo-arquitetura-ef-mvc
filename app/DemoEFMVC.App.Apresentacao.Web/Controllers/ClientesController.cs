using System;
using System.IO;
using System.Web.Mvc;
using DemoEFMVC.App.Apresentacao.Web.Infra;
using System.Linq;

namespace DemoEFMVC.App.Apresentacao.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Dominio.Interface.IClienteServico _cliServ;
        public ClientesController(Dominio.Interface.IClienteServico cliServ)
        {
            _cliServ = cliServ;
        }

        public ActionResult Index()
        {
            return View(_cliServ.Clientes());
        }

        [HttpPost]
        public JsonResult RemoverClientes(string ids)
        {
            //System.Threading.Thread.Sleep(2000);
            var itens = ids.Split(',').Select(Int32.Parse).ToList();
            var mensagem = string.Empty;

            try
            {
                _cliServ.ExcluirClientes(itens);
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return Json(new { msg = mensagem }, JsonRequestBehavior.DenyGet);
        }

        public ActionResult Novo()
        {
            return View("AddEditCliente", new ViewModels.ClienteVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(ViewModels.ClienteVM dadosForm)
        {
            return salvarCliente(dadosForm);
        }

        public ActionResult Editar(int id)
        {
            var dados = _cliServ.ObterCliente(id).ToClienteVM();

            if (dados == null)
                throw new System.Web.HttpException(400, "O cliente não foi encontrado ou não está disponível para edição");

            return View("AddEditCliente", dados);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ViewModels.ClienteVM dadosForm)
        {
            return salvarCliente(dadosForm);
        }

        private ActionResult salvarCliente(ViewModels.ClienteVM dadosForm)
        {


            if (Request.Files[0].ContentLength > 0)
                dadosForm.Foto = MontarFoto(Request.Files[0]);

            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = dadosForm.ToCliente();
                    _cliServ.AdicionarOuEditarCliente(cliente);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        if (ex.InnerException.ToString().Contains("UQ_dbo.Cliente.Nome-Nascimento"))
                        {
                            ModelState.AddModelError("", "Já existe um cliente cadastrado com esse nome e essa data de nascimento");
                        }
                        else
                            ModelState.AddModelError("", ex.InnerException.ToString());
                    }
                    else
                        ModelState.AddModelError("", ex.Message);
                }
            }
            return View("AddEditCliente", dadosForm);
        }

        private ViewModels.FotoVM MontarFoto(System.Web.HttpPostedFileBase file)
        {

            if (file.ContentLength > 1048576) //1MB
            {
                ModelState.AddModelError("", "Arquivo excedeu o limite permitido");
            }

            var foto = new ViewModels.FotoVM();
            FileInfo arqEnviado = null;
            arqEnviado = new FileInfo(file.FileName);

            if (arqEnviado != null)
            {
                foto.NomeArquivo = arqEnviado.Name;
                foto.ExtensaoArquivo = arqEnviado.Extension;
                foto.TipoArquivo = file.ContentType;
                using (var reader = new BinaryReader(file.InputStream))
                {
                    foto.Binario = reader.ReadBytes(file.ContentLength);
                }
            }

            return foto;
        }

        protected override void Dispose(bool disposing)
        {
            _cliServ.Dispose();
        }
    }
}