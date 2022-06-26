//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.PostGreSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBehind.PostGreSQL.Repository
{
    public interface IPessoaRepository
    {
        Pessoa Selecionar(Guid id);

        int Persistir(Pessoa cliente);
        IEnumerable<Pessoa> Listar();

        int Excluir(Guid id);

        int Atualizar(Pessoa cliente);

    }

    public class PessoaRepository : IPessoaRepository
    {

        private readonly Contexto _contexto;

        public PessoaRepository(Contexto contexto_)
        {
            _contexto = contexto_;
        }

        public IEnumerable<Pessoa> Listar()
        {
            return _contexto.Set<Pessoa>();
        }

        public int Persistir(Pessoa cliente)
        {
            _contexto.Clientes.Add(cliente);
            return _contexto.SaveChanges();
        }

        public int Atualizar(Pessoa cliente)
        {
            _contexto.Update(cliente);
            return _contexto.SaveChanges();
        }

        public int Excluir(Guid id)
        {
            _contexto.Clientes.Remove(_contexto.Clientes.Find(id));
            return _contexto.SaveChanges();
        }

        public Pessoa Selecionar(Guid id)
        {
            return _contexto.Set<Pessoa>().FirstOrDefault(x => x.Id == id);
        }
    }
}
