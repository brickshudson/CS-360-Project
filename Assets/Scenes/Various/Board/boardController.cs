using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardController : MonoBehaviour
{
    LinkedList<Contestant> contestants = new LinkedList<Contestant>();
    bool eliminationRound = false;
    LinkedListNode<Contestant> frontRunner;
    int roundCnt;
    int elimCnt; //this will be equal to however many turns we want to have eliminations on [i.e, every 3 turns]

    // Start is called before the first frame update
    void Start()
    {
        /* for(int i=0; i < # of players; i++)
         * {
         *    contestents.AddLast(new Contestent());
         * }
         */
        elimCnt = 3;
        roundCnt = 1;
        frontRunner = contestants.First;
    }

    // Update is called once per frame
    void Update()
    {
        if(roundCnt % elimCnt == 0)
        {
            eliminationRound = true;
        }
        /* for(LinkedListNode<Contestant> current = frontRunner; current.Next != null; current = current.Next)
         * {
         *      current.turnStart();
         *      while(current.isTurn)
         *      {
         *          wait for current player to finish turn
         *      }
         * }
         */
        if(eliminationRound)
        {
            ChallengeTime();
        }
        roundCnt++;
    }

    public void ChallengeTime()
    {
        //this will be the method that loads the minigame
    }
}
