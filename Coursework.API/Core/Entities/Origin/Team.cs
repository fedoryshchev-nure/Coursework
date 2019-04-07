using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Origin
{
    class Team : IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}
