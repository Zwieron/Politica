using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionsManager : MonoBehaviour
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
    public void setActiveCardAction(CharacterCardAction cardAction)
    {
        this.activeCardAction = cardAction;
    }
    public CharacterCardAction getActiveCardAction()
    {
        return activeCardAction;
    }
    public bool isSelectable()
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
    
    public CharacterCardAction getCardActionToExecute()
    {
        return cardActionToExecute;
    }
    public void setCardActionToExecute(CharacterCardAction cardAction)
    {
        this.cardActionToExecute = cardAction;
    }
    public void reset()
    {
        activeCardAction = null;
        cardActionToExecute = null;
    }
}
