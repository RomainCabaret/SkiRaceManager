using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager
{
    internal static class DbContext
    {
        private static readonly string HOSTNAME = "localhost";
        //private static readonly string DB = "skieracemanager";
        private static readonly string DB = "test";


        private static readonly string USER = "root";
        private static readonly string PASSWORD = "";


        public static MySqlConnection CreateConnexion()
        {
            return new MySqlConnection($"server={HOSTNAME};database={DB};uid={USER};pwd={PASSWORD};");
        } 
    }
}
