//Written by The-Architect01
using System.Collections;
using UnityEngine;

public class TowerPart : MonoBehaviour {

    public int Rank;
    public TOHTower Tower;
    public bool IsSelectable;

    public Vector2 LastLegalLocation;
    public RectTransform Transform;
    public static TowerPart Selected;

    // Start is called before the first frame update
    void Start() { 
        LastLegalLocation = Transform.anchoredPosition;
    }

    public void OnClick() {
        if(IsSelectable)
            Selected = this;
    }

    private void LateUpdate() {
        if (Selected == this) {
            StartCoroutine(nameof(Hover));
        } else {
            transform.localPosition = LastLegalLocation;
        }
    }

    IEnumerator Hover() { 
        for(float i = 0f; i<=1f; i += .1f){
            transform.localPosition = new Vector3() {
                x = LastLegalLocation.x,
                y = (Mathf.Pow(Mathf.Sin(Time.realtimeSinceStartup * 2),2) * 10f) + LastLegalLocation.y,
                z = 0,
            };
            yield return new WaitForSeconds(.015f);
        }
    }
}
