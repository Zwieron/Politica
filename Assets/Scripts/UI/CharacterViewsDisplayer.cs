using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterViewsDisplayer : MonoBehaviour
{
    public Character character;
    public TMP_Text economicText;
    public TMP_Text worldviewText;
    public TMP_Text notorietyText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Display();
    }

    public void Display()
    {
        economicText.text = character.getEconomicView().ToString();
        worldviewText.text = character.getWorldview().ToString();
        notorietyText.text = character.getNotoriety().ToString();
    }
}
