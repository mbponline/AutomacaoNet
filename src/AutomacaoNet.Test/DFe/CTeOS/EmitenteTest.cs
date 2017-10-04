using AutomacaoNet.DFe.CTeOS;
using NUnit.Framework;

namespace AutomacaoNet.Test.DFe.CTeOS
{
    [TestFixture]
    public class EmitenteTest
    {
        [Test]
        public void TesteObterNome()
        {
            var emitente = new Emitente
            {
                NomeFantasia = "Automação NET"
            };

            Assert.AreEqual("Automação NET", emitente.NomeFantasia);
        }
    }
}