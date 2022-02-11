using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayTris : MonoBehaviour
{
    public static void OnMouseOver() {
        Tris.bPausePlay=true;
        Tris.bPause=false;
    }
    public static void OnMouseExit() {
        Tris.bPausePlay=false;
        Tris.bPause=true;
    }
}
