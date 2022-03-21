using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPart : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

    public int Rank;
    public GameObject[] LegalObjects;

    public Vector2 LastLegalLocation;
    public RectTransform Transform;

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Drag Start");
    }

    public void OnDrag(PointerEventData eventData) {
        Transform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("Drag End");
    }

    public void Snap() {
        Transform.anchoredPosition = LastLegalLocation;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        foreach (GameObject go in LegalObjects) {
            if (collision.gameObject == go) { return; }
        }
        collision.GetComponent<TowerPart>().Snap();
    }

    // Start is called before the first frame update
    void Start()
    {
        LastLegalLocation = Transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
