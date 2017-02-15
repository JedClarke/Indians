using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indians
{

    //Each Player object will hold current dynamic information for each player in the current game/round(most likely just that round)
    //this information will either be commited to the scoresheet as a running total or stored in the database (eventually)
    class Player
    {
        string name;    //players display name
        int call;       //current call
        int tricks;     //tricks currently won
        bool dealer;    //is the player the current dealer? potentially a variable for the scoresheet rather than the player
        int forced;      //counts previous number of zeros, if = 3 then can't go zero
        int total;      //the players current total score

        //basic (defualt) constructor, is given a player name and whether or not that player is the dealer (maybe not dealer)
        public Player(string n, bool d)
        {
            name = n;
            dealer = d;
            forced = 0;
        }

        //Destructor
        ~Player()
        {
            //cleanse purge kill
        }
        
        //checks if the current call is valid and assigns it to call, if invalid returns false to get another call
        public bool makeCall(int c)
        {
            if (forced == 3 && c == 0)  //can't call 0 if three zeros already called
            {
                return false;   //false returned, invalid call
            }
            else
            {
                call = c;   //call is assigned
                return true;    //call is valid, return true
            }
        }

        //the player has won a trick so the trick value will be incremented
        //possibly change to bool to confirm valid entry, if that situation arrises where a trick will be invalid
        public void trickWon()
        {
            tricks++;   //self explanitory
        }

        //calculates the players new score, this should be used at the end of the round, this will do all the end of the round cleanup, delete tricks and calls
        //eventually tricks and calls and so forth will be stored in the mythical database that will definitely exist one day
        public void recalculateScore()
        {
            if (tricks == call)
            {
                total += 10 * (call + 1);
            }
            else
            {
                //this seems like an awful way of doing things...
                //in future I'll write my own darn divide and round function
                total = (int)Math.Ceiling(((decimal)total)/2);
            }
        }

        //assigns player as current dealer, may need to be done elsewhere as dealer is unique, unsure
        public void isDealer(bool d)
        {
            dealer = d;
        }

    }
}
