using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthenNotorietyButton : CharacterCardAction
{   int oldNotoriety;
    int newNotoriety;
    Party party;
    int oldFunds;
    int newFunds;
    int price;
    public int priceModifier;
    // Start is called before the first frame update
    void Start()
    {
        party = player.getParty();
        oldNotoriety = character.getNotoriety();
        price=character.getNotoriety()*priceModifier;
        newFunds = party.getFunds();
        oldFunds = newFunds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action(int value)
    {
        if(character.GetCharacterActionsManager().getActiveCardAction()!=null)
        {
        newNotoriety = oldNotoriety++;
        newFunds = party.getFunds() - price;
        character.GetCharacterActionsManager().setActiveCardAction(this);
        Debug.Log("notoriety of " + character.getCharacterName() + " changed");
        }
        else return; 
    }
    public override void tooltip()
    {
        Debug.Log("Strengthen Notoriety");
    }
    public override void update()
    {
        if(character.GetCharacterActionsManager().getActiveCardAction()==this)
        {
        character.GetCharacterActionsManager().setCardActionToExecute(this);
        oldNotoriety = newNotoriety;
        oldFunds = newFunds;
        }
    }
    public override void reset()
    {
        if(character.GetCharacterActionsManager().getActiveCardAction()==this)
        {
        newFunds=party.getFunds();
        newNotoriety=oldNotoriety;
        character.GetCharacterActionsManager().setActiveCardAction(null);
        }
        else
        return;
    }
    public override void execute()
    {
        character.setNotoriety(newNotoriety);
        party.setFunds(newFunds);
    }
}
