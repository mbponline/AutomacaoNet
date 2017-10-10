using System;
using System.Collections.Generic;
using AutomacaoNet.Cfg;
using AutomacaoNet.Cfg.Flags;
using AutomacaoNet.DFe.CTeOS;
using AutomacaoNet.DFe.CTeOS.Flags;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.AutorizadoDownloadXml;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Emitente;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.infCteAnu;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.infCteComp;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.infCTeNormal.infCteSubs;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.infCTeNormal.infModals.rodoviarioOS;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Tipos;
using DFe.DocumentosEletronicos.CTe.Classes.Informacoes.Valores;
using DFe.DocumentosEletronicos.CTe.CTeOS;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes.Identificacao;
using DFe.DocumentosEletronicos.CTe.CTeOS.Informacoes.InfCTeNormal;
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
            cteOs.InfCte.infCTeNorm = ConverterCteNormal(documento);

            return string.Empty;
        }

        private infCTeNormOs ConverterCteNormal(Documento documento)
        {
            var infCteNorm = new infCTeNormOs();

            InfPrestacaoServico(documento, infCteNorm);

            InfDocumentosReferenciados(documento, infCteNorm);

            InfSeguros(documento, infCteNorm);

            InfCteSubstituicao(documento, infCteNorm);

            InfCteComplementado(documento, infCteNorm);

            InfCteAnulacao(documento, infCteNorm);

            AutorizadosParaDownloadXml(documento, infCteNorm);

            infCteNorm.infModal = new infModalOs();
            var modalRodo = new rodoOS();
            infCteNorm.infModal.ContainerModal = modalRodo;

            modalRodo.TAF = documento.RodoviarioOS.Taf;
            modalRodo.NroRegEstadual = documento.RodoviarioOS.NumeroRegistroEstadual;

            ModalRodoviarioOs(documento, modalRodo);

            return infCteNorm;
        }

        private static void ModalRodoviarioOs(Documento documento, rodoOS modalRodo)
        {
            if (documento.RodoviarioOS.Veiculo != null)
            {
                var veiculo = new veicOs();
                modalRodo.veic = veiculo;

                veiculo.placa = documento.RodoviarioOS.Veiculo.Placa;
                veiculo.RENAVAM = documento.RodoviarioOS.Veiculo.Renavam;

                if (documento.RodoviarioOS.Veiculo.Proprietario != null)
                {
                    var docProprietario = documento.RodoviarioOS.Veiculo.Proprietario;
                    var proprietario = new prop();
                    modalRodo.veic.prop = proprietario;

                    if (docProprietario.DocumentoUnico.Length == 11)
                    {
                        proprietario.CPF = docProprietario.DocumentoUnico;
                    }

                    if (docProprietario.DocumentoUnico.Length == 14)
                    {
                        proprietario.CNPJ = docProprietario.DocumentoUnico;
                    }

                    proprietario.TAF = docProprietario.Taf;
                    proprietario.NroRegEstadual = docProprietario.NumeroRegistroEstadual;
                    proprietario.xNome = docProprietario.NomeOuRazaoSocial;
                    proprietario.IE = docProprietario.InscricaoEstadual;
                    proprietario.UF = proprietario.UF.SiglaParaEstado(docProprietario.EstadoUf.Sigla);

                    switch (docProprietario.TipoProprietario)
                    {
                        case TipoProprietario.TacAgregado:
                            proprietario.tpProp = tpPropProp.TACAgregado;
                            break;
                        case TipoProprietario.TacIndependente:
                            proprietario.tpProp = tpPropProp.TACIndependente;
                            break;
                        case TipoProprietario.Outros:
                            proprietario.tpProp = tpPropProp.Outros;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    veiculo.UF = veiculo.UF.SiglaParaEstado(documento.RodoviarioOS.Veiculo.EstadoUf.Sigla);
                }
            }
        }

        private static void AutorizadosParaDownloadXml(Documento documento, infCTeNormOs infCteNorm)
        {
            var autorizadosDownXml = documento.DocumentoUnicoAutorizadoDownoad;
            if (autorizadosDownXml != null && autorizadosDownXml.Count != 0)
            {
                infCteNorm.autXml = new List<autXML>();
                foreach (var autoDownXml in autorizadosDownXml)
                {
                    var autXml = new autXML();

                    if (autoDownXml.Length == 11)
                    {
                        autXml.CPF = autoDownXml;
                    }

                    if (autoDownXml.Length == 14)
                    {
                        autXml.CNPJ = autoDownXml;
                    }

                    infCteNorm.autXml.Add(autXml);
                }
            }
        }

        private static void InfCteAnulacao(Documento documento, infCTeNormOs infCteNorm)
        {
            if (documento.CteAnulacao != null)
            {
                infCteNorm.infCteAnu = new infCteAnu
                {
                    dEmi = documento.CteAnulacao.EmissaoEm,
                    chCte = documento.CteAnulacao.ChaveCTe
                };
            }
        }

        private static void InfCteComplementado(Documento documento, infCTeNormOs infCteNorm)
        {
            if (!string.IsNullOrWhiteSpace(documento.ChaveCteComplemento))
            {
                infCteNorm.infCteComp = new infCteComp
                {
                    chCTe = documento.ChaveCteComplemento
                };
            }
        }

        private static void InfCteSubstituicao(Documento documento, infCTeNormOs infCteNorm)
        {
            if (documento.CteSubstituicao != null)
            {
                infCteNorm.infCteSub = new infCteSubOs();
                var infCteSub = infCteNorm.infCteSub;

                infCteSub.chCte = documento.CteSubstituicao.ChaveCTe;
                infCteSub.refCteAnu = documento.CteSubstituicao.ChaveCTeAnulacao;

                infCteSub.tomaICMS = new tomaICMS();
                var tomaIcms = infCteSub.tomaICMS;

                tomaIcms.refNFe = documento.CteSubstituicao.ChaveNFeEmitidaPeloTomador;
                tomaIcms.refNF = new refNF();

                var refNf = tomaIcms.refNF;
                var documentoUnicoRefNf = documento.CteSubstituicao.NF.DocumentoUnico;

                if (documentoUnicoRefNf.Length == 11)
                {
                    refNf.CPF = documentoUnicoRefNf;
                }

                if (documentoUnicoRefNf.Length == 14)
                {
                    refNf.CNPJ = documentoUnicoRefNf;
                }

                refNf.mod = documento.CteSubstituicao.NF.ModeloDocumentoFiscal;
                refNf.serie = documento.CteSubstituicao.NF.Serie;
                refNf.subserie = documento.CteSubstituicao.NF.SubSerie;
                refNf.nro = documento.CteSubstituicao.NF.NumeroFiscal;
                refNf.valor = documento.CteSubstituicao.NF.Valor;
                refNf.dEmi = documento.CteSubstituicao.NF.EmissaoEm;

                tomaIcms.refCte = documento.CteSubstituicao.ChaveCTeEmitidaPeloTomador;
            }
        }

        private static void InfSeguros(Documento documento, infCTeNormOs infCteNorm)
        {
            var seguros = documento.Seguros;
            if (seguros != null && seguros.Count != 0)
            {
                infCteNorm.seg = new List<segOs>();
                foreach (var seguro in seguros)
                {
                    var seg = new segOs();

                    switch (seguro.Responsavel)
                    {
                        case Responsavel.EmitenteCte:
                            seg.respSeg = respSeg.EmitenteDoCTe;
                            break;
                        case Responsavel.TomadorDeServico:
                            seg.respSeg = respSeg.TomadorDoServico;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    seg.xSeg = seguro.NomeSeguradora;
                    seg.nApol = seguro.NumeroApolice;

                    infCteNorm.seg.Add(seg);
                }
            }
        }

        private static void InfDocumentosReferenciados(Documento documento, infCTeNormOs infCteNorm)
        {
            var documentosReferenciados = documento.DocumentosReferenciados;
            if (documentosReferenciados != null && documentosReferenciados.Count != 0)
            {
                infCteNorm.infDocRef = new List<infDocRef>();

                foreach (var documentosReferenciado in documentosReferenciados)
                {
                    var docRef = new infDocRef();

                    docRef.nDoc = documentosReferenciado.Numero;
                    docRef.serie = documentosReferenciado.Serie;
                    docRef.subserie = documentosReferenciado.SubSerie;
                    docRef.dEmi = documentosReferenciado.EmitidoEm;
                    docRef.vDoc = documentosReferenciado.Valor;

                    infCteNorm.infDocRef.Add(docRef);
                }
            }
        }

        private static void InfPrestacaoServico(Documento documento, infCTeNormOs infCteNorm)
        {
            if (string.IsNullOrWhiteSpace(documento.InfPrestacaoServico?.DescricaoServico)) return;

            infCteNorm.infServico = new infServico
            {
                xDescServ = documento.InfPrestacaoServico.DescricaoServico
            };

            if (documento.InfPrestacaoServico.QuantidadeCarga != null)
            {
                infCteNorm.infServico.infQ = new infQOs
                {
                    qCarga = documento.InfPrestacaoServico.QuantidadeCarga
                };
            }
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