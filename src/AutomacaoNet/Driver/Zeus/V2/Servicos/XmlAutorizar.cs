using System;
using AutomacaoNet.Cfg;
using AutomacaoNet.Cfg.Flags;
using AutomacaoNet.DFe.CTeOS;
using AutomacaoNet.DFe.CTeOS.Flags;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Emitente;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Tipos;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Valores;
using DFe.DocumentosEletronicos.CTe.CTeOS;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes.Identificacao;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes.Tomador;
using DFe.DocumentosEletronicos.Entidades;
using DFe.DocumentosEletronicos.Flags;

namespace AutomacaoNet.Driver.Zeus.V2.Servicos
{
    public class XmlAutorizar : IGetXml<Documento>
    {
        private readonly Configuracao _configuracao;

        public XmlAutorizar(Configuracao configuracao)
        {
            _configuracao = configuracao;
        }

        public string GetXml(Documento documento)
        {
            var cteOs = new CTeOS {InfCte = new infCteOS()};

            cteOs.InfCte.ide = ConverteIde(documento);
            cteOs.InfCte.emit = ConverteEmitente(documento);
            cteOs.InfCte.toma = ConverteTomador(documento);
            cteOs.InfCte.vPrest = ConvertePrestacaoServico(documento);

            return string.Empty;
        }

        private vPrestOs ConvertePrestacaoServico(Documento documento)
        {
            var vPrest = new vPrestOs();

            vPrest.vTPrest = documento.PrestacaoServico.ValorTotal;
            vPrest.vRec = documento.PrestacaoServico.ValorReceber;

            return vPrest;
        }

        private tomaOs ConverteTomador(Documento documento)
        {
            var docToma = documento.Tomador;
            var toma = new tomaOs();

            if (docToma.DocumentoUnico.Length == 11)
            {
                toma.CPF = docToma.DocumentoUnico;
            }

            if (docToma.DocumentoUnico.Length == 14)
            {
                toma.CNPJ = docToma.DocumentoUnico;
            }

            toma.IE = docToma.InscricaoEstadual;
            toma.xNome = docToma.NomeOuRazaoSocial;
            toma.xFant = docToma.NomeFantasia;
            toma.fone = docToma.Telefone;

            var endereco = new enderTomaOs();

            endereco.xLgr = documento.Tomador.EnderecoTomador.Logradouro;
            endereco.nro = documento.Tomador.EnderecoTomador.Numero;
            endereco.xCpl = documento.Tomador.EnderecoTomador.Complemento;
            endereco.xBairro = documento.Tomador.EnderecoTomador.Bairro;
            endereco.cMun = documento.Tomador.EnderecoTomador.Cidade.CodigoIbge;
            endereco.xMun = documento.Tomador.EnderecoTomador.Cidade.Nome;
            endereco.CEP = documento.Tomador.EnderecoTomador.Cep;
            endereco.UF = endereco.UF.SiglaParaEstado(documento.Tomador.EnderecoTomador.Cidade.SiglaUF);

            toma.enderToma = endereco;
            return toma;
        }

        private ideOs ConverteIde(Documento documento)
        {
            var ide = new ideOs();

            ide.cUF = ide.cUF.SiglaParaEstado(_configuracao.Sefaz.Origem.Sigla);
            ide.cCT = new Random().Next(11111111, 99999999);
            ide.CFOP = documento.Identificacao.Cfop;
            ide.natOp = documento.Identificacao.NaturezaOperacao;
            ide.mod = ModeloDocumento.CTeOS;
            ide.serie = documento.Identificacao.Serie;
            ide.nCT = documento.Identificacao.NumeroFiscal;
            ide.dhEmi = documento.Identificacao.EmitidoEm;
            ide.tpImp = documento.Identificacao.TipoImpressao == TipoImpressao.Paisagem
                ? tpImp.Paisagem
                : tpImp.Retrado;

            switch (documento.Identificacao.TipoImpressao)
            {
                case TipoImpressao.Retrato:
                    ide.tpImp = tpImp.Retrado;
                    break;
                case TipoImpressao.Paisagem:
                    ide.tpImp = tpImp.Paisagem;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ide.tpAmb = _configuracao.Sefaz.AmbienteSefaz == AmbienteSefaz.Producao
                ? TipoAmbiente.Producao
                : TipoAmbiente.Homologacao;

            switch (documento.Identificacao.TipoCte)
            {
                case TipoCte.Normal:
                    ide.tpCTe = tpCTe.Normal;
                    break;
                case TipoCte.Complementar:
                    ide.tpCTe = tpCTe.Complemento;
                    break;
                case TipoCte.Anulacao:
                    ide.tpCTe = tpCTe.Anulacao;
                    break;
                case TipoCte.Substituicao:
                    ide.tpCTe = tpCTe.Substituto;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ide.procEmi = procEmi.AplicativoContribuinte;

            ide.verProc = documento.Identificacao.VersaoAplicativoEmissor;

            ide.cMunEnv = documento.Identificacao.CidadeEnvio.CodigoIbge;
            ide.xMunEnv = documento.Identificacao.CidadeEnvio.Nome;
            ide.UFEnv = ide.UFEnv.SiglaParaEstado(documento.Identificacao.CidadeEnvio.SiglaUF);

            ide.modal = modal.rodoviario;

            switch (documento.Identificacao.TipoServico)
            {
                case TipoServico.TransportePessoas:
                    ide.tpServ = tpServ.transportePessoas;
                    break;
                case TipoServico.TransporteValores:
                    ide.tpServ = tpServ.transporteValores;
                    break;
                case TipoServico.ExcessoBagagem:
                    ide.tpServ = tpServ.excessoBagagem;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (documento.Identificacao.IndicadorIETomador)
            {
                case IndicadorIETomador.ContribuienteIcms:
                    ide.indIEToma = indIEToma.ContribuinteIcms;
                    break;
                case IndicadorIETomador.ContribuienteIsentoDeInscricao:
                    ide.indIEToma = indIEToma.ContribuinteIsentoDeInscricao;
                    break;
                case IndicadorIETomador.NaoContribuiente:
                    ide.indIEToma = indIEToma.NaoContribuinte;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ide.cMunIni = documento.Identificacao.CidadeInicio.CodigoIbge;
            ide.xMunIni = documento.Identificacao.CidadeInicio.Nome;
            ide.UFIni = ide.UFIni.SiglaParaEstado(documento.Identificacao.CidadeInicio.SiglaUF);

            ide.cMunFim = documento.Identificacao.CidadeFim.CodigoIbge;
            ide.xMunFim = documento.Identificacao.CidadeFim.Nome;
            ide.UFFim = ide.UFFim.SiglaParaEstado(documento.Identificacao.CidadeFim.SiglaUF);

            return ide;
        }

        private static emitOs ConverteEmitente(Documento documento)
        {
            var emit = new emitOs();

            emit.CNPJ = documento.Emitente.Cnpj;
            emit.IE = documento.Emitente.InscricaoEstadual;
            emit.IEST = documento.Emitente.InscricaoEstadualST;
            emit.xNome = documento.Emitente.RazaoSocial;
            emit.xFant = documento.Emitente.NomeFantasia;

            var enderEmit = new enderEmit();
            enderEmit.xLgr = documento.Emitente.EnderecoBase.Logradouro;
            enderEmit.nro = documento.Emitente.EnderecoBase.Numero;
            enderEmit.xCpl = documento.Emitente.EnderecoBase.Complemento;
            enderEmit.xBairro = documento.Emitente.EnderecoBase.Bairro;
            enderEmit.cMun = documento.Emitente.EnderecoBase.Cidade.CodigoIbge;
            enderEmit.xMun = documento.Emitente.EnderecoBase.Cidade.Nome;
            enderEmit.CEP = documento.Emitente.EnderecoBase.Cep;
            enderEmit.UF = enderEmit.UF.SiglaParaEstado(documento.Emitente.EnderecoBase.Cidade.SiglaUF);
            enderEmit.fone = documento.Emitente.Telefone;

            emit.enderEmit = enderEmit;
            return emit;
        }
    }
}