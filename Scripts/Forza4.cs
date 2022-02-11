using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Forza4 : MonoBehaviour
{
    public AudioSource mainMusic, pauseMusic, selezione;
    public GameObject pedinaGialla, pedinaRossa, sfondo, SfondoPausa, pausePlay, pauseExit, sfondoBackButton;
    public GameObject gioco, colonna1, colonna2, colonna3, colonna4, colonna5, colonna6, colonna7;
    public GameObject c1, c2, c3, c4, c5, c6, c7, buttonPause, buttonPlay, buttonExit, vittoriaG1, vittoriaG2;
    private bool bGioco, bcolonna1, bcolonna2, bcolonna3, bcolonna4, bcolonna5, bcolonna6, bcolonna7, bsfondoBackButton;
    private bool exManoChiusa, vittoria, bPause, bPausePlay, bPauseExit, Pausa;
    public CursoreTris cursore;
    private int rCella = 0, fase = 0;
    private float[] vettX = { -420, -295, -165, -39, 89, 210, 335 };
    private float[] vettY = { -494, -375, -249, -120, 10, 134 };
    public ManoTris hand;

    private int exfase;
    private int[,] campo = { { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 } };
    //private int[,] campo = new int[6, 7];
    void Start()
    {
        /*for (int k = 0; k < 6; k++)
        {
            for (int j = 0; j < 7; j++)
            {
                campo[k, j] = 404;
            }
        }*/
        bGioco = true;
        vittoria = false;
        bcolonna1 = false;
        bcolonna2 = false;
        bcolonna3 = false;
        bcolonna4 = false;
        bcolonna5 = false;
        bcolonna6 = false;
        bcolonna7 = false;
        exManoChiusa = false;
        Pausa = false;
        bPause=false;
        bPausePlay=false;
        bPauseExit=false;
        vittoriaG1.SetActive(false);
        vittoriaG2.SetActive(false);
        mainMusic.Play();
    }

    void Update()
    {
        settaSfondi();
        if (!Pausa)
        {
            pauseMusic.Stop();
            if (!vittoria)
            {
                controllaMano();
                if (fase == 0)
                {
                    exfase = 1;
                }
                else
                {
                    exfase = 0;
                }
                if (controllaVittoria(exfase))
                {
                    vittoria = true;
                }
            }
            else
            {
                if(exfase==0){
                    vittoriaG1.SetActive(true);
                }else{
                    vittoriaG2.SetActive(true);
                }
                if (hand.isManoChiusa()&& exManoChiusa==false)
                {
                    selezione.Play();
                    exManoChiusa=true;
                    for (int k = 0; k < 6; k++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            campo[k, j] = 404;
                        }
                    }
                    var clones = GameObject.FindGameObjectsWithTag("clone");
                    foreach (var clone in clones)
                    {
                        Destroy(clone);
                    }
                    vittoriaG1.SetActive(false);
                    vittoriaG2.SetActive(false);
                    vittoria = false;
                }else{
                    exManoChiusa=hand.isManoChiusa();
                }
            }
        }
        else
        {
            mainMusic.Stop();
            if (cursore.isOnQ(buttonPlay))
            {
                bPause = false;
                bPausePlay = true;
                if (hand.isManoChiusa())
                {
                    selezione.Play();
                    mainMusic.Play();
                    exManoChiusa=true;
                    bPausePlay = false;
                    bGioco = true;
                    Pausa = false;
                }
            }
            else
            {
                bPause = true;
                bPausePlay = false;
                if (cursore.isOnQ(buttonExit))
                {
                    bPause = false;
                    bPauseExit = true;
                    if (hand.isManoChiusa())
                    {
                        selezione.Play();
                        bPauseExit = false;
                        bGioco = true;
                        Pausa = false;
                        SceneManager.LoadScene(0);
                    }
                }
                else
                {
                    bPause = true;
                    bPauseExit = false;
                }
            }
        }
    }

    void controllaMano()
    {
        if (cursore.isOnQ(buttonPause))
        {
            bGioco = false;
            bsfondoBackButton = true;
            if (hand.isManoChiusa())
            {
                pauseMusic.Play();
                mainMusic.Stop();
                selezione.Play();
                bsfondoBackButton = false;
                bPause = true;
                Pausa = true;
            }
        }
        else
        {
            bGioco = true;
            bsfondoBackButton = false;
            if (cursore.isOnQ(c1))
            {
                bcolonna1 = true;
                bGioco = false;
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    selezione.Play();
                    exManoChiusa = true;
                    rCella = cellaColonna(0);
                    if (rCella != -1)
                    {
                        campo[rCella, 0] = fase;
                        creaPedina(vettX[0], vettY[5 - rCella], fase);
                        if (fase == 1)
                        {
                            fase = 0;
                        }
                        else
                        {
                            fase += 1;
                        }
                    }
                }
            }
            else
            {
                bcolonna1 = false;
                bGioco = true;
                if (cursore.isOnQ(c2))
                {
                    bcolonna2 = true;
                    bGioco = false;
                    if (hand.isManoChiusa() && exManoChiusa == false)
                    {
                        selezione.Play();
                        exManoChiusa = true;
                        rCella = cellaColonna(1);
                        if (rCella >= 0)
                        {
                            campo[rCella, 1] = fase;
                            creaPedina(vettX[1], vettY[5 - rCella], fase);
                            if (fase == 1)
                            {
                                fase = 0;
                            }
                            else
                            {
                                fase += 1;
                            }
                        }
                    }
                }
                else
                {
                    bcolonna2 = false;
                    bGioco = true;
                    if (cursore.isOnQ(c3))
                    {
                        bcolonna3 = true;
                        bGioco = false;
                        if (hand.isManoChiusa() && exManoChiusa == false)
                        {
                            selezione.Play();
                            exManoChiusa = true;
                            rCella = cellaColonna(2);
                            if (rCella >= 0)
                            {
                                campo[rCella, 2] = fase;
                                creaPedina(vettX[2], vettY[5 - rCella], fase);
                                if (fase == 1)
                                {
                                    fase = 0;
                                }
                                else
                                {
                                    fase += 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        bcolonna3 = false;
                        bGioco = true;
                        if (cursore.isOnQ(c4))
                        {
                            bcolonna4 = true;
                            bGioco = false;
                            if (hand.isManoChiusa() && exManoChiusa == false)
                            {
                                selezione.Play();
                                exManoChiusa = true;
                                rCella = cellaColonna(3);
                                if (rCella >= 0)
                                {
                                    campo[rCella, 3] = fase;
                                    creaPedina(vettX[3], vettY[5 - rCella], fase);
                                    if (fase == 1)
                                    {
                                        fase = 0;
                                    }
                                    else
                                    {
                                        fase += 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            bcolonna4 = false;
                            bGioco = true;
                            if (cursore.isOnQ(c5))
                            {
                                bcolonna5 = true;
                                bGioco = false;
                                if (hand.isManoChiusa() && exManoChiusa == false)
                                {
                                    selezione.Play();
                                    exManoChiusa = true;
                                    rCella = cellaColonna(4);
                                    if (rCella >= 0)
                                    {
                                        campo[rCella, 4] = fase;
                                        creaPedina(vettX[4], vettY[5 - rCella], fase);
                                        if (fase == 1)
                                        {
                                            fase = 0;
                                        }
                                        else
                                        {
                                            fase += 1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                bcolonna5 = false;
                                bGioco = true;
                                if (cursore.isOnQ(c6))
                                {
                                    bcolonna6 = true;
                                    bGioco = false;
                                    if (hand.isManoChiusa() && exManoChiusa == false)
                                    {
                                        selezione.Play();
                                        exManoChiusa = true;
                                        rCella = cellaColonna(5);
                                        if (rCella >= 0)
                                        {
                                            campo[rCella, 5] = fase;
                                            creaPedina(vettX[5], vettY[5 - rCella], fase);
                                            if (fase == 1)
                                            {
                                                fase = 0;
                                            }
                                            else
                                            {
                                                fase += 1;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bcolonna6 = false;
                                    bGioco = true;
                                    if (cursore.isOnQ(c7))
                                    {
                                        bcolonna7 = true;
                                        bGioco = false;
                                        if (hand.isManoChiusa() && exManoChiusa == false)
                                        {
                                            selezione.Play();
                                            exManoChiusa = true;
                                            rCella = cellaColonna(6);
                                            if (rCella >= 0)
                                            {
                                                campo[rCella, 6] = fase;
                                                creaPedina(vettX[6], vettY[5 - rCella], fase);
                                                if (fase == 1)
                                                {
                                                    fase = 0;
                                                }
                                                else
                                                {
                                                    fase += 1;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bcolonna7 = false;
                                        bGioco = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (exManoChiusa == true && !hand.isManoChiusa())
        {
            exManoChiusa = false;
        }
    }
    void settaSfondi()
    {
        gioco.SetActive(bGioco);
        sfondoBackButton.SetActive(bsfondoBackButton);
        colonna1.SetActive(bcolonna1);
        colonna2.SetActive(bcolonna2);
        colonna3.SetActive(bcolonna3);
        colonna4.SetActive(bcolonna4);
        colonna5.SetActive(bcolonna5);
        colonna6.SetActive(bcolonna6);
        colonna7.SetActive(bcolonna7);
        SfondoPausa.SetActive(bPause);
        pauseExit.SetActive(bPauseExit);
        pausePlay.SetActive(bPausePlay);
    }
    int cellaColonna(int c)
    {
        int k = 5;
        while (campo[k, c] != 404 && k > 0)
        {
            k -= 1;
        }
        if (campo[k, c] != 404)
        {
            k = -1;
        }
        return k;
    }
    void creaPedina(float x, float y, int ped)
    {
        if (ped == 0)
        {
            GameObject p = Instantiate(pedinaGialla, new Vector3(x, y, pedinaGialla.transform.position.z), transform.rotation);
            p.transform.SetParent(sfondo.transform, false);
        }
        else
        {
            GameObject p = Instantiate(pedinaRossa, new Vector3(x, y, pedinaRossa.transform.position.z), transform.rotation);
            p.transform.SetParent(sfondo.transform, false);
        }

    }
    bool is4(int r, int c)
    {
        bool win = false;
        if (campo[r, c] != 404)
        {
            if (r >= 3)
            {
                int k = 0;
                win = true;
                while (k <= 3 && win == true)
                {
                    if (campo[r - k, c] != campo[r, c])
                    { win = false; }
                    k += 1;
                }
                if (win == true) { return true; }
                if (c >= 3)
                {
                    k = 0;
                    win = true;
                    while (k <= 3 && win == true)
                    {
                        if (campo[r - k, c - k] != campo[r, c])
                        {
                            win = false;
                        }
                        k += 1;
                    }
                    if (win == true) return true;
                }
                if (c <= 3)
                {
                    k = 0;
                    win = true;
                    while (k <= 3 && win == true)
                    {
                        if (campo[r - k, c + k] != campo[r, c])
                        {
                            win = false;
                        }
                        k += 1;
                    }
                    if (win == true) return true;
                }
            }
            if (c <= 3)
            {
                int k = 0;
                win = true;
                while (k <= 3 && win == true)
                {
                    if (campo[r, c + k] != campo[r, c])
                    {
                        win = false;
                    }
                    k += 1;
                }
                if (win == true) return true;
            }
        }
        return win;
    }
    bool controllaVittoria(int ped)
    {
        int righe = 5;
        int colonne = 0;
        bool vittoria = false;
        while (righe >= 0 && vittoria == false)
        {
            colonne=0;
            while (colonne < 7 && vittoria == false)
            {
                if (campo[righe, colonne] == ped)
                {
                    vittoria = is4(righe, colonne);
                }
                colonne += 1;
            }
            righe -= 1;
        }
        return vittoria;
    }
}
