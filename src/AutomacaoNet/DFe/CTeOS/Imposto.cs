using System.Collections.Generic;

namespace AutomacaoNet.DFe.CTeOS
{
    public class Imposto
    {
        public Imposto(ICMS icms)
        {
            Icms = icms;
        }

        public ICMS Icms { get; set; }

        public decimal ValorTotalTributos { get; set; }

        public IList<string> InformacaoAdicionalInteresseFisco { get; set; }

        public IcmsPartilha IcmsPartilha { get; set; }

        public TributosFederais TributosFederais { get; set; }
    }
}