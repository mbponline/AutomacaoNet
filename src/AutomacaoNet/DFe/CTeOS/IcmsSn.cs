using AutomacaoNet.DFe.CTeOS.Flags;

namespace AutomacaoNet.DFe.CTeOS
{
    public class IcmsSn : ICMS
    {
        public IcmsSn()
        {
            Cst = Cst.Cst90;
        }

        public Cst Cst { get; }

        public bool IsContribuinteSimplesNacional { get; set; }
    }
}