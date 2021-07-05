using FCamara_Test.Interfaces;
using FCamara_Test.Models;
using System.Collections.Generic;
using System.Linq;

namespace FCamara_Test.Dados.Repositorio
{
    public class HistoricoAuditoriaRepositorio : IHistoricoAuditoriaRepositorio
    {
        private readonly ToledoDBContext _toledoDBContext;

        public HistoricoAuditoriaRepositorio(ToledoDBContext toledoDBContext)
        {
            _toledoDBContext = toledoDBContext;
        }

        public bool Adicionar(HistoricoAuditoria historicoAuditoria)
        {
            _toledoDBContext.Add(historicoAuditoria);
           return _toledoDBContext.SaveChanges() > 0;
        }

        public List<HistoricoAuditoria> BuscarTodos()
        {
            return _toledoDBContext.HistoricoAuditoria
                .OrderBy(x => x.DataCadastro)
                .OrderBy(x => x.IdentificadorFuncionalidade)
                .ToList();
        }
    }
}
