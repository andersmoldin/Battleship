using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeEnvironment(); // Initiera spelet
            InitializeForm();
            Cheat();
        }

        public void button_Click(object sender, EventArgs e)
        {
            players[0].Shoot(sender as GameBoardCoordinateButton);
            FocusOnNothing();
            if (players[0].gameBoard.AllShipsSunk())
            {
                MessageBox.Show("Du vann");

                foreach (var control in this.Controls)
                {
                    if (control.GetType().Name == "GameBoardCoordinateButton")
                    {
                        GameBoardCoordinateButton button = control as GameBoardCoordinateButton;
                        button.Enabled = false;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FocusOnNothing();
        }
    }
}
