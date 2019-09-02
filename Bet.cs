using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Race.Classes // comment for the name of the classes //
{
    public class Bet : Bike // in the below the is a description about class bet and bike //
    {
        public int amount { get; set; } //comment for the amount //
        public string biker { get; set; } // comment for the biker //
        public Guy guy { get; set; } // comment for the guy //
        public int odds { get; set; } // comment for the odds //
        public int dbOdds { get; set; } //comment for the dbodds //

        public string GetDescription() // comment for the get description //
        {
            if (amount == 0) // comment for the description of amount //
            {
                return guy.name + " hasn't placed a bet";
            }
            else
            {
                return guy.name + " placed a bet of $" + amount + " on " + biker;
            }
        }

        public int Payout(string winner) // comment for the payout winner //
        {
            if (winner == biker)
            {
                return amount * odds;
            }
            else
            {
                return (0 - amount);
            }
        }
    }
}
