//Written by The-Architect01
using UnityEngine;

public class Composite : MonoBehaviour {
    
    public SpriteRenderer Eye;
    public SpriteRenderer Nose;
    public SpriteRenderer Mouth;

    public TextMesh Name;
    public TextMesh Number;

    public bool IsCorrect = false;

    public Face.Shape EyeShape;
    public Face.Shape NoseShape;
    public Face.Shape MouthShape;

    public void Start() {
        Number.text = $"{Random.Range(0, 9999999)}".PadLeft(7,'0');
    }

    public void Populate(Face.Shape eyes, Face.Shape nose, Face.Shape mouth, bool iscorrect) {
        EyeShape = eyes;
        NoseShape = nose;
        MouthShape = mouth;
        IsCorrect = iscorrect;

        Eye.sprite = Face.Eyes[(int)eyes];
        Nose.sprite = Face.Noses[(int)nose];
        Mouth.sprite = Face.Mouths[(int)mouth];
    }

    public void OnPointerDown() {
        if (IsCorrect) {
            Debug.Log("Correct");
        } else {
            Debug.Log("Incorrect");
        }
    }


}
public static class Face {
    public static Sprite[] Eyes = new Sprite[] {
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Eyes_Ellipse.png"),
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Eyes_Rectangle.png"),
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Eyes_Triangle.png"),
    };

    public static Sprite[] Noses = new Sprite[] {
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Mouth_Ellipse.png"),
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Mouth_Rectangle.png"),
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Mouth_Triangle.png"),
    };

    public static Sprite[] Mouths = new Sprite[] {
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Nose_Ellipse.png"),
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Nose_Rectangle.png"),
        Resources.Load<Sprite>("Assets/Resources/Find the Pointer/Nose_Triangle.png"),
    };

    public enum Shape {
        Ellipse = 0,
        Rectangle = 1,
        Triangle = 2,
    }

}