namespace AutomacaoNet.Cfg
{
    public class BancoDados
    {
        public BancoDados(bool isAtivar)
        {
            IsAtivar = isAtivar;
        }

        public bool IsAtivar { get; }
        public StringConexaoBd StringConexaoBd { get; set; }
    }
}