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
    public Rigidbody2D persona;
    Vector2 test; 
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
        moveLimit = 0;
        eliminated = false;
    }
    // Update is called once per frame
    void Update()
    {
        persona.MovePosition(current.getLoc());
        if(Input.GetKeyDown(KeyCode.W))
        {
            current = island.goUp(current);
            here.text = "" + current.getIndex() + " - " + current.getType();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            current = island.goDown(current);
            here.text = "" + current.getIndex() + " - " + current.getType();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            current = island.goLeft(current);
            here.text = "" + current.getIndex() + " - " + current.getType();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            current = island.goRight(current);
            here.text = "" + current.getIndex() + " - " + current.getType();
        }
    }
}
