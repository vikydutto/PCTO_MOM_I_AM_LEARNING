using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTris : MonoBehaviour
{
    public static void OnMouseOver()
    {
        Menu.bTrisButton=true;
        Menu.bGamesMenu=false;
    }
    public static void OnMouseExit()
    {
        Menu.bTrisButton=false;
        Menu.bGamesMenu=true;
    }
}