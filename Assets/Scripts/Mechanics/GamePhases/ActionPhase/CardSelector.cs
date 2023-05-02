using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    ButtonAction selectingButtonAction;
    Card selectedCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectCard(Card card)
    {
        this.selectedCard = card;
    }
    public Card getSelectedCard()
    {
        return selectedCard;
    }
    public void setSelectingButtonAction(ButtonAction buttonAction)
    {
        this.selectingButtonAction=buttonAction;
    }
    public ButtonAction getSelectingButtonAction()
    {
        return selectingButtonAction;
    }
    public void reset()
    {
        selectedCard=null;
    }
}
