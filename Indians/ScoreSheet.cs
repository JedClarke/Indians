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
        int cardsEach;          //total number of cards per person
        int totalCalled;
        string trumps;           //string to represent trumps H D S C

        //constructor with total number of players, might implement later, not sure
        public ScoreSheet(int pl)
        {
            totalPlayers = pl;
            players = new List<Player>();
            totalCalled = 0;
        }

        //constructor that takes the dealer as the only input, all other players added later
        public ScoreSheet(string d)
        {
            totalPlayers = 1;
            players = new List<Player>();
            players.Add(new Player(d, true));
            totalCalled = 0;
        }

        //adds a player, returns true if successfully added
        // will return false if player name is taken or some other fail conditions
        public bool addPlayer(string n)
        {
            //if player name is not already taken, check that later
            players.Add(new Player(n, false));
            totalPlayers++;
            return true;
        }

        //function for adding each player's call
        //I think this will be called from the main function and parse in an int, rather than getting all from this class
        //don't want to do any output from this class
        //will return true if call is valid, false if not
        //don't think I can use name to identify each player, each one will need a number (0, 1, 2 etc) eventual change
        public bool getCall(int c, string pl)   //at the moment pl is name, later change to int
        {
            //need to iterate through list to find player that matches
            //use foreach on each item in list
            foreach (Player play in players)
            {
                if (play.getName() == pl)
                {
                    if (play.makeCall(c))
                    {
                        //player has made their call
                        return true;
                    }
                }
            }
            return false;
        }

        //class for determining if players have gone up/down, can do all at once thankfully
        public void calculateScores()
        {
            foreach (Player play in players)
            {
                play.recalculateScore();
            }
        }

        //when a trick is won it goes to the player
        public void trickToPlayer(string pl)
        {
            foreach (Player play in players)
            {
                if (play.getName() == pl)  //iterate through the list to find the correct player
                {
                    play.trickWon();
                }
            }
        }
   


    }
}
