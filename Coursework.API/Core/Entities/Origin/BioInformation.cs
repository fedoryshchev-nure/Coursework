﻿using Core.Models;
using System;

namespace Core.Entities.Origin
{
    class BioMeasure : IEntity
    {
        public string Id { get; set; }

        public int Pulse { get; set; }
        public int Pressure { get; set; }
        public DateTime DateMeasured { get; set; }

        public string PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
