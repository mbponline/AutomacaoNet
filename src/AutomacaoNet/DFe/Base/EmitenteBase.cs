namespace AutomacaoNet.DFe.Base
{
    public abstract class EmitenteBase
    {
        /// <summary>
        /// CNPJ do emitente Min:14 Max:14 Required
        /// </summary>
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public EnderecoBase EnderecoBase { get; set; }
    }
}