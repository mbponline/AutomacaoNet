namespace AutomacaoNet.DFe.CTeOS
{
    public class Componente
    {
        public Componente(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; }

        public decimal Valor { get; }
    }
}