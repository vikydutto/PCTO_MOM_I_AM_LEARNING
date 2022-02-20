using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Bottone per entrare nel minigame di forza 4 */

public class ButtonForza4 : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static void OnMouseOver() { // metodo per vedere se la mano è sopra all'oggetto del bottone per iniziare a giocare a forza quattro: e quindi cambiare scena
        Menu.bForza4Button = true; // si fa il "turn on" di questo bottone e quindi poi si cambia scena
        Menu.bGamesMenu = false;
    }
    public static void OnMouseExit() { // metodo per non cambiare scena
        Menu.bForza4Button = false;
        Menu.bGamesMenu = true; // la schermata non cambia: schermata del menù dei giochi
    }
}
