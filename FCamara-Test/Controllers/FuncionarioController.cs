using FCamara_Test.Dtos;
using FCamara_Test.Interfaces;
using FCamara_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FCamara_Test.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(Guid id)
        {
            Funcionario funcionario = _funcionarioService.BuscarPorId(id);

            return View(funcionario);
        }

        [HttpGet]
        public IActionResult NovoDependente(Guid id)
        {
            DependenteFuncionario dependenteFuncionario = new DependenteFuncionario
            {
                FuncionarioId = id
            };

            return View(dependenteFuncionario);
        }

        [HttpGet]
        public IActionResult Excluir(Guid id)
        {
            bool excluido = _funcionarioService.Excluir(id);

            if (excluido)
            {
                return View("ExcluidoComSucesso");
            }

            return View();
        }

        [HttpGet]
        public IActionResult MostrarDependentes(Guid id)
        {
           List<DependenteFuncionario> dependenteFuncionarios = _funcionarioService.TodosDependentesDoFuncionario(id);
            return View(dependenteFuncionarios);
        }

        [HttpGet]
        public IActionResult CadastroFeitoComSucesso()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditadoComSucesso()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExcluidoComSucesso()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult ListagemFuncionarios(FiltroDTO filtroDTO)
        {
            List<Funcionario> funcionarios = _funcionarioService.BuscarPorFiltro(filtroDTO);

            return PartialView(funcionarios);
        }

        [HttpPost]
        public IActionResult CadastrarFuncionario(Funcionario funcionario)
        {
            try
            {
                bool adicionado = _funcionarioService.Adicionar(funcionario);

                if (adicionado)
                {
                    return View("CadastroFeitoComSucesso");
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Novo");
            }
        }

        [HttpPost]
        public IActionResult EditarFuncionario(Funcionario funcionario)
        {
            bool editado = _funcionarioService.Editar(funcionario);

            if (editado)
            {
                return View("EditadoComSucesso");
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult CadastrarDependenteFuncionario(DependenteFuncionario dependenteFuncionario)
        {
            try
            {
                bool adicionado = _funcionarioService.AdicionarDependente(dependenteFuncionario);

                if (adicionado)
                {
                    return View("CadastroFeitoComSucesso");
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("NovoDependente");
            }
        }
    }
}
