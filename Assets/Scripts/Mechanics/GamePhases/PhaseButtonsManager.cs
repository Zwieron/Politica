using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PhaseButtonsManager : MonoBehaviour
{
    Game game;
    GamePhase phase;
    List<ButtonAction> buttons = new List<ButtonAction>();
    List<CharacterCardAction> activeCharacterCardActions = new List<CharacterCardAction>();
    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createButtonAroundCard(Card card, ButtonTypes buttonTypes, Directions direction)
    {
    Vector2 newPosition = switchPositionByDirection(card.getCardInteraction().getPosition(),direction);   
    switchCreateButtonType(buttonTypes, newPosition);
    }
    public void addButton(ButtonAction buttonAction)
    {   
        buttons.Add(buttonAction);
        Debug.Log("button added");
        if(buttonAction is CharacterCardAction)
        {
            activeCharacterCardActions.Add(buttonAction as CharacterCardAction);
        }
        else return;
    }
    public List<ButtonAction> getButtons()
    {
        return buttons;
    }
    public void clearActiveCardButtons()
    {
        Debug.Log("clearing active card buttons");
        foreach(CharacterCardAction characterCardAction in activeCharacterCardActions)
        {
            buttons.Remove(characterCardAction);
            activeCharacterCardActions.Remove(characterCardAction);
            Destroy(characterCardAction.gameObject);
        }
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
            //////CHARACTER CARD ACTIONS//////
            case ButtonTypes.BlockAction:
            game.getPrefabModifier().createBlockActionButton(position, phase);
            break;
            case ButtonTypes.ExposeCharacter:
            game.getPrefabModifier().createExposeCharacterButton(position, phase);
            break;
            case ButtonTypes.StrengthenNotoriety:
            game.getPrefabModifier().createStrengthenNotorietyButton(position, phase);
            break;
            case ButtonTypes.OvertakeInstitution:
            game.getPrefabModifier().createOvertakeInstitutionButton(position, phase);
            break;
            case ButtonTypes.InstitutionAction:
            game.getPrefabModifier().createInstitutionActionButton(position, phase);
            break;
        }
    }
    public void createDefaultButtonsForPlayer(Player player)
    {
            //pass 
            Vector2  passButtonPosition = new Vector2(player.getHandVisual().getHandPosition().x-175, player.getHandVisual().getHandPosition().y+40);
            game.getPrefabModifier().createPassButton(passButtonPosition, phase);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<PassAction>().setPlayer(player);
            //end turn button
            Vector2  endButtonPosition = new Vector2(player.getHandVisual().getHandPosition().x-175, player.getHandVisual().getHandPosition().y);
            game.getPrefabModifier().createEndTurnButton(endButtonPosition, phase);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<EndTurnAction>().setPlayer(player);
            //undo turn button
            Vector2  undoButtonPosition = new Vector2(player.getHandVisual().getHandPosition().x-175, player.getHandVisual().getHandPosition().y - 40);
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
    public void clearButtons()
    {
        buttons.Clear();
    }
    public void removeButton(ButtonAction buttonAction)
    {
        buttons.Remove(buttonAction);
    }
}
