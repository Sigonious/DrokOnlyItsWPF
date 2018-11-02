using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace BlackjackInARealLanguage
{
    class Card
    {
        int cardValue;
        int aCardValue;
        string suit;
	    BitmapImage image;
	    bool hasBeenUsed;

        public Card()
        {
            HasBeenUsed = false;
        }

        public int CardValue { get => cardValue; set => cardValue = value; }
        public int ACardValue { get => aCardValue; set => aCardValue = value; }
        public string Suit { get => suit; set => suit = value; }
        public BitmapImage Image { get => image; set => image = value; }
        public bool HasBeenUsed { get => hasBeenUsed; set => hasBeenUsed = value; }
    }
}
