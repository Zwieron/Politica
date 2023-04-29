using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPositioner : MonoBehaviour
{
    public GameObject buttonUP;
    public GameObject buttonLU;
    public GameObject buttonRU;
    public GameObject buttonLD;
    public GameObject buttonRD;
    public GameObject buttonDOWN;
    Vector2 buttonUPPosition;
    Vector2 buttonLUPosition;
    Vector2 buttonRUPosition;
    Vector2 buttonLDPosition;
    Vector2 buttonRDPosition;
    Vector2 buttonDOWNPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void checkButtonsPosition()
    {
        buttonUPPosition = buttonUP.transform.position;
        buttonLUPosition = buttonLU.transform.position;
        buttonRUPosition = buttonRU.transform.position;
        buttonLDPosition = buttonLD.transform.position;
        buttonRDPosition = buttonRD.transform.position;
        buttonDOWNPosition = buttonDOWN.transform.position;
    }
    public Vector2 getButtonPosition(Directions direction)
    {
        checkButtonsPosition();
        switch(direction)
        {
            case Directions.UP:
            return buttonUPPosition;
            case Directions.RIGHTUP:
            return buttonRUPosition;
            case Directions.LEFTUP:
            return buttonLUPosition;
            case Directions.DOWN:
            return buttonDOWNPosition;
            case Directions.RIGHTDOWN:
            return buttonRDPosition;
            case Directions.LEFTDOWN:
            return buttonLDPosition;
            default:
            return buttonUPPosition;
        }
    }
}
