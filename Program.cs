using System;

namespace BancoTerminal
{
    class Program
    {
        public static void Main(string[] args)
        {
            Menu.ExibirMenu();
            Menu.GerenciarOpcao();
            Banco nomeBanco = new Banco("BellaPay");
            while (true)
            {
                Menu.MenuTrasacao();
                Menu.EscolherOpcao();
            }
        }
    }
}