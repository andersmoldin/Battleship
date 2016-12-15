using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BattleShip
{
    public class GameBoardCoordinateButton : Button
    {
        public Coordinate Coordinate { get; set; }

        public GameBoardCoordinateButton(int x, int y)
        {
            this.Coordinate = new Coordinate(x, y);

            this.Name = $"button{x}{y}";
        }
    }
}