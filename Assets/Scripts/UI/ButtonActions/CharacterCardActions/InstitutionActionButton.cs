using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstitutionActionButton : CharacterCardAction, SelectingCharacterButton
{
    new Institution card;
    CardSelector cardSelector;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action(int value)
    {
        if(characterActionsManager.getActiveCardAction()==null)
        {
        turnOfActivity = player.getCurrentPlayerTurn();
        player.selectAction(this);
        gameObject.AddComponent<CardSelector>().setSelectingButtonAction(this);
        cardSelector = GetComponent<CardSelector>();
        characterActionsManager.setActiveCardAction(this);
        }
        else return;
    }
    public override void tooltip()
    {
        Debug.Log("institution action");
    }
    public override void update()
    {
        if(characterActionsManager.getActiveCardAction()==this)
        {
            card.AttackAction(this);
        }
        else return;
    }
    public override void reset()
    {}
    public override void execute()
    {}
    public CardSelector getSelector()
    {
        return this.cardSelector;
    }
}
