using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croupier : MonoBehaviour
{
    List<Card> cards = new List<Card>();
    Player reciever;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void addCard(Card card)
    {   
        card.GetHand().removeCard(card);
        cards.Add(card);
    }
    void giveCards()
    {
        foreach(Card card in cards)
        {
        if(reciever==null)
        Debug.Log("Brak recievera");
        if(reciever.getHand()==null)
        Debug.Log("Brak reki recievera");
        reciever.getHand().addCard(card);
        }
    }
    void setReciever(Player reciever)
    {
        this.reciever = reciever;
    }
    public void changeCardsOwner(Player reciever, Card card)
    {
        setReciever(reciever);
        addCard(card);
        giveCards();
        cards.Clear();
    }
}

