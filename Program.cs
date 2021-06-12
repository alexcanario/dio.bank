using System;
using System.Linq;
using dio.bank.Enums;
using dio.bank.Models;
using System.Collections.Generic;
 
namespace dio.bank {
    class Program {
        static IList<Conta> _listaContas = new List<Conta>();
        
        static void Main(string[] args) {
            var opcao = string.Empty;
            while(!opcao.Equals("X")) {
                opcao = ObterOpcaoUsuario();
                switch (opcao) {
                    case "1": 
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
                        LimparTela();
                        break;
                    case "X":
                        Sair();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine("DIO Bank ao seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");

            var opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        } 

        private static void ListarContas() { 
            Console.WriteLine();
            Console.WriteLine("Listando contas existentes!");
            Console.WriteLine();

            if(!_listaContas.Any()) {
                Console.WriteLine("Nenhuma conta para listar!");
                Console.WriteLine();
                Console.WriteLine("Pressione uma tecla para continuar!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"#id     |     Nome          ")            
            foreach(var conta in _listaContas) {
                Console.WriteLine($"#{_listaContas.IndexOf(conta)} - {conta}");
            }
            Console.ReadKey();
        }
        private static void InserirConta() {
            Console.WriteLine("Inserir nova conta!");

            Console.WriteLine("Digite (1) para conta Física, (2) para conta jurídica.");
            var tipoConta = (TipoConta)Enum.Parse(typeof(TipoConta), Console.ReadLine());

            Console.WriteLine("Informe o nome do títular da conta!");
            var nome = Console.ReadLine();

            Console.WriteLine("Informe o valor do saldo inicial.");
            var saldoInicial = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor do seu limite de crédito.");
            var valorLimite = decimal.Parse(Console.ReadLine());

            _listaContas.Add(new Conta(nome, saldoInicial, valorLimite, tipoConta));
        }
        private static void Transferir(){}
        private static void Sacar(){
            Console.WriteLine("Sacar em sua conta");
            Console.WriteLine();
            Console.WriteLine("Informe o id da conta que deseja sacar.");
            var id = int.Parse(Console.ReadLine());
        }
        private static void Depositar(){}
        private static void LimparTela(){}
        private static void Sair(){}
    }
}