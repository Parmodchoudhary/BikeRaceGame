using System.Windows.Forms;

namespace Bike_Race.Classes
{
    public class Guy : Bet // comment for the guy //
    {
        public Bet bet; //comment for the brt //
        public int cash { get; set; } // comment for the cash //

        public RadioButton radioBtn;//comment for the  radio button and label 1 //
        public Label label;

        public void UpdateLabels() // comment for the void update labels //
        {
            radioBtn.Text = name + " has $" + cash;
        }

        public void ClearBet() // comment for the void clear bet //
        {
            bet = null;
            label.Text = name + " hasn't placed any bets.";
        }

        public bool PlaceBet(int betAmount, string bikerToWin, int test) // comment for the place bet //
        {
            this.bet = new Bet() { amount = betAmount, biker = bikerToWin, odds = test }; // comment for the new bet //
            if (betAmount <= cash)
            {
                label.Text = this.name + " bets $" + betAmount + " on " + bikerToWin; // comment for the name brt amount //
                cash -= betAmount;
                this.UpdateLabels();
                return true;
            }
            else
            {
                MessageBox.Show(name + " does not have enough to cover that bet"); // comment for the picture box //
                this.bet = null;
                return false;
            }
        }

        public void Collect(string winner) //  comment for the descriptin about the void collect of winner and null //
        {
            if (bet != null)
                cash += bet.Payout(winner);
            ClearBet();
            UpdateLabels();
        }
    }
}
