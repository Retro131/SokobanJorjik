﻿
using System;

namespace Sokoban
{
    public class Results
    {
        public int Id { get; set; }
        public Users Users { get; set; }
        public Levels Levels { get; set; }
        public int Steps { get; set; }
        public DateTime date { get; set; }
    }
}
