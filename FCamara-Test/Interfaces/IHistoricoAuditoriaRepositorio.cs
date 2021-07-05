using FCamara_Test.Models;
using System.Collections.Generic;

namespace FCamara_Test.Interfaces
{
    public interface IHistoricoAuditoriaRepositorio
    {
        bool Adicionar(HistoricoAuditoria funcionario);
        List<HistoricoAuditoria> BuscarTodos();
    }
}
