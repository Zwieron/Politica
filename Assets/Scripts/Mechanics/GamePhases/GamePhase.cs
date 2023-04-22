using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GamePhase : MonoBehaviour
{
    public Game game;
    public Deck deck;
    // Start is called before the first frame update
    protected void Start()
    {
        game = GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected enum Direction{UP, DOWN, LEFT, RIGHT}
    protected void createButtonAroundCard(Card card, Direction direction )
    {   Vector2 oldPosition= card.getCardInteraction().getPosition();
        Vector2 newPosition = new Vector2();
        switch (direction)
        {
            case Direction.DOWN:
            newPosition = new Vector2(oldPosition.x, oldPosition.y - 100);
            break;
            case Direction.UP:
            newPosition = new Vector2(oldPosition.x, oldPosition.y + 100);
            break;
            case Direction.LEFT:
            newPosition = new Vector2(oldPosition.x - 20, oldPosition.y);
            break;
            case Direction.RIGHT:
            newPosition = new Vector2(oldPosition.x + 20, oldPosition.y);
            break;
        }
    game.getPrefabModifier().createButton(newPosition);
    }
}
