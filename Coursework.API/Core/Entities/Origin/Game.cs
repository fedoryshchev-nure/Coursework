using Core.Models;
using System;

namespace Core.Entities.Origin
{
    class Game : IEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
    }
}
