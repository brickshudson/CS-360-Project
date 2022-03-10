//Written by The-Architect01
using UnityEngine;

/// <summary>Contains all DropCapture elements for a given menu</summary>
public class SnapPositions : MonoBehaviour
{
    #region Public Variables
    public DropCapture Snap1;
    public DropCapture Snap2;
    public DropCapture Snap3;
    public DropCapture Snap4;
    public DropCapture Snap5;
    public DropCapture Snap6;
    public DropCapture Snap7;
    public DropCapture Snap8;
    public DropCapture Snap9;
  
    /// <summary>Returns an array of all of the contained values</summary>
    public DropCapture[] Snaps {
        get {
            return new DropCapture[] {
                Snap1,
                Snap2,
                Snap3,
                Snap4,
                Snap5,
                Snap6,
                Snap7,
                Snap8,
                Snap9,
            };
        }
    }
    #endregion
    public void UpdateValues() {
        for(int i = 0; i < Snaps.Length; i++) {
            if (Snaps[i].HasValue && Snaps[i].IsLast) {
                Snaps[i].IsLast = false;
                Snaps[i + 1].IsLast = true;
                break;
            }
        }
    }
}
