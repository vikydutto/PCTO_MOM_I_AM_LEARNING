using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

public class MuoviPallina : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static bool isWaiting; // statiche in modo che sia comune a tutti sappiano che la pallina è ferma
    public static Vector3 answer, answer1, answer2, answer3, answer4; // ogni risposta più quella per "attivarle"
    public float speed; // velocità della pallina
    private int fase; // fase del gioco

    void Start(){ // quando appare la schermata del gioco del quiz
        fase = 0; // fase iniziale
        isWaiting = false;
        answer1 = new Vector3(-68,15,105); // Vector3 (daDoveParte, doveArriva, velocità)
        answer2 = new Vector3(71,15,105);
        answer3 = new Vector3(-68,40,105);
        answer4 = new Vector3(71,40,105); // settaggio delle risposte e delle loro diumensioni
    }
    
    void Update() {
        if(!isWaiting){ // se la pallina non sta aspettando
            Vector3 a,b; // si creano due variabili
            if(fase == 0){ // se la fase è ancora quella iniziale
                a = transform.position; // si modifica la posizione
                b = new Vector3(0,-10,65); // posizione al centro per quando non sta aspettando
                transform.position = Vector3.Lerp(a,b,speed); // la pallina si muove in base al metodo Learp
                if(Mathf.Abs(b.y-transform.position.y) <= speed * 2){ // si trasforma il numero in valore assoluto
                    isWaiting = true;
                    fase = 1; // si cambiano le variabili
                }
            }else{ // se sta aspettando
                a = transform.position;
                b = answer; // la b è la destinazione: answer è la risposta in generale
                transform.position = Vector3.Lerp(a,b,speed); // la pallina va nella risposta
            }
        
        }
    }
}
