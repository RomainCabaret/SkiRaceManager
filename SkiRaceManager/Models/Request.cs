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
        public int AccountID { get; set; }
        public int SlopeID { get; set; }

        public string AccountName { get; set; }
        public string SlopeName { get; set; }

        public DateTime DateDemande { get; set; }
        public bool IsTraite { get; set; }
      
    }
}
