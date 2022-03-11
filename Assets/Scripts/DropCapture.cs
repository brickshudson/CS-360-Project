//Written by The-Architect01
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropCapture : MonoBehaviour, IDropHandler {

    /// <summary>The value contained in the captured game object.</summary>
    public string ValueCaptured { get; set; }
    public bool HasValue { get; set; } = false;
    public bool Interactable;
    public GameObject CapturedObject { get; set; }
    public bool IsLast { get; set; } = false;

    private void Awake() {
        if (gameObject.name.Contains("Dummy")) {
            CapturedObject = new GameObject();
            CapturedObject.AddComponent<Draggable>();
            CapturedObject.AddComponent<RectTransform>();
        }
    }

    //Snaps the captured gameobject to this object's position. It then grabs the value contained in the captured game object.
    public void OnDrop(PointerEventData eventData) {
        if(eventData.pointerDrag != null && IsLast && !gameObject.name.Contains("Dummy")) {
            CapturedObject = eventData.pointerDrag;
            if (CapturedObject.GetComponent<Draggable>().Interactable) {
                Snap(CapturedObject);
                HasValue = true;
                MendTheMenu.ChangeDetected = true;
            }
        }
    }

    public void Snap(GameObject GO) {
        CapturedObject = GO;
        
        GO.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        GO.GetComponent<Draggable>().LastLocation = GetComponent<RectTransform>().anchoredPosition;
        GO.GetComponent<Draggable>().Interactable = Interactable;
        GO.GetComponent<Draggable>().LastSnap = this;

        ValueCaptured = GO.GetComponent<TextMeshProUGUI>().text;
        Debug.Log($"{gameObject.name} Captured {ValueCaptured}.");
    }

}
