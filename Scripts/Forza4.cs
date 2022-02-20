using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.UI; // header per la user interface
using UnityEngine.SceneManagement; // inclusione della libreria per controllare il movimento delle scene

/** Script per il mini-game Forza 4 */

public class Forza4 : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public AudioSource mainMusic, pauseMusic, selezione; // variabili per la source dell'audio
    public GameObject pedinaGialla, pedinaRossa, sfondo, SfondoPausa, pausePlay, pauseExit, sfondoBackButton; // oggettidella schermata
    public GameObject gioco, colonna1, colonna2, colonna3, colonna4, colonna5, colonna6, colonna7; // ogni colonna della "tabella" come grafiche
    public GameObject c1, c2, c3, c4, c5, c6, c7, buttonPause, buttonPlay, buttonExit, vittoriaG1, vittoriaG2; // colonne e bottoni come oggetti
    private bool bGioco, bcolonna1, bcolonna2, bcolonna3, bcolonna4, bcolonna5, bcolonna6, bcolonna7, bsfondoBackButton; // background(s) booleani: or on or off
    private bool exManoChiusa, vittoria, bPause, bPausePlay, bPauseExit, Pausa; // stato passato della mano, vittoria e bottoni
    public CursoreTris cursore; // cursore mano: immagine del cursore
    private int rCella = 0, fase = 0; // righe delle celle e fase di gioco inizializzate entrambe a 0
    private float[] vettX = { -420, -295, -165, -39, 89, 210, 335 };
    private float[] vettY = { -494, -375, -249, -120, 10, 134 }; // coordinate delle celle
    public ManoTris hand; // mano "fisica", in 3D

    private int exfase; // fase precedente
    private int[,] campo = { { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 }, { 404, 404, 404, 404, 404, 404, 404 } };
    // inizializzazione del campo di gioco a "vuoto" scrivere 404 è uguale a scrivere 0 (faceva molto perito informatico)
    //private int[,] campo = new int[6, 7];
    
    void Start(){
        /*for (int k = 0; k < 6; k++){
            for (int j = 0; j < 7; j++){
                campo[k, j] = 404;
            }
        }*/
        bGioco = true; // inizio del gioco: background della "tabella" di gioco senza "illuinazione" delle colonne
        vittoria = false; // inizio del gioco != vittoria
        bcolonna1 = false;
        bcolonna2 = false;
        bcolonna3 = false;
        bcolonna4 = false;
        bcolonna5 = false;
        bcolonna6 = false;
        bcolonna7 = false; // nessuna colonna è illuminata
        exManoChiusa = false; // la mano in passato era paerta
        Pausa = false; // la schermata della pausa non viene attivata
        bPause = false; // bottone della pause non viene "toccato": background della pausa non si avvia
        bPausePlay = false; // la schermata del gioco non viene fermata: la schermata della pausa non viene vista
        bPauseExit = false; // la schermata della pausa non viene fermata: la schermata del gioco viene vista
        vittoriaG1.SetActive(false); 
        vittoriaG2.SetActive(false); // nessuan vittoria è stata raggiunta essendo che il gioco è appena partito
        mainMusic.Play(); // la musica del gioco parte
    } // quando tutto è ancora pulito in sostanza: prioprio il "load" della scena in pratica

    void Update() { // update della schermata: cursore, gioco
        settaSfondi(); // metodo che implementa lo sfondo del gioco: ovvero tutte le variabili che iniziano con b (anche negli altri script(s))
        if (!Pausa)
        {
            pauseMusic.Stop(); // non parte la musica della Pausa
            if (!vittoria) // se la vittoria non l'ha ancora raggiunta nessuno
            {
                controllaMano(); // continua a controllare la mano (update)
                if (fase == 0)  exfase = 1;
                else exfase = 0;
                
                if (controllaVittoria(exfase)) vittoria = true; // se la fase passata è == , allora vuol dire che ha vinto qualcuno
            }else
            { // vittoria == true
                if(exfase == 0) vittoriaG1.SetActive(true); // vittoria del giocatore 1
                else vittoriaG2.SetActive(true); // altrimenti vittoria del giocatore 2
                
                if (hand.isManoChiusa() && exManoChiusa == false) // se adesso la mano è chiusa e prima era aperta allora vuol dire che ha selezionato:
                {
                    selezione.Play();
                    exManoChiusa = true;
                    for (int k = 0; k < 6; k++){
                        for (int j = 0; j < 7; j++){
                            campo[k, j] = 404;
                        }
                    } // ogni cella è settata a "zero" == vuota == 404
                    var clones = GameObject.FindGameObjectsWithTag("clone");
                    foreach (var clone in clones) Destroy(clone); // data la cancellazione magari sono stati creati dei cloni: quindi li va a cancellare: li "distrugge"
                    
                    vittoriaG1.SetActive(false);
                    vittoriaG2.SetActive(false);
                    vittoria = false; // essendo ripartito il gioco nessuno a vinto e tutte le celle sono ripulite
                }else{
                    exManoChiusa = hand.isManoChiusa(); // si da l'impostazione della mano nel presente a quella passata
                }
            }
        }else // Pausa
        {
            mainMusic.Stop(); // parte la musica della pausa
            if (cursore.isOnQ(buttonPlay)) // se il cursore è sul bottone del play
            {
                bPause = false; // non viene fatta la show dello sfondo della pausa (altrimenti ci sarebbero due sfondi nello stesso momento)
                bPausePlay = true; // clicca sul bottone play della pausa -> si ritorna al mini-game forza 4: backround del play colorato
                if (hand.isManoChiusa()) // se la mano è chiusa
                {
                    selezione.Play();
                    mainMusic.Play();
                    exManoChiusa = true; // si passa il valore della mano alla mano del passato
                    bPausePlay = false;
                    bGioco = true; // bottone del gioco "schiacciato" -> ritorno al mini-game (sfondo)
                    Pausa = false; // per non creare bug: si setta a false la class Pausa
                }
            }
            else
            {
                bPause = true; // scena della pausa
                bPausePlay = false;
                if (cursore.isOnQ(buttonExit)) // se è sul bottone exit
                {
                    bPause = false;
                    bPauseExit = true; // si attiva il bottone
                    if (hand.isManoChiusa()) // se la mano è chiusa
                    {
                        selezione.Play(); // suono della selezione di un pulsante
                        bPauseExit = false; // corrispondente sfondo disattivato
                        bGioco = true; // il gioco ri-inizia: sfondo cambiato
                        Pausa = false; // scena della pausa disattivata
                        SceneManager.LoadScene(0); // fa il load della scena 0 == menù principale -- fase menù scelta gioco == 1, menù options == 2
                    }
                }else {
                    bPause = true; // sfondo della pausa: schermata della pausa
                    bPauseExit = false;
                }
            }
        }
    } // fune dell'update della scena

    void controllaMano(){ // metodo del controllo della mano dell'utente
        if (cursore.isOnQ(buttonPause)) // se la il cursore è sul bottone della pausa
        {
            bGioco = false; // back del menù principale si setta a falso
            bsfondoBackButton = true; // il "Back" "diventa" più grande
            if (hand.isManoChiusa())
            {
                pauseMusic.Play(); // canzone specifica per la schermata della pausa
                mainMusic.Stop();
                selezione.Play();
                bsfondoBackButton = false;
                bPause = true; // back pausa attivo
                Pausa = true; // senza della pausa
            }
        } else
        {
            bGioco = true; // il gioco inizia
            bsfondoBackButton = false;
            if (cursore.isOnQ(c1)) // se il cursore è sulla colonna 1
            {
                bcolonna1 = true; // backgoìround della colonna 1 attivo
                bGioco = false;
                if (hand.isManoChiusa() && exManoChiusa == false)
                {
                    selezione.Play(); // suono della selezione
                    exManoChiusa = true; // dato che ha selezionato la mano del passato viene settata a chiusa
                    rCella = cellaColonna(0);
                    if (rCella != -1) {
                        campo[rCella, 0] = fase; // campo[riga, colonna1]
                        creaPedina(vettX[0], vettY[5 - rCella], fase); // disegna la pedina: colonna0, 5-riga, fase
                        if (fase == 1) fase = 0; // per capire la riga in cui si deve depositare la pedina
                        else fase += 1;
                    }
                }
            } else
            {
                bcolonna1 = false; // setta allora il background della prima colonna a false
                bGioco = true; // il background del gioco continua ad apparire
                if (cursore.isOnQ(c2)) // cursore sulla seconda colonna
                {
                    bcolonna2 = true; // background con la seconda colonna illuminata
                    bGioco = false;
                    if (hand.isManoChiusa() && exManoChiusa == false)
                    {
                        selezione.Play();
                        exManoChiusa = true; // dato che ha cliccato una colonna
                        rCella = cellaColonna(1);
                        if (rCella >= 0)
                        {
                            campo[rCella, 1] = fase; // campo[riga, colonna1]
                            creaPedina(vettX[1], vettY[5 - rCella], fase);
                            if (fase == 1) fase = 0;
                            else fase += 1; // ultime tre righe sempre uguali e quelle prima cambiano solo numero della colonna
                        }
                    }
                }
                else
                { // sfondi del gioco
                    bcolonna2 = false;
                    bGioco = true;
                    if (cursore.isOnQ(c3)) // se il cursore è sulla 3^ colonna
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
                                if (fase == 1)  fase = 0;
                                else fase += 1;// ultime tre righe sempre uguali e quelle prima cambiano solo numero della colonna
                                }
                            }
                        }
                    }
                    else
                    { // sfondi del gioco
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
                                    if (fase == 1) fase = 0;
                                    else  fase += 1; // ultime tre righe sempre uguali e quelle prima cambiano solo numero della colonna
                                }
                            }
                        }
                        else
                        { // sfondi
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
                                        if (fase == 1)fase = 0;
                                        else fase += 1; // ultime tre righe sempre uguali e quelle prima cambiano solo numero della colonna
                                    }
                                }
                            }
                            else
                            { // sfondi
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
                                            if (fase == 1) fase = 0;
                                            else fase += 1; // ultime tre righe sempre uguali e quelle prima cambiano solo numero della colonna
                                        }
                                    }
                                }
                                else
                                { // sfondi
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
                                                if (fase == 1) fase = 0;
                                                else fase += 1; // ultime tre righe sempre uguali e quelle prima cambiano solo numero della colonna
                                            }
                                        }
                                    } else {
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
        if (exManoChiusa == true && !hand.isManoChiusa()) exManoChiusa = false; // se la mano passata era chiusa e adesso la mano non è chiusa: mano passata impostata ad aperta
    }
    void settaSfondi() { // setta gli sfondi: variabili di tipo GameObject che iniziano con la b (in tutti gli script(s))
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

    int cellaColonna(int c){
        int k = 5; // riga massima da cui partire con il ciclo while
        while (campo[k, c] != 404 && k > 0) k -= 1; // da quella più in alto finché NON è vuota e finché non arriva all'ultima riga controllabile
        if (campo[k, c] != 404) k = -1; // se la cella che sta controllando è piena
        return k; // ritorna la riga
    }

    void creaPedina(float x, float y, int ped) {
        if (ped == 0) // ped == turno di quale giocatore? Giallo
            GameObject p = Instantiate(pedinaGialla, new Vector3(x, y, pedinaGialla.transform.position.z), transform.rotation); // p = pedina gialla nella cella x,y
        else // turno pedinas rossa
            GameObject p = Instantiate(pedinaRossa, new Vector3(x, y, pedinaRossa.transform.position.z), transform.rotation); // p = pedina rossa nella cella x,y
        p.transform.SetParent(sfondo.transform, false);
    }

    bool is4(int r, int c) { // checka se ci sono le 4 pedine per fare le 4 consecutive -> vittoria
        bool win = false; // inizialmente la vittoria è false == non c'è vittoria per nessun giocatore
        if (campo[r, c] != 404) // se il campo r,c è pieno
        {
            if (r >= 3) // se la r del campo
            {
                int k = 0;
                win = true;
                while (k <= 3 && win == true) { // controllo: max 4 volte
                    if (campo[r - k, c] != campo[r, c]) win = false; // se uno è diverso la win non esiste
                    k += 1; // se le celle sono piene dello stesso colore: continua il controllo
                }
                if (win == true) return true; // ritorno del metodo: vuol dire che qualcuno ha vinto
                if (c >= 3){ // se la colonna della cella
                    k = 0;
                    win = true;
                    while (k <= 3 && win == true){ // lo fa al massimo 4 volte
                        if (campo[r - k, c - k] != campo[r, c]) win = false; // se una cella non è uguale all'altra si ferma subito
                        k += 1; // se la pedina è sempre la stessa continua il controllo
                    }
                    if (win == true) return true; //ritorno della funzione: vittoria arrivata
                }
                if (c <= 3){ // se la colonna della cella è minore di 4
                    k = 0;
                    win = true;
                    while (k <= 3 && win == true) { // così il controllo va al max 4 volte
                        if (campo[r - k, c + k] != campo[r, c]) win = false;
                        k += 1;
                    }
                    if (win == true) return true; // ritorno della vittoria = true
                }
            } // tutto questo se la riga è maggiore dalla 3^ riga
            
            if (c <= 3) // se la colonna < 4 (4 colonne vengono contate: parte da 0)
            {
                int k = 0;
                win = true;
                while (k <= 3 && win == true) {
                    if (campo[r, c + k] != campo[r, c]) win = false; // se una pedina è diversa dalle altre il controllo si ferma
                    k += 1; // se le pedine sono tutte uguali continua il controllo
                }
                if (win == true) return true; // ritorna il risultato del metodo
            }
        }
        return win;
    }

    bool controllaVittoria(int ped)
    {
        int righe = 5;
        int colonne = 0;
        bool vittoria = false;
        while (righe >= 0 && vittoria == false) { // 5 -> 0, estremi inclusi e vittoria falsa
            colonne = 0;
            while (colonne < 7 && vittoria == false) { // dalla colonna 0 -> 6, estremi inclusi
                if (campo[righe, colonne] == ped) vittoria = is4(righe, colonne); // quando trova una pedina controlla se è vittoria
                colonne += 1;
            }
            righe -= 1;
        } // da in alto a sx fino in basso a dx
        return vittoria; // vittoria vera o falsa in base al metodo vittoria grazie al controllo delle celle
    }
}
