namespace AutomacaoNet.Driver
{
    public interface IGetXml<in TDocumento>
    {
        string GetXml(TDocumento documento);
    }
}