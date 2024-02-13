using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager.Models
{
    public static class Session
    {
        public static int Id { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string ProfilePicture { get; set; }
        public static string Rank { get; set; }
    }
}
