using System;

namespace Coursework.API.DTOs
{
    public class PlayerDTO
    {
        public string Id { get; set; }

        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string TeamId { get; set; }
    }
}
