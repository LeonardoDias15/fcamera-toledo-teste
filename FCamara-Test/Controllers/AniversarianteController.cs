using FCamara_Test.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FCamara_Test.Controllers
{
    public class AniversarianteController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;

        public AniversarianteController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult ListagemAniversariantes(int mes)
        {
            var aniversariantes =  _funcionarioService.ListarAniversariantesMes(mes);
            return PartialView(aniversariantes);
        }
    }
}
