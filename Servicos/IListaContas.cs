using ContaBancaria.Entidades;

namespace ContaBancaria.Servicos
{
    public interface IListaContas
    {
        List<Conta> contas { get; set; }
    }
}