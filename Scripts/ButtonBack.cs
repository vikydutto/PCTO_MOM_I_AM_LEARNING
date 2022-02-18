using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Controllo della puntatore sullo schermo */

public class ButtonBack : MonoBehaviour{ // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
   public static void OnMouseOver(){ // metodo per vedere se la mano è sopra all'oggetto del bottone per andare indietro
        Menu.bBackButton = true; // la variabile diventa true -> cambia la schermata
        Menu.bGamesMenu = false;
   }
    public static void OnMouseExit(){ // metodo per verificare se la mano non è sopra il button
        Menu.bBackButton = false;
        Menu.bGamesMenu = true; // la variabile diventa true -> non cambia la schermata
    }
}
