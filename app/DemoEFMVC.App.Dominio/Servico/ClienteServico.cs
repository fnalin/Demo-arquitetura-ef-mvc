using System.Collections.Generic;

namespace DemoEFMVC.App.Dominio.Servico
{
    public class ClienteServico : Interface.IClienteServico
    {
        private readonly Interface.IClienteRepositorio _cliRep;

        public ClienteServico(Interface.IClienteRepositorio cliRep)
        {
            _cliRep = cliRep;
        }

        public IList<Entidade.Cliente> Clientes()
        {
            return _cliRep.Todos();
        }

        public Entidade.Cliente ObterCliente(int id)
        {
            return _cliRep.ObterPorID(id);
        }

        public void AdicionarOuEditarCliente(Entidade.Cliente cliente)
        {
            cliente.ChecarCliente();


            if (cliente.ID == 0)
            {
                _cliRep.Adicionar(cliente);
                if (cliente.Foto.Binario.Length == 0)
                    cliente.Foto = null;
            }
            else
                _cliRep.Atualizar(cliente);

            _cliRep.Salvar();
        }

        public void ExcluirCliente(int id)
        {
            _cliRep.Excluir(id);
            _cliRep.Salvar();
        }

        public void ExcluirClientes(List<int> itens)
        {
            _cliRep.Excluir(itens);
            _cliRep.Salvar();
        }

        public void Dispose()
        {
            _cliRep.Dispose();
        }
    }
}
