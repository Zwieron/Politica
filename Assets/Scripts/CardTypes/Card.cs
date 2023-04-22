using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardInteraction cardInteraction;
    GameObject cardObject;
    Hand hand;
    CardState cardState;

    // Start is called before the first frame update
    void Awake()
    {
        if(gameObject==null)
        cardObject = new GameObject();
        else
        cardObject = gameObject;
        cardObject.tag = "Card";
        if(cardInteraction==null)
        cardInteraction = cardObject.GetComponent<CardInteraction>();
        if(cardInteraction==null)
        cardInteraction = cardObject.AddComponent<CardInteraction>();
        Debug.Log(cardObject.GetInstanceID());
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public CardInteraction getCardInteraction()
    {
        return cardInteraction;
    }
    public void SetHand(Hand hand)
    {
        this.hand = hand;
    }
    public Hand GetHand()
    {
        return hand;
    }

    public GameObject  GetGameObject()
    {
        return cardObject;
    
    }
    public void SetCardState(CardState cardState)
    {
        this.cardState = cardState;
    
    }

}

public class InstitutionCard : Card
{
    Institution institution;
}

public class CharacterCard : Card
{
    Character character;
}

public class SpecialCard : Card
{

}
