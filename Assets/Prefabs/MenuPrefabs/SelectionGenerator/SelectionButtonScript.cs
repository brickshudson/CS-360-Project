using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionButtonScript : MonoBehaviour
{
    public delegate void Callback(string selection);
    public Callback callback;

    public string selectionData;

    void Start()
    {
        // Set the button text to display the selection
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = selectionData;

        // When the button is clicked, run the provided callback
        GetComponent<Button>().onClick.AddListener(delegate { callback(selectionData); });
    }
}
