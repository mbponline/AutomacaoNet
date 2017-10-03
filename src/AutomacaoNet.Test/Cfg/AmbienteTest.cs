using AutomacaoNet.Cfg;
using NUnit.Framework;

namespace AutomacaoNet.Test.Cfg
{
    [TestFixture]
    public class AmbienteTest
    {

        [Test]
        public void EsperaStringConexao()
        {
            const string stringConexao = "integridade.stringConexao";

            Assert.AreEqual(stringConexao, Ambiente.StringConexao);
        }

        [Test]
        public void EsperaBancoDados()
        {
            const string bancoDados = "integridade.bancoDados";

            Assert.AreEqual(bancoDados, Ambiente.BancoDados);
        }

        [Test]
        public void EsperaIsIntegridade()
        {
            const string isIntegridade = "integridade.ativar";

            Assert.AreEqual(isIntegridade, Ambiente.IsIntegridade);
        }

        [Test]
        public void EsperaAmbienteSefaz()
        {
            const string ambienteSefaz = "dfe.ambienteSefaz";

            Assert.AreEqual(ambienteSefaz, Ambiente.AmbienteSefaz);
        }

        [Test]
        public void EsperaDocumentoFiscalEletronico()
        {
            const string documentoFiscalEletronico = "dfe.documentoFiscalEletronico";

            Assert.AreEqual(documentoFiscalEletronico, Ambiente.DocumentoFiscalEletronico);
        }

        [Test]
        public void EsperaTipoCertificadoDigital()
        {
            const string tipoCertificadoDigital = "certificado.tipoCertificadoDigital";

            Assert.AreEqual(tipoCertificadoDigital, Ambiente.TipoCertificadoDigital);
        }

        [Test]
        public void EsperaSerialCertificadoDigital()
        {
            const string serialCertificadoDigital = "certificado.serial";

            Assert.AreEqual(serialCertificadoDigital, Ambiente.SerialCertificadoDigital);
        }

        [Test]
        public void EsperaArquivoCertificadoDigital()
        {
            const string arquivoCertificadoDigital = "certificado.arquivo";

            Assert.AreEqual(arquivoCertificadoDigital, Ambiente.ArquivoCertificadoDigital);
        }

        [Test]
        public void EsperaSenhaCertificadoDigital()
        {
            const string senhaCertificadoDigital = "certificado.senha";

            Assert.AreEqual(senhaCertificadoDigital, Ambiente.SenhaCertificadoDigital);
        }

        [Test]
        public void EsperaLog()
        {
            const string log = "log.ativar";

            Assert.AreEqual(log, Ambiente.LogAtivar);
        }
    }
}
