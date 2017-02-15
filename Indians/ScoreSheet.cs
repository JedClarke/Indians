using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indians
{
    //the scoresheet class will keep track of the current round and the total scores, I think all previous rounds in the current game should be stored in the database, maybe
    //don't really want to store every previous round within the object, rather unnecessary I think
    //actually each player should have their current total, stupid to store it seperately
    class ScoreSheet
    {
        List<Player> players;    //list of players
        int totalPlayers;        //total current players

        //constructor with total number of players, might implement later, not sure
        public ScoreSheet(int pl)
        {
            totalPlayers = pl;
            players = new List<Player>();
        }

        //constructor that takes the dealer as the only input, all other players added later
        public ScoreSheet(string d)
        {
            totalPlayers = 1;
            players = new List<Player>();
            players.Add(new Player(d, true));
        }

        //adds a player, returns true if successfully added
        // will return false if player name is taken or some other fail conditions
        public bool addPlayer(string n)
        {
            //if player name is not already taken, check that later
            players.Add(new Player(n, false));
            return true;
        }
    }
}
