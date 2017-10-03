﻿namespace AutomacaoNet.DFe.Base
{
    public abstract class EnderecoBase
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public Cidade Cidade { get; set; }
        public string Cep { get; set; }
    }
}