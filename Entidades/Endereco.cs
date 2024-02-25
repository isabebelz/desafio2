namespace ContaBancaria.Entidades
{
    public class Endereco
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Estado { get; set; }

        public Endereco(string cep, string logradouro, string bairro, string localidade, string estado)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Localidade = localidade;
            Estado = estado;
        }

        public Endereco()
        {
        }
        public override string ToString()
        {
            return "\nCEP: "
            + Cep
            + "\nLogradouro: "
            + Logradouro
            + "\nBairro: "
            + Bairro
            + "\nnLocalidade: "
            + Localidade
            + "\nUF: "
            + Estado;
        }

    


    }
}