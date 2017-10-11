using AutomacaoNet.Cfg.Flags;

namespace AutomacaoNet.Cfg
{
    public class DadosCertificadoDigital
    {
        public TipoCertificado TipoCertificado { get; set; }
        public string Serial { get; set; }
        public string Arquivo { get; set; }
        public string Senha { get; set; }
        public byte[] CertBytes { get; set; }
        public bool IsCache { get; set; }
    }
}