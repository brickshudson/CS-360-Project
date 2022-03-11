//Written by The-Architect01
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Vector2 LastLocation;
    public bool Interactable = false;

    public DropCapture LastSnap;
    DropCapture TempSnap;

    //Sets variables
    void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        LastLocation = GetComponent<RectTransform>().anchoredPosition;
    }

    //Does simple graphic alterations
    public void OnBeginDrag(PointerEventData eventData) {
        TempSnap = LastSnap;
        LastSnap.GetComponent<DropCapture>().HasValue = false;
        LastSnap = null;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
    }

    //Moves the gameobject with mouse
    public void OnDrag(PointerEventData eventData) {
        if (Interactable) {rectTransform.anchoredPosition += eventData.delta; }
    }

    //If a snap has not been detected, go back to last valid location
    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        GetComponent<RectTransform>().anchoredPosition = LastLocation;
        LastSnap ??= TempSnap;
        LastSnap.GetComponent<DropCapture>().HasValue = true;
    }
}
