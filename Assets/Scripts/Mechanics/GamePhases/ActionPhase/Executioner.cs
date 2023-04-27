using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : MonoBehaviour
{ List<CharacterCardAction> actionsToExecute = new List<CharacterCardAction>();
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
    public void executeActions()
    {
        foreach(CharacterCardAction action in actionsToExecute)
        {
            action.checkAndExecute();
        }
    }
    
}
