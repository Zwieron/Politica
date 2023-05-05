using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstitutionActionManager : MonoBehaviour , CardActionsManager
{
    public InstitutionCardAction activeCardAction;
    InstitutionCardAction cardActionToExecute;
    public void setActiveCardAction(ButtonAction cardAction)
    {
        if(cardAction is InstitutionCardAction)
        {
            this.activeCardAction = (InstitutionCardAction)cardAction;
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
        if(cardAction is InstitutionCardAction)
        {
            this.cardActionToExecute = (InstitutionCardAction)cardAction;
        }
    }
    public void reset()
    {
        activeCardAction = null;
        cardActionToExecute = null;
    }
}
