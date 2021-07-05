using System;

namespace FCamara_Test.Models
{
    public class DependenteFuncionario : Entidade
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public Guid FuncionarioId { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}
