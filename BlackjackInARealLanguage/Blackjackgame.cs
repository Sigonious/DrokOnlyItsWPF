using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BlackjackInARealLanguage
{
    class Blackjackgame
    {
	    int totalBetAmount;
        public int TotalBetAmount
        {
            get => totalBetAmount;
            set
            {
                if(player.Money >= value && value > 0)
                {
                    player.Money -= value;
                    totalBetAmount += value;
                }
            }
        }

        Player player;
        public Player ThePlayer { get => player; }

	    Player dealer;
        public Player TheDealer { get => dealer; }

	    Deck d;
        
	    public Blackjackgame(ResourceDictionary rd)
        {
            player = new Player(1000);
            dealer = new Player(0);
            d = new Deck(rd);
            totalBetAmount = 0;
        }

        public void start_game()
        {
            d.populate();
            d.resetDeck();
            player.resetPlayer(1000);
            dealer.resetPlayer(0);
            totalBetAmount = 0;
        }

        public void startAnotherRound()
        {

        }

        public BitmapImage hit(Player player)
        {
            int pindex = new Random().Next(52);
            while (d.TheDeck[pindex].HasBeenUsed)
            {
                pindex = new Random().Next(52);
            }
            d.TheDeck[pindex].HasBeenUsed = true;
            // check to see if it is an ACE
            if (pindex == 0 || pindex == 13 || pindex == 26 || pindex == 39)
            {
                if (player.TotalCardValue + 11 > 21) { player.TotalCardValue += + 1; }
                else { player.TotalCardValue += 11; }
                player.NumOfAces += 1;
            }
            // it is not an ace
            else { player.TotalCardValue += d.TheDeck[pindex].CardValue; }
            
            return d.TheDeck[pindex].Image;
        }

        public void stay()
        {

        }
    }
}
