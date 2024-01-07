using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class CreaturePosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CreaturePosition(int X, int Y)
        {
            this.X = X; 
            this.Y = Y;
        }
    }
}
