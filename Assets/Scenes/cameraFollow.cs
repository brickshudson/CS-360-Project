using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 offSet;
    public float speedMultiplier = 10f;
    public float speedCap = 25.0f;

    private void Update()
    {
        Vector3 distance = (target.position - transform.position);

        if(distance.magnitude > 0.01 && distance.magnitude < 10000)
        {
            if(speedMultiplier * distance.magnitude < speedCap)
                distance = speedMultiplier * distance.magnitude * distance.normalized;
            else
                distance = speedCap * distance.normalized;

            transform.position = transform.position + Time.deltaTime * distance;
        }
        else
            transform.position = target.position;
    }
}
