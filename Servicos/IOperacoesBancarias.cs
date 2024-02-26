namespace ContaBancaria.Servicos
{
    public interface IOperacoesBancarias
    {
        void Transferir();
        void Sacar();

        void Depositar();

        void FiltrarTransacoes();

        void FecharConta();
        
    }
}