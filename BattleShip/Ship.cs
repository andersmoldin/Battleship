using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public enum Type
    {
        Submarine,
        Cruiser,
        Destroyer,
        Monsterbåt,
        Blåval
    }

    public enum Direction
    {
        Vertical,
        Horizontal
    }

    class Ship
    {
        public List<Coordinate> coordinates = new List<Coordinate>();
        //public bool Hit { get; set; }
        public bool Afloat { get; set; }
        public Type Type { get; set; }
        public int Length { get; set; }

        public Ship(Coordinate startCoordinate, int shipLength, Direction direction)
        {
            this.Afloat = true;

            this.Type = (Type)(shipLength - 1);

            for (int i = 0; i < shipLength; i++)
            {
                if (direction == Direction.Horizontal)
                {
                    this.coordinates.Add(new Coordinate(startCoordinate.X + i, startCoordinate.Y));
                }
                else
                {
                    this.coordinates.Add(new Coordinate(startCoordinate.X, startCoordinate.Y + i));
                }
            }
        }

        public override string ToString()
        {
            if (this.IsAfloat())
            {
                return " ";
            }
            else
            {
                return "x";
            }
        }

        public bool IsAfloat()
        {
            if (this.Afloat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Hit(Coordinate coordinate)
        {
            coordinate.Hit = true;

            this.Afloat = CheckIfStillAfloat();
        }

        private bool CheckIfStillAfloat()
        {
            foreach (Coordinate coordinate in this.coordinates)
            {
                if (coordinate.Hit != true)
                {
                    return true;
                }
            }

            MessageBox.Show($"Du har sänkt en {this.Type.ToString()}!");
            return false;
        }



        //public virtual bool isHit(int x, int y)
        //{ return true; }
    }
}
