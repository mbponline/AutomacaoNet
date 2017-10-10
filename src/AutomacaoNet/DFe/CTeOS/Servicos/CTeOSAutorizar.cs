using AutomacaoNet.Cfg;
using AutomacaoNet.Driver;
using CTeOs = DFe.DocumentosEletronicos.CTe.CTeOS.CTeOS;
namespace AutomacaoNet.DFe.CTeOS.Servicos
{
    public class CTeOSAutorizar : IAutorizar<Documento>
    {
        private readonly IGetObjeto<Documento, CTeOs> _getObjeto;
        private readonly Configuracao _configuracao;

        public CTeOSAutorizar(IGetObjeto<Documento, CTeOs> getObjeto, Configuracao configuracao)
        {
            _getObjeto = getObjeto;
            _configuracao = configuracao;
        }

        public IRespostaAutorizar Enviar(Documento documento)
        {
            


            var cteOs = _getObjeto.GetObjeto(documento);



            return null;
        }
    }
}