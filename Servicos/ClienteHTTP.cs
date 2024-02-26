using System.Text.Json;
using ContaBancaria.Entidades;

namespace ContaBancaria.Servicos
{
    public class ClienteHTTP
    {

        public static async Task<Endereco> IntegracaoCep(string cep)
        {
            Endereco endereco;

            using (HttpClient cliente = new HttpClient())
            {
                string resposta = await cliente.GetStringAsync($"viacep.com.br/ws/{cep}/json/");
                endereco = JsonSerializer.Deserialize<Endereco>(resposta)!;
            }

            return endereco;
        }


    }
}