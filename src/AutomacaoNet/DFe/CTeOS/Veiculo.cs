using AutomacaoNet.DFe.Base;

namespace AutomacaoNet.DFe.CTeOS
{
    public class Veiculo
    {
        public string Placa { get; set; }

        public string Renavam { get; set; }

        public Proprietario Proprietario { get; set; }

        public EstadoUF EstadoUf { get; set; }
    }
}