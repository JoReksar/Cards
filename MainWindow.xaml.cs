using System;
using System.Windows;
using System.Windows.Controls;

namespace Modelling_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Deck.IsInfinite = true;

            //Deck.ShuffleDeck();
            //int countCardsInRow = 8;
            //double sizeImage = 100.0;
            //double marginLeft = 5.0;
            //double marginTop = 5.0;

            //for (int i = 0; i < Deck.CountCards; i++)
            //{
            //    mainCanvas.Children.Add(new Image()
            //    {
            //        Source = Deck.DrawCard().Image.Source,
            //        Width = sizeImage,
            //        Height = sizeImage,
            //        Margin = new Thickness(marginLeft, marginTop, 0, 0)
            //    });
            //    if (((i + 1) % countCardsInRow) == 0)
            //    {
            //        marginTop += sizeImage;
            //        marginLeft -= countCardsInRow * sizeImage;
            //    }

            //    marginLeft += sizeImage;
            //}
        }

        private void ShowCards(object sender, RoutedEventArgs e)
        {
            RemoveCards();
            Deck.ShuffleDeck();

            int countCardsInRow;
            int sizeCards;
            try
            {
                countCardsInRow = int.Parse(this.countCardsInRow.Text);
                sizeCards = int.Parse(this.sizeCards.Text);
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            double marginLeft = 5.0;
            double marginTop = 100.0;

            for (int i = 0; i < Deck.CountCards; i++)
            {

                mainCanvas.Children.Add(new Image()
                {
                    Source = Deck.DrawCard().Image.Source,
                    Width = sizeCards,
                    Height = sizeCards,
                    Margin = new Thickness(marginLeft, marginTop, 0, 0)
                });

                if (((i + 1) % countCardsInRow) == 0)
                {
                    marginTop += sizeCards;
                    marginLeft -= countCardsInRow * sizeCards;
                }

                marginLeft += sizeCards;
            }
        }

        private void RemoveCards()
        {
            mainCanvas.Children.RemoveRange(6, 36);
        }
    }
}
