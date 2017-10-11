using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.Postgres;

namespace AutomacaoNet.Migracoes
{
    public static class ExecutaMigracao
    {
        public static string StringConexao =
            @"Server=localhost;Port=5432;User ID=postgres;Password=root;Database=nfeapi;";

        public  static void Executar()
        {
            Announcer announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));

            announcer.ShowSql = true;

            var assembly = Assembly.GetExecutingAssembly();
            IRunnerContext migrationContext = new RunnerContext(announcer);

            var options = new ProcessorOptions
            {
                PreviewOnly = false, // set to true to see the SQL
                Timeout = 60
            };

            var factory = new PostgresProcessorFactory();

            using (var processor = factory.Create(StringConexao, announcer, options))
            {
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);
            }
        }
    }
}