using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    partial class Form1
    {
        List<Player> players = new List<Player>();

        private void Cheat()
        {
            if (Settings.cheat)
            {
                foreach (var control in this.Controls)
                {
                    if (control.GetType().Name == "GameBoardCoordinateButton")
                    {
                        GameBoardCoordinateButton button = control as GameBoardCoordinateButton;

                        foreach (Ship ship in players[0].gameBoard.ships)
                        {
                            foreach (Coordinate coordinate in ship.coordinates)
                            {
                                if (coordinate.Equals(button.Coordinate))
                                {
                                    button.BackColor = System.Drawing.Color.DimGray;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void InitializeEnvironment()
        {
            players.Add(new Player(this, "Arne", Settings.gameSize)); // 1 player
        }

        private void InitializeForm()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.Height = this.Controls[this.Controls.Count - 1].Bottom+39; //190;
            this.Width = this.Controls[this.Controls.Count - 1].Right+16; //166;

            //this.Size = new System.Drawing.Size(this.Controls[this.Controls.Count - 1].Right, this.Controls[this.Controls.Count - 1].Bottom);

            //this.Controls[this.Controls.Count - 1].BackColor = System.Drawing.Color.Red;
            //MessageBox.Show(this.Controls[this.Controls.Count - 1].Bottom.ToString());
            //this.Size = new System.Drawing.Size((Settings.buttonSize + 3) * Settings.gameSize, (Settings.buttonSize + 3) * Settings.gameSize);
        }

        public void FocusOnNothing()
        {
            textBox1.TabStop = false;
            textBox1.Focus();
            textBox1.Left = -300;
        }
    }
}
