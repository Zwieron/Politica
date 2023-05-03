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
        oldNotoriety = card.GetComponent<Character>().getNotoriety();
        price=characterActionsManager.GetComponent<Character>().getNotoriety()*priceModifier;
        newFunds = party.getFunds();
        oldFunds = newFunds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action(int value)
    {
        if(characterActionsManager.getActiveCardAction()==null)
        {
        player.selectAction(this);
        newNotoriety = oldNotoriety++;
        newFunds = party.getFunds() - price;
        characterActionsManager.setActiveCardAction(this);
        Debug.Log("notoriety of " + card.GetComponent<Character>().getCharacterName() + " changed");
        }
        else return; 
    }
    public override void tooltip()
    {
        Debug.Log("Strengthen Notoriety");
    }
    public override void update()
    {
        if(characterActionsManager.getActiveCardAction()==this)
        {
        characterActionsManager.setCardActionToExecute(this);
        oldNotoriety = newNotoriety;
        oldFunds = newFunds;
        }
    }
    public override void reset()
    {
        if(characterActionsManager.getActiveCardAction()==this)
        {
        newFunds=party.getFunds();
        newNotoriety=oldNotoriety;
        characterActionsManager.setActiveCardAction(null);
        Destroy(this.gameObject);
        }
        else
        return;
    }
    public override void execute()
    {
        card.GetComponent<Character>().setNotoriety(newNotoriety);
        party.setFunds(newFunds);
    }
}
