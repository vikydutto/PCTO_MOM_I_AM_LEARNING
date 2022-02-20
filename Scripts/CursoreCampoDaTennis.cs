using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.UI; // header per la user interface

/** Cursore della scena/gioco del campo da tennis: Quiz*/

public class CursoreCampoDaTennis : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public ManoCampoDaTennis hand; // mano
    public GameObject r1, r2,r3,r4; // risposte
    private float x;
    private float y; // posizione x e y
    
    void Start() {
        y = gameObject.transform.position.y;
        x = gameObject.transform.position.x; // posizione della mano: x, y
    }
    
    void Update() { // bisogna sempre fare l'update perché la mano dell'utente di sicuro non sta ferma
        gameObject.transform.position = new Vector3(x, y, transform.position.z); // update della posizione della mano
    }

    public void setX(float x) this.x = x;
    public void setY(float y) this.y = y;
    public float getX() return x;
    public float getY() return y; // setter e getter della posizione della mano

    public bool isOnQ(GameObject q) { // isOnQ della classe Cursore, metodo per capire se il mouse è su un quadrato == risposta
        float width = q.GetComponent<RectTransform>().rect.width;
        float height = q.GetComponent<RectTransform>().rect.height;
        float cordx = q.transform.position.x*10;
        float cordy = q.transform.position.y*10;
        return gameObject.transform.position.x*10 > cordx - width / 2 && gameObject.transform.position.x*10 < cordx + width / 2 && gameObject.transform.position.y*10 > cordy - height / 2 && gameObject.transform.position.y *10< cordy + height / 2;
    }
    public bool isOnRisposta1() return isOnQ(r1);
    public bool isOnRisposta2() return isOnQ(r2);
    public bool isOnRisposta3() return isOnQ(r3); 
    public bool isOnRisposta4() return isOnQ(r4); // metodi per capire se è su una risposta: rihiamo dei metodi della classe stessa
}
