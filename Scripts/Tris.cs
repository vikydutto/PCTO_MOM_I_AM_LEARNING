using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.SceneManagement; // inclusione della libreria per controllare il movimento delle scene

/** Gioco del tris: intero script */

public class Tris : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public AudioSource mainMusic, pauseMusic, selezione; // variabili per l'audio
    public GameObject q1x, q1o, q2x, q2o, q3x, q3o, q4x, q4o, q5x, q5o, q6x, q6o, q7x, q7o, q8x, q8o, q9x, q9o, buttonPause, buttonPlay, buttonExit; // ogni quadrato: se ha x oppure cerchio, pulsanti della schermata
    public ManoTris hand; // mano della classe ManoTris
    public CursoreTris c; // cursore della classe CursoreTris
    private int[] campo = { 404, 404, 404, 404, 404, 404, 404, 404, 404 }; // ogni campo del gioco è vuoto (poteva essere benissimo 0, come "vuoto", ma faceva più figo scrivere 404 come "Error 404! page not found!")
    public static bool bTris, bPause, bPausePlay, bPauseExit; // booleane per gli sfondi
    public GameObject tris, pause, pausePlay, pauseExit; // oggetti per i vari bottoni
    private int turno = 0; // per capire di chi è il turno
    private bool victory = false, PauseMenu = false; // vittoria e variabile per sapere se si è schiacciato il "Pause" button
    public GameObject vittoriaG1, vittoriaG2; // oggetti per la vittoria: scritte
    private bool exManoChiusa = false; // stato della mano passato
    private int exTurno = 0; // turno precedente: per la manipolazione del turno presente, che sarà diverso da quello passato
    
    void Start() {
        bTris = true; // sfondo del gioco
        bPause = false;
        bPauseExit = false;
        bPausePlay = false; // tutti gli altri sfondi non vengono messi a true
        tris.SetActive(bTris);
        pause.SetActive(bPause);
        pauseExit.SetActive(bPauseExit);
        pausePlay.SetActive(bPausePlay); // ma vengono tutti attivati
        
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
        q9o.SetActive(false); // nessun quadrato è pieno: per il momento non vengono attivati
        vittoriaG1.SetActive(false);
        vittoriaG2.SetActive(false); // vittorie: non ancora attive dato che il gioco è appena iniziato da un frame
        mainMusic.Play(); // inizio della musica da noi composta
    }
    
    void Update() {
        tris.SetActive(bTris);
        pause.SetActive(bPause);
        pauseExit.SetActive(bPauseExit);
        pausePlay.SetActive(bPausePlay); // background settati ad attivi

        if (PauseMenu) controllo(); // se il menù di pausa è attivo allora fa il controllo
        else
        {
            if (victory) { // se c'è una vittoria
                if (exTurno == 0) { // turno della croce
                    vittoriaG1.SetActive(true); // allora vuol dire che l'ultima mossa l'ha fatta la croce == la croce ha vinto
                } else {
                    vittoriaG2.SetActive(true); // il cerchio ha vinto
                }
                setCampo();
                // non ci sono vittorie
                if (hand.isManoChiusa() && exManoChiusa == false) // se la mano adesso è chiusa e prima era aperta:
                {
                    selezione.Play();
                    vittoriaG2.SetActive(false);
                    vittoriaG1.SetActive(false);
                    exManoChiusa = true; // ha selezionato: stato passato della mano == chiusa
                    victory = false;
                    for (int k = 0; k < 9; k++) campo[k] = 404;
                    Start(); // ricomincia da capo
                } else {
                    exManoChiusa = hand.isManoChiusa(); // da come valore quello rilevato dal metodo isManoChiusa
                }
            } else {
                if (isADraw()) { // pareggio
                    for (int k = 0; k < 9; k++) campo[k] = 404;
                    Start(); // restarta tutto da capo
                } else {
                    exTurno = turno; // turno 0 o 1 == croce o cerchio
                    setCampo(); // disegna il campo
                    controllo();
                    victory = controlloVittoria(exTurno); // controllo della vittoria -> exTruno vince se ha vinto
                }
            }
        }

    }
    void setCampo()
    {
        for (int k = 0; k < 9; k++) { // controlla ogni cella, non un while
            if (campo[k] == 1) // se è il turno dell'1
            {
                switch (k)
                {
                    case 0:
                        q1x.SetActive(false);
                        q1o.SetActive(true); // nel campo ci sarà il simbolo di chi ha il turno 1
                        break;
                    case 1:
                        q2x.SetActive(false);
                        q2o.SetActive(true); // così sarà per tutte le celle
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
                        q9o.SetActive(true); // così è stato per tutte le celle
                        break;
                }
            }
            if (campo[k] == 0) // se invece nella cella c'è il numero 0
            {
                switch (k)
                {
                    case 0:
                        q1x.SetActive(true);// ci sarà il simbolo della x
                        q1o.SetActive(false);
                        break;
                    case 1:
                        q2x.SetActive(true); // così per tutte le celle
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
                        break; // così è stato per tutte le celle
                }
            }
        }
    }
    
    void controllo() {
        if (!PauseMenu) // se il gioco non è in pausa
        {
            if (exManoChiusa == false) // e la mano pria era aperta
            {
                if (c.isOnQ(q1x) && hand.isManoChiusa()) { // se il cursore è su un quadrato e la mano è chiusa
                    selezione.Play(); // parte il suono della selezione
                    exManoChiusa = true; // ha appena selezionato
                    if (turno == 0)  { // se il turno della x
                        if (campo[0] == 404) { // se il campo è vuoto
                            campo[0] = 0; // metto una x
                            turno = 1; // turno successivo: opponent: cerchio
                        }
                    } else { // turno == 1
                        if (campo[0] == 404){
                            campo[0] = 1; // si mette un cerchio
                            turno = 0; // turno successivo: oppnent: croce
                        }
                    }
                }
                if (c.isOnQ(q2x) && hand.isManoChiusa()) { // si ripete per tutte le celle
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
                if (c.isOnQ(q3x) && hand.isManoChiusa()) {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0) {
                        if (campo[2] == 404) {
                            campo[2] = 0;
                            turno = 1;
                        }
                    } else {
                        if (campo[2] == 404) {
                            campo[2] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q4x) && hand.isManoChiusa()) {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0) {
                        if (campo[3] == 404)  {
                            campo[3] = 0;
                            turno = 1;
                        }
                    } else {
                        if (campo[3] == 404) {
                            campo[3] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q5x) && hand.isManoChiusa()) {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0) {
                        if (campo[4] == 404) {
                            campo[4] = 0;
                            turno = 1;
                        }
                    } else {
                        if (campo[4] == 404) {
                            campo[4] = 1;
                            turno = 0;
                        }
                    }
                }

                if (c.isOnQ(q6x) && hand.isManoChiusa()) {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0) {
                        if (campo[5] == 404) {
                            campo[5] = 0;
                            turno = 1;
                        }
                    } else {
                        if (campo[5] == 404) {
                            campo[5] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q7x) && hand.isManoChiusa()) {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0) {
                        if (campo[6] == 404) {
                            campo[6] = 0;
                            turno = 1;
                        }
                    } else {
                        if (campo[6] == 404) {
                            campo[6] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q8x) && hand.isManoChiusa()) {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0) {
                        if (campo[7] == 404) {
                            campo[7] = 0;
                            turno = 1;
                        }
                    } else {
                        if (campo[7] == 404) {
                            campo[7] = 1;
                            turno = 0;
                        }
                    }
                }
                if (c.isOnQ(q9x) && hand.isManoChiusa()) {
                    selezione.Play();
                    exManoChiusa = true;
                    if (turno == 0) {
                        if (campo[8] == 404) {
                            campo[8] = 0;
                            turno = 1;
                        }
                    } else {
                        if (campo[8] == 404) {
                            campo[8] = 1;
                            turno = 0;
                        }
                    }
                }
                
                if (c.isOnQ(buttonPause) && hand.isManoChiusa()) { // se il cursore è sul pulsate della pausa e è a mano chiusa
                    selezione.Play();
                    mainMusic.Stop();
                    pauseMusic.Play(); // si ferma la canzone del tris e si fa partire quella della pausa
                    exManoChiusa = true; // si passa al vecchio stato lo stato attuale
                    bPause = true; // background della pausa: lo si fa vedere
                    bTris = false;
                    PauseMenu = true; // si passa alla schermata del menù della pausa
                }
            } else exManoChiusa = hand.isManoChiusa(); // valore della amno passato a quella del passato
        } else {
            if (c.isOnQ(buttonPlay)) { // se è sul bottone play del menù di pausa
                ButtonPlayTris.OnMouseOver();
                if (hand.isManoChiusa() && exManoChiusa == false) {
                    selezione.Play();
                    pauseMusic.Stop();
                    mainMusic.Play();
                    exManoChiusa = true;
                    bPausePlay = false;
                    bTris = true; // si ritorna al minigame del tris
                    PauseMenu = false; // si fa la stessa cosa di prima
                } else {
                    exManoChiusa = hand.isManoChiusa(); // si passa allo stato precedente lo stato attuale dell mano
                }
            } else {
                ButtonPlayTris.OnMouseExit();
                if (c.isOnQ(buttonExit)) { // se è sul bottone exit della pausa
                    ButtonExitTris.OnMouseOver();
                    if (hand.isManoChiusa() && exManoChiusa == false) {
                        selezione.Play();
                        SceneManager.LoadScene(0); // scena zero = menù principale
                    } else exManoChiusa = hand.isManoChiusa(); // mano passato: sistuazione presente mano
                }
                else ButtonExitTris.OnMouseExit(); // si esce e si va nel menù
            }
        }
    }

    bool controlloVittoria(int turno) {
        int[,] comb = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 4, 8 }, { 2, 4, 6 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 } };
        bool trov = false; // vittoria non è attiva all'inizio
        int k = 0; // contatore da 0
        while (trov == false && k < 8) { // while che va al massimo a fare 9 giri
            // se la cella ha lo stesso valoore del turno come nelle combinazioni sovrascritte
            if (campo[comb[k, 0]] == turno && campo[comb[k, 1]] == turno && campo[comb[k, 2]] == turno) trov = true; // combinazione trovata
            k += 1; // altrimenti non c'è la vittoria
        }
        return trov; // ritorno del menìtodo per il controllo della vittoria -> trov == victory
    }
    bool isADraw() {
        bool tro = false; // inizializzato a falso
        int k = 0;
        while (k < 9 && tro == false) {
            tro = (campo[k] == 404); // se la cella è vuota allora tro == true
            k++; // si devono controllare tutte le celle finché tro == false
        }
        return !tro; // ritorna il valore NEGATO di tro
    }
}
