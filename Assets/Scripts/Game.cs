using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject player;
    public int activeButtons = 0;
    public Sprite cardSprite;
    Hand hand;
    HandVisual handVisual;
    
    // Start is called before the first frame update
    void Start()
    {
        hand = player.GetComponent<Hand>();
        handVisual = player.GetComponent<HandVisual>();
        handVisual.SetHand(hand);
        for(int i = 0; i<5;i++)
        {
            GameObject card = new GameObject("Card");
            card.AddComponent<Card>();
            hand.AddCard(card.GetComponent<Card>());
            hand.GetCards()[i].SetSprite(cardSprite);
            hand.GetCards()[i].GetSprite().sortingOrder = i;
            Debug.Log(hand.GetCards().Count);
        }
        handVisual.RenderHand();
        foreach(Card card in hand.GetCards()) 
        {
            card.GetGameObject().transform.localScale = new Vector3(20,20,20);
            card.GetCardInteraction().onClick();
            card.GetCardInteraction().setDragging(false);
            card.GetCardInteraction().onUnclick();
            Debug.Log("gruba akcja ");
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
