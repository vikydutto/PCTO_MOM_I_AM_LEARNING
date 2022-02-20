using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Pulsante in generale per far startare il minigioco, qualsiasi esso sia */

public class ButtonPlay : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static void OnMouseOver() { // questo metodo quando il mouse arriva sul pulsante fa si che
        /*Menu.bplayButton=true;
        Menu.bMenuHome=true;*/
        Menu.bplayButton = true; // questa variabile diventi true per cambiare scena e quella successiva per non creare bugs
        Menu.bMenuHome = false;
    }
    public static void OnMouseExit() { // se il mouse non è sul pulsante
        /*Menu.bMenuHome=true;
        Menu.bplayButton=false;*/
        Menu.bplayButton = false;
        Menu.bMenuHome = true; // variabile che diventa true per restare alla schermata del menù home, ovvero quella iniziale
    }
}
