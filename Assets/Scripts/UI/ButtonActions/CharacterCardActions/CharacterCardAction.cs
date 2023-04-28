using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class CharacterCardAction : ButtonAction
{
    protected Card card;
    protected bool activatedAction;
    // Start is called before the first frame update
    public abstract void execute();
    public bool getActivatedAction()
    {
        return activatedAction;
    }
    public void checkAndExecute()
    {
        if(activatedAction)
        {
            execute();
        }
    }
    public void setCard(Card card)
    {
        this.card=card;
    }
}
