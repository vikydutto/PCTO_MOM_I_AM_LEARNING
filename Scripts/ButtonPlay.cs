using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public static void OnMouseOver() {
        /*Menu.bplayButton=true;
        Menu.bMenuHome=true;*/
        Menu.bplayButton=true;
        Menu.bMenuHome=false;
    }
    public static void OnMouseExit() {
        /*Menu.bMenuHome=true;
        Menu.bplayButton=false;*/
        Menu.bplayButton=false;
        Menu.bMenuHome=true;
    }
}
