using Byte_Bank.Businnes;
using Byte_Bank.DAO;
using Byte_Bank.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Byte_Bank
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao cadastro de Titular: ");
            Console.WriteLine("Digite seu nome:  ");
            string nome = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Digite seu CPF: ");
            string cpf = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Digite sua Profissao: ");
            string profissao = Convert.ToString(Console.ReadLine());

            var titular = new Titular(nome, cpf, profissao);
            var dao = new TitularDAO();
            bool resultado = dao.Save(titular);

            if (resultado)
            {
                Console.WriteLine("Titular cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível cadastrar o titular!");
            }

            //Metodo();



            Console.WriteLine("Finalizando a execução...");
            Console.ReadLine();
        }








        public static void Metodo()
        {
            TestaDivisao(2);
            TestaDivisao(0);
        }

        public static void TestaDivisao(int divisor)
        {
            try
            {
                int resultado = Dividir(10, divisor);
                ContaCorrente conta = null;
                double value = conta.Saldo;
                Console.WriteLine("Resultado da divisão por 10 pelo divisor " + divisor + " é: " + resultado);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        private static int Dividir(int numero, int divisor)
        {
            return numero / divisor;
        }

    }

}
