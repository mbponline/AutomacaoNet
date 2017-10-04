using System.Collections.Generic;

namespace AutomacaoNet.DFe.CTeOS
{
    /// <summary>
    /// compl - Dados complementares do CT-e para fins operacionais ou comerciais
    /// </summary>
    public class DadosComplementares
    {
        public string CaracteristicaTransporte { get; set; }

        public string CaracteristicaServico { get; set; }

        public string FuncionarioEmissor { get; set; }

        public string Observacao { get; set; }

        public IList<ObservacaoContribuinte> ObservacoesContribuinte { get; set; }

        public IList<ObservacaoFisco> ObservacoesFisco { get; set; }
    }
}