using AutomacaoNet.Driver;
using CTeOs = DFe.DocumentosEletronicos.CTe.CTeOS.CTeOS;
namespace AutomacaoNet.DFe.CTeOS.Servicos
{
    public class CTeOSAutorizar : IAutorizar<Documento>
    {
        private readonly IGetObjeto<Documento, CTeOs> _getObjeto;

        public CTeOSAutorizar(IGetObjeto<Documento, CTeOs> getObjeto)
        {
            _getObjeto = getObjeto;
        }

        public IRespostaAutorizar Enviar(Documento documento)
        {
            var cteOs = _getObjeto.GetObjeto(documento);

            return null;
        }
    }
}