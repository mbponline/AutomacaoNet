using System;

namespace AutomacaoNet.DFe.CTeOS.Historico
{
    public class CteOsEmissaoHistorico
    {
        public int Id { get; set; }
        public string CnpjEmitente { get; set; }
        public string XmlEnvio { get; set; }
        public string XmlRetorno { get; set; }
        public string XmlAutorizado { get; set; }
        public int NumeroFiscal { get; set; }
        public string Chave { get; set; }
        public bool IsFinalizou { get; set; }
        public bool IsAutorizado { get; set; }
        public DateTime EnviadoEm { get; set; }
        public DateTime AutorizadoEm { get; set; }
        public short CodigoStatusSefaz { get; set; }
        public string MotivoSefaz { get; set; }
        public string Referencia { get; set; }
    }
}