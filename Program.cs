using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();


        static void Main(string[] args)
        {
            
            string opcaoUsuario=  ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario)
                {
                    case"1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }//switch
                opcaoUsuario = ObterOpcaoUsuario();

            }//while
            Console.WriteLine("Obrigado por utilizar nossos servisos");
            Console.ReadLine();

        }//main

        private static void Transferir()
        {
            Console.WriteLine("Transferir");

            Console.Write("Digite o numero da conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser Trasferido: ");
            Double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Trasferir(valorTransferencia, listContas[indiceContaDestino]);
        }//trasferir

        private static void Depositar()
        {
            Console.WriteLine("Depositar");

            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Sacar");

            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }//sacar

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if (listContas.Count==0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            int i =0;
            foreach (Conta conta in listContas)
            {
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
                i++;
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o NOME do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o SALDO inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o CREDITO: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta:(TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listContas.Add(novaConta);

        }//InserirConta

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("L7 Bank, Bom dia!");
            Console.WriteLine("informe a opção desejada:");
            
            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Trasferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }//ObterOpcaoUsuario
    }
}
