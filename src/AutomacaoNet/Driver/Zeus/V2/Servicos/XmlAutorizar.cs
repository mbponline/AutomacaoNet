using AutomacaoNet.DFe.CTeOS;
using DFe.DocumentosEletronicos.CTe.CTeOS;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes.Identificacao;

namespace AutomacaoNet.Driver.Zeus.V2.Servicos
{
    public class XmlAutorizar : IGetXml<Documento>
    {
        public string GetXml(Documento documento)
        {
            var cteOs = new CTeOS {InfCte = new infCteOS()};

            cteOs.InfCte.ide = ConverteIde(documento);

            return string.Empty;
        }

        private ideOs ConverteIde(Documento documento)
        {
            var ide = new ideOs();

            

            return ide;
        }
    }
}