using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Risposta : MonoBehaviour
{
    public TextMeshProUGUI t;
    public string testo;
    void Start()
    {
        testo=":/";
    }

    void Update()
    {
        TextMeshPro p = t.GetComponent<TextMeshPro>();
        t.text=testo;
        
    }
}
