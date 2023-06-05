using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ministry : Institution
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public void BlockadeAction()
    {

    }
    override public void AttackAction(SelectingCharacterButton buttonAction)
    {
        CardSelector selector = buttonAction.getSelector();
        selector.getSelectedCard();
    }
    override public void BuffAction()
    {
        
    }
}
