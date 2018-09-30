using System;
using System.Collections.Generic;

namespace trmgr.Models.DatabaseModels.Organization
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