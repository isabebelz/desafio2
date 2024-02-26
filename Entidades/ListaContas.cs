using ContaBancaria.Servicos;

namespace ContaBancaria.Entidades
{
    public class ListaContas : IContas
    {
        public virtual List<Conta> contas { get; set; }

        
        public ListaContas()
        {
            contas = new List<Conta> {
                new Conta(new Titular("Elias Junior", "84461844781", new Endereco("69901000", "Travessa da Serra", "Conjunto Jardim São Francisco", "Rio Branco", "AC"), DateOnly.ParseExact("15/04/1999", "dd/MM/yyyy")), 446821, 10000),
                new Conta(new Titular("Bruna Costa", "65939727972", new Endereco("40020470", "Rua do Paraíso", "Centro", "Salvador", "BA"), DateOnly.ParseExact("25/08/2003", "dd/MM/yyyy")), 776095, 900),
                new Conta(new Titular("John Wesley", "26034104076", new Endereco("20050000", "Rua Alexandre Herculano", "Centro", "Rio de Janeiro", "RJ"), DateOnly.ParseExact("13/07/2002", "dd/MM/yyyy")), 776095, 900),
                new Conta(new Titular("Enzo Fernandes", "21983583790", new Endereco("01002000", "Rua Direita - lado par", "Sé", "São Paulo", "SP"), DateOnly.ParseExact("19/03/2003", "dd/MM/yyyy")), 235546, 900)
            };
        }
    }
}