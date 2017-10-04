using AutomacaoNet.DFe.Base;
using AutomacaoNet.DFe.CTeOS.Flags;

namespace AutomacaoNet.DFe.CTeOS
{
    public class Proprietario
    {
        /// <summary>
        /// CPF ou CNPJ
        /// </summary>
        public string DocumentoUnico { get; set; }

        public string Taf { get; set; }

        public string NumeroRegistroEstadual { get; set; }

        public string NomeOuRazaoSocial { get; set; }

        public string InscricaoEstadual { get; set; }

        public EstadoUF EstadoUf { get; set; }

        public TipoProprietario TipoProprietario { get; set; }
    }
}