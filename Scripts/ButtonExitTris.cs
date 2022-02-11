using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExitTris : MonoBehaviour
{
    public static void OnMouseOver() {
        Tris.bPauseExit=true;
        Tris.bPause=false;
    }
    public static void OnMouseExit() {
        Tris.bPauseExit=false;
        Tris.bPause=true;
    }
}
