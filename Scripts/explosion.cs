using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices

/** Classe che controlla l'esplosione delle parti dietro la scena del gioco del quiz */

public class explosion : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public static GameObject sfondo; // sfondo della scena
    public GameObject expGreen, expRed; // esplosione verde e rossa in base alla correttezza della risposta dell'utente
    public static bool right = false; // booleana per la risposta, vera o scorretta
    
    void OnCollisionEnter() { // se la pallina arriva e tocca l'oggetto dietro al quadrato della risposta data
        if (explosion.right) { // se la risposta data è corretta
            GameObject p = Instantiate(expGreen, transform.position, transform.rotation); // pallina fa esplodere di verde l'oggetto dietro lo sfondo del quiz
        } else { // se la risposta data NON è corretta
            GameObject p = Instantiate(expRed, transform.position, transform.rotation); // pallina fa esplodere di rosso l'oggetto dietro lo sfondo del quiz
        }
        p.transform.SetParent(sfondo.transform, false); // la pallina adesso è come se non avesse una classe genitore
        Destroy(gameObject); // distruzione dell'oggetto p 
    }
}


