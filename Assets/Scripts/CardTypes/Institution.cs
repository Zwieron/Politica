using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Institution : Card
{
    public string institutionName;
    public string institutionDescription;
    public int insitutionLevel;
    public int institutionPrice;
    Institution blockedInstitution;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void checkAvailibleActions()
    {  
        availibleActions.Clear();
        availibleActions.Add(ButtonTypes.InstitutionAct1);
        availibleActions.Add(ButtonTypes.InstitutionAct2);
        availibleActions.Add(ButtonTypes.BlockAction);
    }
    abstract public void BlockadeAction();
    abstract public void AttackAction(SelectingCharacterButton buttonAction);
    abstract public void BuffAction();
}