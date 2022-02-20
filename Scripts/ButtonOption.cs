using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Pulsante per entrare nel menù opzioni */

public class ButtonOption : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static void OnMouseOver() { // se il cursore è sul bottone delle opzioni la scena cambierà andando sulla shermata richiesta dall'utente
        /*Menu.bplayButton=true;
        Menu.bMenuHome=true;*/
        Menu.boptionButton = true; // se il cursore è sul bottone delle opzioni allora questa variabile sarà true e quindi poi cambierà scena di gioco
        Menu.bMenuHome = false;
    }
    public static void OnMouseExit() { // se il mouse non è sul bottone questo metodo farà sì che
        /*Menu.bMenuHome=true;
        Menu.bplayButton=false;*/
        Menu.boptionButton = false;
        Menu.bMenuHome = true; // questa variabile sia true e la boptionButton sia false così da non cambiare schermata di gioco
    }
}
