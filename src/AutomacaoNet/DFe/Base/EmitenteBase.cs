namespace AutomacaoNet.DFe.Base
{
    /// <summary>
    /// Emitente Base para outras classes exemplo
    /// <para>O CT-e OS tem dados em comun com a NF-e ou NFC-e ou SAT Fiscal</para>
    /// <para>esse fica sendo a classe base</para>
    /// </summary>
    public abstract class EmitenteBase
    {
        /// <summary>
        /// CNPJ do emitente 
        /// </summary>
        public string Cnpj { get; set; }

        /// <summary>
        /// Inscrição Estadual do Emitente
        /// </summary>
        public string InscricaoEstadual { get; set; }

        /// <summary>
        /// Razão social ou Nome do emitente
        /// </summary>
        public string RazaoSocial { get; set; }

        /// <summary>
        /// Nome fantasia
        /// </summary>
        public string NomeFantasia { get; set; }

        /// <summary>
        /// Endereço do emitente
        /// </summary>
        public EnderecoBase EnderecoBase { get; set; }
    }
}