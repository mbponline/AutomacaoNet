using AutomacaoNet.DFe;

namespace AutomacaoNet.Driver
{
    public interface IDriver<in TDocumento>
    {
        IRespostaAutorizar Autorizar(TDocumento documento);
    }
}