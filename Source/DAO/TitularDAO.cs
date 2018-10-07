using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Byte_Bank.entity;
/*
    CREATE TABLE [dbo].[titular] (
        [id]        BIGINT         IDENTITY (1, 1) NOT NULL,
        [nome]      NVARCHAR (MAX) NULL,
        [cpf]       NVARCHAR (MAX) NULL,
        [profissao] NVARCHAR (MAX) NOT NULL
    );
*/
namespace Byte_Bank.DAO
{
    // Primeiro ponto implementar a Interface IDisposable
    public class TitularDAO : IDisposable
    {
        // Atributo connection geral da classe
        private SqlConnection connection;
        private static readonly string URL = "Server=(localdb)\\mssqllocaldb;Database=ByteBank;Trusted_Connection=true;";

        public TitularDAO()
        {
            // Instância o objeto SQLConnection
            this.connection = new SqlConnection(URL);
            // Abre a conexão
            try
            {
                this.connection.Open();
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);
            }

            Console.WriteLine("Abrindo conexão...");
        }

        public void Dispose()
        {
            // Fecha a conexão
            this.connection.Close();
        }

        /*
        *   @desc: Salva um objeto do tipo Titular
        *   @param: um objeto do tipo Titular = DTO
        *   @return: void
        */
        public bool Save(Titular titular)
        {
            // Tratamento de erro do SQLException
            int result;
            try
            {
                // Cria um objeto do tipo SQLCommand através do objeto SQLConnection
                IDbCommand sqlCommand = this.connection.CreateCommand();
                // Atribui a query a ser executada pelo SQLCommand
                sqlCommand.CommandText = "INSERT INTO titular (nome, cpf, profissao) VALUES (@nome, @cpf, @profissao)";

                // Seta o paramêtro da query escrita a cima
                IDbDataParameter parametroNome = new SqlParameter("nome", titular.Nome);
                sqlCommand.Parameters.Add(parametroNome);

                IDbDataParameter parametroCPF = new SqlParameter("cpf", titular.CPF);
                sqlCommand.Parameters.Add(parametroCPF);

                IDbDataParameter parametroProfissao = new SqlParameter("profissao", titular.Profissao);
                sqlCommand.Parameters.Add(parametroProfissao);

                // Executa o comando SQL
                result = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
            // Compara a quantidade de linha afetadas retornando verdadeiro caso seja maior que zero
            if (result > 0)
            {
                return true;
            }
            return false;

        }

        /*
        *   @desc: atualiza o objeto
        *   @param: um objeto do tipo Titular = DTO
        *   @return: void
        */
        public void Update(Titular titular)
        {
            try
            {
                IDbCommand sqlCommand = this.connection.CreateCommand();
                // Define a QUERY
                sqlCommand.CommandText = "UPDATE titular SET nome = @nome, cpf = @cpf, profissao = @profissao WHERE id = @id";

                IDbDataParameter paramNome = new SqlParameter("nome", titular.Nome);
                sqlCommand.Parameters.Add(paramNome);
                IDbDataParameter paramCPF = new SqlParameter("cpf", titular.CPF);
                sqlCommand.Parameters.Add(paramCPF);
                IDbDataParameter paramProfissao = new SqlParameter("profissao", titular.Profissao);
                sqlCommand.Parameters.Add(paramProfissao);
                IDbDataParameter paramId = new SqlParameter("id", titular.Id);
                sqlCommand.Parameters.Add(paramId);

                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);
            }
        }

        /*
        *   @desc: Busca um objeto no banco de dados
        *   @param: um objeto do tipo Titular = DTO
        *   @return: Titular
        */
        public Titular SelectById(Titular titular)
        {
            try
            {
                SqlCommand command = this.connection.CreateCommand();
                command.CommandText = "SELECT * FROM titular WHERE id = @id";

                SqlParameter paramId = new SqlParameter("id", titular.Id);
                command.Parameters.Add(paramId);
                var resultObjects = command.ExecuteReader();

                if (resultObjects.Read())
                {
                    titular = new Titular(Convert.ToString(resultObjects["nome"]), Convert.ToString(resultObjects["cpf"]),
                        Convert.ToString(resultObjects["profissao"]));
                    titular.Id = Convert.ToInt64(resultObjects["id"]);
                }
                else
                {
                    titular = null;
                }
                return titular;
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);
            }
            return titular;
        }

        public LinkedList<Titular> SelectAll()
        {
            try
            {
                var titulares = new LinkedList<Titular>();
                var command = this.connection.CreateCommand();
                command.CommandText = "SELECT * FROM titular";
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    Titular titular = new Titular(Convert.ToString(result["nome"]), Convert.ToString(result["cpf"]),
                        Convert.ToString(result["profissao"]));
                    titular.Id = Convert.ToInt64(result["id"]);
                    titulares.AddLast(titular);
                }
                return titulares;
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }
    }
}
