using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertakeInstitutionButton : SelectingCharacterButton
{
    public Institution institutionToOvertake;
    
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
        if(character.GetCharacterActionsManager().getActiveCardAction()==null)
        {
        player.selectAction(this);
        gameObject.AddComponent<CardSelector>().setSelectingButtonAction(this);
        cardSelector = GetComponent<CardSelector>();
        character.GetCharacterActionsManager().setActiveCardAction(this);
        }
        else return;
    }
    public override void tooltip()
    {
        Debug.Log("Overtake institution");
    }
    public override void update()
    {
        if(character.GetCharacterActionsManager().getActiveCardAction()==this)
        {
            if(cardSelector.getSelectedCard().GetComponent<Institution>()!=null)
            {
            institutionToOvertake = cardSelector.getSelectedCard().GetComponent<Institution>();
            character.GetCharacterActionsManager().setCardActionToExecute(this);
            }
            else Debug.Log("No institution selected");
        }
        else return;
    }
    public override void reset()
    {
        if(character.GetCharacterActionsManager().getActiveCardAction()==this)
        {
        Destroy(this.gameObject);
        character.GetCharacterActionsManager().setActiveCardAction(null);
        }
        else return;
    }
    public override void execute()
    {
        character.setInstitution(institutionToOvertake);
    }
    public void setInstitution(Institution institution)
    {
        institutionToOvertake = institution;
    }
}
