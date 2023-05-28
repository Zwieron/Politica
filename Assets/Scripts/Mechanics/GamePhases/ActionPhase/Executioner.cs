using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : MonoBehaviour
{ 
    Croupier croupier;
    List<ButtonAction> actionsToExecute = new List<ButtonAction>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addAction(CharacterCardAction action)
    {
        actionsToExecute.Add(action);
    }
    public void addAction(ButtonAction action)
    {
        if(action is CharacterCardAction || action is InstitutionCardAction)
        {
            actionsToExecute.Add(action);
        }
    }
    public void executeActions()
    {
        foreach(CharacterCardAction action in actionsToExecute)
        {
            if(action!=null)
            action.checkAndExecute();
        }
    }
    
}
