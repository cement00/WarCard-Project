using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wojna 
{
    class Player : Human
    {
        enum figures
        {
            two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7,
            eight = 8, nine = 9, ten = 10, jack = 11, queen = 12, king = 13, ace = 14
        }
        private List<string> ownCards = new List<string>();
        private string firstcard;
        private int powerOfCard;
        public Player(Deck deck)
        {
            for (int i = 0; i < 26; i++)
            {
                ownCards.Add(deck.drawCard());
            }
        }

        override
        public void write_cards()
        {
            for (int i = 0; i < ownCards.Count(); i++)
            {
                Console.Write(ownCards[i] + " ");
            }
        }
       override
        public int getPower()
        {
            return powerOfCard;
        }
        override
        public string getCard()
        {
            if (ownCards.Count() != 0)
            {
                firstcard = ownCards[0];
                powerOfCard = (int)Enum.Parse(typeof(figures), firstcard);
                ownCards.RemoveAt(0);
            }
            else
            {
                firstcard = "nothingmore";
                powerOfCard = 0;
            }
            return firstcard;
        }
        override
        public void addCard(string card)
        {
            ownCards.Add(card);
        }
    }
}
