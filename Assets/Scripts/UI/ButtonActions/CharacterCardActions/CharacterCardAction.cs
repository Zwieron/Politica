using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class CharacterCardAction : ButtonAction
{
    protected Card card;
    public  CharacterActionsManager characterActionsManager;
    // Start is called before the first frame update
    public abstract void execute();
    public bool getActivatedAction()
    {
        if(characterActionsManager.getCardActionToExecute()==this)
        return true;
        else
        return false;
    }
    public void checkAndExecute()
    {
        if(characterActionsManager.getCardActionToExecute()==this)
        {
            execute();
        }
    }
    public override void setCard(Card card)
    {
        this.card=card;
        characterActionsManager = (CharacterActionsManager)card.GetCardActionsManager();
    }
    public Card getCard()
    {
        return card;
    }
    public CharacterActionsManager getCharacter()
    {
        return characterActionsManager;
    }
}
