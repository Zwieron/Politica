using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class GamePhase : MonoBehaviour
{
    public Game game;
    public Deck deck;
    protected List<ButtonAction> buttons = new List<ButtonAction>();
    public Croupier croupier;
    // Start is called before the first frame update
    protected void Start()
    {
        game = GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //TODO: Wszystko niżej gdzieś przenieść do klas
    protected void createButtonAroundCard(Card card, Directions direction )
    {   Vector2 oldPosition= card.getCardInteraction().getPosition();
        Vector2 newPosition = new Vector2();
        switch (direction)
        {
            case Directions.DOWN:
            newPosition = new Vector2(oldPosition.x, oldPosition.y - 100);
            break;
            case Directions.UP:
            newPosition = new Vector2(oldPosition.x, oldPosition.y + 100);
            break;
            case Directions.LEFT:
            newPosition = new Vector2(oldPosition.x - 20, oldPosition.y);
            break;
            case Directions.RIGHT:
            newPosition = new Vector2(oldPosition.x + 20, oldPosition.y);
            break;
        }
    game.getPrefabModifier().createBidButton(newPosition, this);
    Debug.Log("old position: " + oldPosition + " new position: " + newPosition);
    }
    public void addButton(ButtonAction buttonAction)
    {
        buttons.Add(buttonAction);
        Debug.Log("button added");
    }
    public List<ButtonAction> getButtons()
    {
        return buttons;
    }
}
