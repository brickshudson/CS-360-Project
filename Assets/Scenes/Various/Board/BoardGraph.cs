using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGraph //Note - for testing purposes this is NOT a monobehavior atm, may need to be changed
    //in the future though!
{
    //This will be where all the spaces are kept (100 is a placeholder number)
    GameSpace[] routes = new GameSpace[100];

    // Note for the connections: If there is no connection on a side, input '-1' for that direction!
    //Ex: A space with 2 connections, left and right = new GameSpace(20, "Type", -1, -1, 19, 21, x, y)
    void Start()
    {}//As of now we don't need this method
    public BoardGraph()
    {
        routes[0] = new GameSpace(0, "Green", -1, -1, 2, 1, 0f, 0f);
        routes[1] = new GameSpace(1, "Blue" , -1, -1, 0, 3, 3.05f, 0.64f);
        routes[2] = new GameSpace(2, "Red"  , -1, -1, 4, 0, -3.28f, 1.17f);
    }
    
    public GameSpace get(int i)
    {
        return routes[i];
    }
    public GameSpace goUp(GameSpace g)
    {
        if(g.getUp() != -1)
        {
            return routes[g.getUp()];
        }
        else 
        { 
            return g; 
        }
    }
    public GameSpace goDown(GameSpace g)
    {
        if (g.getDown() != -1)
        {
            return routes[g.getDown()];
        }
        else
        {
            return g;
        }
    }
    public GameSpace goLeft(GameSpace g)
    {
        if (g.getLeft() != -1)
        {
            return routes[g.getLeft()];
        }
        else
        {
            return g;
        }
    }
    public GameSpace goRight(GameSpace g)
    {
        if (g.getRight() != -1)
        {
            return routes[g.getRight()];
        }
        else
        {
            return g;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
