using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnTower : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        collision.GetComponent<TowerPart>().Snap();
        Debug.LogError("Encounter");
    }

}
