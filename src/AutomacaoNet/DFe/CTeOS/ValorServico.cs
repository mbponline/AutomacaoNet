using System.Collections.Generic;

namespace AutomacaoNet.DFe.CTeOS
{
    public class ValorServico
    {
        public decimal Valor { get; set; }

        public decimal ValorReceber { get; set; }

        public IList<Componente> Componentes { get; set; }
    }
}