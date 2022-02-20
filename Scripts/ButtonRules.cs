using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Pulsante delle regole */

public class ButtonRules : MonoBehaviour{ // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static void OnMouseOver() { // metodo che viene chiamato quando il cursore si posiziona sul pulsante delle regole
        /*Menu.bplayButton=true;
        Menu.bMenuHome=true;*/
        Menu.bRulesButton = true; // si mette questa variabile a true per far passare alla schermata delle regole il gioco
        Menu.bMenuHome = false; // questa la si imposta a false per non creare bug
    }
    public static void OnMouseExit() { // metodo chiamato quando il cursore NON è sul pulsante opzioni
        /*Menu.bMenuHome=true;
        Menu.bplayButton=false;*/
        Menu.bRulesButton = false; // questa la si imposta a false per non creare bug
        Menu.bMenuHome = true; // variabile che se impostata a true porta a far vedere la scena della home: schermata iniziale
    }
}
