﻿using System.Net;
using AutomacaoNet.Cfg.Flags;
using AutomacaoNet.DFe.Base;

namespace AutomacaoNet.Cfg
{
    public class Sefaz
    {
        public EstadoUF Origem { get; set; }
        public DFeEletronico DFeEletronico { get; set; }
        public AmbienteSefaz AmbienteSefaz { get; set; }
        public string VersaoLayout { get; set; }
        public SecurityProtocolType ProtocoloSeguranca { get; set; }
        public int TimeOut { get; set; }
    }
}