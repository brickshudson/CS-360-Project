using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contestant : MonoBehaviour
{
    //This is the player class for the game board. We will need to make one of these for each player in the
    //game when we get multiplayer implemented. But for now I'm just using this to test the basic functions
    //of the game board.

    //Initializing all variables
    int bits;
    GameSpace current;
    public BoardGraph island;
    private int moveLimit;
    private bool eliminated;
    private bool isTurn;
    public Rigidbody2D persona;
    //These only exist for ez testing!
    public TextMeshProUGUI here;
    public TextMeshProUGUI bitCoin;
    
    //item[] items; <-- we don't have items yet so this will need to wait

    // Start is called before the first frame update
    void Start()
    {
        bits = 0;
        island = new BoardGraph();
        current = island.get(0);
        here.text = ""+ current.getIndex() + " - " + current.getType();
        bitCoin.text = "Bits: " + bits;
        moveLimit = 6; //will be set by dice roll in final version
        eliminated = false;
        isTurn = true; //Change when we begin testing turn system!!!
    }
    // Update is called once per frame
    void Update()
    {
        persona.MovePosition(current.getLoc());
        if(isTurn)
        {
            if(moveLimit > 0)
            {
                movement();
            }
        }
        
    }

    public void movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveLimit--;
            current = island.goUp(current);
            here.text = "" + moveLimit;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveLimit--;
            current = island.goDown(current);
            here.text = "" + moveLimit;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLimit--;
            current = island.goLeft(current);
            here.text = "" + moveLimit;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveLimit--;
            current = island.goRight(current);
            here.text = "" + moveLimit;
        }
    }
}
