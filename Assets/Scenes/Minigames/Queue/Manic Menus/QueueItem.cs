//Written by The-Architect01
using UnityEngine;
using System.Collections;

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

        Selected.LastLegalLocation = Selected.GetComponent<RectTransform>().anchoredPosition = new Vector3(
            GetComponent<RectTransform>().anchoredPosition.x + 25,
            GetComponent<RectTransform>().anchoredPosition.y,
            0
        );
        Selected.IsSelectable = true;
        Selected = null;
    }

    private void LateUpdate() {
        if (Selected == this) {
            StartCoroutine(nameof(Hover));
        } else {
            transform.localPosition = LastLegalLocation;
        }
    }

    IEnumerator Hover() {
        for (float i = 0f; i <= 1f; i += .1f) {
            transform.localPosition = new Vector3() {
                x = LastLegalLocation.x,
                y = (Mathf.Pow(Mathf.Sin(Time.realtimeSinceStartup * 2), 2) * 10f) + LastLegalLocation.y,
                z = 0,
            };
            yield return new WaitForSeconds(.015f);
        }
    }
}
