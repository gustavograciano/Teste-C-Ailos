using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {
        private int numeroConta;
        private string titular;
        private double saldo;

        public ContaBancaria(int numeroConta, string titular, double saldo = 0)
        {
            this.numeroConta = numeroConta;
            this.titular = titular;
            this.saldo = saldo;
        }

        public void Deposito(double valor)
        {
            saldo += valor;
        }

        public void Saque(double valor)
        {
            double taxa = 3.50;
            if (saldo >= valor + taxa)
            {
                saldo -= valor + taxa;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque.");
            }
        }

        public void MostrarDados()
        {
            Console.WriteLine($"Conta {numeroConta}, Titular: {titular}, Saldo: ${saldo:f2}");
        }
    }
}
