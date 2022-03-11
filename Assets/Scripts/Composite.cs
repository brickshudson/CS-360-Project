//Written by The-Architect01
using UnityEngine;

public class Composite : MonoBehaviour {

    public LineUpController Controller;

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

        Eye.sprite = Face.Eyes[(int)EyeShape];
        Nose.sprite = Face.Noses[(int)NoseShape];
        Mouth.sprite = Face.Mouths[(int)MouthShape];
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
            Controller.ChoiceMade(true);
        } else {
            Debug.Log("Incorrect");
            Controller.ChoiceMade(false);
        }
    }


}
public static class Face {
    public static Sprite[] Eyes = new Sprite[] {
        Resources.Load<Sprite>("Find the Pointer/Eyes_Ellipse"),
        Resources.Load<Sprite>("Find the Pointer/Eyes_Rectangle"),
        Resources.Load<Sprite>("Find the Pointer/Eyes_Triangle"),
    };

    public static Sprite[] Mouths = new Sprite[] {
        Resources.Load<Sprite>("Find the Pointer/Mouth_Ellipse"),
        Resources.Load<Sprite>("Find the Pointer/Mouth_Rectangle"),
        Resources.Load<Sprite>("Find the Pointer/Mouth_Triangle"),
    };

    public static Sprite[] Noses = new Sprite[] {
        Resources.Load<Sprite>("Find the Pointer/Nose_Ellipse"),
        Resources.Load<Sprite>("Find the Pointer/Nose_Rectangle"),
        Resources.Load<Sprite>("Find the Pointer/Nose_Triangle"),
    };

    public enum Shape {
        Ellipse = 0,
        Rectangle = 1,
        Triangle = 2,
    }

}