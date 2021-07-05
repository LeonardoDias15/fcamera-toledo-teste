using FCamara_Test.Dtos;
using FCamara_Test.Models;
using System;
using System.Collections.Generic;

namespace FCamara_Test.Interfaces
{
    public interface IFuncionarioService
    {
        bool Adicionar(Funcionario funcionario);
        bool AdicionarDependente(DependenteFuncionario dependenteFuncionario);
        bool Editar(Funcionario funcionario);
        bool Excluir(Guid id);
        Funcionario BuscarPorId(Guid id);
        List<Funcionario> BuscarPorFiltro(FiltroDTO filtro);
        List<DependenteFuncionario> TodosDependentesDoFuncionario(Guid funcionarioId);
        List<AniversarianteDTO> ListarAniversariantesMes(int mes);
    }
}
