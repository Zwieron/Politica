using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    CardInteraction cardInteraction;
    GameObject cardObject;
    Hand hand;
    CardState cardState;
    CardTypes cardType;


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
        switchToCheckCardType();
        Debug.Log(cardObject.GetInstanceID());
        
    }
    

    // Update is called once per frame
    void Update()
    {
        highlightActivated();
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
    public CardState GetCardState()
    {
        return cardState;
    }
    void switchToCheckCardType()
    {
        if(GetComponent<Character>()!=null)
        {
            cardType = CardTypes.CharacterCard;
        }
        else if(GetComponent<Institution>()!=null)
        {
            cardType = CardTypes.InstitutionCard;
        }
        // else if (GetComponent<ActionCard>()!=null)
        // {
        //     cardType = CardTypes.ActionCard;
        // }
    }
    void highlightActivated()
    {
        if(cardState==CardState.Activated)
        cardInteraction.getHighlighter().highlightYellow();
        else
        cardInteraction.getHighlighter().highlightWhite();
    }
    public bool isCharacterCard()
    {
        if(cardType==CardTypes.CharacterCard)
        return true;
        else
        return false;
    }

}
