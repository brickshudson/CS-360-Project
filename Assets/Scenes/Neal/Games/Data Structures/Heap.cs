using UnityEngine;
using TMPro;

public class Heap : MonoBehaviour
{
    public GameObject HeapDisplay;

    private GameObject Root;
    public TextMeshProUGUI RootValue;

    private GameObject LeftChildDepth1;
    public TextMeshProUGUI D1L_Value;

    private GameObject RightChildDepth1;
    public TextMeshProUGUI D1R_Value;


    private GameObject LLeftChildDepth2;
    public TextMeshProUGUI D2LL_Value;
    private GameObject LRightChildDepth2;
    public TextMeshProUGUI D2LR_Value;

    private GameObject RLeftChildDepth2;
    public TextMeshProUGUI D2RL_Value;
    private GameObject RRightChildDepth2;
    public TextMeshProUGUI D2RR_Value;

    //private GameObject LLLeftChildDepth3;
    //private GameObject LLRightChildDepth3;

    int[] RandomHeap;

    // Start is called before the first frame update
    void Start()
    {
        Root = HeapDisplay.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        RootValue.text = "150";

        LeftChildDepth1 = Root.transform.GetChild(0).gameObject;

        RightChildDepth1 = Root.transform.GetChild(1).gameObject;
        
        LLeftChildDepth2 = LeftChildDepth1.transform.GetChild(0).gameObject;
        LRightChildDepth2 = LeftChildDepth1.transform.GetChild(1).gameObject;

        RLeftChildDepth2 = RightChildDepth1.transform.GetChild(0).gameObject;
        RRightChildDepth2 = RightChildDepth1.transform.GetChild(1).gameObject;

        //LLLeftChildDepth3 = LLeftChildDepth2.transform.GetChild(0).gameObject;
        //LLRightChildDepth3 = LLLeftChildDepth3.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InsertElement(int value) {

    }

}
