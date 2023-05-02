using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class CharacterCardAction : ButtonAction
{
    protected Card card;
    public  Character character;
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
    public override void setCard(Card card)
    {
        this.card=card;
        character = card.GetComponent<Character>();
    }
    public Card getCard()
    {
        return card;
    }
    public Character getCharacter()
    {
        return character;
    }
}
