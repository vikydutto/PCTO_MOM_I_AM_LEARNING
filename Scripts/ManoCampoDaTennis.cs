using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.UI; // header per la user interface

public class ManoCampoDaTennis : MonoBehaviour{ // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public GameObject palmo, dito; // palmo e dito per la mano nel gioc del campo da tennis
    private float sx,sy,sz, dx,dy,dz; // coordinate del palmo nella realtà: rilevate dall'UltraLeap
    private float x = 0, y = 0; // coordinate del cursore iniazializzate a 0
    public CursoreCampoDaTennis cursore; // cursore di tipo CursoreCampoDaTennis (classe)

    void Update() {
        sx = palmo.transform.position.x;
        sy = palmo.transform.position.y;
        sz = palmo.transform.position.z; // coordinate del palmo
        dx = dito.transform.position.x;
        dy = dito.transform.position.y;
        dz = dito.transform.position.z; // coordinate del dito medio

        x = (sx + 90)*1920/60-1920;
        y = (sy + 70)*1080/55f-1080; // numeri che si aggiungono, sottraaggono, moltiplicano per regolare la posizione e la velocità del cursore sulla scena
        cursore.setX(x);
        cursore.setY(y); // si passano i valori al cursore
    }

    public bool isManoChiusa() return Mathf.Sqrt((sx-dx)*(sx-dx)+(sy-dy)*(sy-dy)+(sz-dz)*(sz-dz))<8; // metodo per rilevare se la mano è chiusa
}
