using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineUpController : MonoBehaviour
{
    public Image Eyes;
    public Image Nose;
    public Image Mouth;
    public Composite[] Charges;

    public Face.Shape[] CorrectFace;
    public TextMeshProUGUI Characteristics;

    void Awake(){

        CorrectFace = new Face.Shape[] {
            (Face.Shape)Random.Range(0,3),
            (Face.Shape)Random.Range(0,3),
            (Face.Shape)Random.Range(0,3),
        };

        foreach (Composite charge in Charges) {
            Face.Shape Eye = (Face.Shape)Random.Range(0, 3);
            Face.Shape Nose = (Face.Shape)Random.Range(0, 3);
            Face.Shape Mouth = (Face.Shape)Random.Range(0, 3);
            charge.Populate(Eye, Nose, Mouth, false);
        }

        int CorrectCharge = Random.Range(0, Charges.Length);
        Charges[CorrectCharge].Populate(CorrectFace[0], CorrectFace[1], CorrectFace[2], true);

        Eyes.sprite = Resources.Load<Sprite>($"Assets/Resources/Find the Pointer/Eyes_{CorrectFace[0]}.png");
        Nose.sprite = Resources.Load<Sprite>($"Assets/Resources/Find the Pointer/Nose_{CorrectFace[1]}.png");
        Mouth.sprite = Resources.Load<Sprite>($"Assets/Resources/Find the Pointer/Mouth_{CorrectFace[2]}.png");
        Eyes.sprite = Face.Eyes[(int)CorrectFace[0]];
        Nose.sprite = Face.Noses[(int)CorrectFace[1]];
        Mouth.sprite = Face.Mouths[(int)CorrectFace[2]];

        Characteristics.text = $"Eyes: {CorrectFace[0]}\nNose: {CorrectFace[1]}\n" +
            $"Mouth: {CorrectFace[2]}\n\nWanted For:\n"+
            "- Energy Consumption\n- Memory Leakage";

    }

}
