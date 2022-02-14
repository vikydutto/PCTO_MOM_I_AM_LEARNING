using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Bottone per entrare nel minigame di forza 4 */
public class ButtonForza4 : MonoBehaviour{
    public static void OnMouseOver(){
        Menu.bForza4Button=true;
        Menu.bGamesMenu=false;
    }
    public static void OnMouseExit(){
        Menu.bForza4Button=false;
        Menu.bGamesMenu=true;
    }
}
