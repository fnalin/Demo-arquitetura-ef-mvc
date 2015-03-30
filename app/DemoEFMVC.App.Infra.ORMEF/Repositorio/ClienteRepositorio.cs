using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoEFMVC.App.Infra.ORMEF.Repositorio
{
    public class ClienteRepositorio : Dominio.Interface.IClienteRepositorio
    {
        private Contexto.DemoEFMVCContexto _ctx;
        private readonly System.Data.Entity.IDbSet<Dominio.Entidade.Cliente> _dbSet;


        public ClienteRepositorio()
        {
            _ctx = new Contexto.DemoEFMVCContexto();
            _dbSet = _ctx.Set<Dominio.Entidade.Cliente>();
        }

        public void Adicionar(Dominio.Entidade.Cliente cliente)
        {
            _dbSet.Add(cliente);
        }

        public void Atualizar(Dominio.Entidade.Cliente cliente)
        {
            var dadosDB = ObterPorID(cliente.ID);
            dadosDB.Nome = cliente.Nome;
            dadosDB.Nascimento = cliente.Nascimento;
            dadosDB.Sexo = cliente.Sexo;

            //Atualizando a foto se necessário
            if (cliente.Foto != null && cliente.Foto.Binario.Length > 0)
            {
                if (dadosDB.Foto != null)
                {
                    dadosDB.Foto.NomeArquivo = cliente.Foto.NomeArquivo;
                    dadosDB.Foto.ExtensaoArquivo = cliente.Foto.ExtensaoArquivo;
                    dadosDB.Foto.TipoArquivo = cliente.Foto.TipoArquivo;
                    dadosDB.Foto.Binario = cliente.Foto.Binario;
                }
                else
                {
                    var novaFoto = new Dominio.Entidade.Foto
                    {
                        NomeArquivo = cliente.Foto.NomeArquivo,
                        ExtensaoArquivo = cliente.Foto.ExtensaoArquivo,
                        TipoArquivo = cliente.Foto.TipoArquivo,
                        Binario = cliente.Foto.Binario
                    };
                    dadosDB.Foto = novaFoto;
                }
            }
            else if (cliente.Foto != null && cliente.Foto.NomeArquivo != dadosDB.Foto.NomeArquivo)
            {
                dadosDB.Foto = null;
            }
        }

        public void Excluir(int id)
        {
            var cli = ObterPorID(id);

            if (cli == null)
                throw new Exception("Cliente não encontrado");

            _dbSet.Remove(cli);
        }

        public void Excluir(List<int> itens)
        {
            var clientes = _dbSet.Where(d => itens.Contains(d.ID));
            
            if (clientes == null)
                throw new Exception("Cliente(s) não encontrado(s)");

            clientes.ToList().ForEach(d => {
                _dbSet.Remove(d);
            });
        }

        public Dominio.Entidade.Cliente ObterPorID(int id)
        {
            return _dbSet.Find(id);
        }

        public IList<Dominio.Entidade.Cliente> Todos()
        {
            return _dbSet.ToList();
        }

        public void Salvar()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

    }
}
