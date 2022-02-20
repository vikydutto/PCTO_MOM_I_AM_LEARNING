using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.UI; // header per la user interface

/** Cursore del gioco del Tris */

public class CursoreTris : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    private float x;
    private float y; // coordinate per la posizione della mano: float come sempre
    
    void Start(){
        y = gameObject.transform.position.y;
        x = gameObject.transform.position.x; // dall'UltraLeap alla posizione nella scena
    }
    
    void Update(){ // update continuo della posizione della mano, come negli altri script dei cursori
        gameObject.transform.position = new Vector3(x, y, transform.position.z);
    }

    public void setX(float x) this.x = x;
    public void setY(float y) this.y = y;
    public float getX() return x;
    public float getY()return y; // setter e getter della mano
    
    public bool isOnQ(GameObject q) // metodo per capire se la mano è su uno dei 9 quadrati del mini-game
    {
        float width = q.GetComponent<RectTransform>().rect.width;
        float height = q.GetComponent<RectTransform>().rect.height;
        float cordx = q.transform.position.x*10;
        float cordy = q.transform.position.y*10;
        return gameObject.transform.position.x*10 > cordx - width / 2 && gameObject.transform.position.x*10 < cordx + width / 2 && gameObject.transform.position.y*10 > cordy - height / 2 && gameObject.transform.position.y *10< cordy + height / 2;
    }
}
