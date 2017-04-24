using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Black_Jack
{
    class Program
    {
        struct Cards
        {
            public Value Value;
            public Suit Suit;
        }
        enum Value
        {
            Jacke = 2,
            Lady = 3,
            King = 4,
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9,
            ten = 10,
            Ace = 11
        }
        enum Suit
        {
            Clubs,
            Spades,
            Diamonds,
            Hearts
        }
        
        static void MakeCards(Cards[] card)
        {
            int temp = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j <= 11; j++)
                {
                    if (j == 5) continue;
                    else
                    {
                        card[temp] = new Cards { Suit = (Suit)i, Value = (Value)j };
                        temp++;
                    }
                }
            };
        }

        static void ShuffleCards(Cards[] card)
        {
            Random rand = new Random();
            for (int i = 0; i < card.Length; i++)
            {
                int randomIndex = rand.Next(0, card.Length - 1);
                Cards temp = card[i];
                card[i] = card[randomIndex];
                card[randomIndex] = temp;
            }
        }

        static int PullCardDealer(List<Cards> dealer, Cards[] card)
        {
            int totalHandDealer = 0;
            int index = 0;
            for (int i = 0; i < dealer.Count; i++)
            {
                totalHandDealer += (int)dealer[i].Value;
                if (totalHandDealer >= 16) break;
                else
                {
                    dealer.Add(card[index]);
                    index++;
                    ShowHandDealer(dealer);
                }
            }
            return totalHandDealer;
        }

        static int PullCardPlayer(List<Cards> player, Cards[] card)
        {
            int totalHandPlayer = 0;
            int index = 0;
            for (int i = 0; i < player.Count; i++)
            {
                totalHandPlayer += (int)player[i].Value;
                Console.WriteLine("Do you want more cards? (y => yes , n => no)");
                char choice = char.Parse(Console.ReadLine());
                if (choice == 'n') break;
                else
                {
                    player.Add(card[index]);
                    index++;
                    ShowHandPlayer(player);
                }
            }
            return totalHandPlayer;
        }

        static void ShowHandDealer(List<Cards> dealer)
        {
            foreach (var item in dealer)
            {
                Console.WriteLine("Dealer Cards: {0,6}{1,7}", item.Value, item.Suit);
            };
        }

        static void ShowHandPlayer(List<Cards> player)
        {
            foreach (var item in player)
            {
                Console.WriteLine("Players Cards: {0,6}{1,7}", item.Value, item.Suit);
            };
        }

        static void DealersMove()
        {
            Cards[] card = new Cards[36];
            MakeCards(card);
            ShuffleCards(card);
            List<Cards> Dealer;
            List<Cards> Player;
            int totalScoreDealer = 0;
            int totalScorePlayer = 0;
            Dealer = new List<Cards> { card[0], card[1] };
            Player = new List<Cards> { card[0], card[1] };
            totalScoreDealer = Dealer.Count;
            totalScorePlayer = Player.Count;

            if (Dealer.Count <= 21)
            {
                PullCardDealer(Dealer, card);
            }
            if (Dealer.Count == 22)
            {
                ShowHandDealer(Dealer);
                Console.WriteLine("Dealer has Black Jack!");
            }
            else if (Player.Count == 22)
            {
                ShowHandPlayer(Player);
                Console.WriteLine("Player has Black Jack");
            }
            if (Player.Count < 21) PullCardPlayer(Player, card);
            if (totalScoreDealer > totalScorePlayer && totalScoreDealer <= 21 && totalScorePlayer > 21) Console.WriteLine("Dealer win!");
            if (totalScorePlayer > totalScoreDealer && totalScorePlayer <= 21 && totalScoreDealer > 21) Console.WriteLine("Player win!");
        }

        static void PlayersMove()
        {
            Cards[] card = new Cards[36];
            MakeCards(card);
            ShuffleCards(card);
            List<Cards> Dealer;
            List<Cards> Player;
            int totalScoreDealer = 0;
            int totalScorePlayer = 0;
            Dealer = new List<Cards> { card[0], card[1] };
            Player = new List<Cards> { card[0], card[1] };
            totalScoreDealer = Dealer.Count;
            totalScorePlayer = Player.Count;

            if (Dealer.Count <= 21)
            {
                PullCardDealer(Dealer, card);
            }
            if (Dealer.Count == 22)
            {
                ShowHandDealer(Dealer);
                Console.WriteLine("Dealer has Black Jack!");
            }
            else if (Player.Count == 22)
            {
                ShowHandPlayer(Player);
                Console.WriteLine("Player has Black Jack");
            }
            if (Player.Count < 21) PullCardPlayer(Player, card);
            if (totalScoreDealer > totalScorePlayer && totalScoreDealer <= 21 && totalScorePlayer > 21) Console.WriteLine("Dealer win!");
            if (totalScorePlayer > totalScoreDealer && totalScorePlayer <= 21 && totalScoreDealer > 21) Console.WriteLine("Player win!");
         }

        static void StartGame()
        {
            int chooseTurn = 0;
            Console.WriteLine("Choose number pls!/n 0 - turn Dealer , 1 - turn Player");
            chooseTurn = int.Parse(Console.ReadLine());
           
             switch (chooseTurn)
            {
                case 0:
                    DealersMove();
                     break;
                case 1:
                    PlayersMove();
                    break;
                default:
                    Console.WriteLine("End Game!");
                    break;
            }
            Console.ReadLine();
        }
        
        static void Main(string[] args)
        {
            Console.Write("It's Black Jack Game!");
            StartGame();
        }
    } 
}

