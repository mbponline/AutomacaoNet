namespace AutomacaoNet.DFe
{
    public interface IFactoryConfiguracao<in TConfiguracao, out TConfiguracaoFramework>
    {
        TConfiguracaoFramework Criar(TConfiguracao configuracao);
    }
}