using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpace
{
    //This will be used so we know which direction the connecting space is in
    const int UP = 0;
    const int DOWN = 1;
    const int LEFT = 2;
    const int RIGHT = 3;

    //The type string will tell us what the space actually does when a player lands on it!
    //The index will be used to differentiate between the different spaces
    //The connections are how each space identifies what spaces it's connected to.
    string type;
    int index;
    int[] connections = new int[4];

    //This is to streamline the player moving from space to space as much as possible
    Vector2 location;

    //The world's worst constructor! :D [if any of you can think of a way to make this better, plz do!]
    public GameSpace(int i, string t, int u, int d, int l, int r, float locX, float locY)
    {
        index = i;
        type = t;
        connections[UP] = u;
        connections[DOWN] = d;
        connections[LEFT] = l;
        connections[RIGHT] = r;
        location.Set(locX, locY);
    }
    public int getUp()
    {
        return connections[UP];
    }
    public int getDown()
    {
        return connections[DOWN];
    }
    public int getLeft()
    {
        return connections[LEFT];
    }
    public int getRight()
    {
        return connections[RIGHT];
    }
    public int getIndex()
    {
        return index;
    }
    public string getType()
    {
        return type;
    }
    public Vector2 getLoc()
    {
        return location;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
