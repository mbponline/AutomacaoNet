using System;
using System.IO;
using AutomacaoNet.Cfg.Flags;
using DFe.DocumentosEletronicos.Entidades;
using DFe.DocumentosEletronicos.Flags;

namespace AutomacaoNet.DFe.CTeOS.Cfg.Factory
{
    public class ConfiguracaoFactory : IFactoryConfiguracao<AutomacaoNet.Cfg.Configuracao, CTeConfig>
    {
        public CTeConfig Criar(AutomacaoNet.Cfg.Configuracao configuracao)
        {
            var cteConfig = new CTeConfig();

            cteConfig.EstadoUf = cteConfig.EstadoUf.SiglaParaEstado(configuracao.Sefaz.Origem.Sigla);
            cteConfig.CnpjEmitente = configuracao.CnpjEmitente;
            cteConfig.ProtocoloDeSeguranca = configuracao.Sefaz.ProtocoloSeguranca;

            cteConfig.TipoAmbiente = configuracao.Sefaz.AmbienteSefaz == AmbienteSefaz.Homologacao
                ? TipoAmbiente.Homologacao
                : TipoAmbiente.Producao;

            cteConfig.VersaoServico = (VersaoServico) Enum.Parse(typeof(VersaoServico), configuracao.Sefaz.VersaoLayout);
            cteConfig.IsSalvarXml = false;
            cteConfig.TimeOut = configuracao.Sefaz.TimeOut;
            cteConfig.CaminhoSchemas = Path.Combine(LocalAplicacao.GetLocalAplicacao(), "Schemas");
            cteConfig.IsEfetuarCacheCertificadoDigital = configuracao.DadosCertificadoDigital.IsCache;

            return cteConfig;
        }
    }
}