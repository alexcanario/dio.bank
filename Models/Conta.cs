using dio.bank.Enum;
using System;

namespace dio.bank.Models {
    public class Conta {
        public Conta(string nome, decimal saldo, decimal credito, TipoConta tipoConta) {
            Nome = nome;
            Saldo = saldo;
            Credito = credito;
            TipoConta = tipoConta;
        }

        public string Nome { get; private set; }
        public decimal Saldo { get; private set; }
        public decimal Credito { get; private set; }
        public TipoConta TipoConta { get; private set; }

        public void Depositar(decimal valorDeposito) {
            if(valorDeposito <= 0) { 
                Console.WriteLine($"Depósito cancelado, valor incorreto {valorDeposito:C2}");
                return;
            }
            
            Debitar(valorDeposito);
            Console.WriteLine($"Depósito efetuado com sucesso. Seu saldo atual é de: {Saldo:C2}");
        }

        public void Sacar(decimal valorSaque) {
            if(valorSaque > Saldo + Credito) {
                Console.WriteLine("Não foi possível efetuar o seu saque. Saldo insuficiente:");
                Console.WriteLine();
                Console.WriteLine($"Saldo: {Saldo:C2}. {Environment.NewLine}");
                Console.WriteLine($"Crédito: {Credito:C2}. {Environment.NewLine}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Disponível para saque: {(Saldo+Credito):C2}");
            }

            Creditar(valorSaque);

            Console.WriteLine($"Saque efetuado com sucesso, seu saldo atual é de :{Saldo:C2}");
        }

        private void Creditar(decimal valor) {
            Saldo -= valor;
            if(Saldo < 0) {
                Credito += Saldo;
                Saldo = 0;
            }
        }

        private void Debitar(decimal valor) {
            Saldo += valor;
        }

        public void Transferir(Conta conta, decimal valorTransferencia) {
            if(valorTransferencia < (conta.Saldo + conta.Credito)) {
                Console.WriteLine($"Saldo Insufciente, transferência cancelada. Saldo: {conta.Saldo:C2}");
                return;
            }

            Creditar(valorTransferencia);
            conta.Debitar(valorTransferencia);
            Console.WriteLine($"Transferência efetuado com sucesso, seu saldo atual é de :{Saldo:C2}");
        }
    }
}