using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wojna
{
    public class Program : CardGames
    {
        private List<string> cardsInGame = new List<string>();
        private int end;
        private string ageString;
        private int age;
        private string readline;

        private void getPlayers(Human player1, Human player2)
        {
            Console.WriteLine("Witajcie! Ta gra to wojna, na początku wpiszcie swoje dane, aby lepiej się poznać, miłej zabawy!");
            Console.WriteLine("Imie gracza nr1:");
            player1.Name = Console.ReadLine();
            Console.WriteLine("wiek gracza nr1:");
            try
            {
                ageString = Console.ReadLine();
                age = int.Parse(ageString);
            }
            catch (FormatException fEx)
            {
                Console.WriteLine(fEx.Message);
                Console.WriteLine("Podaj wiek w liczbach....");
                ageString = Console.ReadLine();
                age = int.Parse(ageString);
            }
            player1.Age = age;
            Console.WriteLine("Imie gracza nr2:");
            player2.Name = Console.ReadLine();
            Console.WriteLine("wiek gracza nr2:");
            try
            {
                ageString = Console.ReadLine();
                age = int.Parse(ageString);
            }
            catch (FormatException fEx)
            {
                Console.WriteLine(fEx.Message);
                Console.WriteLine("Podaj wiek w liczbach....");
                ageString = Console.ReadLine();
                age = int.Parse(ageString);
            }
            player2.Age = age;
            Console.Clear();
       }
        
        public void distributionCard()
        {
            Deck firstDeck = new Deck();
            Human player1 = new Player(firstDeck);
            Human player2 = new Player(firstDeck);
            getPlayers(player1, player2);
            game(player1, player2);
        }

        private void game(Human player1, Human player2)
        {
            end = 0;
            readline = "go";
            Console.WriteLine("Mała instrukcja:");
            Console.WriteLine("Po każdej turze napisz 'go' i wciśnij enter, aby rozegrać kolejną turę. ");
            Console.WriteLine("Jesli chcesz zobaczyć aktualny stan talii graczy po każdej turze możesz napisać 'check' i wcisnąć enter.");
            Console.WriteLine("Karty zostały rozlosowane, zaczynamy rozgrywkę!");
            while (end == 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("napisz 'go' lub 'check' ");
                readline =Console.ReadLine();
                Console.Clear();
                if (readline.Equals("go"))
                    nextRound(player1, player2);
                if (readline.Equals("check"))
                {
                    Console.WriteLine("Karty gracza nr1: ");
                    player1.write_cards();
                    Console.WriteLine(" ");
                    Console.WriteLine("Karty gracza nr2: ");
                    player2.write_cards();
                }
            }
            Console.WriteLine("Dziękujemy za udział w grze i gratulujemy zwycięzcy!");
        }

        private void nextRound(Human player1, Human player2)
        {
            string name1 = player1.Name;
            string name2 = player2.Name;
            string card1, card2;
            int power1, power2;
            card1 = player1.getCard();
            card2 = player2.getCard();
            addCardToList(card1, card2);
            power1 = player1.getPower();
            power2 = player2.getPower();
            Console.WriteLine(name1 + ": " + card1);
            Console.WriteLine(name2 + ": " + card2);
            if(power1>power2)
            {
                Console.WriteLine("gracz nr1 wygrał turę!");
                while (cardsInGame.Count() != 0)
                {
                    if(!cardsInGame[0].Equals("nothingmore"))
                        player1.addCard(cardsInGame[0]);
                    cardsInGame.RemoveAt(0);
                }
            }
            if(power1<power2)
            {
                Console.WriteLine("gracz nr2 wygrał turę!");
                while (cardsInGame.Count() != 0)
                {
                    if (!cardsInGame[0].Equals("nothingmore"))
                        player2.addCard(cardsInGame[0]);
                    cardsInGame.RemoveAt(0);
                }
            }
            if(power1==power2)
            {
                string hidden_card1 = player1.getCard();
                string hidden_card2 = player2.getCard();
                Console.WriteLine("Zasłonięte karty to: " +hidden_card1+ " oraz " + hidden_card2);
                addCardToList(hidden_card1, hidden_card2);
                nextRound(player1, player2);
            }
        }

       private void addCardToList(string card1, string card2)
        {
            if (card1.Equals("nothingmore"))
                someone_just_lost(1);
            else
                cardsInGame.Add(card1);
            if (card2.Equals("nothingmore"))
                someone_just_lost(2);
            else
                cardsInGame.Add(card2);
        }

        private void someone_just_lost(int who)
        {
            Console.WriteLine("PRZEGRAL gracz nr: " + who);
            end = 1;
        }
        static void Main(string[] args)
        {
            Program game = new Program();
            game.distributionCard();
            System.Console.ReadKey();
        }
    }
}

