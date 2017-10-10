using AutomacaoNet.Driver;

namespace AutomacaoNet.DFe.CTeOS.Servicos
{
    public class CTeOSAutorizar : IAutorizar<Documento>
    {
        private readonly IGetXml<Documento> _getXml;

        public CTeOSAutorizar(IGetXml<Documento> getXml)
        {
            _getXml = getXml;
        }

        public IRespostaAutorizar Enviar(Documento documento)
        {
            var xml = _getXml.GetXml(documento);

            return null;
        }
    }
}