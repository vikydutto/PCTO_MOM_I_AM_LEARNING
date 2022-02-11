using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public static GameObject sfondo;
    public GameObject expGreen;
    public GameObject expRed;
    public static bool right = false;
    void OnCollisionEnter()
    {
        if (explosion.right)
        {
            GameObject p = Instantiate(expGreen, transform.position, transform.rotation);
            p.transform.SetParent(sfondo.transform, false);
        }
        else
        {
            GameObject p = Instantiate(expRed, transform.position, transform.rotation);
            p.transform.SetParent(sfondo.transform, false);
        }
        Destroy(gameObject);
    }
}


