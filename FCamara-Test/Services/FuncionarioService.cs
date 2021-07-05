using FCamara_Test.Dtos;
using FCamara_Test.Help;
using FCamara_Test.Interfaces;
using FCamara_Test.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCamara_Test.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IHistoricoAuditoriaRepositorio _historicoAuditoriaRepositorio;

        public FuncionarioService(IFuncionarioRepositorio funcionarioRepositorio,
                                  IHistoricoAuditoriaRepositorio historicoAuditoriaRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _historicoAuditoriaRepositorio = historicoAuditoriaRepositorio;
        }

        public List<Funcionario> BuscarPorFiltro(FiltroDTO filtro)
        {
            return _funcionarioRepositorio.BuscarPorFiltro(filtro);
        }

        public Funcionario BuscarPorId(Guid id)
        {
            return _funcionarioRepositorio.BuscarPorId(id);
        }

        public bool Adicionar(Funcionario funcionario)
        {
            funcionario.CPF = funcionario.CPF.RemoverMascara();
            funcionario.Cep = funcionario.Cep.RemoverMascara();
            funcionario.Sexo = funcionario.Sexo == '0' ? 'F' : funcionario.Sexo;

            Funcionario funcionarioPorCPF = _funcionarioRepositorio.BuscarPorCPF(funcionario.CPF);

            if(funcionarioPorCPF != null)
            {
                throw new Exception($"Funcionário já cadastrado com o CPF {funcionario.CPF} no banco de dados!");
            }

            bool adicionado = _funcionarioRepositorio.Adicionar(funcionario);

            if (adicionado)
            {
                // salva log historico de auditoria
                HistoricoAuditoria historicoAuditoria = MontarAuditoria("Funcionario", "Adicionado", funcionario.Id, funcionario);
                _historicoAuditoriaRepositorio.Adicionar(historicoAuditoria);
                return true;
            }

            return false;
        }

        public bool AdicionarDependente(DependenteFuncionario dependenteFuncionario)
        {
            dependenteFuncionario.CPF = dependenteFuncionario.CPF.RemoverMascara();

            bool adicionado = _funcionarioRepositorio.AdicionarDependente(dependenteFuncionario);

            if (adicionado)
            {
                // salva log historico de auditoria
                HistoricoAuditoria historicoAuditoria = MontarAuditoria("DependenteFuncionario", "Adicionado", dependenteFuncionario.Id, dependenteFuncionario);
                _historicoAuditoriaRepositorio.Adicionar(historicoAuditoria);
                return true;
            }

            return false;
        }

        public bool Editar(Funcionario funcionario)
        {
            Funcionario funcionarioDB = _funcionarioRepositorio.BuscarPorId(funcionario.Id);

            if (funcionarioDB == null)
            {
                throw new Exception($"Funcionário para o ID {funcionario.Id} não foi encontrado na base de dados!");
            }

            funcionario.CPF = funcionario.CPF.RemoverMascara();
            funcionario.Cep = funcionario.Cep.RemoverMascara();
            funcionario.Sexo = funcionario.Sexo == '0' ? 'F' : funcionario.Sexo;

            Funcionario funcionarioPorCPF = _funcionarioRepositorio.BuscarPorCPF(funcionario.CPF);

            if (funcionarioPorCPF != null && funcionarioPorCPF.Id != funcionario.Id)
            {
                throw new Exception("Funcionário já cadastrado no banco de dados!");
            }

            funcionarioDB.Nome = funcionario.Nome;
            funcionarioDB.CPF = funcionario.CPF;
            funcionarioDB.Sexo = funcionario.Sexo;
            funcionarioDB.DataNascimento = funcionario.DataNascimento;
            funcionarioDB.Cep = funcionario.Cep;
            funcionarioDB.Endereco = funcionario.Endereco;
            funcionarioDB.Numero = funcionario.Numero;
            funcionarioDB.Bairro = funcionario.Bairro;
            funcionarioDB.Complemento = funcionario.Complemento;
            funcionarioDB.Estado = funcionario.Estado;
            funcionarioDB.Cidade = funcionario.Cidade;

            bool editado = _funcionarioRepositorio.Editar(funcionarioDB);

            if (editado)
            {
                // salva log historico de auditoria
                HistoricoAuditoria historicoAuditoria = MontarAuditoria("Funcionario", "Editado", funcionario.Id, funcionarioDB);
                _historicoAuditoriaRepositorio.Adicionar(historicoAuditoria);

                return true;
            }

            return false;
        }

        public bool Excluir(Guid id)
        {
            Funcionario funcionario = _funcionarioRepositorio.BuscarPorId(id);

            if (funcionario == null)
            {
                throw new Exception($"Funcionário para o ID {id} não foi encontrado na base de dados!");
            }

            bool excluido = _funcionarioRepositorio.Excluir(funcionario);

            if (excluido)
            {
                // salva log historico de auditoria
                HistoricoAuditoria historicoAuditoria =  MontarAuditoria("Funcionario", "Excluido", id, funcionario);
                _historicoAuditoriaRepositorio.Adicionar(historicoAuditoria);

                return true;
            }

            return false;
        }

        public List<AniversarianteDTO> ListarAniversariantesMes(int mes)
        {
            List<AniversarianteDTO> aniversarianteDTOs = new List<AniversarianteDTO>();

            List<Funcionario> funcionariosAniversarios =  _funcionarioRepositorio.BuscarAniversariantesMes(mes);
            List<DependenteFuncionario> dependenteFuncionariosAniversarios = _funcionarioRepositorio.BuscarDependentesAniversariantesMes(mes);

            if(funcionariosAniversarios != null && funcionariosAniversarios.Any())
            {
                foreach(var item in funcionariosAniversarios)
                {
                    aniversarianteDTOs.Add(new AniversarianteDTO(item.Nome, item.CPF, item.DataNascimento));
                }
            }

            if (dependenteFuncionariosAniversarios != null && dependenteFuncionariosAniversarios.Any())
            {
                foreach (var item in dependenteFuncionariosAniversarios)
                {
                    aniversarianteDTOs.Add(new AniversarianteDTO(item.Nome, item.CPF, item.DataNascimento));
                }
            }

            return aniversarianteDTOs.OrderBy(x => x.DataNascimento).ToList();
        }

        public List<DependenteFuncionario> TodosDependentesDoFuncionario(Guid funcionarioId)
        {
            return _funcionarioRepositorio.TodosDependentesDoFuncionario(funcionarioId);
        }
        
        private HistoricoAuditoria MontarAuditoria(string funcionalidade, string evento, Guid idFuncionalidade, object dados)
        {
            HistoricoAuditoria historicoAuditoria = new HistoricoAuditoria
            {
                Funcionalidade = funcionalidade,
                Evento = evento,
                IdentificadorFuncionalidade = idFuncionalidade,
                Dados = JsonConvert.SerializeObject(dados)
            };

            return historicoAuditoria;
        }
    }
}
