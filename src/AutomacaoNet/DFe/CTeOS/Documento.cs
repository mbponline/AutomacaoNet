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
    }
}