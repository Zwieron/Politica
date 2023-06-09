using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionsManager : MonoBehaviour , CardActionsManager
{
    public CharacterCardAction activeCardAction;
    CharacterCardAction cardActionToExecute;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setActiveCardAction(ButtonAction cardAction)
    {
        if(cardAction is CharacterCardAction)
        {
            this.activeCardAction = (CharacterCardAction)cardAction;
        }
    }
    public ButtonAction getActiveCardAction()
    {
        return activeCardAction;
    }
    public bool isActiveCardActionSelectable()
    {
        if(activeCardAction == null)
            return false;
        else if(activeCardAction is SelectingCharacterButton)
        {
            return true;
        }
        else
            return false;
    }
    
    public ButtonAction getCardActionToExecute()
    {
        return cardActionToExecute;
    }
    public void setCardActionToExecute(ButtonAction cardAction)
    {
        if(cardAction is CharacterCardAction)
        {
            this.cardActionToExecute = (CharacterCardAction)cardAction;
        }
    }
    public void reset()
    {
        activeCardAction = null;
        cardActionToExecute = null;
    }
}
