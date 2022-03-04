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

    //Constructor
    public GameSpace(int i, string t, int u, int d, int l, int r)
    {
        index = i;
        type = t;
        connections[UP] = u;
        connections[DOWN] = d;
        connections[LEFT] = l;
        connections[RIGHT] = r;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
