//Written by The-Architect01
using UnityEngine;

public class QueueItem : MonoBehaviour
{
    public QueueHost Host;
    public bool IsSelectable;

    public Vector2 LastLegalLocation;
    public RectTransform Transform;
    public static QueueItem Selected;
    public bool IsTemp = false;

    void Start() {
        LastLegalLocation = Transform.anchoredPosition;
    }

    public void OnClick() {
        if (IsSelectable && !IsTemp)
            Selected = this;
    }

    public void TempCapture() {
        if (Selected == null)
            return;

        if (Selected.Host != null) {
            Selected.Host.Queue.Remove(Selected);
            Selected.Host.UpdateTree();
        }
        Selected.Host = null;

        Selected.GetComponent<RectTransform>().anchoredPosition = new Vector3(
            GetComponent<RectTransform>().anchoredPosition.x + 25,
            GetComponent<RectTransform>().anchoredPosition.y,
            0
        );
        Selected.IsSelectable = true;
    }
}
