using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class boardController : MonoBehaviour
{
    //2 lists, one for players still in the game, one for the losers! :D
    LinkedList<Contestant> contestants = new LinkedList<Contestant>();
    LinkedList<Contestant> loserParty = new LinkedList<Contestant>();
    LinkedListNode<Contestant> frontRunner;
    int roundCnt;
    int elimCnt; // minigames will happen on ever xth turn
    int numPlayers;
    bool eliminationRound = false;
    TextMeshPro bitCoin;

    void Start()
    {
        numPlayers = 5;
         for(int i=0; i < numPlayers; i++)
         {
            contestants.AddLast(new Contestant());
         }
        elimCnt = 3;
        roundCnt = 1;
        frontRunner = contestants.First;
        bitCoin.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(roundCnt % elimCnt == 0)
        {
            eliminationRound = true;
        }
         for(LinkedListNode<Contestant> current = frontRunner; current.Next != null; current = current.Next)
         {
              current.Value.turnStart();
              while(current.Value.isTurn)
              {
                  
              }
              
         }
         
        if (eliminationRound)
        {
            ChallengeTime();
        }

        roundCnt++;
    }

    public void ChallengeTime()
    {
        
    }
}
