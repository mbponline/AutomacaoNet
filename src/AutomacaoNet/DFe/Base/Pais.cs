namespace AutomacaoNet.DFe.Base
{
    public class Pais
    {
        public Pais(short codigoPais, string nome)
        {
            CodigoPais = codigoPais;
            Nome = nome;
        }

        public short CodigoPais { get; }
        public string Nome { get; }
    }
}