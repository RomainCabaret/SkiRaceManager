using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager.Models
{
    internal class Accounts
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public string Rank { get; set; }

        public string AccountPictureFullPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", ProfilePicture); }
        }
    }

}
