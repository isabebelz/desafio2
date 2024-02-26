using System.Net;
using ContaBancaria.Aplicacao;
using ContaBancaria.Entidades;

namespace ContaBancaria.Servicos
{
    public class GerenciadorContas
    {
        private readonly List<Conta> _contas;

        public GerenciadorContas(List<Conta> contas)
        {
            _contas = contas;
        }

        public void Entrar()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine()!);

            string cpf;

            do
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine()!;
            }
            while (!Validacao.ValidarCPF(cpf));

            (bool existe, Conta? conta) = ContaExiste(numero);

            if (existe && conta!.Titular.CPF.Equals(cpf))
            {
                Menu.Conta(conta);
            }
            else
            {
                Console.WriteLine("CPF ou número incorretos. Por favor, tente novamente.");

            }

        }

        public void AbrirConta()
        {
            Console.WriteLine("Bem vindo(a)! Preencha os dados para prosseguirmos com a abertura da sua conta.");

            string cpf;
            do
            {
                Console.Write("\nCPF: ");
                cpf = Console.ReadLine()!;
            }
            while (!Validacao.ValidarCPF(cpf));



            Console.Write("Nome: ");
            string nome = Console.ReadLine()!;

            bool atendeIdadeMinima;

            DateOnly dataNascimento;

            do
            {
                atendeIdadeMinima = true;

                Console.Write("Data de nascimento (dd/mm/aaaa): ");
                string data = Console.ReadLine()!;

                dataNascimento = DateOnly.ParseExact(data, "dd/MM/yyyy");

                if (DateTime.Now.Year - dataNascimento.Year < 18)
                {
                    Console.WriteLine("Desculpe, parece que você não atende à idade mínima necessária para abrir uma conta. No momento, só podemos abrir contas para indivíduos com 18 anos ou mais.");
                    atendeIdadeMinima = false;
                }
            }
            while (!atendeIdadeMinima);

            Console.WriteLine("Endereço");

            Console.Write("CEP: ");
            string cep = Console.ReadLine()!;

            Console.Write("Logradouro: ");
            string logradouro = Console.ReadLine()!;

            Console.Write("Bairro: ");
            string bairro = Console.ReadLine()!;

            Console.Write("Cidade: ");
            string localidade = Console.ReadLine()!;

            Console.Write("UF: ");
            string uf = Console.ReadLine()!;

            Endereco endereco = new Endereco(cep, logradouro, bairro, localidade, uf);

            Titular titular = new Titular(nome, cpf, endereco, dataNascimento);

            int numeroConta = GeradorNumeroConta();

            Console.WriteLine("Gostaria de iniciar sua conta com um saldo inicial? ");
            Console.Write("(s/n): ");

            char escolha = char.Parse(Console.ReadLine()!.ToLower());

            Conta conta;

            switch (escolha)
            {
                case 's':
                    Console.Write("Saldo inicial: ");
                    double saldo = double.Parse(Console.ReadLine()!);

                    conta = new Conta(titular, numeroConta, saldo);

                    Console.WriteLine("Conta aberta com sucesso! Obrigado pela confiança.");

                    break;
                case 'n':
                    conta = new Conta(titular, numeroConta);

                    Console.WriteLine("Conta aberta com sucesso! Obrigado pela confiança.");
                    
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    break;
            }


        }

        public void ListarContas()
        {

            Console.Clear();

            foreach (var contas in _contas)
            {
                Console.WriteLine(contas);
                Console.WriteLine();
            }

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();

        }

        public (bool, Conta?) ContaExiste(int numero)
        {
            return (_contas.Any(conta => conta.Numero == numero), _contas.Find(conta => conta.Numero == numero));
        }

        public int GeradorNumeroConta()
        {
            Random random = new Random();

            return random.Next(100000, 1000000);
        }

        public void RemoveConta(Conta conta)
        {
            _contas.Remove(conta);
        }


    
    }
}