using ContaBancaria.Entidades;
using ContaBancaria.Servicos;

namespace ContaBancaria.Aplicacao
{

    public class Menu
    {
        public GerenciadorContas Gerenciador { get; set; }
        public Menu(GerenciadorContas gerenciador)
        {
            Gerenciador = gerenciador;
        }
        public void Principal()
        {
            
            Console.WriteLine("\n1. Entrar");
            Console.WriteLine("2. Abrir Conta");
            Console.WriteLine("3. Listar contas");
            Console.WriteLine("4. Sair");

            int escolha = int.Parse(Console.ReadLine()!);

            switch (escolha)
            {
                case 1:
                    Gerenciador.Entrar();
                    break;
                case 2:
                    Gerenciador.AbrirConta();
                    break;
                case 3:
                    Gerenciador.ListarContas();
                    Principal();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }

        }
        public static void Conta(Conta conta)
        {
            Console.WriteLine($"Bem Vindo(a) {conta.Titular!.Nome}!");
            Console.WriteLine($"Número da conta: {conta.Numero}");
            Console.WriteLine($"Saldo: {conta.Saldo}");
            Console.WriteLine("\n1. Meus dados");
            Console.WriteLine("2. Depositar");
            Console.WriteLine("3. Transferir");
            Console.WriteLine("4. Sacar");
            Console.WriteLine("5 Extrato");
            Console.WriteLine("6. Alterar meus dados");
            Console.WriteLine("7. Fechar conta");
            Console.WriteLine("8. Sair");

            int escolha = int.Parse(Console.ReadLine()!);

            switch (escolha)
            {
                case 1:
                    conta.ToString();
                    break;
                case 2:
                    conta.Depositar();
                    break;
                case 3:
                    conta.Transferir();
                    break;
                case 4:
                    conta.Sacar();
                    break;
                case 5:
                    conta.Extrato();
                    break;
                case 6:
                    conta.AlterarNome();
                    break;
                case 7:
                    break;
                case 8:
                    break;
            }
        }
    }
}