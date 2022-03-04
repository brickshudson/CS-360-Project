using UnityEngine;

public class Heap_GameController : MonoBehaviour
{

    public GameObject SelectorObject;

    private static Vector3 Root = new Vector3() {
        x = 0f,
        y = 1.35f,
        z = 10.8f
    };

    private static Vector3 LeftChild;

    private static Vector3 RightChild;

    private static Vector3 LeftChildLeft;

    private static Vector3 LeftChildRight;

    private static Vector3 RightChildLeft;

    private static Vector3 RightChildRight;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectorObject.transform.SetPositionAndRotation(Root, SelectorObject.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
