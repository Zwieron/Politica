using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstitutionActionButton : CharacterCardAction
{
    Institution institution;
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
        player.selectAction(this);
    }
    public override void tooltip()
    {}
    public override void update()
    {}
    public override void reset()
    {}
    public override void execute()
    {}
}
