using ContaBancaria.Servicos;

namespace ContaBancaria.Entidades
{
    public class Endereco
    {
        public string? cep { get; set; }
        public string? logradouro { get; set; }
        public string? bairro { get; set; }
        public string? localidade { get; set; }
        public string? uf { get; set; }

        public Endereco(string cep, string logradouro, string bairro, string localidade, string uf)
        {
            this.cep = cep;
            this.logradouro = logradouro;
            this.bairro = bairro;
            this.localidade = localidade;
            this.uf = uf;
        }

        public Endereco()
        {
        }

        public override string ToString()
        {
            return "\nCEP: "
            + cep
            + "\nLogradouro: "
            + logradouro
            + "\nBairro: "
            + bairro
            + "\nnLocalidade: "
            + localidade
            + "\nUF: "
            + uf;
        }

        
        public async void ExibirEndereco()
        {
            var endereco = await ClienteHTTP.IntegracaoCep(cep!);
            Console.WriteLine($"CEP: {endereco.cep}");
            Console.WriteLine($"Logradouro: {endereco.logradouro}");
            Console.WriteLine($"Bairro: {endereco.bairro}");
            Console.WriteLine($"Localidade: {endereco.localidade}");
            Console.WriteLine($"UF: {endereco.uf}");
        }
    


    }
}