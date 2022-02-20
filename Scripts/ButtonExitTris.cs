using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Bottone "Back"/"Indietro" gioco Tris */

public class ButtonExitTris : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static void OnMouseOver() { // metodo per vedere se la mano è sopra all'oggetto del bottone per uscire dal gioco del Tris
        Tris.bPauseExit = true; // la variabile diventa true -> cambia la schermata: torna al menù di pausa
        Tris.bPause = false;
    }
    public static void OnMouseExit() { // metodo per verificare se la mano non è sopra il button
        Tris.bPauseExit = false;
        Tris.bPause = true; // la scena continua a runnare
    }
}
