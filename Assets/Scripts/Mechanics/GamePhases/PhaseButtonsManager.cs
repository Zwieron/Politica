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
    List<SelectCardAction> selectCardActions = new List<SelectCardAction>();
    public float defaultButtonsOffset;
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
    Vector2 newPosition = switchPositionByDirection(card,direction);   
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
    public void clearActiveCardButtons() //czysci i niszczy
    {
        Debug.Log("clearing active card buttons");
        foreach(CharacterCardAction characterCardAction in activeCharacterCardActions)
        {
            if(characterCardAction.getCharacterActionsManager().getActiveCardAction()!=characterCardAction)
            {
            buttons.Remove(characterCardAction); //nie usuwac przycisku z listy bo jest juz wykorzystywany?
            Destroy(characterCardAction.gameObject);
            }
            else 
            {
                characterCardAction.gameObject.transform.position = new Vector3(0,-10000,0);
            }
        }
        activeCharacterCardActions.Clear();
    }
    public bool checkIfAnySelectButtonIsSelected()
    {
        foreach(SelectCardAction select in selectCardActions)
        {
            if(select.isSelected()&&select.getPlayer().Equals(game.getTurnManager().getCurrentPlayer())&&select.isTurnOfActivityNow())
            {
                return true;
            }
        }
        return false;
    }
    public void clearSelectCardButtons()
    {
        List<SelectCardAction> selects = new List<SelectCardAction>(selectCardActions);
        Player player = game.getTurnManager().getCurrentPlayer();
        foreach(Card card in player.getHand().getCards())
        {
            if(card is Character && card.GetCardActionsManager().isActiveCardActionSelectable())
                {
                    SelectingCharacterButton action = (SelectingCharacterButton) card.GetCardActionsManager().getActiveCardAction();
                    foreach(SelectCardAction select in selectCardActions)
                    {
                        if(select.isTurnOfActivityNow()&&select.getSelector().getSelectingButtonAction().Equals(action)||select.isSelected())
                        {
                            continue;
                        }
                        else
                        // (select.isTurnOfActivityNow()&&select.getSelector().getSelectingButtonAction().Equals(action)&&!select.isSelected())
                        {
                            buttons.Remove(select);
                            selects.Remove(select);
                            Destroy(select.gameObject);
                        }
                    }
                }
            }
        selectCardActions = new List<SelectCardAction>(selects);
    }
    Vector2 switchPositionByDirection(Card card, Directions direction)
    {
        return card.getCardInteraction().getButtonPositioner().getButtonPosition(direction);
    }
    Directions switchDirectionByButtonType(ButtonTypes buttonType)
    {
        switch(buttonType)
        {
            case ButtonTypes.BlockAction:
            return Directions.LEFTUP;
            case ButtonTypes.ExposeCharacter:
            return Directions.UP;
            case ButtonTypes.StrengthenNotoriety:
            return Directions.RIGHTUP;
            case ButtonTypes.OvertakeInstitution:
            return Directions.RIGHTDOWN;
            case ButtonTypes.InstitutionAction:
            return Directions.LEFTDOWN;
            default:
            return Directions.DOWN;
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
            ///////SELECT CARD ACTION//////
            case ButtonTypes.SelectCardAction:
            game.getPrefabModifier().createSelectCardActionButton(position, phase);
            break;
        }
    }
    public void createDefaultButtonsForPlayer(Player player)
    {
            //pass 
            Vector2  passButtonPosition = new Vector2(game.getPrefabModifier().getPlayerPosition(player.playerNumber).x, game.getPrefabModifier().getPlayerPosition(player.playerNumber).y);
            game.getPrefabModifier().createPassButton(passButtonPosition, phase);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<PassAction>().setPlayer(player);
            //end turn button
            Vector2  endButtonPosition = new Vector2(game.getPrefabModifier().getPlayerPosition(player.playerNumber).x, game.getPrefabModifier().getPlayerPosition(player.playerNumber).y-defaultButtonsOffset);
            game.getPrefabModifier().createEndTurnButton(endButtonPosition, phase);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<EndTurnAction>().setPlayer(player);
            //undo turn button
            Vector2  undoButtonPosition = new Vector2(game.getPrefabModifier().getPlayerPosition(player.playerNumber).x, game.getPrefabModifier().getPlayerPosition(player.playerNumber).y-defaultButtonsOffset*2);
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
    public void createButtonsForActivatedCharacterCard(Card card, Player player)
    {
        card.GetComponent<Character>().checkAvailibleActions();
        foreach(ButtonTypes buttonType in card.GetComponent<Character>().getAvailibleActions())
        {
            switchCreateButtonType(buttonType, switchPositionByDirection(card, switchDirectionByButtonType(buttonType)));
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<CharacterCardAction>().setPlayer(player);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<CharacterCardAction>().setCard(card);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().transform.SetParent(card.getCardInteraction().GetCanvas().gameObject.transform);
            activeCharacterCardActions.Add(game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<CharacterCardAction>());
        }
    }
    public void createSelectButtonForActivatedInstitutionCard(Card card, Player player, SelectingCharacterButton selectingCharacterButton)
    {
        switchCreateButtonType(ButtonTypes.SelectCardAction, switchPositionByDirection(card, player.buttonDirection));
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<SelectCardAction>().setPlayer(player);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<SelectCardAction>().setCard(card);
            game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<SelectCardAction>().setSelector(selectingCharacterButton.getSelector());
            buttons.Add(game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<SelectCardAction>());
            selectCardActions.Add(game.getPrefabModifier().getPrefabInstantiator().getLastPrefab().GetComponent<SelectCardAction>());
    }
}
