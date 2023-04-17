using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUsing : MonoBehaviour
{
    CardInteraction cardInteraction;
    CardAttributes cardAttributes;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CardInteraction>();
        GetComponent<CardAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateButtonToUseUNextToTheSprite()
    {
        //Generate a button to use the card
        GameObject buttonToUse = new GameObject();
        buttonToUse.AddComponent<SpriteRenderer>();
        buttonToUse.AddComponent<BoxCollider2D>();
        buttonToUse.transform.position = new Vector3(Screen.width/2, 100, 0);

    }
    void PreUseCard()
    {
        if(cardInteraction.active)
        {
            GenerateButtonToUseUNextToTheSprite();
        }
    }
}
