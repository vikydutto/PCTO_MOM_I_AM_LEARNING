using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuHome;
    public GameObject OptionMenu,playButton,optionButton,RulesButton, QuizButton, TrisButton, Forza4Button, GamesMenu, BackButton;
    public static bool bMenuHome,bOptionMenu,bplayButton,boptionButton,bRulesButton,bQuizButon, bTrisButton, bForza4Button, bGamesMenu, bBackButton;

    void Start()
    {
       bMenuHome=true;
       boptionButton=false;
       bplayButton=false;
       bOptionMenu=false;
       bQuizButon=false;
       bForza4Button=false;
       bTrisButton=false;
       bGamesMenu=false;
       bBackButton=false;
       MenuHome.SetActive(bMenuHome);
       OptionMenu.SetActive(bOptionMenu);
       playButton.SetActive(bplayButton); 
       optionButton.SetActive(boptionButton);
       RulesButton.SetActive(bRulesButton);
       QuizButton.SetActive(bQuizButon);
       TrisButton.SetActive(bTrisButton);
       Forza4Button.SetActive(bForza4Button);
       GamesMenu.SetActive(bGamesMenu);
       BackButton.SetActive(bBackButton);
    }

    void Update()
    {
        MenuHome.SetActive(bMenuHome);
       OptionMenu.SetActive(bOptionMenu);
       playButton.SetActive(bplayButton); 
       optionButton.SetActive(boptionButton);
       RulesButton.SetActive(bRulesButton);
       QuizButton.SetActive(bQuizButon);
       TrisButton.SetActive(bTrisButton);
       Forza4Button.SetActive(bForza4Button);
       GamesMenu.SetActive(bGamesMenu);
        BackButton.SetActive(bBackButton);
    }
}
