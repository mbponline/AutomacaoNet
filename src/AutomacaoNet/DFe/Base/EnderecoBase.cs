namespace AutomacaoNet.DFe.Base
{
    /// <summary>
    /// Endereço Base para outras classes que compartilham dos dados em comun
    /// </summary>
    public abstract class EnderecoBase
    {
        /// <summary>
        /// Logradouro
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public Cidade Cidade { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        public long? Cep { get; set; }
    }
}