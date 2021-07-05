using System;

namespace FCamara_Test.Models
{
    public class Entidade
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
