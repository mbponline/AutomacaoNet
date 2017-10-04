using AutomacaoNet.DFe.Base;

namespace AutomacaoNet.DFe.CTeOS
{
    /// <summary>
    /// emit - Identificação do Emitente do CT-e 
    /// </summary>
    public class Emitente : EmitenteBase
    {
        /// <summary>
        /// Inscrição Estadual do Substituto Tributário
        /// </summary>
        public string InscricaoEstadualST { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }
    }
}