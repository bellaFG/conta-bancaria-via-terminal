using System;

namespace BancoTerminal
{
    class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }

        public Cliente(string nome, string cpf, string senha)
        {
            Nome = nome; CPF = cpf; Senha = senha;
        }
    }

}