using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPart : MonoBehaviour {

    public int Rank;
    public TOHTower Tower;
    public bool IsSelectable;

    public Vector2 LastLegalLocation;
    public RectTransform Transform;
    public static TowerPart Selected;

    // Start is called before the first frame update
    void Start()
    {
        LastLegalLocation = Transform.anchoredPosition;
    }

    public void OnClick() {
        if(IsSelectable)
            Selected = this;
    }
}
