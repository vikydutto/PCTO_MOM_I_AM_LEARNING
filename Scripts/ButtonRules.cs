using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRules : MonoBehaviour
{
    public static void OnMouseOver() {
        /*Menu.bplayButton=true;
        Menu.bMenuHome=true;*/
        Menu.bRulesButton=true;
        Menu.bMenuHome=false;
    }
    public static void OnMouseExit() {
        /*Menu.bMenuHome=true;
        Menu.bplayButton=false;*/
        Menu.bRulesButton=false;
        Menu.bMenuHome=true;
    }
}
