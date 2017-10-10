using System;

namespace AutomacaoNet.DFe.CTeOS
{
    public class DocumentoReferenciado
    {
        public string Numero { get; set; }

        public short? Serie { get; set; }

        public short? SubSerie { get; set; }

        public DateTime EmitidoEm { get; set; }

        public decimal? Valor { get; set; }
    }
}