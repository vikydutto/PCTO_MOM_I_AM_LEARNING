using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Pulsante per entrare nel menù opzioni */
public class ButtonOption : MonoBehaviour{
    public static void OnMouseOver() {
        /*Menu.bplayButton=true;
        Menu.bMenuHome=true;*/
        Menu.boptionButton=true;
        Menu.bMenuHome=false;
    }
    public static void OnMouseExit() {
        /*Menu.bMenuHome=true;
        Menu.bplayButton=false;*/
        Menu.boptionButton=false;
        Menu.bMenuHome=true;
    }
}
