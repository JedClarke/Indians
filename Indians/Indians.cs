using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indians
{
    class Indians
    {
        static void Main(string[] args)
        {
            int players;

            //starts game by creating a scoresheet for the current round and then getting player names

            Console.WriteLine("Please enter the number of players: ");
            players = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter name for player 1: ");
            ScoreSheet currentRound = new ScoreSheet(Console.ReadLine());

            for (int p = 2; p <= players; p++ )
            {
                Console.WriteLine("Please enter name for player {0}: ", p);
                currentRound.addPlayer(Console.ReadLine()); //will eventually check for duplicate names, not right now
            }
        }
    }
}
