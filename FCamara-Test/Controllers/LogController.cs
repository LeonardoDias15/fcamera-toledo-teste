using FCamara_Test.Interfaces;
using FCamara_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FCamara_Test.Controllers
{
    public class LogController : Controller
    {
        private readonly IHistoricoAuditoriaService _historicoAuditoriaService;

        public LogController(IHistoricoAuditoriaService historicoAuditoriaService)
        {
            _historicoAuditoriaService = historicoAuditoriaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<HistoricoAuditoria> logs = _historicoAuditoriaService.BuscarTodos();

            return View(logs);
        }
    }
}
