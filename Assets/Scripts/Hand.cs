using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Player owner;
    bool blockade = false;
    Card selectedCard;
    public List<Card> cards = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            BlockHand(blockade);
    }
    public void AddCard(Card card)
    {
        cards.Add(card);
        card.SetHand(this);
    }
    public void RemoveCard(Card card)
    {
        cards.Remove(card);
        card.SetHand(null);
    }
    public List<Card> GetCards()
    {
        return cards;
    }
    public int GetSize()
    {
        return cards.Count;
    }
    public  void SetOwner(Player owner)
    {
        this.owner = owner;
    
    }
    public void BlockHand(bool block)
    {
        foreach (Card card in cards)
        {
            if(block==false)
            {
                card.GetCardInteraction().setBlockade(block);
            }
            else if(card != selectedCard)
            {
                card.GetCardInteraction().setBlockade(block);
            }
        }
    }
    public Player GetOwner()
    {
        return owner;
    }
    public void SetBlockade(bool blockade, Card selectedCard)
    {
        this.blockade = blockade;
        this.selectedCard = selectedCard;
    }
        public void SetBlockade(bool blockade)
    {
        this.blockade = blockade;
    }
}
