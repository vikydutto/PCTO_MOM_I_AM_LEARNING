using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.SceneManagement; // inclusione della libreria per controllare il movimento delle scene

/** classe generale per ogni Menù: classe */

public class Menu : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public GameObject MenuHome; // menù principale: quello di inizio
    public GameObject OptionMenu,playButton,optionButton,RulesButton, QuizButton, TrisButton, Forza4Button, GamesMenu, BackButton; // ogni bottone della fase 0 e 1
    public static bool bMenuHome,bOptionMenu,bplayButton,boptionButton,bRulesButton,bQuizButon, bTrisButton, bForza4Button, bGamesMenu, bBackButton; // background(s)

    void Start() { // all'inizio: quando si apre il gioco
       bMenuHome = true; // si parte dal menù principale e quindi si setta il suo sfondo a vero
       boptionButton = false;
       bplayButton = false;
       bOptionMenu = false;
       bQuizButon = false;
       bForza4Button = false;
       bTrisButton = false;
       bGamesMenu = false;
       bBackButton = false; // mentre tutti gli altri a falso, dato che non sono delle scene che vogliamo
       MenuHome.SetActive(bMenuHome);
       OptionMenu.SetActive(bOptionMenu);
       playButton.SetActive(bplayButton); 
       optionButton.SetActive(boptionButton);
       RulesButton.SetActive(bRulesButton);
       QuizButton.SetActive(bQuizButon);
       TrisButton.SetActive(bTrisButton);
       Forza4Button.SetActive(bForza4Button);
       GamesMenu.SetActive(bGamesMenu);
       BackButton.SetActive(bBackButton); // si settano ad attivi tutti i background
    }

    void Update() { // all'update, che viene molte volte al secondo dato che avviene ad ogni frame
       MenuHome.SetActive(bMenuHome);
       OptionMenu.SetActive(bOptionMenu);
       playButton.SetActive(bplayButton); 
       optionButton.SetActive(boptionButton);
       RulesButton.SetActive(bRulesButton);
       QuizButton.SetActive(bQuizButon);
       TrisButton.SetActive(bTrisButton);
       Forza4Button.SetActive(bForza4Button);
       GamesMenu.SetActive(bGamesMenu);
       BackButton.SetActive(bBackButton); // si settano attivi tutti i background
    }
}
