using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackjackInARealLanguage
{
    class Player
    {
	    int money;
        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        int numOfAces;
        public int NumOfAces
        {
            get { return numOfAces; }
            set { numOfAces = value; }
        }

        int totalCardValue;
        public int TotalCardValue
        {
            get { return totalCardValue; }
            set { totalCardValue = value; }
        }

        int cardPos1, cardPos2;

        public Player(int startingValue)
        {
            money = startingValue;
            numOfAces = 0;
            totalCardValue = 0;
        }

        public void Bet(int wager)
        {
            if( wager <= money)
            {
                money -= wager;
            }
        }

        public void resetPlayer(int initValue)
        {
            money = initValue;
            numOfAces = 0;
            totalCardValue = 0;
        }
    }
}
