using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BlackjackInARealLanguage
{
    class Deck
    {
        int deckSize;
        string[] suitsTotal;
        Card[] deck;
        public Card[] TheDeck { get => deck; }

        BitmapImage[] cardList = new BitmapImage[52];

	    public Deck(ResourceDictionary rd)
        {
            deck = new Card[52];
            for (int i = 0; i < deck.Count(); i++)
            {
                deck[i] = new Card();
            }
            deckSize = deck.Count();
            suitsTotal = new string[]{ "s", "c", "d", "h" };

            cardList[0] = rd["spadesA"] as BitmapImage;
            cardList[13] = rd["diamondsA"] as BitmapImage;
            cardList[26] = rd["heartsA"] as BitmapImage;
            cardList[39] = rd["clubsA"] as BitmapImage;

            for (int i = 2; i <= 10; i++)
            {
                cardList[i - 1] = rd["spades" + i] as BitmapImage;
                cardList[i + 13] = rd["diamonds" + i] as BitmapImage;
                cardList[i + 26] = rd["hearts" + i] as BitmapImage;
                cardList[i + 39] = rd["clubs" + i] as BitmapImage;
            }

            cardList[10] = rd["spadesJ"] as BitmapImage;
            cardList[11] = rd["spadesQ"] as BitmapImage;
            cardList[12] = rd["spadesK"] as BitmapImage;
            cardList[23] = rd["diamondsJ"] as BitmapImage;
            cardList[24] = rd["diamondsQ"] as BitmapImage;
            cardList[25] = rd["diamondsK"] as BitmapImage;
            cardList[36] = rd["heartsJ"] as BitmapImage;
            cardList[37] = rd["heartsQ"] as BitmapImage;
            cardList[38] = rd["heartsK"] as BitmapImage;
            cardList[49] = rd["clubsJ"] as BitmapImage;
            cardList[50] = rd["clubsQ"] as BitmapImage;
            cardList[51] = rd["clubsK"] as BitmapImage;

        }

        public void shuffle()
        {

        }

        public void populate()
        {
            /*
        *	 Set values of the deck. Aces should have a value of 1 or 11
        *	 However, each card will get a second value so that we do not have to search for Aces.
        *
        *	 Indices of the cards at initialization
        *	 0-12 Spades		10-12 face cards
        *	 13-25 Clubs		23-25 face cards
        *	 26-38 Diamonds		36-38 face cards
        *	 39-51 Hearts		49-51 face cards
        */
            int cardName = 1;
            int count = 0;
            int j = 1; // value of the cards
                       // count to reset for face cards
            int suitCount = 0;

            for (int i = 1; i < deckSize; i++)
            {
                // aCardValue to be only used for Aces
                deck[i].ACardValue = 11;
                deck[i].CardValue = j++;

                deck[i].Image = cardList[i];
                cardName++;

                if (j >= 10) // when j = 10, let the value persist until all face cards are accounted for
                {
                    j = 10;
                    count++;
                    if (count > 4) // when count reaches 5, all face cards for that suit has been assigned a value of 10
                    {
                        j = 1;
                        count = 0;
                    }
                }

                // set suits. if index is multiple of 13, change suit
                deck[i].Suit = suitsTotal[suitCount];
                if (i == 12 || i == 25 || i == 38) // end of one set of suits
                {
                    suitCount++;
                    j = 1;
                }
            }
        }

        public bool cardHasBeenDrawn(int index)
        {
            return deck[index].HasBeenUsed;
        }

        public void resetDeck()
        {
            foreach (Card item in deck)
            {
                item.HasBeenUsed = false;
            }
        }

        public bool deckHasBeenReset()
        {
            foreach (Card item in deck)
            {
                if (item.HasBeenUsed)
                    return false;
            }
            return true;
        }
    }
}
