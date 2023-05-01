using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class GamePhase : MonoBehaviour
{
    public Game game;
    public Deck deck;
    public Croupier croupier;
    public PhaseButtonsManager phaseButtonsManager;
    // Start is called before the first frame update
    protected void Start()
    {
        game = GetComponent<Game>();
        phaseButtonsManager = GetComponent<PhaseButtonsManager>();
        phaseButtonsManager.setGamePhase(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public PhaseButtonsManager getPhaseButtonsManager()
    {
        return phaseButtonsManager;
    }
}

