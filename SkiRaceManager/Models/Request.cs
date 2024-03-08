using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager.Models
{
    internal class Request
    {
        public int Id { get; set; }
        public string AccountID { get; set; }
        public string SlopeID { get; set; }

        public string AccountName { get; set; }
        public string SlopeName { get; set; }

        public DateTime DateDemande { get; set; }
        public bool IsTraite { get; set; }
      
    }
}
