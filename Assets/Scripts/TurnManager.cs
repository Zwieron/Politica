using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurnManager : MonoBehaviour
{   GameInfo gameInfo;
    int currentPlayerIndex;
    List<EndTurnAction> turnButtons = new List<EndTurnAction>();
    // Start is called before the first frame update
    void Start()
    {
        gameInfo = GetComponent<GameInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        getButtonsOfGamePhase();
        checkTurnButtons();
    }
    void getButtonsOfGamePhase()
    {
        switch(gameInfo.getGamePhase())
        {
            case GamePhases.BiddingPhase:
                refreshTurnButtons(GetComponent<BiddingPhase>().getButtons());
                break;
            case GamePhases.ActionPhase:
                refreshTurnButtons(GetComponent<ActionPhase>().getButtons());
                break;
            case GamePhases.PollPhase:
                refreshTurnButtons(GetComponent<PollPhase>().getButtons());
                break;
        }
    }
    void nextPlayer()
    {
        gameInfo.getPlayers()[currentPlayerIndex].GetComponent<Player>().endTurn();
        currentPlayerIndex ++;
        Debug.Log("Current player index 1: "+currentPlayerIndex);
        if (currentPlayerIndex >= gameInfo.getPlayers().Count)
        {
            currentPlayerIndex = 0;
        }
        gameInfo.getPlayers()[currentPlayerIndex].GetComponent<Player>().startTurn();
        Debug.Log("Current player index 2: "+currentPlayerIndex);
    }
    void refreshTurnButtons(List<ButtonAction> buttons)
    {
        turnButtons.Clear();
        foreach(EndTurnAction button in buttons.OfType<EndTurnAction>())
        {
            turnButtons.Add(button);
        }
    }
    void checkTurnButtons()
    {
        foreach(EndTurnAction button in turnButtons)
        {
            if (button.isTurnEnded()&&button.getPlayer().Equals(gameInfo.getPlayers()[currentPlayerIndex]))
            {
                foreach(ButtonAction buttonAction in gameInfo.getPlayers()[currentPlayerIndex].GetComponent<Player>().getPlayerButtonActions())
                {
                    buttonAction.update();
                }
                nextPlayer();
                button.resetTurnEnded();
                Debug.Log("Player " + (getCurrentPlayerIndex()+1) + " turn ended");
            }
        }
    }
    public int getCurrentPlayerIndex()
    {
        return  currentPlayerIndex;
    }
}
