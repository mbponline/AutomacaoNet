using System;
using AutomacaoNet.DFe.Base;
using AutomacaoNet.DFe.CTeOS.Flags;

namespace AutomacaoNet.DFe.CTeOS
{
    /// <summary>
    /// ide - 1 Identificação do CTe-e Outros Serviços
    /// </summary>
    public class Identificacao
    {
        public int Cfop { get; set; }

        public string NaturezaOperacao { get; set; }

        public short Serie { get; set; }

        public int NumeroFiscal { get; set; }

        public DateTime EmitidoEm { get; set; }

        public TipoImpressao TipoImpressao { get; set; }

        public TipoCte TipoCte { get; set; }

        public TipoEmissao TipoEmissao { get; set; }

        public string VersaoAplicativoEmissor { get; set; }

        public Cidade CidadeEnvio { get; set; }

        public TipoServico TipoServico { get; set; }

        public IndicadorIETomador IndicadorIETomador { get; set; }

        public Cidade CidadeInicio { get; set; }

        public Cidade CidadeFim { get; set; }

        public Contingencia Contingencia { get; set; }
    }
}