using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.UI; // header per la user interface

/** Mano per il gioco del tris */

public class ManoTris : MonoBehaviour {  // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public GameObject palmo, dito; // palmo e dito per la mano nel mini gioco del Tris
    private float sx,sy,sz, dx,dy,dz; // coordinate del palmo nella realtà: rilevate dall'UltraLeap
    public CursoreTris cursore; // il cursore della classe CursoreTris
    private float x;
    private float y; // coordinate del cursore
    // stessi attributi per anche le altre mani
    
    void Update() {
        sx=palmo.transform.position.x;
        sy=palmo.transform.position.y;
        sz=palmo.transform.position.z; // coordinate del palmo
        dx=dito.transform.position.x;
        dy=dito.transform.position.y;
        dz=dito.transform.position.z; // coordinate del dito medio

        x= ((sx + 75.0f)*2400/450.0f)-130;
        y= (sy + 40)*1500/220-140; // numeri per regolazre posizione e velocità cursore nel gioco del tris
        cursore.setX(x);
        cursore.setY(y); // si passano i valori al cursore

    }

    public bool isManoChiusa() return Mathf.Sqrt((sx-dx)*(sx-dx)+(sy-dy)*(sy-dy)+(sz-dz)*(sz-dz))<10; // metodo per rilevare se la mano è chiusa
}
