using Byte_Bank.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_Bank.Businnes
{
    public class OperacoesBancarias
    {
        // Métodos | Ações de uma Conta -:>
        public bool Saca(ContaCorrente conta, double valor)
        {
            if (conta.Saldo >= valor)
            {
                conta.Saldo -= valor;
                return true;
            }
            return false;
        }

        public void Depositar(ContaCorrente conta, double valor)
        {
            if (valor > 0)
            {
                conta.Saldo += valor;
            }
        }

        public bool Tranfere(ContaCorrente contaTranferidora, ContaCorrente contaBeneficiaria, double valor)
        {

            if (contaTranferidora.Saldo >= valor)
            {

                try
                {
                    this.Saca(contaTranferidora, valor);
                    this.Depositar(contaBeneficiaria, valor);
                    return true;
                }
                catch (NullReferenceException error)
                {
                    Console.WriteLine("Não foi possível realizar a tranferência!");
                    Console.WriteLine(error.Message);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            return false;
        }
    }
}