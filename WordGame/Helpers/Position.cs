using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordGame.Helpers
{
    public class Position
    {
        public int Row { get; set; }
        public int Columnn { get; set; }
        public string Character { get; set; } = "X";
        public bool Selected { get; set; } = false;

    }
}
