using System;
using System.Collections.Generic;


namespace doc
{
    class Player
    {
//         Give the Player class a name property.
// Give the Player a hand property that is a List of type Card.
// Give the Player a draw method of which draws a card from a deck, adds it to the player's hand and returns the Card.
// Note this method will require reference to a deck object
// Give the Player a discard method which discards the Card at the specified index from the player's hand and returns this Card or null if the index does not exist.

        public string name {get; set;}
        public List<Card> hand {get; set;}

        public Player()
        {
            hand = new List<Card>();
        }

        public Card draw(Deck deck)
        {
            Card newCard = deck.deal();
            hand.Add(newCard);
            return newCard;
        }

        public Card Discard(int idx)
        {
            if(idx>=0 && idx<hand.Count)
            {
                Card disCard = hand[idx];
                hand.RemoveAt(idx);
                return disCard;
            }
            else
            {
                return null;
            }
        }
    }
}