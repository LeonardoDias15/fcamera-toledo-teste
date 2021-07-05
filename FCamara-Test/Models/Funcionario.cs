using System;
using System.Collections.Generic;

namespace FCamara_Test.Models
{
    public class Funcionario : Entidade
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public  char Sexo { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public virtual ICollection<DependenteFuncionario> DependenteFuncionarios { get; set; }
    }
}
