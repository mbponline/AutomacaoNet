namespace AutomacaoNet.DFe.Base
{
    public class Cidade
    {
        public string Nome { get; set; }
        public long CodigoIbge { get; set; }
        public EstadoUF EstadoUf { get; set; }

        public string SiglaUF => EstadoUf?.Sigla;
    }
}