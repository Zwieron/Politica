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
        cards = new List<Card>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void addCard(Card card)
    {   
        cards.Add(card);
        card.SetHand(this);
    }
    public void removeCard(Card card)
    {
        cards.Remove(card);
        card.SetHand(null);
    }
    public List<Card> getCards()
    {
        return cards;
    }
    public int getSize()
    {
        return cards.Count;
    }
    public  void setOwner(Player owner)
    {
        this.owner = owner;
        Debug.Log("Hand owner: " + owner.name);
    }
    
    public Player getOwner()
    {
        return owner;
    }
    public void setHandVisual(HandVisual handVisual)
    {
        this.handVisual = handVisual;
    }
       
}
