using ContaBancaria.Aplicacao;
using ContaBancaria.Entidades.Enum;
using ContaBancaria.Servicos;

namespace ContaBancaria.Entidades
{
    public class Conta : IOperacoesBancarias
    {
        public double Saldo { get; private set; }
        public int Numero { get; private set; }
        public Titular Titular { get; set; }
        public Operacoes Operacao { get; set; }
        public List<Transacoes> HistoricoTransacoes { get; set; } = new List<Transacoes>();
        public GerenciadorContas? Gerenciador { get; set; }

        public Conta(Titular titular, int numero)
        {
            Titular = titular;
            Numero = numero;
        }

        public Conta(Titular titular, int numero, double saldo)
        : this(titular, numero)
        {
            Saldo = saldo;
        }

        public override string ToString()
        {
            return "Dados bancários"
              + "\nTitular"
              + "\nNome: "
              + Titular.Nome
              + "\nConta número: "
              + Numero
              + "\nSaldo: "
              + Saldo
              + Titular.Endereco;

        }
        public void Depositar()
        {

            Console.Write("Insira o valor de depósito: ");

            try
            {

                double deposito = double.Parse(Console.ReadLine()!);

                if (deposito > 0)
                {
                    Saldo += deposito;
                    Operacao = Operacoes.Deposito;
                    HistoricoTransacoes.Add(new Transacoes(deposito, DateTime.Now, Operacao));
                    Console.WriteLine("Depósito realizado com sucesso! O depósito foi adicionado ao saldo da sua conta.");
                }
                else
                {
                    Console.WriteLine("Parece que houve um engano. Infelizmente, não é possível depositar um valor menor ou igual zero. Por favor, insira um valor válido e positivo para realizar o depósito.");

                }

                Menu.Conta(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "Tente novamente.");
            }




        }

        public void Sacar()
        {

            try
            {
                Console.Write("Insira o valor de saque: ");
                double saque = double.Parse(Console.ReadLine()!);

                if (saque <= Saldo && saque != 0)
                {
                    Saldo -= saque;
                    Operacao = Operacoes.Saque;
                    HistoricoTransacoes.Add(new Transacoes(saque, DateTime.Now, Operacao));
                    Console.WriteLine("Saque efetuado com sucesso! O transferencia solicitado foi retirado da sua conta.");

                }
                else
                {
                    Console.WriteLine("Parece que você está tentando sacar mais do que o saldo disponível na sua conta. Por favor, verifique o saldo atual e insira um transferencia de saque dentro dos limites disponíveis.");
                }

                Menu.Conta(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Tente novamente.");
            }


        }
        public void Sacar(double saque)
        {
            if (saque <= Saldo && saque != 0)
            {
                Saldo -= saque;
                Operacao = Operacoes.Saque;
                HistoricoTransacoes.Add(new Transacoes(saque, DateTime.Now, Operacao));
                Console.WriteLine("Saque efetuado com sucesso! O transferencia solicitado foi retirado da sua conta.");

            }
            else
            {
                Console.WriteLine("Parece que você está tentando sacar mais do que o saldo disponível na sua conta. Por favor, verifique o saldo atual e insira um transferencia de saque dentro dos limites disponíveis.");
            }

        }
        public void Transferir()
        {
            try
            {

                Console.Write("Insira o valor de transferência: ");
                double transferencia = double.Parse(Console.ReadLine()!);

                Console.WriteLine("Insira os dados da conta para a qual deseja transferir");
                Console.Write("Nome: ");
                string nome = Console.ReadLine()!;
                Console.Write("Número da conta: ");
                int numeroConta = int.Parse(Console.ReadLine()!);

                (bool existe, Conta? conta) = Gerenciador!.ContaExiste(numeroConta);

                if (transferencia <= Saldo && transferencia > 0 && existe)
                {
                    Saldo -= transferencia;
                    conta!.Saldo += transferencia;
                    Operacao = Operacoes.Transferencia;
                    Console.WriteLine("Transferência realizada com sucesso! O transferencia foi debitado da sua conta e creditado na conta de destino.");
                }
                else
                {
                    Console.WriteLine("Parece que houve um problema ao tentar transferir o transferencia desejado. Certifique-se de que o transferencia que você está tentando transferir não excede o saldo disponível na sua conta e que não seja igual a zero. Por favor, insira um transferencia válido e tente novamente.");
                }

                Menu.Conta(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Tente novamente.");
            }



        }
        public void AlterarNome()
        {

            try
            {
                Console.Write("Digite um novo nome: ");
                Titular.Nome = Console.ReadLine()!;

                Console.WriteLine("Nome alterado com sucesso!");
                Menu.Conta(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Tente novamente.");
            }

        }

        public void FiltrarTransacoes()
        {
            try
            {
                Console.WriteLine("Operação:");
                Console.WriteLine("\n1. Saque");
                Console.WriteLine("2. Transferência");
                Console.WriteLine("3. Depósito");

                int escolha = int.Parse(Console.ReadLine()!);

                switch (escolha)
                {
                    case 1:

                        HistoricoTransacoes.FindAll(transacao => transacao.Operacao == Operacoes.Saque);

                        break;
                    case 2:

                        HistoricoTransacoes.FindAll(transacao => transacao.Operacao == Operacoes.Transferencia);

                        break;
                    case 3:
                        HistoricoTransacoes.FindAll(transacao => transacao.Operacao == Operacoes.Deposito);

                        break;
                }

                Menu.Conta(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Tente novamente.");
            }


        }

        public void FecharConta()
        {
            if (Saldo > 0)
            {
                Console.WriteLine("Antes de prosseguirmos com o fechamento da sua conta, gostaria de confirmar como você gostaria de lidar com o saldo restante. Você prefere transferir para outra conta ou sacar?");
                Console.WriteLine($"Saldo atual: {Saldo}");

                try
                {

                    Console.WriteLine("1. Sacar");
                    Console.WriteLine("2. Transferir");

                    int escolha = int.Parse(Console.ReadLine()!);

                    switch (escolha)
                    {
                        case 1:

                            Console.WriteLine("Por favor, esteja ciente de que o saldo será retirado e a conta será fechada após a conclusão do saque.");
                            Console.WriteLine("Deseja prosseguir com o fechamento?");
                            Console.WriteLine("(s/n) : ");

                            char op = char.Parse(Console.ReadLine()!.ToLower());

                            switch (op)
                            {
                                case 's':

                                    Sacar(Saldo);
                                    Console.WriteLine($"Saldo: {Saldo}");
                                    Console.WriteLine("Agradecemos por sua confiança em nossos serviços. Se surgir a necessidade de reabrir uma conta no futuro ou se precisar de assistência adicional, não hesite em entrar em contato conosco.");
                                    Gerenciador!.RemoveConta(this);
                                    break;

                                case 'n':
                                    Menu.Conta(this);
                                    break;
                            }

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Tente novamente.");
                }

            }
        }

        public void Extrato()
        {
            foreach (Transacoes transacoes in HistoricoTransacoes)
            {
                Console.WriteLine(transacoes.ToString());
            }

            Menu.Conta(this);
        }

    }
}