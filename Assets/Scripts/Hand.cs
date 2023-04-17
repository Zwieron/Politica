using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
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
}
