using System.Windows.Controls;

namespace Modelling_Project
{
    class Card
    {
        public Suit SuitCard { get; }
        public Rank RankCard { get; }
        public Image Image { get; }

        public Card(Suit suit, Rank rank, Image image)
        {
            SuitCard = suit;
            RankCard = rank;
            Image = image;
        }

        public override string ToString()
        {
            return $"{SuitCard} - {RankCard}";
        }
    }
}
