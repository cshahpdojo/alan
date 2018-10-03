using System;
using System.Collections.Generic;

namespace doc
{
    public class Deck
    {
        public List<Card> cards {get;set;}
        public Deck()
        {
            reset();
        }
        public List<Card> buildDeck()
        {
            List<Card> results = new List<Card>();
            Dictionary<int,string> chris = new Dictionary<int, string>{
                {1,"Ace"},
                {2,"Two"},
                {3,"Three"},
                {4,"Four"},
                {5,"FIve"},
                {6,"Six"},
                {7,"Seven"},
                {8,"eight"},
                {9,"nine"},
                {10,"ten"},
                {11,"eleebefnef"},
                {12,"twelve"},
                {13,"Acthirteen"}};
            string[] suits = {"Clubs","Hearts","Diamonds","Spades"};
            foreach(string suit in suits)
            {
                for(int i = 1; i<=chris.Count; i++)
                {
                    results.Add(new Card(chris[i], suit, i));
                }
            }
            return results;
        } 
    
        public Card deal()
        {
            int idx = 0;
            Card result = cards[idx];
            cards.RemoveAt(idx);
            return result;
        }

        public void reset()
        {
            cards = buildDeck();
        }
    
        public void shuffle()
        {
            int idx = cards.Count;
            Random jen = new Random();
            while(idx > 0)
            {
                int rdx = jen.Next(idx);
                Card temp = cards[rdx];
                cards[rdx] = cards[idx-1];
                cards[idx-1] = temp;
                idx--;
            }
        }
    }   

}