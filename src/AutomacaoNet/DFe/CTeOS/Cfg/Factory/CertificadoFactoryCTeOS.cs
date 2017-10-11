using AutomacaoNet.Cfg;
using DFe.CertificadosDigitais.Implementacao;

namespace AutomacaoNet.DFe.CTeOS.Cfg.Factory
{
    public class CertificadoFactoryCTeOS : IFactoryConfiguracao<Configuracao, DFeConfigCertificadoDigital>
    {
        public DFeConfigCertificadoDigital Criar(Configuracao configuracao)
        {
            var configCertDigital = new DFeConfigCertificadoDigital();

            configCertDigital.LocalArquivo = configuracao.DadosCertificadoDigital.Arquivo;
            configCertDigital.Senha = configuracao.DadosCertificadoDigital.Senha;
            


            return configCertDigital;
        }
    }
}