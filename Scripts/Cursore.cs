using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.UI; // header per la user interface
using UnityEngine.SceneManagement; // inclusione della libreria per controllare il movimento delle scene

public class Cursore : MonoBehaviour {
    public AudioSource SuonoSelezione; // variabile per la musica: da dove proviene il suono della scena
    public GameObject menuHome, optionMenu, optionIta, optionEng, optionBack; // menu (scene) e pulsanti
    public Button PlayButton, OptionButton, QuizButton, TrisButton, Forza4Button, BackButton, ItaButton, EngButton, BackOption; // pulasnti
    public Mano hand; // mano
    private float x;
    private float y; // coordinate della mano == cursore
    private int fase; // per capire quando cambiare scena

    public static int lingua = 0; // preimpostazione di una lingua
    private bool exManoChiusa; // booleano per la mano
    
    void Start(){ // posizione della mano ogni volta che parte una scena si "azzera" e la mano viene vista aperta
        y = gameObject.transform.position.y; // rilevazione grazie all'UltraLeap della posizione y della mano
        x = gameObject.transform.position.x; // rilevazione grazie all'UltraLeap della posizione x della mano
        fase = 0; // fase 0: menù principale (show del play e dell'option buttons)
        exManoChiusa = false; // la mano viene da subito vista come aperta
    }
    void Update(){ // la scena deve essere aggiornata sempre: per la pozizione della mano
        gameObject.transform.position = new Vector3(x, y, transform.position.z); // posizione della mano

        if (fase == 0) // schermata del menù di inizio -- fasi della schermata: fase menu principale == 0, fase menù scelta gioco == 1, menù options == 2
        {
            if (isOnButton(PlayButton)) // se è sulla figura del bottone play
            {
                ButtonPlay.OnMouseOver(); // invoco il metodo per far cambiare la scena: menù della scelta dei giochi
                if (hand.isManoChiusa() && exManoChiusa == false) // selezione: all'oggetto hand invoco il metodo isManoChiusa e mi chiedo se lo stato precedente della mano NON fosse "chiuso"
                {
                    SuonoSelezione.Play(); // quando clicco il pulsante parte l'audio
                    fase = 1; // cambia schermata: scena della scelta del gioco
                    Menu.bMenuHome = false;
                    Menu.bplayButton = false; // bisogna settarle a false per non creare bug
                    Menu.bGamesMenu = true; // impostazioni della scena menu
                    exManoChiusa = true; // stato passato della mano: chiuso
                }
            }else
            {
                ButtonPlay.OnMouseExit(); // se il cursore non è sul pulsante "Play" allora:
                if (isOnButton(OptionButton)) // se è sulla figura del bottone "Option"
                {
                    ButtonOption.OnMouseOver(); // si attiva una variabile e si disattiva l'altra per cambiare scena
                    if (hand.isManoChiusa() && exManoChiusa == false) // selezione uguale a quella di prima
                    {
                        SuonoSelezione.Play();
                        exManoChiusa = true; // stato passato della mano: chiuso
                        menuHome.SetActive(false); // si disattiva il menù principale
                        optionMenu.SetActive(true); // si ativa il pulsante delle opzioni
                        fase = 2; // scena delle opzioni
                    }
                }
                else ButtonOption.OnMouseExit(); // se non è invece sul pulsante delle opzioni si tiene la schermata del menù principale
            }
        }
        if (fase == 1) // schermata del menù scelta dei giochi -- fasi della schermata: fase menu principale == 0, fase menù scelta gioco == 1, menù options == 2
        {
            if (isOnButton(QuizButton)) // se il mouse è sul pulsante dei quiz
            {
                ButtonQuiz.OnMouseOver(); // allora si invoca questo metodo che cambia lo stato di alcune variabili
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    SuonoSelezione.Play();
                    SceneManager.LoadScene(1); // si passa al gioco: cambia la scena facendo il load della scena 1: gioco del quiz
                }

            } else
            {
                ButtonQuiz.OnMouseExit(); // se non è sul bottone della scelta del gioco del quiz
                if (isOnButton(TrisButton)) // scelta del gioco tris conil mouse sopra il pulsante "Tris"
                {
                    ButtonTris.OnMouseOver();
                    ButtonQuiz.OnMouseOver(); // le chiamo entrambe per impostare le varie variabili per il cambio delle scene
                    if (hand.isManoChiusa() && exManoChiusa == false)
                    {
                        SuonoSelezione.Play();
                        SceneManager.LoadScene(2); // si passa al gioco: cambia la scena facendo il load della scena 2: gioco del tris
                    }
                }else
                {
                    ButtonTris.OnMouseExit(); // se il mouse non è più sul bottone del tris
                    if (isOnButton(Forza4Button)) // ma è su quello del Forza 4 allora:
                    {
                        ButtonForza4.OnMouseOver(); // dato che il mouse è sopra si chiama questo attributo per fargli cambiare le booleane apposite
                        if (hand.isManoChiusa() && exManoChiusa == false)
                        {
                            SuonoSelezione.Play();
                            SceneManager.LoadScene(3); // load della scena 3: gioco di Forza 4
                        }
                    }else
                    {
                        ButtonForza4.OnMouseExit(); // non è sul pulsante del mini-game forza 4
                        if (isOnButton(BackButton)) // ultimo pulsante della scena: il cursore è sul bottone che dice "Indietro" o "Back" (dipende: lingua impostata dall'utente)
                        {
                            ButtonBack.OnMouseOver(); // si cambia il valore delle variabili con il metodo della classe ButtonBack
                            if (hand.isManoChiusa() && exManoChiusa == false)
                            {
                                SuonoSelezione.Play();
                                fase = 0; // si ritorna alla fase 0 == menù principale (coi bottoni play e option)
                                Menu.bGamesMenu = false;
                                Menu.bBackButton = false;
                                Menu.bMenuHome = true; // menù della fase 0
                                exManoChiusa = true;
                            }
                        }
                        else ButtonBack.OnMouseExit();
                    }
                }
            }
        }
        if (fase == 2) // opzioni == scelta della lingua dato ch è il menù delle opzioni
        {
            if (isOnButton(BackOption)) // se è sul pulsante "back" della schermata delle opzioni
            {
                optionMenu.SetActive(false); // disattivo il menù delle opzioni
                optionBack.SetActive(true); // attivo la funzione del pulsante back
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    exManoChiusa = true;
                    fase = 0; // ritorno al menù principale
                    SuonoSelezione.Play();
                    menuHome.SetActive(true); // e attivo quella del menù principale iniziale
                    optionBack.SetActive(false); // ora che ho utilizzato il bottone ne disattivo la funzione
                }
            }else
            {
                optionMenu.SetActive(true); // è ora attivo il menù a cui si arriva col tasto delle opzioni dal menù principale
                optionBack.SetActive(false);
                if (isOnButton(EngButton)) // pulsante per scegliere la lingua inglese: la "mano" ci è sopra
                {
                    optionMenu.SetActive(false); // si disattiva l'azione di cambiare scena
                    optionEng.SetActive(true); // si attiva la funzione del bottone
                    if (hand.isManoChiusa() && exManoChiusa == false)
                    {
                        Cursore.lingua = 1; // il cursore si sposta sulla scelta della lingua: la lingua inglese è quella 1
                        exManoChiusa = true;
                        SuonoSelezione.Play();
                    }
                }else
                {
                    optionMenu.SetActive(true);
                    optionEng.SetActive(false); // mi assicuro che le variabili siano impostate a dovere
                    if (isOnButton(ItaButton)) // se è sul pulsante della lingua italiana
                    {
                        optionMenu.SetActive(false);
                        optionIta.SetActive(true); // si attiva il "potere" della lingua italiana
                        if (hand.isManoChiusa() && exManoChiusa == false)
                        {
                            Cursore.lingua = 0; // la lingua italiana corrisponde alla lingua 0
                            exManoChiusa = true;
                            SuonoSelezione.Play();
                        }
                    }else{ // nell'ultimo caso
                        optionMenu.SetActive(true); // la scena è statica della scena del menù opzioni
                        optionIta.SetActive(false);
                    }
                }
            }
        }
        if (exManoChiusa == true && !hand.isManoChiusa()) exManoChiusa = false; // imposto lo stato passato della mano ad aperto: se lo stato passato della stessa era true e se il risultato del metodo diceva che fosse aperta
    }

    public void setX(float x) this.x = x;
    public void setY(float y) this.y = y;
    public float getX() return x;
    public float getY() return y; // setter e getter per le variabili della posizione della mano

    private bool isOnButton(Button b) // metodo chiamato diverse volte nel codice per capire se il cursore era su un pulsante (qualsiasi)
    {
        float width = b.GetComponent<RectTransform>().rect.width;
        float height = b.GetComponent<RectTransform>().rect.height; // prese la larghezza e l'altezza del bottone (prese come rettangoli)
        float cordx = b.transform.position.x;
        float cordy = b.transform.position.y; // cordinate x,y dell'angolo del bottone: quello in alto a sx

        return gameObject.transform.position.x > cordx - width / 2 && gameObject.transform.position.x < cordx + width / 2 && gameObject.transform.position.y > cordy - height / 2 && gameObject.transform.position.y < cordy + height / 2;
    } // ritorna dalla fx: se il cursore è appunto nell'area del bottone

    public bool isOnQ(GameObject q) // q == quadrato -- dice se la mano è su un quadrato
    {
        float width = q.GetComponent<RectTransform>().rect.width;
        float height = q.GetComponent<RectTransform>().rect.height; // stesso metodo per prendere la posizione dei pulsanti
        float cordx = q.transform.position.x * 10;
        float cordy = q.transform.position.y * 10; // angolo in alto a sx del quadrato
        return gameObject.transform.position.x * 10 > cordx - width / 2 && gameObject.transform.position.x * 10 < cordx + width / 2 && gameObject.transform.position.y * 10 > cordy - height / 2 && gameObject.transform.position.y * 10 < cordy + height / 2;
    } // ritorno del booleano per inidicare appunto se il mouse è sul quadrato
}
