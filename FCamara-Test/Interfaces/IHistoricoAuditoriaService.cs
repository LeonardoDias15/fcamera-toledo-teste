using FCamara_Test.Models;
using System.Collections.Generic;

namespace FCamara_Test.Interfaces
{
    public interface IHistoricoAuditoriaService
    {
        List<HistoricoAuditoria> BuscarTodos();
    }
}
