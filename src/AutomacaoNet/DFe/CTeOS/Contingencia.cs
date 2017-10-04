using System;

namespace AutomacaoNet.DFe.CTeOS
{
    public class Contingencia
    {
        public Contingencia(DateTime entrouEm, string justificativa)
        {
            EntrouEm = entrouEm;
            Justificativa = justificativa;
        }

        public DateTime EntrouEm { get; }

        public string Justificativa { get; }
    }
}