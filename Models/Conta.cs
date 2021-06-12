using dio.bank.Enums;
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
            
            if (Creditar(valorDeposito) is true)
                Console.WriteLine($"Depósito efetuado com sucesso. Seu saldo atual é de: {Saldo:C2}");
            else
                Console.WriteLine("Houve um erro não tratato, chame o suporte.");
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

            Debitar(valorSaque);
            Console.WriteLine($"Saque efetuado com sucesso, seu saldo atual é de :{Saldo:C2}");
        }

        
        private bool Debitar(decimal valor) {
            var temSaldo = valor <= (Saldo + Credito);
            var saldoBloqueado = false;

            if(!temSaldo) {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            if(!saldoBloqueado) {
                Console.WriteLine("Saldo Bloqueado");
                return false;
            }

            Saldo -= valor;
            if(Saldo < 0) {
                Credito += Saldo;
                Saldo = 0;
            }
            return true;
        }

        private bool Creditar(decimal valor) {
            Saldo += valor;
            return true;
        }

        public void Transferir(Conta conta, decimal valorTransferencia) {
            if(Debitar(valorTransferencia).Equals(false) || (conta.Creditar(valorTransferencia).Equals(false))) {
                Console.WriteLine();
                Console.WriteLine($"Erro ao transferir. Operação cancelada");
            } else
                Console.WriteLine($"Transferência efetuado com sucesso, seu saldo atual é de :{Saldo:C2}");
        }

        public override string ToString() {
            var retorno  = $"{TipoConta} | {Nome} | {Saldo} | {Credito} ";
            return retorno;
        }
    }
}