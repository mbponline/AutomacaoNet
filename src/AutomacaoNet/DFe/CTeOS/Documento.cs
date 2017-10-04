using System.Collections.Generic;

namespace AutomacaoNet.DFe.CTeOS
{
    /// <summary>
    /// CTeOS
    /// </summary>
    public class Documento
    {
        /// <summary>
        /// ide - 1 Identificação do CTe-e Outros Serviços
        /// </summary>
        public Identificacao Identificacao { get; set; }

        /// <summary>
        /// compl - Dados complementares do CT-e para fins operacionais ou comerciais
        /// </summary>
        public DadosComplementares DadosComplementares { get; set; }

        /// <summary>
        /// emit - Identificação do Emitente do CT-e OS
        /// </summary>
        public Emitente Emitente { get; set; }

        public Tomador Tomador { get; set; }

        public Valores Valores { get; set; }

        public Imposto Imposto { get; set; }

        public PrestacaoServico PrestacaoServico { get; set; }

        public IList<DocumentosReferenciados> DocumentosReferenciados { get; set; }

        public IList<Seguro> Seguros { get; set; }

        public RodoviarioOS RodoviarioOS { get; set; }

        public CteSubstituicao CteSubstituicao { get; set; }

        public string ChaveCteComplemento { get; set; }

        public CteAnulacao CteAnulacao { get; set; }

        public List<string> DocumentoUnicoAutorizadoDownoad { get; set; }

    }
}