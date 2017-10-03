using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AutomacaoNet.Cfg
{
    public class Configuracao
    {
        private IDictionary<string, string> Propriedades { get; set; } = new ConcurrentDictionary<string, string>();

        public void AdicionarPropriedades(IDictionary<string, string> propriedades)
        {
            Propriedades = propriedades;
        }
    }
}