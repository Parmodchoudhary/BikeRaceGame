using System;
using System.Windows.Forms;

namespace Bike_Race.Classes
{
    public class Bike // comment for the name of class //
    {
        public string name { get; set; } // comment for the name //
        public int startingPosition { get; set; } //comment for the starting position //
        public int raceTrackLength { get; set; } // comment for the race track length //
        public PictureBox bikePicture = null;
        // comment for the bike pictures box //
        public bool winner = false;//  comment for the if winner false //
        public int location = 0; // comment for the locations //
        public int oddsFor, oddsAgainst;

        public Random randomizer = new Random(); // comment for the new random //

        public bool Run() // comment for the run procedure //
        {
            int move = randomizer.Next(1, 6);
            location = location + move;
            bikePicture.Left = startingPosition + location;
            if (bikePicture.Right >= raceTrackLength)
            {
                winner = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition() // comment for the starting position //
        {
            location = 0;
            bikePicture.Left = startingPosition;
        }
    }
}
