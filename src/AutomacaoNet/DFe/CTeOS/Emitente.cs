using AutomacaoNet.DFe.Base;

namespace AutomacaoNet.DFe.CTeOS
{
    /// <summary>
    /// emit - Identificação do Emitente do CT-e 
    /// </summary>
    public class Emitente : EmitenteBase
    {
        public string InscricaoEstadualST { get; set; }
        public string Telefone { get; set; }
    }
}