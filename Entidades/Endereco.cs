using ContaBancaria.Servicos;

namespace ContaBancaria.Entidades
{
    public class Endereco
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? UF { get; set; }

        public Endereco(string cep, string logradouro, string bairro, string localidade, string uf)
        {
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Localidade = localidade;
            UF = uf;
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
            + UF;
        }

        
        public void ExibirEndereco()
        {
            Console.WriteLine($"CEP: {Cep}");
            Console.WriteLine($"Logradouro: {Logradouro}");
            Console.WriteLine($"Bairro: {Bairro}");
            Console.WriteLine($"Localidade: {Localidade}");
            Console.WriteLine($"UF: {UF}");
        }
    


    }
}