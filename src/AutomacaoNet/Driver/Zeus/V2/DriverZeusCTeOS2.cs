﻿using AutomacaoNet.Cfg;
using AutomacaoNet.DFe;
using AutomacaoNet.DFe.CTeOS;
using AutomacaoNet.DFe.CTeOS.Servicos;
using AutomacaoNet.Driver.Zeus.V2.Servicos;

namespace AutomacaoNet.Driver.Zeus.V2
{
    public class DriverZeusCTeOS2 : IDriver<Documento>
    {
        private readonly IAutorizar<Documento> _autorizar;

        public DriverZeusCTeOS2(Configuracao configuracao)
        {
            _autorizar = new CTeOSAutorizar(new XmlAutorizar(configuracao), configuracao);
        }

        public IRespostaAutorizar Autorizar(Documento documento)
        {
            return _autorizar.Enviar(documento);
        }
    }
}