using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Race.Classes // comment for the name of the classes //
{
    abstract class Data// comment for the description of the data //
    {
        public static Bike[] bikers = new Bike[4]; // comment for the bike //
        public static Guy[] bettor = new Guy[3]; // comment for the guy //
        public static Random randomizer = new Random();// comment for random // 
        public static int player1 = 0, player2 = 0, player3 = 0; //  comment for player 1 , 2 , and 3 //
        public static bool bet = false; // comment for bet //
        public static string winningRider; // comment for winner rider //
        public static int odds;
        public static string[] riders = new string[4] { // comment for riders //
                "Valentino Rossi",
                "Marc Marquez",
                "Casey Stoner",
                "Jorge Lorenzo" };
        public static string[] gamblers = new string[3] { "Joe", "Nick", "Hadi" }; // comment for gamblers //
    }
}
