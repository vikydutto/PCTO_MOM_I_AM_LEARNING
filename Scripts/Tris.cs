using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tris : MonoBehaviour
{
    public AudioSource mainMusic, pauseMusic, selezione;
    public GameObject q1x, q1o, q2x, q2o, q3x, q3o, q4x, q4o, q5x, q5o, q6x, q6o, q7x, q7o, q8x, q8o, q9x, q9o, buttonPause, buttonPlay, buttonExit;
    public ManoTris hand;
    public CursoreTris c;
    private int[] campo = { 404, 404, 404, 404, 404, 404, 404, 404, 404 };
    public static bool bTris, bPause, bPausePlay, bPauseExit;
    public GameObject tris, pause, pausePlay, pauseExit;
    private int turno = 0;
    private bool victory = false, PauseMenu = false;
    public GameObject vittoriaG1, vittoriaG2;
    private bool exManoChiusa = false;
    private int exTurno = 0;
    void Start()
    {
        bTris = true;
        bPause = false;
        bPauseExit = false;
        bPausePlay = false;
        tris.SetActive(bTris);
        pause.SetActive(bPause);
        pauseExit.SetActive(bPauseExit);
        pausePlay.SetActive(bPausePlay);
        q1x.SetActive(false);
        q1o.SetActive(false);
        q2x.SetActive(false);
        q2o.SetActive(false);
        q3x.SetActive(false);
        q3o.SetActive(false);
        q4x.SetActive(false);
        q4o.SetActive(false);
        q5x.SetActive(false);
        q5o.SetActive(false);
        q6x.SetActive(false);
        q6o.SetActive(false);
        q7x.SetActive(false);
        q7o.SetActive(false);
        q8x.SetActive(false);
        q8o.SetActive(false);
        q9x.SetActive(false);
        q9o.SetActive(false);
        vittoriaG1.SetActive(false);
        vittoriaG2.SetActive(false);
        mainMusic.Play();
    }
    void Update()
    {
        tris.SetActive(bTris);
        pause.SetActive(bPause);
        pauseExit.SetActive(bPauseExit);
        pausePlay.SetActive(bPausePlay);

        if (PauseMenu)
        {
            controllo();
        }
        else
        {
            if (victory)
            {
                if (exTurno == 0)
                {
                    vittoriaG1.SetActive(true);
                }
                else
                {
                    vittoriaG2.SetActive(true);
                }
                setCampo();
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    selezione.Play();
                    vittoriaG2.SetActive(false);
                    vittoriaG1.SetActive(false);
                    exManoChiusa = true;
                    victory = false;
                    for (int k = 0; k < 9; k++)
                    {
                        campo[k] = 404;
                    }
                    Start();
                }
                else
                {
                    exManoChiusa = hand.isManoChiusa();
                }
            }
            else
            {
                if (isADraw())
                {
                    for (int k = 0; k < 9; k++)
                    {
                        campo[k] = 404;
                    }
                    Start();
                }
                else
                {
                    exTurno = turno;
                    setCampo();
                    controllo();
                    victory = controlloVittoria(exTurno);
                }
            }
        }

    }
    void setCampo()
    {
        for (int k = 0; k < 9; k++)
        {
            if (campo[k] == 1)
            {
                switch (k)
                {
                    case 0:
                        q1x.SetActive(false);
                        q1o.SetActive(true);
                        break;
                    case 1:
                        q2x.SetActive(false);
                        q2o.SetActive(true);
                        break;
                    case 2:
                        q3x.SetActive(false);
                        q3o.SetActive(true);
                        break;
                    case 3:
                        q4x.SetActive(false);
                        q4o.SetActive(true);
                        break;
                    case 4:
                        q5x.SetActive(false);
                        q5o.SetActive(true);
                        break;
                    case 5:
                        q6x.SetActive(false);
                        q6o.SetActive(true);
                        break;
                    case 6:
                        q7x.SetActive(false);
                        q7o.SetActive(true);
                        break;
                    case 7:
                        q8x.SetActive(false);
                        q8o.SetActive(true);
                        break;
                    case 8:
                        q9x.SetActive(false);
                        q9o.SetActive(true);
                        break;
                }
            }
            if (campo[k] == 0)
            {
                switch (k)
                {
                    case 0:
                        q1x.SetActive(true);
                        q1o.SetActive(false);
                        break;
                    case 1:
                        q2x.SetActive(true);
                        q2o.SetActive(false);
                        break;
                    case 2:
                        q3x.SetActive(true);
                        q3o.SetActive(false);
                        break;
                    case 3:
                        q4x.SetActive(true);
                        q4o.SetActive(false);
                        break;
                    case 4:
                        q5x.SetActive(true);
                        q5o.SetActive(false);
                        break;
                    case 5:
                        q6x.SetActive(true);
                        q6o.SetActive(false);
                        break;
                    case 6:
                        q7x.SetActive(true);
                        q7o.SetActive(false);
                        break;
                    case 7:
                        q8x.SetActive(true);
                        q8o.SetActive(false);
                        break;
                    case 8:
                        q9x.SetActive(true);
                        q9o.SetActive(false);
                        break;
                }
            }
        }
    }
    void controllo()
    {
        if (!PauseMenu)
        {
            if (exManoChiusa == false)
            {
                if (c.isOnQ(q1x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[0] == 404)
                        {
                            campo[0] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[0] == 404)
                        {
                            campo[0] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q2x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[1] == 404)
                        {
                            campo[1] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[1] == 404)
                        {
                            campo[1] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q3x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[2] == 404)
                        {
                            campo[2] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[2] == 404)
                        {
                            campo[2] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q4x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[3] == 404)
                        {
                            campo[3] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[3] == 404)
                        {
                            campo[3] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q5x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[4] == 404)
                        {
                            campo[4] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[4] == 404)
                        {
                            campo[4] = 1;
                            turno = 0;
                        }
                    }
                }

                if (c.isOnQ(q6x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[5] == 404)
                        {
                            campo[5] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[5] == 404)
                        {
                            campo[5] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q7x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[6] == 404)
                        {
                            campo[6] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[6] == 404)
                        {
                            campo[6] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q8x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[7] == 404)
                        {
                            campo[7] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[7] == 404)
                        {
                            campo[7] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q9x) && hand.isManoChiusa())
                {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0)
                    {
                        if (campo[8] == 404)
                        {
                            campo[8] = 0;
                            turno = 1;
                        }
                    }
                    else
                    {
                        if (campo[8] == 404)
                        {
                            campo[8] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(buttonPause) && hand.isManoChiusa())
                {
                    selezione.Play();
                    mainMusic.Stop();
                    pauseMusic.Play();
                    exManoChiusa = true;
                    bPause = true;
                    bTris = false;
                    PauseMenu = true;
                }
            }
            else
            {
                exManoChiusa = hand.isManoChiusa();
            }
        }
        else
        {
            if (c.isOnQ(buttonPlay))
            {
                ButtonPlayTris.OnMouseOver();
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    selezione.Play();
                    pauseMusic.Stop();
                    mainMusic.Play();
                    exManoChiusa = true;
                    bPausePlay = false;
                    bTris = true;
                    PauseMenu = false;
                }
                else
                {
                    exManoChiusa = hand.isManoChiusa();
                }
            }
            else
            {
                ButtonPlayTris.OnMouseExit();
                if (c.isOnQ(buttonExit))
                {
                    ButtonExitTris.OnMouseOver();
                    if (hand.isManoChiusa() && exManoChiusa == false)
                    {
                        selezione.Play();
                        SceneManager.LoadScene(0);
                    }
                    else
                    {
                        exManoChiusa = hand.isManoChiusa();
                    }
                }
                else
                {
                    ButtonExitTris.OnMouseExit();
                }
            }
        }
    }

    bool controlloVittoria(int turno)
    {
        int[,] comb = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 4, 8 }, { 2, 4, 6 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 } };
        bool trov = false;
        int k = 0;
        while (trov == false && k < 8)
        {

            if (campo[comb[k, 0]] == turno && campo[comb[k, 1]] == turno && campo[comb[k, 2]] == turno)
            {
                trov = true;
            }
            k += 1;
        }
        return trov;
    }
    bool isADraw()
    {
        bool tro = false;
        int k = 0;
        while (k < 9 && tro == false)
        {
            tro = (campo[k] == 404);
            k++;
        }
        return !tro;
    }
}