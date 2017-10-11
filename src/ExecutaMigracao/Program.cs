using System;

namespace ExecutaMigracao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AutomacaoNet.Migracoes.ExecutaMigracao.Executar();
                Console.WriteLine("Atualização do banco de dados concluida com sucesso");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }


        }
    }
}
