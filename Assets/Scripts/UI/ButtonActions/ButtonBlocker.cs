using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBlocker : MonoBehaviour
{
    Player player;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        player = GetComponent<ButtonAction>().getPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.isPlayerTurn())
            button.setBlockade(true);
        else
            button.setBlockade(false);
    }
}
