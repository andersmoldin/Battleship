using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    class Player
    {
        public GameBoard gameBoard { get; set; }

        public string Name { get; }

        public Player(object sender, string name, int gameBoardSize)
        {
            Name = name;
            this.gameBoard = new GameBoard(sender, gameBoardSize);
        }

        public void Shoot(GameBoardCoordinateButton gameBoardCoordinateButton)
        {
            bool didFindShipWithCoordinate = false;

            foreach (Ship ship in gameBoard.ships)
            {
                if (!didFindShipWithCoordinate)
                {
                    foreach (Coordinate coordinate in ship.coordinates)
                    {
                        if (gameBoardCoordinateButton.Coordinate.Equals(coordinate))
                        {
                            ship.Hit(coordinate);
                            gameBoardCoordinateButton.BackColor = System.Drawing.Color.Red;
                            didFindShipWithCoordinate = true;
                            break;
                        }
                    }
                }
            }

            gameBoardCoordinateButton.Enabled = false;
        }
    }
}
