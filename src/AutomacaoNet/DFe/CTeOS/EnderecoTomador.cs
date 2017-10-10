using AutomacaoNet.DFe.Base;

namespace AutomacaoNet.DFe.CTeOS
{
    public class EnderecoTomador
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public Cidade Cidade { get; set; }

        public long? Cep { get; set; }

        public Pais Pais { get; set; }
    }
}