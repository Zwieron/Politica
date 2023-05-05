using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertakeInstitutionButton : CharacterCardAction, SelectingCharacterButton
{
    public Institution institutionToOvertake;
    CardSelector cardSelector;
    
    // Start is called before the first frame update
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
        Debug.Log("Overtake institution");
    }
    public override void update()
    {
        if(characterActionsManager.getActiveCardAction()==this)
        {
            if(cardSelector.getSelectedCard()==null)
            {
                Debug.Log("No card selected");
                return;
            }
            else if(cardSelector.getSelectedCard().GetComponent<Institution>()!=null)
            {
                institutionToOvertake = cardSelector.getSelectedCard().GetComponent<Institution>();
                characterActionsManager.setCardActionToExecute(this);
            }
            else Debug.Log("No institution selected");
        }
        else return;
    }
    public override void reset()
    {
        if(characterActionsManager.getActiveCardAction()==this)
        {
        characterActionsManager.setActiveCardAction(null);
        if(this.gameObject!=null)
        Destroy(this.gameObject);
        else return;
        }
        else return;
    }
    public override void execute()
    {
        card.GetComponent<Character>().setInstitution(institutionToOvertake);
    }
    public void setInstitution(Institution institution)
    {
        institutionToOvertake = institution;
    }
    public CardSelector getSelector()
    {
        return cardSelector;
    }
}
