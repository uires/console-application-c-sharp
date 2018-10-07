using Byte_Bank.entity;
using System;

namespace Byte_Bank.entity
{
    public class ContaCorrente
    {
        // Atributos | Getters e Setters -:>
        private double _saldo;
        public Titular Titular { get; set; }

        // Atributos Readonly
        public int Numero { get; }
        public int Agencia { get; }
        public static int TotalDeContasCriadas { get; set; }

        // Construtor -:>

        public ContaCorrente(int agencia, int numero, double saldo)
        {
            Agencia = agencia;
            Numero = numero;


            Saldo = saldo;
            TotalDeContasCriadas++;
        }

        //Getter e Setter 
        public double Saldo
        {
            get
            {
                return this._saldo;
            }
            set
            {
                if (value > 0)
                {
                    _saldo = value;
                }
                else
                {
                    Console.WriteLine("Não foi possível realizar a alteração do saldo.");
                }
            }
        }
    }
}