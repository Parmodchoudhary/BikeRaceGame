using Bike_Race.Classes;
using System;
using System.Windows.Forms;

namespace Bike_Race
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            Classes.Data.bikers[0] = new Bike() { bikePicture = bikeBlue, name = Classes.Data.riders[0], raceTrackLength = raceTrack.Width - bikeBlue.Left, randomizer = Classes.Data.randomizer, oddsFor = Classes.Data.randomizer.Next(1, 3), oddsAgainst = Classes.Data.randomizer.Next(2, 8) };
            Classes.Data.bikers[1] = new Bike() { bikePicture = bikePurple, name = Classes.Data.riders[1], raceTrackLength = raceTrack.Width - bikePurple.Left, randomizer = Classes.Data.randomizer, oddsFor = Classes.Data.randomizer.Next(1, 3), oddsAgainst = Classes.Data.randomizer.Next(2, 14) };
            Classes.Data.bikers[2] = new Bike() { bikePicture = bikeRed, name = Classes.Data.riders[2], raceTrackLength = raceTrack.Width - bikeRed.Left, randomizer = Classes.Data.randomizer, oddsFor = Classes.Data.randomizer.Next(1, 3), oddsAgainst = Classes.Data.randomizer.Next(2, 12) };
            Classes.Data.bikers[3] = new Bike() { bikePicture = bikeYellow, name = Classes.Data.riders[3], raceTrackLength = raceTrack.Width - bikeYellow.Left, randomizer = Classes.Data.randomizer, oddsFor = Classes.Data.randomizer.Next(1, 3), oddsAgainst = Classes.Data.randomizer.Next(2, 10) };

            Classes.Data.bettor[0] = new Guy() { bet = null, name = Classes.Data.gamblers[0], label = player1Bet, cash = 50, radioBtn = radioButton1 };
            Classes.Data.bettor[1] = new Guy() { bet = null, name = Classes.Data.gamblers[1], label = player2Bet, cash = 50, radioBtn = radioButton2 };
            Classes.Data.bettor[2] = new Guy() { bet = null, name = Classes.Data.gamblers[2], label = player3Bet, cash = 50, radioBtn = radioButton3 };

            for (int i = 0; i < Classes.Data.bettor.Length; i++)
            {
                Classes.Data.bettor[i].UpdateLabels();
            }

            ridersList.Items.AddRange(new object[] {
                Classes.Data.riders[0], Classes.Data.riders[1], Classes.Data.riders[2], Classes.Data.riders[3]
            });
            ridersList.Text = Classes.Data.riders[0];

            currentBettor.Text = radioButton1.Text;

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Enabled)
                currentBettor.Text = Classes.Data.gamblers[0];
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled)
                currentBettor.Text = Classes.Data.gamblers[1];
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Enabled)
                currentBettor.Text = Classes.Data.gamblers[2];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ridersList.Text.ToString() == Classes.Data.riders[0])
            {
                Classes.Data.odds = Classes.Data.bikers[0].oddsAgainst / Classes.Data.bikers[0].oddsFor;
            }
            if (ridersList.Text.ToString() == Classes.Data.riders[1])
            {
                Classes.Data.odds = Classes.Data.bikers[1].oddsAgainst / Classes.Data.bikers[1].oddsFor;
            }
            if (ridersList.Text.ToString() == Classes.Data.riders[2])
            {
                Classes.Data.odds = Classes.Data.bikers[2].oddsAgainst / Classes.Data.bikers[2].oddsFor;
            }
            if (ridersList.Text.ToString() == Classes.Data.riders[3])
            {
                Classes.Data.odds = Classes.Data.bikers[3].oddsAgainst / Classes.Data.bikers[3].oddsFor;
            }

            if (currentBettor.Text == Classes.Data.gamblers[0])
            {
                Console.WriteLine(Classes.Data.gamblers[0]);
                if (Classes.Data.player1 == 0)
                {
                    Classes.Data.bet = Classes.Data.bettor[0].PlaceBet(Convert.ToInt16(numericUpDown1.Value), ridersList.Text.ToString(), Classes.Data.odds);
                    if (Classes.Data.bet)
                    {
                        Classes.Data.player1 = 1;
                    }
                    else
                    {
                        MessageBox.Show(Classes.Data.gamblers[0] + " has already placed a bet");
                    }
                }
            }
            if (currentBettor.Text == Classes.Data.gamblers[1])
            {
                if (Classes.Data.player2 == 0)
                {
                    Classes.Data.bet = Classes.Data.bettor[1].PlaceBet(Convert.ToInt16(numericUpDown1.Value), ridersList.Text.ToString(), Classes.Data.odds);
                    if (Classes.Data.bet)
                    {
                        Classes.Data.player2 = 1;
                    }
                    else
                    {
                        MessageBox.Show(Classes.Data.gamblers[1] + " has already placed a bet");
                    }
                }
            }
            if (currentBettor.Text == Classes.Data.gamblers[2])
            {
                if (Classes.Data.player3 == 0)
                {
                    Classes.Data.bet = Classes.Data.bettor[2].PlaceBet(Convert.ToInt16(numericUpDown1.Value), ridersList.Text.ToString(), Classes.Data.odds);
                    if (Classes.Data.bet)
                    {
                        Classes.Data.player3 = 1;
                    }
                    else
                    {
                        MessageBox.Show(Classes.Data.gamblers[2] + " has already placed a bet");
                    }
                }
            }
        }

        private void BeginRace_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Classes.Data.bikers.Length; i++)
            {
                Classes.Data.bikers[i].TakeStartingPosition();
            }

            Classes.Data.player1 = 0;
            Classes.Data.player2 = 0;
            Classes.Data.player3 = 0;
            beginRace.Enabled = false;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < Classes.Data.bikers.Length; i++)
            {
                Classes.Data.bikers[i].Run();
                if (Classes.Data.bikers[i].Run())
                {
                    timer.Stop();
                    timer.Enabled = false;
                    MessageBox.Show(Classes.Data.bikers[i].name + " has won the race");
                    Classes.Data.winningRider = Classes.Data.bikers[i].name;
                    i = Classes.Data.bikers.Length;
                    beginRace.Enabled = true;
                    for (int j = 0; j < Classes.Data.bettor.Length; j++)
                    {
                        Classes.Data.bettor[j].Collect(Classes.Data.winningRider);
                    }
                }
            }
        }

        

    }
}
