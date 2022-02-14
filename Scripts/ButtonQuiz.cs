using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Pulsante specifico per far partire il minigioco del Quiz, gioco originale del team */
public class ButtonQuiz : MonoBehaviour{
    public static void OnMouseOver(){
        Menu.bQuizButon=true;
        Menu.bGamesMenu=false;
    }
    public static void OnMouseExit(){
        Menu.bQuizButon=false;
        Menu.bGamesMenu=true;
    }
}
