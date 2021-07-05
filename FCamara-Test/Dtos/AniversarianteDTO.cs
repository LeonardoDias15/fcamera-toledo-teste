using System;

namespace FCamara_Test.Dtos
{
    public class AniversarianteDTO
    {
        public AniversarianteDTO(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
