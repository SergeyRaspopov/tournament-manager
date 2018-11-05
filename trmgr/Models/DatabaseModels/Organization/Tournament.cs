using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class Tournament
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string StreetAddress { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string City { get; set; }

        public DateTime Date { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime RegistrationEnd { get; set; }

        public IEnumerable<Bracket> Brackets { get; set; }
        //divisions
        public IEnumerable<DivisionGroup> Divisions { get; set; }

        public string ApplicationUserId { get; set; }

        public Tournament()
        {
            Divisions = new List<DivisionGroup>();
            Brackets = new List<Bracket>();
        }

        public void AddDivision(DivisionGroup divisionGroup)
        {
            Divisions = Divisions.Append(divisionGroup);
        }
    }
}