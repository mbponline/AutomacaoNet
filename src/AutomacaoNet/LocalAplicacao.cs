using System;
using System.IO;
using System.Reflection;

namespace AutomacaoNet
{
    public class LocalAplicacao
    {
        public static string GetLocalAplicacao()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}