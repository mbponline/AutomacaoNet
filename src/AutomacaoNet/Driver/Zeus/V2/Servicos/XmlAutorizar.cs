using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using AutomacaoNet.Cfg;
using AutomacaoNet.Cfg.Flags;
using AutomacaoNet.DFe.CTeOS;
using AutomacaoNet.DFe.CTeOS.Flags;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Emitente;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Identificacao;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Tipos;
using DFe.DocumentosEletronicos.CTe.CTeOS;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes.Identificacao;
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
            cteOs.InfCte.emit = ConverteEmite(documento);

            return string.Empty;
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

        private emitOs ConverteEmite(Documento documento)
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