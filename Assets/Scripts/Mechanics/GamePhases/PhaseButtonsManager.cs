using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseButtonsManager : MonoBehaviour
{
    Game game;
    GamePhase phase;
    List<ButtonAction> buttons = new List<ButtonAction>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //TODO: Wszystko niżej gdzieś przenieść do klas
    public void createButtonAroundCard(Card card, ButtonTypes buttonTypes, Directions direction)
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
            game.getPrefabModifier().createBidButton(position, phase);
            break;
            case ButtonTypes.PassAction:
            game.getPrefabModifier().createPassButton(position, phase);
            break;
            case ButtonTypes.ActivateCardAction:
            game.getPrefabModifier().createActivateCardButton(position, phase);
            break;
            case ButtonTypes.EndTurnAction:
            game.getPrefabModifier().createEndTurnButton(position, phase);
            break;
            case ButtonTypes.UndoTurnAction:
            game.getPrefabModifier().createUndoTurnButton(position, phase);
            break;
        }
    }
    public void createDefaultButtonsForPlayer(Player player)
    {
            //end turn button
            Vector2  endButtonPosition = new Vector2(player.getHandVisual().getHandPosition().x, player.getHandVisual().getHandPosition().y - 40);
            game.getPrefabModifier().createEndTurnButton(endButtonPosition, phase);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<EndTurnAction>().setPlayer(player);
            //undo turn button
            Vector2  undoButtonPosition = new Vector2(player.getHandVisual().getHandPosition().x, player.getHandVisual().getHandPosition().y - 80);
            game.getPrefabModifier().createUndoTurnButton(undoButtonPosition, phase);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<UndoTurnAction>().setPlayer(player);
            player.gatherPlayerButtonActions(buttons);
    }
    public void setGamePhase(GamePhase phase)
    {
        this.phase = phase;
    }
    public void setGame(Game game)
    {
        this.game = game;
    }
}
