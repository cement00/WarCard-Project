using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wojna
{
   class Deck
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        private enum figures {two=2 , three=3 , four=4 , five=5 , six=6 , seven=7 ,
                     eight=8 , nine=9 , ten=10, jack=11 , queen=12 , king=13 , ace=14 }
        private enum colors {hearts, diamonds, spades, clubs }
        private static int numberofcards=52;
        private struct card
        {
            private string figure;
            private string color;
            public card(string i, string j)
            {
                figure = i;
                color = j;
            }
            public string Figure { get { return figure; } set { figure = value; } }
            public string Color { get { return color; } set { color = value; } }
        }
        private List<card> deck = new List<card>();

        public Deck()
        {
            GenerateDeck();
        }

        private void GenerateDeck()
        {
            foreach (string figure in Enum.GetNames(typeof(figures)))
            {
                foreach (string color in Enum.GetNames(typeof(colors)))
                {
                    deck.Add(new card(figure, color));
                }
            }
        }

        public string drawCard()
        {
            int randomcard = GetRandomNumber(0, numberofcards);
            string figurecard = deck[randomcard].Figure;
            deck.RemoveAt(randomcard);
            return figurecard;
        }
        private static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { 
                numberofcards = numberofcards - 1;
                return getrandom.Next(min, max);
            }
        }
    }
}
