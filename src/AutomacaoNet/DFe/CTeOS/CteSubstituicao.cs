namespace AutomacaoNet.DFe.CTeOS
{
    public class CteSubstituicao
    {
        public string Chave { get; set; }

        public string ChaveAnulacao { get; set; }

        public string ChaveNFeEmitidaPeloTomador { get; set; }

        public NF NF { get; set; }

        public string ChaveCTeEmitidaPeloTomador { get; set; }
    }
}