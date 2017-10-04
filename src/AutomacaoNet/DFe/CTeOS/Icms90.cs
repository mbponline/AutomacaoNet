using AutomacaoNet.DFe.CTeOS.Flags;

namespace AutomacaoNet.DFe.CTeOS
{
    public class Icms90 : ICMS
    {
        public Icms90()
        {
            Cst = Cst.Cst90;
        }

        public Cst Cst { get; }

        public decimal PercentualReducaoBc { get; set; }

        public decimal ValorIcmsBc { get; set; }

        public decimal PercentualAliquotaIcms { get; set; }

        public decimal ValorIcms { get; set; }

        public decimal ValorCredito { get; set; }
    }
}