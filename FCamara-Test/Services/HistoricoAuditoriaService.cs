using FCamara_Test.Interfaces;
using FCamara_Test.Models;
using System.Collections.Generic;

namespace FCamara_Test.Services
{
    public class HistoricoAuditoriaService : IHistoricoAuditoriaService
    {
        private readonly IHistoricoAuditoriaRepositorio _historicoAuditoriaRepositorio;

        public HistoricoAuditoriaService(IHistoricoAuditoriaRepositorio historicoAuditoriaRepositorio)
        {
            _historicoAuditoriaRepositorio = historicoAuditoriaRepositorio;
        }

        public List<HistoricoAuditoria> BuscarTodos()
        {
            return _historicoAuditoriaRepositorio.BuscarTodos();
        }
    }
}
