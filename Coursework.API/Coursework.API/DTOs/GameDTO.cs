using System;

namespace Coursework.API.DTOs
{
    public class GameDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateReleased { get; set; }
    }
}
