using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Player owner;
    public List<Card> cards = new List<Card>();
    HandVisual handVisual;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    
    public Player GetOwner()
    {
        return owner;
    }
    public void SetHandVisual(HandVisual handVisual)
    {
        this.handVisual = handVisual;
    }
       
}
