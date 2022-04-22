using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public Button OpenOptions;

    // Start is called before the first frame update
    void Start()
    {
        OpenOptions.onClick.AddListener(delegate {
            SceneManager.LoadScene("Options Menu");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
