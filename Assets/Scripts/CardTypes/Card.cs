using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    protected CardInteraction cardInteraction;
    protected GameObject cardObject;
    public Hand hand;
    protected CardState cardState;
    protected CardActionsManager cardActionsManager;


    // Start is called before the first frame update
    protected virtual void Awake()
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
    void highlightActivated()
    {
        if(cardState==CardState.Activated)
        cardInteraction.getHighlighter().highlightYellow();
        else
        cardInteraction.getHighlighter().highlightWhite();
    }
    public CardActionsManager GetCardActionsManager()
    {
        return cardActionsManager;
    }
    public bool isCardActionSelecting(ButtonAction registeredSelectAction)
    {
        if(GetCardActionsManager().getActiveCardAction()!=null && 
        GetCardActionsManager().isActiveCardActionSelectable()&&
        GetCardActionsManager().getActiveCardAction()!=registeredSelectAction&&
        GetCardActionsManager().getCardActionToExecute()==null)
        return true;
        else
        return false;
    }

}
