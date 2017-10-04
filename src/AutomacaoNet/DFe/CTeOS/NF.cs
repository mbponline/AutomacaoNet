using System;

namespace AutomacaoNet.DFe.CTeOS
{
    public class NF
    {
        public string DocumentoUnico { get; set; }

        public string ModeloDocumentoFiscal { get; set; }

        public short Serie { get; set; }

        public short SubSerie { get; set; }

        public int NumeroFiscal { get; set; }

        public decimal Valor { get; set; }

        public DateTime EmissaoEm { get; set; }
    }
}