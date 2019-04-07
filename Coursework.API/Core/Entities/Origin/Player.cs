using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Origin
{
    class Player : IEntity
    {
        public string Id { get; set; }


        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string TeamId { get; set; }
        public Team Team { get; set; }

        public IEnumerator<BioMeasure> BioMeasures { get; set; }
    }
}
