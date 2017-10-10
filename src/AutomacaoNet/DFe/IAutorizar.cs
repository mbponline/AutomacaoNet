namespace AutomacaoNet.DFe
{
    public interface IAutorizar<in TEntity>
    {
        IRespostaAutorizar Enviar(TEntity documento);
    }

}