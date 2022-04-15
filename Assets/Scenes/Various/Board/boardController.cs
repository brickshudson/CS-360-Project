using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LinkedList<Contestant> contestants = new LinkedList<Contestant>();
        contestants.AddLast(new Contestant());
        /* for(# of players)
         *    contestents.add(new Contestent())
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
