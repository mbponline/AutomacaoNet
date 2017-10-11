using FluentMigrator;

namespace AutomacaoNet.Migracoes.V01
{
    [Migration(1)]
    public class CriaTabelaEmissaoCTeOsHistorico : Migration
    {
        public override void Up()
        {
            Create.Table("cteos_emissao_historico")
                .WithColumn("id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("cnpjEmitente").AsString(14).NotNullable()
                .WithColumn("xmlEnvio").AsString().NotNullable()
                .WithColumn("xmlRetorno").AsString().NotNullable()
                .WithColumn("xmlAutorizado").AsString().NotNullable()
                .WithColumn("numeroFiscal").AsInt32().NotNullable()
                .WithColumn("chave").AsString(44).NotNullable()
                .WithColumn("isFinalizou").AsBoolean().NotNullable()
                .WithColumn("isAutorizado").AsBoolean().NotNullable()
                .WithColumn("enviadoEm").AsDateTime().NotNullable()
                .WithColumn("autorizadoEm").AsDateTime()
                .WithColumn("codigoStatusSefaz").AsInt16().NotNullable()
                .WithColumn("motivoSefaz").AsString(255).NotNullable()
                .WithColumn("referencia").AsString(100).NotNullable();
        }

        public override void Down()
        {
            
        }
    }
}