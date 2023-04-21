using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePhase : MonoBehaviour
{
    public Game game;
    public Deck deck;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void getGame()
    {
        if(game==null)
        {
            GetComponent<Game>();
        }
    }
}
