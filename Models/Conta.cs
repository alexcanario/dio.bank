using dio.bank.Enums;
using dio.bank.helper;
using System;

namespace dio.bank.Models {
    public class Conta {
        private const string erroOperacao = "Opercação Cancelada";

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
                Console.WriteLine($"Valor incorreto {valorDeposito:C2}");
                msg.AvisoRetornoMenu(erroOperacao);
                return;
            }
            
            if (Creditar(valorDeposito) is true) {
                Console.WriteLine($"Depósito efetuado com sucesso. Seu saldo atual é de: {Saldo:C2}");
                // msg.AvisoRetornoMenu();
            } else {
                Console.WriteLine("Houve um erro não tratato, chame o suporte.");
                msg.AvisoRetornoMenu(erroOperacao);
            }
        }

        public void Sacar(decimal valorSaque) {
            //Se não houver saldo disponível
            if(valorSaque > Saldo + Credito) {
                Console.WriteLine("Não foi possível efetuar o seu saque. Saldo insuficiente:");
                Console.WriteLine();
                Console.WriteLine($"Saldo: {Saldo:C2}. {Environment.NewLine}");
                Console.WriteLine($"Crédito: {Credito:C2}. {Environment.NewLine}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Disponível para saque: {(Saldo+Credito):C2}");
                msg.AvisoRetornoMenu("Operacao Cancelada");
                return;
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

            if(saldoBloqueado) {
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
                Console.WriteLine($"Erro ao transferir.");
                msg.AvisoRetornoMenu(erroOperacao);
            } else
                Console.WriteLine($"Transferência efetuado com sucesso, seu saldo atual é de :{Saldo:C2}");
                msg.AvisoRetornoMenu();
        }

        public override string ToString() {
            var retorno  = $"Tipo: {TipoConta} | Nome: {Nome} | Saldo: {Saldo:C2} | Crédito: {Credito:C2} ";
            return retorno;
        }
    }
}