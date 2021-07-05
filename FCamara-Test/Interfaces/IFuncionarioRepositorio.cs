using FCamara_Test.Dtos;
using FCamara_Test.Models;
using System;
using System.Collections.Generic;

namespace FCamara_Test.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        bool Adicionar(Funcionario funcionario);
        bool AdicionarDependente(DependenteFuncionario dependenteFuncionario);
        bool Editar(Funcionario funcionario);
        bool Excluir(Funcionario funcionario);
        Funcionario BuscarPorId(Guid id);
        Funcionario BuscarPorCPF(string cpf);
        List<Funcionario> BuscarPorFiltro(FiltroDTO filtro);
        List<DependenteFuncionario> TodosDependentesDoFuncionario(Guid funcionarioId);
        List<Funcionario> BuscarAniversariantesMes(int mes);
        List<DependenteFuncionario> BuscarDependentesAniversariantesMes(int mes);
    }
}
