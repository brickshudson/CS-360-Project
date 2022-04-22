using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAMItem : Item
{
    public RAMItem()
    {
        name = "RAM";
        Itemdescription = "Teleports you to a random point on the island!";
    }

    public void use(Contestant c)
    {
        GameSpace newLocation = c.getLocation();
        newLocation = c.island.get(numPicker.Next());
    }
}
