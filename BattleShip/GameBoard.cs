using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class GameBoard : List<GameBoardCoordinateButton>
    {

        public List<Ship> ships = new List<Ship>();
        Random randomizer = new Random();

        public GameBoard(object sender, int gameBoardSize)
        {
            FillWithButtons(gameBoardSize);
            FillWithShips();
            Print(sender);
        }

        private void FillWithButtons(int gameBoardSize)
        {
            for (int i = 0; i < gameBoardSize; i++)
            {
                for (int j = 0; j < gameBoardSize; j++)
                {
                    this.Add(new GameBoardCoordinateButton(i, j));
                }
            }
        }

        private void FillWithShips()
        {
            // Tre skepp, storlek: 1, 2, 3.
            for (int i = 0; i < Settings.submarines; i++)
            {
                AddShip(1);
            }

            for (int i = 0; i < Settings.cruisers; i++)
            {
                AddShip(2);
            }

            for (int i = 0; i < Settings.destroyers; i++)
            {
                AddShip(3);
            }

            //this.ships.Add(new Ship(ValidStartPosition(1), 1, Direction.Horizontal);

            //this.ships.Add(new Submarine());
            //this.ships.Add(new Cruiser());
            //this.ships.Add(new Destroyer());
        }

        private void AddShip(int shipLength)
        {
            Random randomizer = new Random();
            bool foundGoodCoordinate = false;

            Coordinate startPos;
            Direction direction;

            do
            {
                startPos = new Coordinate(randomizer.Next(Settings.gameSize), randomizer.Next(Settings.gameSize));
                direction = (Direction)randomizer.Next(2);

                if ((direction == Direction.Horizontal && (startPos.X + shipLength) <= Settings.gameSize) || (direction == Direction.Vertical && (startPos.Y + shipLength) <= Settings.gameSize))
                {
                    bool shipNotFound = true;
                    for (int i = 0; i < shipLength && shipNotFound; i++)
                    {
                        for (int j = 0; j < this.ships.Count && shipNotFound; j++)
                        {
                            Ship ship = this.ships[j];

                            foreach (Coordinate coordinate in ship.coordinates)
                            {
                                if ((direction == Direction.Horizontal && (new Coordinate(startPos.X + i, startPos.Y).Equals(coordinate))) || (direction == Direction.Vertical && (new Coordinate(startPos.X, startPos.Y + i).Equals(coordinate))))
                                {
                                    shipNotFound = false;
                                    break;
                                }
                            }
                        }
                    }
                    
                      foundGoodCoordinate = shipNotFound;                    
                }

                
            } while (!foundGoodCoordinate);

            this.ships.Add(new Ship(startPos, shipLength, direction));
        }

        private void Print(object sender)
        {
            Form1 senderForm = sender as Form1;

            foreach (GameBoardCoordinateButton button in this)
            {
                button.Location = new System.Drawing.Point(Settings.buttonSpacing * button.Coordinate.X, Settings.buttonSpacing * button.Coordinate.Y);

                button.Size = new System.Drawing.Size(Settings.buttonSize, Settings.buttonSize);

                button.TabIndex = this.IndexOf(button);

                button.Text = "";

                button.UseVisualStyleBackColor = true;

                button.Click += new EventHandler(senderForm.button_Click);

                senderForm.Controls.Add(button);
            }
        }

        //public void Print()
        //{
        //    Console.Clear();

        //    Console.Write("  ");
        //    for (int i = 0; i < this.Size; i++)
        //    {
        //        Console.Write($"|{i + 1}");
        //    }

        //    Console.WriteLine();

        //    for (int i = 0; i < this.Size; i++)
        //    {
        //        Console.Write(string.Format("{0,2}|", (i + 1)));

        //        for (int j = 0; j < this.Size; j++)
        //        {
        //            if (this.coordinates[i, j] == null)
        //            {
        //                Console.Write(" ");
        //            }
        //            else
        //            {
        //                Console.Write(this.coordinates[i, j]);
        //            }

        //            Console.Write(" ");
        //        }
        //        Console.WriteLine();
        //    }

        //    Console.WriteLine();

        //    if (AllShipsSunk())
        //    {
        //        Console.Write("DU VANN!");
        //        Console.ReadLine();

        //        Program.quit = true;
        //    }
        //}

        public bool AllShipsSunk()
        {
            foreach (Ship ship in this.ships)
            {
                if (ship.IsAfloat())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
