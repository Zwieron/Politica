using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaPositiveAction : InstitutionCardAction
{
    //Wzmacnia rozpoznawalność wybranej postaci
    Media medium;
    Character characterToStrengthen;
    public int notorietyFactor;
    void Start()
    {
        medium = GetComponent<Media>();
    }
    public override void action(int value)
    {
        if(institutionActionManager.getActiveCardAction()==null)
        {
            turnOfActivity = player.getCurrentPlayerTurn();
            player.selectAction(this);
            gameObject.AddComponent<CardSelector>().setSelectingButtonAction(this);
            cardSelector = GetComponent<CardSelector>();
            institutionActionManager.setActiveCardAction(this);
        }
    }
    public override void tooltip()
    {
        Debug.Log("Wzmacnia rozpoznawalność wybranej postaci");
    }
    public override void update()
    {
        if(institutionActionManager.getActiveCardAction()==this)
        {
            if(cardSelector.getSelectedCard()==null)
            {
                Debug.Log("No card selected");
                return;
            }
            else if(cardSelector.getSelectedCard().GetComponent<Character>()!=null)
            {
                characterToStrengthen = cardSelector.getSelectedCard().GetComponent<Character>();
                institutionActionManager.setCardActionToExecute(this);
            }
            else Debug.Log("No character selected");
        }
        else return;
    }
    public override void reset()
    {
        if(institutionActionManager.getActiveCardAction()==this)
        {
        institutionActionManager.setActiveCardAction(null);
        if(this.gameObject!=null)
        Destroy(this.gameObject);
        else return;
        }
        else return;
    }
}
