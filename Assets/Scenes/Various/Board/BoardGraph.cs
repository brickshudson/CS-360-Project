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

    //I lied when I said the GameSpace constructor was the worst, this is MUCH WORSE! >:D
    public BoardGraph()
    {
        //All of this is just constructing the game spaces and building the graph with them.
        //GameSpace(index, up, down, left, right, xPos, yPos)
        routes[0]  = new GameSpace(0, "Green", -1, -1, 2, 1, 0f, 0f);
        routes[1]  = new GameSpace(1, "Blue" , -1, -1, 0, 3, 3.05f, 0.64f);
        routes[2]  = new GameSpace(2, "Red"  , 4, -1, 8, 0, -3.28f, 1.17f);
        routes[3]  = new GameSpace(3, "Blue" , 5, -1, 1, -1, 5.23f, 1.87f);
        routes[4]  = new GameSpace(4, "Blue" , 12, 2, -1, 6, -1.88f, 4.18f);
        routes[5]  = new GameSpace(5, "Red"  , 7, 3, 6, -1, 4.68f, 3.58f);
        routes[6]  = new GameSpace(6, "Green", -1, -1, 4, 5, 1.53f, 3.52f);
        routes[7]  = new GameSpace(7, "Shop", -1, 5, -1, -1, 5.07f, 5.27f);
        routes[8]  = new GameSpace(8, "Green", 13, -1, 9, 2, -6.28f, 2.64f);
        routes[9]  = new GameSpace(9, "Red", -1, -1, 10, 8, -8.9f, 1.18f);
        routes[10] = new GameSpace(10, "Red", 11, -1, -1, 9, -12.98f, 1.57f);
        routes[11] = new GameSpace(11, "Boat", -1, 10, -1, -1, -12.75f, 3.97f);
        routes[12] = new GameSpace(12, "Green", 15, 4, 13, 14, -3.15f, 7.34f);
        routes[13] = new GameSpace(13, "Red", 16, 8, -1, 12, -6.57f, 6.77f);
        routes[14] = new GameSpace(14, "Blue", -1, -1, 12, 20, -0.21f, 8.89f);
        routes[15] = new GameSpace(15, "Green", 17, 12, -1, -1, -3.39f, 11.08f);
        routes[16] = new GameSpace(16, "Blue", 17, 13, -1, -1, -7.13f, 9.78f);
        routes[17] = new GameSpace(17, "Blue", -1, 15, 16, 18, -3.98f, 13.91f);
        routes[18] = new GameSpace(18, "Green", 32, -1, 17, 19, -.49f, 14.02f);
        routes[19] = new GameSpace(19, "Green", -1, 20, 18, -1, 3.12f, 13.48f);
        routes[20] = new GameSpace(20, "Blue", 19, -1, 14, 21, 3.24f, 10.18f);
        routes[21] = new GameSpace(21, "Red", -1, -1, 20, 22, 7.38f, 10.27f);
        routes[22] = new GameSpace(22, "Red", 28, -1, 21, 23, 11.49f, 10.3f);

        routes[23] = new GameSpace(23, "Blue", 24, 22, -1, -1, 14.21f, 12.43f);
        routes[24] = new GameSpace(24, "Red", 25, 23, -1, -1, 14.5f, 16.05f);
        routes[25] = new GameSpace(25, "Blue", -1, 24, 26, -1, 14.05f, 19f);
        routes[26] = new GameSpace(26, "Red", -1, -1, 27, 25, 10.81f, 19.82f);
        routes[27] = new GameSpace(27, "Red", -1, -1, 30, 26, 7.93f, 18.34f);
        routes[28] = new GameSpace(28, "Blue", 29, 22, -1, -1, 11.59f, 11.85f);
        routes[29] = new GameSpace(29, "Sun", -1, 28, -1, -1, 11.74f, 14.93f);
        routes[30] = new GameSpace(30, "Green", -1, -1, 31, 27, 4.66f, 17.11f);
        routes[31] = new GameSpace(31, "Blue", 33, -1, 32, 30, 1.98f, 17.48f);
        routes[32] = new GameSpace(32, "Blue", 37, 18, 34, 31, -.8f, 16.91f);
        routes[33] = new GameSpace(33, "Red", 35, 31, -1, -1, 3.62f, 19.33f);
        routes[34] = new GameSpace(34, "Blue", 36, -1, -1, 32, -3.53f, 18.35f);
        routes[35] = new GameSpace(35, "Green", -1, 33, 36, -1, 3.85f, 22.81f);
        routes[36] = new GameSpace(36, "Green", -1, 34, -1, 35, -4.09f, 22.28f);
        routes[37] = new GameSpace(37, "Volcano", 38, 32, -1, -1, -.08f, 19.64f);
        routes[38] = new GameSpace(38, "Volcano", 39, 37, -1, -1, 1.04f, 20.51f);
        routes[39] = new GameSpace(39, "Volcano", 40, 38, 40, -1, 1.99f, 21.32f);
        routes[40] = new GameSpace(40, "Volcano", -1, -1, 41, 39, .08f, 21.77f);
        routes[41] = new GameSpace(41, "Volcano", 42, -1, -1, 40, -1.94f, 22.5f);
        routes[42] = new GameSpace(42, "Volcano", -1, 41, 41, 43, -.99f, 23.43f);
        routes[43] = new GameSpace(43, "Peak", -1, -1, 42, -1, .49f, 23.66f);

        //These are for skull Island
        routes[44] = new GameSpace(44, "Boat", 45, -1, -1, -1, -10.43f, 18.3f);
        routes[45] = new GameSpace(45, "Green", 46, 47, 49, 44, -11.73f, 19.84f);
        routes[46] = new GameSpace(46, "Red", -1, 45, 49, -1, -11.57f, 23.44f);
        routes[47] = new GameSpace(47, "Red", -1, -1, 48, 45, -14.84f, 18.5f);
        routes[48] = new GameSpace(48, "Blue", 49, 47, -1, -1, -16.7f, 20.54f);
        routes[49] = new GameSpace(49, "Mansion", -1, 45, 48, 46, -14.47f, 22.97f);
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
