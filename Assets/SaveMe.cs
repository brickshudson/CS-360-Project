using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveMe : MonoBehaviour
   
{ 

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");

    if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame

}
