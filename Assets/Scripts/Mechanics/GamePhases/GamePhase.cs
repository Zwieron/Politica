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
    protected void createButtonAroundCard(Card card, ButtonTypes buttonTypes, Directions direction)
    {
    Vector2 newPosition = switchPositionByDirection(card.getCardInteraction().getPosition(),direction);   
    switchCreateButtonType(buttonTypes, newPosition);
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
    Vector2 switchPositionByDirection(Vector2 oldPosition, Directions direction)
    {
        switch (direction)
        {
            case Directions.DOWN:
            return new Vector2(oldPosition.x, oldPosition.y - 100);
            case Directions.UP:
            return new Vector2(oldPosition.x, oldPosition.y + 100);
            case Directions.LEFT:
            return new Vector2(oldPosition.x - 20, oldPosition.y);
            case Directions.RIGHT:
            return new Vector2(oldPosition.x + 20, oldPosition.y);
            default:
            return oldPosition;
        }
    }
    void switchCreateButtonType(ButtonTypes buttonTypes, Vector2 position)
    {
        switch(buttonTypes)
        {
            case ButtonTypes.BidAction:
            game.getPrefabModifier().createBidButton(position, this);
            break;
            case ButtonTypes.PassAction:
            game.getPrefabModifier().createPassButton(position, this);
            break;
            case ButtonTypes.ActivateCardAction:
            game.getPrefabModifier().createActivateCardButton(position, this);
            break;
            case ButtonTypes.EndTurnAction:
            game.getPrefabModifier().createEndTurnButton(position, this);
            break;
            case ButtonTypes.UndoTurnAction:
            game.getPrefabModifier().createUndoTurnButton(position, this);
            break;
        }
    }
}

