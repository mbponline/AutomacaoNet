namespace AutomacaoNet.Driver
{
    public interface IGetObjeto<in TDocumento, out TObjeto>
    {
        TObjeto GetObjeto(TDocumento documento);
    }
}