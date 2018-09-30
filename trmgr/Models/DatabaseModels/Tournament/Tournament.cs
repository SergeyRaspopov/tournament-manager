using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels.Tournament
{
    public class Tournament
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public City City { get; set; }
        public IEnumerable<Bracket> Brackets { get; set; }
        public DateTime Date { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime RegistrationEnd { get; set; }
    }
}