using ContaBancaria.Entidades;

namespace ContaBancaria.Servicos
{
    public interface IContas
    {
        List<Conta> contas { get; set; }
    }
}