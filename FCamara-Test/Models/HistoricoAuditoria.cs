using System;

namespace FCamara_Test.Models
{
    public class HistoricoAuditoria : Entidade
    {
        // Campo responsavel por quardar o identificador da tabela a ser gravada como historico
        public string Funcionalidade { get; set; }

        // Nome da ação que esta sendo gravada, exemplo (criado,editado,excluido)
        public string Evento { get; set; }

        // Campo onde ira guardar, o json do dado a ser alterado ou criado ou excluido
        public string Dados { get; set; }

        // ID do registro que esta sendo gravado, exemplo (criado,editado,excluido)
        public Guid IdentificadorFuncionalidade { get; set; }
    }
}
