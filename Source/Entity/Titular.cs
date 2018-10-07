
namespace Byte_Bank.entity
{
    public class Titular
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public string Profissao { get; set; }

        public Titular()
        {
        }

        public Titular(string nome, string cpf, string profissao)
        {
            Nome = nome;
            CPF = cpf;
            Profissao = profissao;
        }

        public override string ToString()
        {
            return "[id=" + this.Id + ",nome=" + this.Nome +
                    ",CPF=" + this.CPF + ",profissao=" + this.Profissao + "]";
        }
    }

}
