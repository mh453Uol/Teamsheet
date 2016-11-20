using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamsheet.Core.Configuration
{
    public static class ConfigHelper
    {
        public static string GetConnectionString()
        {
            return "Server=.;Database=Teamsheet;Trusted_Connection=True;";
        }
    }
}
