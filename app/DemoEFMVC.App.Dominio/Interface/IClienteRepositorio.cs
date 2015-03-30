using System;
using System.Collections.Generic;

namespace DemoEFMVC.App.Dominio.Interface
{
    public interface IClienteRepositorio : IDisposable
    {
        void Adicionar(Entidade.Cliente cliente);
        void Atualizar(Entidade.Cliente cliente);
        void Excluir(List<int> itens);
        void Excluir(int id);
        Entidade.Cliente ObterPorID(int id);
        IList<Entidade.Cliente> Todos();
        void Salvar();

    }
}
