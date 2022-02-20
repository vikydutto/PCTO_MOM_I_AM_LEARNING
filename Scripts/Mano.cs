using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.UI; // header per la user interface

/** Script per la classe Mano generale */

public class Mano : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public GameObject palmo, dito; // oggetti del gioco che rilevano la posizione del palmo della mano e del dito medio
    private float sx, sy, sz, dx, dy, dz; // variabili per le posizioni del palmo e del dito
    public Cursore cursore; // cursore della classe Cursore

    // Update is called once per frame
    void Update(){
        sx = palmo.transform.position.x;
        sy = palmo.transform.position.y;
        sz = palmo.transform.position.z; // posizione del palmo: coordinate x, y, z
        dx = dito.transform.position.x;
        dy = dito.transform.position.y;
        dz = dito.transform.position.z; // posizione del dito medio: coordinate x, y, z

        float x = (sx + 624.2f)*1920/0.2f-1920;
        float y = (sy + 472.14f)*1080/0.10f-1080; // variabili a cui sono stati sommati, sottratti, moltiplicati e divisi certi numeri per avere una posizione consona all'interno della scena
        cursore.setX(x);
        cursore.setY(y); // al cursore sono state date dunque le coordinate calcolate da quelle rilevate dall'UltraLeap

       //Debug.Log(sy.ToString()+"---"+y.ToString()); 
       /*if(isManoChiusa()){
           Debug.Log("Mano chiusa!!"); // righe di cosice usate per vedere se il codice era giusto
           playButton.GetComponent<Button>().onClick.Invoke();
       }*/
    }

    public bool isManoChiusa() return Mathf.Sqrt((sx-dx)*(sx-dx)+(sy-dy)*(sy-dy)+(sz-dz)*(sz-dz))<120f; // calcolo per vedere se la mano è chiusa
}
