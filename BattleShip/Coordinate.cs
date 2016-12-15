using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Hit { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(other, null))
                return false;

            var num = X;

            if (!num.Equals(other.X))
                return false;

            num = Y;

            return num.Equals(other.Y);
        }
    }
}
