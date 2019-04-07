using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Origin
{
    public class Player : IEntity
    {
        public string Id { get; set; }


        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string TeamId { get; set; }
        public Team Team { get; set; }

        public IEnumerable<BioMeasure> BioMeasures { get; set; }
    }
}
