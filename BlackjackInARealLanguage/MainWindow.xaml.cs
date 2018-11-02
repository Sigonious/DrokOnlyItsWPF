using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackjackInARealLanguage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Blackjackgame bjg;
        int interations = 0;

        public MainWindow()
        {
            InitializeComponent();
            bjg = new Blackjackgame(TheWindow.Resources);
        }

        private void StartGameButtonPress(object sender, RoutedEventArgs e)
        {
            // totalInBets label set to 0. show blank images and back of a card
            bjg.start_game();
            PlayerCardValueLabel.Text = "0";

            DealerCard2.Fill = new ImageBrush(TheWindow.Resources["cardback"] as BitmapImage);
            PlayerCard3.Fill = new ImageBrush(TheWindow.Resources["cardblank"] as BitmapImage);
            PlayerCard4.Fill = new ImageBrush(TheWindow.Resources["cardblank"] as BitmapImage);
            DealerCard3.Fill = new ImageBrush(TheWindow.Resources["cardblank"] as BitmapImage);
            DealerCard4.Fill = new ImageBrush(TheWindow.Resources["cardblank"] as BitmapImage);

            // update pictures for player (picturebox 1 and 3)
            Player x = bjg.ThePlayer;
            PlayerCard1.Fill = new ImageBrush(bjg.hit(x));
            PlayerCard2.Fill = new ImageBrush(bjg.hit(x));

            // show player total
            PlayerCardValueLabel.Text = Convert.ToString(bjg.ThePlayer.TotalCardValue);

            // get card for the dealer
            x = bjg.TheDealer;
            // picture box 2 update to show dealer's card
            DealerCard1.Fill = new ImageBrush(bjg.hit(x));
            DealerCardValueLabel.Text = Convert.ToString(bjg.TheDealer.TotalCardValue);

            // TODO: When getting blackjack on first draw, payout to the player

            // check for gamestate
            if (bjg.ThePlayer.TotalCardValue == 21)
            {
                MiddleLabel.Text = "BLACKJACK";
            }
            else
            {
                MiddleLabel.Text = "Hit or Stay?";
            }
        }

        private void HitButtonPress(object sender, RoutedEventArgs e)
        {
            // Give player one card into first slot
            // i will be 0 if the player just started a game
            Player x = bjg.ThePlayer;
            if (interations == 0 && x.TotalCardValue < 21)
            {
                // update pictures for player pictureBox
                PlayerCard3.Fill = new ImageBrush(bjg.hit(x));
                // show player total
                PlayerCardValueLabel.Text = x.TotalCardValue.ToString();
                interations++; // this will move to the next picturebox next time the player hits
            }
            else if (interations == 1 && x.TotalCardValue < 21)
            {
                // update pictures for player pictureBox 
                PlayerCard4.Fill = new ImageBrush(bjg.hit(x));
                // show player total
                PlayerCardValueLabel.Text = x.TotalCardValue.ToString();
                interations = 0; // go back to the first piturebox for next round
            }
            // check if there were any aces and if the player has busted. if the player busts, use the value of 1 for Aces
            // TODO: Write a function to do this while loop below
            while (x.NumOfAces > 0 && x.TotalCardValue > 21)
            {
                x.NumOfAces -= 1;
                x.TotalCardValue -= 10;
            }
        }

        private void StayButtonPress(object sender, RoutedEventArgs e)
        {

        }

        private void SetBetButtonPress(object sender, RoutedEventArgs e)
        {
            int temp = 0;
            try
            {
                temp = Convert.ToInt32(BetAmount.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid Number Format");
                BetAmount.Text = "INVALID";
            }
            bjg.TotalBetAmount = temp; // use that number to subtract from the player's amount and add to the pot

            TotalBetsLabel.Text = bjg.TotalBetAmount.ToString(); // display the total
            PlayerMoneyLabel.Text = bjg.ThePlayer.Money.ToString();
        }
    }
}
