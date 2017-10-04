using AutomacaoNet.DFe.CTeOS.Flags;

namespace AutomacaoNet.DFe.CTeOS
{
    public class IcmsOutraUf : ICMS
    {
        public IcmsOutraUf()
        {
            Cst = Cst.Cst90;
        }

        public Cst Cst { get; }

        public decimal PercentualReducaoBc { get; set; }

        public decimal ValorIcmsBc { get; set; }

        public decimal PercentualAliquotaIcms { get; set; }

        public decimal ValorIcms { get; set; }
    }
}