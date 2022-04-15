using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contestant : MonoBehaviour
{
    //Initializing all variables
    int bits;
    GameSpace current;
    public BoardGraph island;
    private int moveLimit = 0;
    public bool eliminated;
    public bool isTurn;
    public Rigidbody2D persona;
    //These only exist for ez testing!
    public TextMeshProUGUI here;
    public System.Random die;
    Item[] items;
    public Contestant()
    {
        die = new System.Random();
        bits = 0;
        island = new BoardGraph();
        current = island.get(0);
        eliminated = false;
        isTurn = true; //Change when we begin testing turn system!!!
        here.text = "" + moveLimit;
        items = new Item[6];
    }
    // Start is called before the first frame update
    void Start()
    {
        die = new System.Random();
        bits = 0;
        island = new BoardGraph();
        current = island.get(0);
        eliminated = false;
        isTurn = true; //Change when we begin testing turn system!!!
        here.text = "" + moveLimit;
        items = new Item[6];
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
            case "Blue": bits += 4;
                break;
            case "Red": bits -= 4;
                break;
            case "Green": //This is a neutral space, nothing happens!
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
        isTurn = false;
    }

    public void turnStart()
    {
        isTurn = true;
        moveLimit = die.Next(7);
        here.text = "" + moveLimit;
    }

    public void useItem(Item item)
    {
        if(item == null)
        {
            return;
        }
        if(item.GetType() == typeof(backupDrive))
        {
            return;
        }
        item.use(this);
    }

    public void rollDie(int MAX_VALUE)
    {
        moveLimit = die.Next(MAX_VALUE);
    }

    public GameSpace getLocation()
    {
        return current;
    }
    public void setLocation(GameSpace newLocation)
    {
        current = newLocation;
    }
    public int getBits()
    {
        return bits;
    }
}
