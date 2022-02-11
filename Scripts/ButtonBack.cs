using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBack : MonoBehaviour
{
   public static void OnMouseOver()
    {
        Menu.bBackButton=true;
        Menu.bGamesMenu=false;
    }
    public static void OnMouseExit()
    {
        Menu.bBackButton=false;
        Menu.bGamesMenu=true;
    }
}
