using System;

namespace dio.bank {
    class Program {
        static void Main(string[] args) {
            var opcao = ObterOpcaoUsuario();
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

        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Contas.");
            Console.WriteLine("2 - Inserir Nova Conta.");
            Console.WriteLine("3 - Transferir.");
            Console.WriteLine("4 - Sacar.");
            Console.WriteLine("5 - Depositar.");
            Console.WriteLine("C - Limpar a tela.");
            Console.WriteLine("X - Sair.");

            var opcao = Console.ReadLine();
            return opcao.ToUpper();
        } 

        private static void ListarContas() { }
        private static void InserirConta() {}
        private static void Transferir(){}
        private static void Sacar(){}
        private static void Depositar(){}
        private static void LimparTela(){}
        private static void Sair(){}
    }
}
