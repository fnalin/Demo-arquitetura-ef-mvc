using System;
using System.Collections.Generic;

namespace DemoEFMVC.App.Dominio.Interface
{
    public interface IClienteServico : IDisposable
    {
        IList<Entidade.Cliente> Clientes();
        Entidade.Cliente ObterCliente(int id);
        void AdicionarOuEditarCliente(Entidade.Cliente cliente);
        void ExcluirCliente(int id);

        void ExcluirClientes(List<int> itens);
    }
}
