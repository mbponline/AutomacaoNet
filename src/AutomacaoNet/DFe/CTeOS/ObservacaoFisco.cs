namespace AutomacaoNet.DFe.CTeOS
{
    public class ObservacaoFisco
    {
        public ObservacaoFisco(string campo, string texto)
        {
            Campo = campo;
            Texto = texto;
        }

        public string Campo { get; }
        public string Texto { get; }
    }
}