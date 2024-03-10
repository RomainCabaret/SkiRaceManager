using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager.Models
{
    public class Slope
    {
        public int SlopeID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }

        public int RunCount { get; set; }

        public string SlopePictureFullPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", Image); }
        }
    }
}
