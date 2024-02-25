using System.Text.Json;
using ContaBancaria.Entidades;

namespace ContaBancaria.Servicos
{
    public class  ClienteHTTP
    {
        
        public static async void APICep(string cep)
        {
            //Endereco endereco = new Endereco();

            using(var cliente = new HttpClient())
            {
                HttpResponseMessage resposta = await cliente.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                var endereco = await resposta.Content.ReadAsStringAsync();

                Console.WriteLine(endereco);
                //endereco = JsonSerializer.Deserialize<Endereco>(resposta)!;
            }

            
            
        }
    }
}