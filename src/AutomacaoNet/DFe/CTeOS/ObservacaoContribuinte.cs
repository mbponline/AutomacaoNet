namespace AutomacaoNet.DFe.CTeOS
{
    public class ObservacaoContribuinte
    {
        public ObservacaoContribuinte(string campo, string texto)
        {
            Campo = campo;
            Texto = texto;
        }

        public string Campo { get; }
        public string Texto { get; }
    }
}