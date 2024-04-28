using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager.Models
{
    internal class Participation
    {
        public int Id { get; set; }
        public string AccountLogin { get; set; }
        public string AccountPicture { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime ReleaseDate { get; set; }


        public string AccountPictureFullPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", AccountPicture); }
        }
    }
}