using System;
using AutomacaoNet.Cfg;
using AutomacaoNet.Cfg.Flags;
using DFe.CertificadosDigitais.Implementacao;
using TpCert = DFe.Utils.Flags.TipoCertificado;

namespace AutomacaoNet.DFe.CTeOS.Cfg.Factory
{
    public class CertificadoFactoryCTeOS : IFactoryConfiguracao<Configuracao, DFeConfigCertificadoDigital>
    {
        public DFeConfigCertificadoDigital Criar(Configuracao configuracao)
        {
            var configCertDigital = new DFeConfigCertificadoDigital();

            configCertDigital.LocalArquivo = configuracao.DadosCertificadoDigital.Arquivo;
            configCertDigital.Senha = configuracao.DadosCertificadoDigital.Senha;
            configCertDigital.ArrayBytesArquivo = configuracao.DadosCertificadoDigital.CertBytes;
            configCertDigital.Serial = configuracao.DadosCertificadoDigital.Serial;

            switch (configuracao.DadosCertificadoDigital.TipoCertificado)
            {
                case TipoCertificado.A1Repositorio:
                    configCertDigital.TipoCertificado = TpCert.A1Repositorio;
                    break;
                case TipoCertificado.A1Arquivo:
                    configCertDigital.TipoCertificado = TpCert.A1Arquivo;
                    break;
                case TipoCertificado.A1ByteArray:
                    configCertDigital.TipoCertificado = TpCert.A1ByteArray;
                    break;
                case TipoCertificado.A3:
                    configCertDigital.TipoCertificado = TpCert.A3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            return configCertDigital;
        }
    }
}