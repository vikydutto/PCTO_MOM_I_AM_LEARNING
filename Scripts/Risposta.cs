using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using TMPro; // header per utilizzare i font carivcati su unity dal programmatore: Text Mash Pro
using UnityEngine.UI; // header per la user interface

public class Risposta : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public TextMeshProUGUI t; // componente font
    public string testo; // testo della risposta: la stringa
    
    void Start() testo =":/"; // testo a caso

    void Update() { // ogni volta che fa l'update
        TextMeshPro p = t.GetComponent<TextMeshPro>(); // nuova variabile che contiene testo e font
        t.text = testo; // si assegna il testo a t
    }
}
