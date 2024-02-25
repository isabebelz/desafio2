using ContaBancaria.Aplicacao;
using ContaBancaria.Entidades;
using ContaBancaria.Servicos;

ListaContas contas = new ListaContas();

GerenciadorContas gerenciador = new GerenciadorContas(contas.contas);

Menu menu = new Menu(gerenciador);

menu.Principal();