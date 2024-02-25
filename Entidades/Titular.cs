namespace ContaBancaria.Entidades
{
    public class Titular
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
        public DateOnly DataNascimento { get; set; }

        public Titular(string nome, string cpf, Endereco endereco, DateOnly dataNascimento)
        {
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
            DataNascimento = dataNascimento;
        }
    }
}