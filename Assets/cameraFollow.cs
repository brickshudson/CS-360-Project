using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 offSet;

    private void Update()
    {
        transform.position = target.position;
    }
}
