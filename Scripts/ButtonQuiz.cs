using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Pulsante specifico per far partire il minigioco del Quiz, gioco originale del team */

public class ButtonQuiz : MonoBehaviour{ // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static void OnMouseOver(){ // metodo che viene chiamato quando il mouse è sul bottone apposito
        Menu.bQuizButon = true; // se questo metodo viene chiamato questa variabile viene impostata a true per far partire il gioco del quiz
        Menu.bGamesMenu = false; // questa viene messa a false per non creare bugs
    }
    public static void OnMouseExit(){ // metodo che viene chiamato quando il mouse non è sul pulsante per far "startare" il minigioco main della startup
        Menu.bQuizButon = false; // questa variabile viene messa a false così che non continui con la scena del quiz
        Menu.bGamesMenu = true; // resta sulla schermata della scelta dei giochi
    }
}
