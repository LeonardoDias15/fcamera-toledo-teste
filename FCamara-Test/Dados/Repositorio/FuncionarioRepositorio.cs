using FCamara_Test.Dtos;
using FCamara_Test.Interfaces;
using FCamara_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCamara_Test.Dados.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly ToledoDBContext _toledoDBContext;

        public FuncionarioRepositorio(ToledoDBContext toledoDBContext)
        {
            _toledoDBContext = toledoDBContext;
        }

        public List<Funcionario> BuscarPorFiltro(FiltroDTO filtro)
        {
            IQueryable<Funcionario> query = _toledoDBContext
                    .Funcionario
                    .Include(x => x.DependenteFuncionarios)
                    .AsQueryable();

            if(filtro != null)
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                {
                    query = query.Where(x => x.Nome.Contains(filtro.Nome));
                }

                if (!string.IsNullOrEmpty(filtro.Sexo))
                {
                    query = query.Where(x => x.Sexo == filtro.Sexo.ToCharArray().FirstOrDefault());
                }

                if (filtro.Ativo != null && filtro.Ativo.HasValue)
                {
                    query = query.Where(x => x.Ativo == filtro.Ativo);
                }

                if (filtro.ExibirNaoDependentes != null && filtro.ExibirNaoDependentes.HasValue && filtro.ExibirNaoDependentes.Value == true)
                {
                    query = query.Where(x => !x.DependenteFuncionarios.Any());
                }
            }

            return query.ToList();
        }

        public Funcionario BuscarPorId(Guid id)
        {
            return _toledoDBContext.Funcionario.Find(id);
        }

        public Funcionario BuscarPorCPF(string cpf)
        {
            return _toledoDBContext.Funcionario
                    .FirstOrDefault(x => x.CPF == cpf);
        }

        public List<DependenteFuncionario> TodosDependentesDoFuncionario(Guid funcionarioId)
        {
            return _toledoDBContext.DependenteFuncionario
                    .Where(x => x.FuncionarioId == funcionarioId)
                    .OrderBy(x => x.DataCadastro)
                    .ToList();
        }

        public List<Funcionario> BuscarAniversariantesMes(int mes)
        {
            return _toledoDBContext.Funcionario
                    .Where(x => x.DataNascimento.Month == mes)
                    .OrderBy(x => x.DataNascimento)
                    .ToList();
        }

        public List<DependenteFuncionario> BuscarDependentesAniversariantesMes(int mes)
        {
            return _toledoDBContext.DependenteFuncionario
                    .Where(x => x.DataNascimento.Month == mes)
                    .OrderBy(x => x.DataNascimento)
                    .ToList();
        }

        public bool Adicionar(Funcionario funcionario)
        {
            _toledoDBContext.Add(funcionario);
           return _toledoDBContext.SaveChanges() > 0;
        }

        public bool AdicionarDependente(DependenteFuncionario dependenteFuncionario)
        {
            _toledoDBContext.DependenteFuncionario.Add(dependenteFuncionario);
            return _toledoDBContext.SaveChanges() > 0;
        }

        public bool Editar(Funcionario funcionario)
        {
            funcionario.DataAtualizacao = DateTime.Now;
            _toledoDBContext.Update(funcionario);
            return _toledoDBContext.SaveChanges() > 0;
        }

        public bool Excluir(Funcionario funcionario)
        {
            funcionario.Ativo = false;
            funcionario.DataAtualizacao = DateTime.Now;
            _toledoDBContext.Update(funcionario);
            return _toledoDBContext.SaveChanges() > 0;
        }
    }
}
