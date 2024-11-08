using System;

namespace BancoTerminal
{
   public class Banco
    {

        public string Nome { get; private set; }

            public Banco(string nome)
        {
            Nome = nome;
        }
    }
}