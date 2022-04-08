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
    private int moveLimit = 0;
    private bool eliminated;
    private bool isTurn;
    public Rigidbody2D persona;
    //These only exist for ez testing!
    public TextMeshProUGUI here;
    public TextMeshProUGUI bitCoin;
    public System.Random die;
    
    //item[] items; <-- we don't have items yet so this will need to wait

    // Start is called before the first frame update
    void Start()
    {
        die = new System.Random();
        bits = 0;
        island = new BoardGraph();
        current = island.get(0);
        bitCoin.text = "Bits: " + bits;
        moveLimit = die.Next(7); //will be set by dice roll in final version
        eliminated = false;
        isTurn = true; //Change when we begin testing turn system!!!
        here.text = "" + moveLimit;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            turnStart();
        }
        if(!eliminated)
        {
            persona.MovePosition(current.getLoc());
            if (isTurn)
            {
                if (moveLimit > 0)
                {
                    movement();
                }
                else
                {
                    spaceEffect();
                }
            }
        }
    }

    public void movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(current.getUp() != -1)
            {
                moveLimit--;
                current = island.goUp(current);
                here.text = "" + moveLimit;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (current.getDown() != -1)
            {
                moveLimit--;
                current = island.goDown(current);
                here.text = "" + moveLimit;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (current.getLeft() != -1)
            {
                moveLimit--;
                current = island.goLeft(current);
                here.text = "" + moveLimit;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (current.getRight() != -1)
            {
                moveLimit--;
                current = island.goRight(current);
                here.text = "" + moveLimit;
            }
        }
    }

    public void spaceEffect()
    {
        switch(current.getType())
        {
            case "Blue": bits += 5;
                break;
            case "Red": bits -= 5;
                break;
            case "Green":
                break;
            case "Volcano":
                bits -= 20;
                current = island.get(32);
                break;
            case "Shop": //it's a shop, take a guess
                break;
            case "Boat": current = island.get(44);
                break;
            case "Skull Boat": current = island.get(11);
                break;
            case "Sun": //this will prompt the player to either buy the teletubby sun's services or wait ;P
                break;
            case "Peak": //this will give the player a backup drive
                break;
            case "Mansion":
                break;
        }
        if(bits < 0)
        {
            bits = 0;
        }
        bitCoin.text = "Bits: " + bits;
        isTurn = false;
    }

    public void turnStart()
    {
        isTurn = true;
        moveLimit = die.Next(7);
        bitCoin.text = "Bits: " + bits;
        here.text = "" + moveLimit;
    }
}
