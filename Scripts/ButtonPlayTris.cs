using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Bottone specifico per far startare il gioco del Tris */

public class ButtonPlayTris : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static void OnMouseOver() { // metodo per cui se il cursore è sul pulante farà:
        Tris.bPausePlay = true; // variabile che permette di giocare se messa true
        Tris.bPause = false;
    }
    public static void OnMouseExit() { // metodo per cui se il cursore NON è sul pulante farà:
        Tris.bPausePlay = false;
        Tris.bPause = true; // resterà sulla schermata in cui è al momento
    }
}
