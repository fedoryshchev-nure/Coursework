using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities.Origin
{
    public class Team : IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}
