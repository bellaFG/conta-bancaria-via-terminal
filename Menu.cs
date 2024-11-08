using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;

namespace BancoTerminal
{

    class Menu
    {
        static List<Cliente> clientes = new List<Cliente>();

        public static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("Olá, seja bem-vindo ao BellaPay, seu banco via terminal!");
            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.WriteLine("Aqui você pode gerenciar suas finanças de forma prática e segura.");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine(" Escolha uma opção: ");
            Console.WriteLine("");
            Console.WriteLine("1 - Fazer Login na sua conta");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("==============================");
        }

        public static void GerenciarOpcao()
        {
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Login();
                    break;

                case "2":
                    SingUp();
                    break;

                case "3":
                    Console.WriteLine("Saindo...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        static void Login()
        {
            Console.Clear();
            Console.WriteLine("Informe seu CPF:");
            string cpf = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.CPF == cpf);

            if (cliente == null)
            {
                Console.WriteLine("CPF não cadastrado. Tente novamente.");
                Thread.Sleep(3000);
                Console.Clear();
                return;
            }

            Console.WriteLine("Informe sua senha:");
            string senha = Console.ReadLine();

            if (cliente.Senha == senha)
            {
                Console.WriteLine($"Seja bem-vindo {cliente.Nome}!");
                MenuTrasacao();
                EscolherOpcao();
            }
            else
            {
                Console.WriteLine("Senha incorreta. Tente novamente.");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }

        static void SingUp()
        {
            Console.WriteLine("Que bom tê-lo conosco! Para começarmos, informe seu nome completo:");
            var nomeCadastro = Console.ReadLine();

            string cpfCadastro;
            bool cpfVerificado;

            do
            {
                Console.WriteLine("Insira seu CPF:");
                cpfCadastro = Console.ReadLine();

                if (Regex.IsMatch(cpfCadastro, @"^\d{11}$") && !clientes.Exists(c => c.CPF == cpfCadastro))
                {
                    cpfVerificado = true;
                }
                else
                {
                    Console.WriteLine("CPF inválido ou já cadastrado. Tente novamente.");
                    cpfVerificado = false;
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            } while (!cpfVerificado);

            string senhaCadastro;
            bool senhaVerificada;

            do
            {
                Console.WriteLine("Crie uma senha PIN (somente números, entre 4 a 6 dígitos):");
                senhaCadastro = Console.ReadLine();

                if (Regex.IsMatch(senhaCadastro, @"^\d{4,6}$"))
                {
                    senhaVerificada = true;
                }
                else
                {
                    Console.WriteLine("Senha inválida. Tente novamente.");
                    senhaVerificada = false;
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            } while (!senhaVerificada);

            Console.WriteLine($"Seja bem-vindo {nomeCadastro}!");
            Cliente novoCliente = new Cliente(nomeCadastro, cpfCadastro, senhaCadastro);
            clientes.Add(novoCliente);
            Console.WriteLine($"Cliente {nomeCadastro} cadastrado com sucesso!");
            Login();
        }

        public static void MenuTrasacao()
        {
            Console.WriteLine("==============================");
            Console.WriteLine(" Escolha uma opção: ");
            Console.WriteLine("");
            Console.WriteLine("1 - Consultar saldo");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("==============================");
        }

        public static void EscolherOpcao()
        {
            var escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    Saldo();
                    break;

                case "2":
                    Depositar();
                    break;

                case "3":
                    Sacar();
                    break;

                case "4":
                    Console.WriteLine("Saindo...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        static decimal saldoAtual = 100;
        public static void Saldo()
        {
            Console.WriteLine($"Seu saldo atual é: {saldoAtual}");
        }

        public static void Depositar()
        {
            Console.WriteLine("Informe o valor para depósito:");
            decimal deposito = Convert.ToDecimal(Console.ReadLine());

            saldoAtual += deposito;

            Console.WriteLine("Depósito realizado com sucesso!");
            Console.WriteLine($"Seu saldo atual é: {saldoAtual}");
        }

        public static void Sacar()
        {
            Console.WriteLine("Informe o valor para saque:");
            decimal saque = Convert.ToDecimal(Console.ReadLine());

            if (saque <= saldoAtual)
            {
                saldoAtual -= saque;
                Console.WriteLine("Saque realizado com sucesso!");
                Console.WriteLine($"Seu saldo atual é: {saldoAtual}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para saque.");
            }
        }
    }
}
