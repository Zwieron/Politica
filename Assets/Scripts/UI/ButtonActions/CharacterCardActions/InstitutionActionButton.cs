using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstitutionActionButton : CharacterCardAction
{
    Institution institution;    // Start is called before the first frame update
    void Start()
    {
            institution = card.GetComponent<Character>().getInstitution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void action(int value)
    {
        player.selectAction(this);
    }
    public override void tooltip()
    {
        Debug.Log("institution action");
    }
    public override void update()
    {}
    public override void reset()
    {}
    public override void execute()
    {}
}
