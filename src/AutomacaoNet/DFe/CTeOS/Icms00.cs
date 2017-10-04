using AutomacaoNet.DFe.CTeOS.Flags;

namespace AutomacaoNet.DFe.CTeOS
{
    public class Icms00 : ICMS
    {
        public Icms00()
        {
            Cst = Cst.Cst00;
        }

        public decimal BcIcms { get; set; }

        public decimal PercentualIcms { get; set; }

        public decimal ValorIcms { get; set; }

        public Cst Cst { get; }
    }
}