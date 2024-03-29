﻿using System.ComponentModel;

namespace AutomacaoNet.Cfg.Flags
{
    public enum TipoCertificado
    {
        [Description("Certificado A1")]
        A1Repositorio,

        [Description("Certificado A1 em arquivo")]
        A1Arquivo,

        [Description("Certificado A1 em byte array")]
        A1ByteArray,

        [Description("Certificado A3")]
        A3
    }
}