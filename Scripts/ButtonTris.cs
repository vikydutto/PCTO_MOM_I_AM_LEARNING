using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Bottone per far partire il minigioco specifico del tris */

public class ButtonTris : MonoBehaviour{ // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static void OnMouseOver(){ // se il cursore è sopra il pulsante questo metodo viene invocato
        Menu.bTrisButton = true; // questa variabile diventa true per cambiare scena e fare partire il gioco del tris
        Menu.bGamesMenu = false; // questa viene messa a false per non tornare al menù principale
    }
    public static void OnMouseExit(){ // metodo invocato quando il mouse non è sul pulsante
        Menu.bTrisButton = false; // per non far artire il gioco
        Menu.bGamesMenu = true; // per tornare alla schermata del menù principale
    }
}
