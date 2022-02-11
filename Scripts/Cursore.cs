using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cursore : MonoBehaviour
{
    public AudioSource SuonoSelezione;
    public GameObject menuHome, optionMenu, optionIta, optionEng, optionBack;
    public Button PlayButton, OptionButton, QuizButton, TrisButton, Forza4Button, BackButton, ItaButton, EngButton, BackOption;
    public Mano hand;
    private float x;
    private float y;
    private int fase;

    public static int lingua=0;
    private bool exManoChiusa;
    void Start()
    {
        y = gameObject.transform.position.y;
        x = gameObject.transform.position.x;
        fase = 0;
        exManoChiusa = false;
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(x, y, transform.position.z);

        if (fase == 0)
        {
            if (isOnButton(PlayButton))
            {
                ButtonPlay.OnMouseOver();
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    SuonoSelezione.Play();
                    fase = 1;
                    Menu.bMenuHome = false;
                    Menu.bplayButton = false;
                    Menu.bGamesMenu = true;
                    exManoChiusa = true;
                }
            }
            else
            {
                ButtonPlay.OnMouseExit();
                if (isOnButton(OptionButton))
                {
                    ButtonOption.OnMouseOver();
                    if (hand.isManoChiusa() && exManoChiusa == false)
                    {
                        SuonoSelezione.Play();
                        exManoChiusa = true;
                        menuHome.SetActive(false);
                        optionMenu.SetActive(true);
                        fase = 2;
                    }
                }
                else
                {
                    ButtonOption.OnMouseExit();
                }
            }
        }
        if (fase == 1)
        {
            if (isOnButton(QuizButton))
            {
                ButtonQuiz.OnMouseOver();
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    SuonoSelezione.Play();
                    SceneManager.LoadScene(1);
                }

            }
            else
            {
                ButtonQuiz.OnMouseExit();
                if (isOnButton(TrisButton))
                {
                    ButtonTris.OnMouseOver();
                    ButtonQuiz.OnMouseOver();
                    if (hand.isManoChiusa() && exManoChiusa == false)
                    {
                        SuonoSelezione.Play();
                        SceneManager.LoadScene(2);
                    }
                }
                else
                {
                    ButtonTris.OnMouseExit();
                    if (isOnButton(Forza4Button))
                    {
                        ButtonForza4.OnMouseOver();
                        if (hand.isManoChiusa() && exManoChiusa == false)
                        {
                            SuonoSelezione.Play();
                            SceneManager.LoadScene(3);
                        }
                    }
                    else
                    {
                        ButtonForza4.OnMouseExit();
                        if (isOnButton(BackButton))
                        {
                            ButtonBack.OnMouseOver();
                            if (hand.isManoChiusa() && exManoChiusa == false)
                            {
                                SuonoSelezione.Play();
                                fase = 0;
                                Menu.bGamesMenu = false;
                                Menu.bBackButton = false;
                                Menu.bMenuHome = true;
                                exManoChiusa = true;
                            }
                        }
                        else
                        {
                            ButtonBack.OnMouseExit();
                        }
                    }
                }
            }
        }
        if (fase == 2)
        {
            if (isOnButton(BackOption))
            {
                optionMenu.SetActive(false);
                optionBack.SetActive(true);
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    exManoChiusa = true;
                    fase = 0;
                    SuonoSelezione.Play();
                    menuHome.SetActive(true);
                    optionBack.SetActive(false);
                }
            }
            else
            {
                optionMenu.SetActive(true);
                optionBack.SetActive(false);
                if (isOnButton(EngButton))
                {
                    optionMenu.SetActive(false);
                    optionEng.SetActive(true);
                    if (hand.isManoChiusa() && exManoChiusa == false)
                    {
                        Cursore.lingua=1;
                        exManoChiusa = true;
                        SuonoSelezione.Play();
                    }
                }
                else
                {
                    optionMenu.SetActive(true);
                    optionEng.SetActive(false);
                    if (isOnButton(ItaButton))
                    {
                        optionMenu.SetActive(false);
                        optionIta.SetActive(true);
                        if (hand.isManoChiusa() && exManoChiusa == false)
                        {
                            Cursore.lingua=0;
                            exManoChiusa = true;
                            SuonoSelezione.Play();
                        }
                    }else{
                        optionMenu.SetActive(true);
                        optionIta.SetActive(false);
                    }
                }
            }
        }
        if (exManoChiusa == true && !hand.isManoChiusa())
        {
            exManoChiusa = false;
        }

    }

    public void setX(float x)
    {
        this.x = x;
    }

    public void setY(float y)
    {
        this.y = y;
    }

    public float getX()
    {
        return x;
    }

    public float getY()
    {
        return y;

    }

    private bool isOnButton(Button b)
    {
        float width = b.GetComponent<RectTransform>().rect.width;
        float height = b.GetComponent<RectTransform>().rect.height;
        float cordx = b.transform.position.x;
        float cordy = b.transform.position.y;

        return gameObject.transform.position.x > cordx - width / 2 && gameObject.transform.position.x < cordx + width / 2 && gameObject.transform.position.y > cordy - height / 2 && gameObject.transform.position.y < cordy + height / 2;
    }

    public bool isOnQ(GameObject q)
    {
        float width = q.GetComponent<RectTransform>().rect.width;
        float height = q.GetComponent<RectTransform>().rect.height;
        float cordx = q.transform.position.x * 10;
        float cordy = q.transform.position.y * 10;
        return gameObject.transform.position.x * 10 > cordx - width / 2 && gameObject.transform.position.x * 10 < cordx + width / 2 && gameObject.transform.position.y * 10 > cordy - height / 2 && gameObject.transform.position.y * 10 < cordy + height / 2;
    }
}
