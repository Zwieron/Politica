using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    Card activatedCard;
    Card selectedCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectCard(Card card)
    {
        selectedCard = card;
    }
    public void setActivatedCard(Card card)
    {
        activatedCard=card;
    }
}
