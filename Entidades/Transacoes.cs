using ContaBancaria.Entidades.Enum;
namespace ContaBancaria.Entidades
{
    public class Transacoes
    {
        public double Valor { get; private set; }
        public DateTime Momento { get; private set; }
        public Operacoes Operacao { get; private set; }

        public Transacoes(double valor, DateTime momento, Operacoes operacao)
        {
            Valor = valor;
            Momento = momento;
            Operacao = operacao;
        }

        public override string ToString()
        {
            return "Transações"
            + "Data e hora: "
            + Momento.ToString()
            + "Operação: "
            + Operacao
            + "Valor: "
            + Valor;
        }
    }
}