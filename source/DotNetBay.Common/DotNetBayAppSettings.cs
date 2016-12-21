using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;

namespace DotNetBay.Common
{
    public class DotNetBayAppSettings
    {
        public static readonly string DatabaseConnection =
            //IsAzureEnvironment() ?
            //CloudConfigurationManager.GetSetting("DatabaseConnection") :
            ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

        private static bool IsAzureEnvironment()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            return loadedAssemblies.Any(a => a.FullName.StartsWith("Microsoft.WindowsAzure.ServiceRuntime"));
        }
    }
}
