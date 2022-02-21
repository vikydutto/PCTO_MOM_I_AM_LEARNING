using System.Collections;
using System.Collections.Generic; // 2 headers scritte di default per utilizzare Unity
using UnityEngine; // utilizzata per accesso ad accelerometro e multi-touch sui devices
using UnityEngine.SceneManagement; // inclusione della libreria per controllare il movimento delle scene

/** Script che controlla se le risposte date dall'utente sono corrette, oltre che a creare le stesse con le loro domande e segnare i punti e gestire le scene */

public class VerificaRisposte : MonoBehaviour { // MonoBehaviour: la classe da cui tutti gli script derivano in Unity
    public AudioSource mainMusic, pauseMusic, selezione, vittoriaMusic, sconfittaMusica; // variabili per gli audio
    private string[] domande = { "Con quante pugnalate è stato ucciso Giulio Cesare?", "Quando è stato pugnalato Giulio cesare?", "Quanti lati ha un dodecagono?", "Chi ha enunciato questa formula fisica: E = m(c)^2?", "In quali lavori erano impiegati gli schiavi?", "Quale figura ha il corpo di leone e la testa di umano?", "In quale periodo regnò Tutankhamon?", "Dove scrivevano con i geroglifici gli Egizi?", "Che cosa sono le piramidi?", "Che cos'è una mummia?", "Ade, dio degli Inferi, possiede un cane mostruoso che ha un compito preciso, quale?", "Chi costrinse Atlante a sorreggere il Cielo sulle sue spalle?", "Dedalo fu un grande architetto e inventore. Quale fu la sua opera più famosa?", "Di che cosa erano fatte le ali con le quali Dedalo e suo figlio Icaro volarono?", "La ninfa amata da Apollo che fu trasformata in un albero di alloro si chiamava?", "Incontrando le Sirene, Ulisse si fece alla nave dai suoi compagni, perché?", "L'eroe Achille era invulnerabile, solo in un punto poteva essere colpito a morte, quale?", "Dove viveva rinchiuso il Minotauro?", "Quante volte il cervo cambia le sue corna?", "Il termine 'cucciolo' viene usato di solito per riferirsi ai piccoli di...", "Come cacciano i lupi in inverno?", "Che velocità può raggiungere un ghepardo?", "I piccoli mammiferi ispirano sempre tenerezza, questo fenomeno si chiama...", "Le tigri non sanno...", "Dove trascorre l'inverno l'orso polare?", "Come si chiama il piccolo del cavallo?", "Dove è esposto il più grande scheletro di brachiosauro?", "Il fossile del primo quetzalcoatlo trovato era in Messico, da dove deriva il suo nome?", " Che età poteva raggiungere il tirannosauro?", "Se una specie di animali discende da un'altra si parla di...", "Lo stegosauro sulla schiena aveva due file di placche ossee, perché?", "In che film il velociraptor è uno dei protagonisti?", "Da dove prende l'ossigeno utilizzato per respirare il tuo corpo?", "Che cosa trasportano i globuli rossi?", "In che occasioni il tuo corpo perde, consuma acqua?", "La parte che determina il colore degli occhi si chiama...", "Come si chiama il primo astronauta che ha messo piede sulla Luna?", "Di che cosa sono fatte le macchie scure della Luna?", "All'interno del tuo corpo dove viene creato nuovo sangue dopo averlo donato?", "Come si chiama l'interno dell'osso?", "Dove è più alta la temperatura del Sole?", "Quante sono le lune di Giove conosciute fino ad oggi?", "Quando il cervello è formato completamente?", "Come si chiama il tesuto embrionale che nutre il bambino nella pancia della mamma?", "In che percentuale l'acqua ricopre la superficie terrestre?", "In quale posto del mondo non si vede mai la Stella Polare?", "Che tipo di galassia è la Via Lattea?", "Come chiamiamo anche Marte?", "Chi ha migliorato il telescopio nel 1600?", "Come si chiamava la prima nave spaziale con equipaggio?" };
    private string[] domandeEng = { "How many stabwounds killed Giulio Cesare?", "When did Giulio Cesare die?", "How many sides does have a dodecagon?", "Who enounciated the physics: E = m(c)^2", "In which job were used slaves?", "Which creature has a lion body and a human head?", "In which period  Tutankhamon reigned?", "Where were written hieroglyphs?", "What are the pyramids?", "What is a Mummy?", "Ades, god of Underworld, has a dog which has a precise job, which is?", "Who forced Atlas to sustain the Sky on his shoulders?", "Dedalo was a great architect, which was his most famous building?", "In which material were produced Dedalus and Icarus' wings?", "Apollo loved a nymph during his life who transofermed in a tree, her name was..?", "Meeting the sirens, Ulysses had himself bound to the ship by his companions, why?", "Achilles was an invulnerable hero, only in one spot in his body could be shot to death, where?", "Where did the evil Minotaur live?", "How many times the deer changes his horns?", "The 'puppy' word is usually spent with children of which spieces?", "In what way do the wolves hunt in winter?", "The cheetah can reach a maximum speed of...", "The mammal pups inspire always cuteness, this phenomenon is called...", "The tigers don't know how to...", "Where does the polar bear live in winter?", "In which way is called the puppy of the horse?", "Where is exposed the biggest fossil of brachiosaurus?", "The first quetzalcoatlus' fossil was found in Mexico from what arise its name?", "What age could reach the T-Rex?", "If an an animal spieces descends from another we speak of...", "The stegosaurus on his back had two rows of bone plates, why?", "In which film the velociraptor is one of the protagonist?", "From where do our body get the oxygen we use to breath?", "Which substance do the red blood cells transport in our body?", "In which sistuation does our bosy use wears out or lose water?", "The portion of the eye which determines the eye colours is called...", "What is called the first astronaut who had put his foot on the Moon?", "In which material are composed the dark spots on the Moon surface?", "In our body where is produced the blood after a donation?", "How is called the inner substance of our bones?", "Where is the temperature of the Sun highest?", "How many are the known moons of Jupiter since today?", "When does the brain completes its growth?", "What is called the embryonic tissue that feeds the child in the mum's belly?", "In which percentage the water covers the Earth's surface?", "In which country of the world we can never see the Polar Star?", "Which type of galaxy is the Milky Way?", "In which way we also call Mars?", "Who upgraded the telescope in the sixteenth century?", "What was the first spaceship with astronaut into it called?" };
    private int NDOMANDE; // domande nelle due lingue + numerodelle domande (costante)
    private int nGameGiocatore, nGameCPU; // giocatore e pc
    private int nPuntiGiocatore, nPuntiCPU; // punti giocatore e computer
    private string[,] risposte = new string[,] { { "2", "7", "23", "17" }, { "idi di Marzo", "30 marzo 44 a.C.", "33 d.C.", "150 d.C." }, { "6", "9", "12", "20" }, { "A. Einstein", "A. Volta", "I. Newton", "Leonardo Da Vinci" }, { "Coltivare le terre", "Costruire le piramidi", "Servire i faraoni", "Pulire le prigioni" }, { "La sfinge", "L'obelisco", "Il sarcofago", "La mastaba" }, { "Antico Regno", "Medio Regno", "Nuovo regno", "Tardo regno" }, { "Sabbia", "Tavole di legno", "Fogli di carta", "Pergamene di papiro" }, { "Templi", "Tombe", "Abitazioni", "Fortezze" }, { "Una scultura", "Il faraone", "Una figura inventata", "Un cadavere essiccato" }, { "Far luce con i suoi sei occhi", "Abbaiare all'arrivo dei defunti", "Far comapgnia ai figli di Ade", "Impedire a chiunque di uscire" }, { "Ares, dopo una scommessa", "Suo fratello, per vendetta", "Zeus, dopo la lotta con i titani", "La Terra all'inizio dei tempi" }, { "La Reggia di caserta", "Lo stadio di Olimpia", "Il Colosseo", "Il labirinto di Cnosso" }, { "Di piume e cera", "Di carta e colla", "Di papiro intrecciato", "Di pergamene e corda" }, { "Laura", "Clizia", "Dafne", "Clori" }, { "Per non gettarsi in mare", "Per non schiaffeggiarle", "Per fingersi prigioniero", "Per non volare via con loro" }, { "L'ombelico", "La nuca", "Un tallone", "Il dito mignolo" }, { "In un pozzo in Macedonia", "In una caverna", "Nel labirinto di Dedalo", "In una torre del palazzo principale dell'Olimpo" }, { "Mai", "Una volta all'anno", "Ogni 6 anni", "Ogni 12 anni" }, { "Pesci", "Ucelli", "Anfibi", "Mammiferi" }, { "Da soli", "In famiglia", "In coppia", "In branco" }, { "30 km/h", "60 km/h", "90 km/h", "120 km/h" }, { "Effetto parto", "Svluppo", "Effetto cucciolo", "Effetto baby" }, { "Correre", "Nuotare", "Arrampicarsi", "Strisciare lentamente" }, { "In una tana di neve", "A Maiorca", "Sott'acqua", "Nei boschi" }, { "Pulcino", "Puledro", "Pulce", "Puparo" }, { "A Vienna", "A Firenze", "A Berlino", "A Washington" }, { "Il nome di una dea greca", "Il nome di una popstar americana", "Il nome di un diuo messicano", "Il nome di un liquore europeo" }, { "5 anni", "17 anni", "28 anni", "94 anni" }, { "Evoluzione", "Rivoluzione", "Risoluzione", "Eruzione" }, { "Non si sa", "Per regolare la temperatura corporea", "Per cambiare colore", "Per difesa" }, { "Fantasia", "Godzilla: il pianeta dei mostri", "Jurassic park", "Godzilla" }, { "Negli alveoli polmonari", "Nei padiglioni auricolari", "In un palloncino", "Nel ventilatore" }, { "Gas", "Zucchero", "Calcio", "Ormoni" }, { "Respirando", "Bevendo", "Facendo la doccia", "Tagliando i capelli" }, { "Sclera", "Iride", "Retina", "Cornea" }, { "Nei Armstrong", "Sigmund Jahn", "Juri Gagarin", "Sergei Krikalijow" }, { "Di lava", "Di acqua", "Di catrame", "Di carbone" }, { "Nello stomaco", "Nelle ossa", "Negli occhi", "Nell'intenstino" }, { "Budello osseo", "Collo osseo", "Midollo osseo", "Fibra ossea" }, { "Alle superficie", "Nel nucleo", "A 10 m di profondità", "A 300 m di profondità" }, { "Una", "18", "63", "194" }, { "Alla nascita", "A 10 anni", "A 20 anni", "A 30 anni" }, { "Gelatina alimentare", "Plasma", "Placenta", "Grasso infantile" }, { "10%", "30%", "70%", "90%" }, { "Nella Terra el Fuoco", "In Alaska", "In Siberia", "Nella penisola araba" }, { "A chiocciola", "A vortice", "A mulinello", "A spirale" }, { "Pianeta azzurro", "Pianeta casa", "Pianeta rosso", "Pianeta con gli anelli" }, { "Leonardo da Vinci", "Galileo Galilei", "Isaac Newton", "Albert Einstein" }, { "Mercury", "Wostock 1", "Space Shuttle", "Enterprise" } };
    private string[,] risposteEng = new string[,] { { "2", "7", "23", "17" }, { "Ides of March", "30th of March 44 b.C.", "33 a.C.", "150 a.C." }, { "6", "9", "12", "20" }, { "A. Einstein", "A. Volta", "I. Newton", "Leonardo Da Vinci" }, { "Cultivate the ground", "Pyramids building", "Serving the pharaoh", "Wash jails" }, { "Sphinx", "Obelisc", "Sarcophagus", "Mastaba" }, { "Ancient Kingdom", "Middle Kingdom", "New Kingdom", "Later Kingdom" }, { "Sand", "Wooden boards", "Paper", "Papyrus parchment" }, { "Temples", "Grave", "Houses", "Fortresses" }, { "A sculpture", "The pharaoh", "A made up creature", "A dead dried body" }, { "To light up with his 6 eyes", "To bark when souls arrive", "To keep company to Ade's chilldren", "To block everyone from getting out" }, { "Ares after a bet", "His brother, in revenge", "Zeus, after a fight versus the Titans", "The Earth at the beginning of time" }, { "Caserta's Royal mansion", "The Olympia's stadium", "The Colosseum", "The Cnosso's Maze" }, { "In feather and wax", "In paper and glue", "In braided papyrum", "In scrolls and rope" }, { "Laura", "Clizia", "Dafne", "Clori" }, { "To not jump in the waters", "To not slap them", "To pretend to be a prisoner", "To not fly away with them" }, { "The belly button", "The nape", "A heel", "A pinky" }, { "A reservoir in Macedonia", "In a cave", "In the Dedalo's Maze", "In a tower of the main palace on the Olympus" }, { "Never", "Once in a year", "Every 6 years", "Every 12 years" }, { "Fish", "Birds", "Amphibious", "Mammals" }, { "On their own", "In family", "In couple", "In packs" }, { "30 km/h", "60 km/h", "90 km/h", "120 km/h" }, { "Childbrith effect", "Growth", "Puppy effect", "baby effect" }, { "Run", "Swim", "Climb", "Slith slowly" }, { "In a snow cave", "In Maiorca", "Underwater", "In the woods" }, { "Chick", "Colt", "Flea", "Puppy" }, { "In Vienna", "In Florence", "In Berlin", "In Washington" }, { "A name of a greek goddess", "The name of an american popstar", "The name of a mexican god", "The name of an European liqueur" }, { "5 years", "17 years", "28 years", "94 years" }, { "Evolution", "Revolution", "Resolution", "Eruption" }, { "We don't know", "To regulate his body temperature", "To change colour", "To defence himself from any attack" }, { "Fantasia", "Godzilla: King of the Monsters", "Jurassic park", "Godzilla" }, { "In the lung alveoli", "In the ear cups", "In the baloon", "In the fan" }, { "Gasses", "Sugars", "Calcium", "Hormones" }, { "Breathing", "Drinking", "Taking a shower", "Triming your hair" }, { "Sclera", "Iris", "Retina", "Cornea" }, { "Nei Armstrong", "Sigmund Jahn", "Juri Gagarin", "Sergei Krikalijow" }, { "Of lava", "Of water", "Of tar", "Of carbon" }, { "In the stomach", "In the bones", "In the eyes", "In the intestine" }, { "Bone bowel", "Bone neck", "Bone marrow", "Bone fiber" }, { "On the surface", "In the nucleus", "At 10 m of depth", "At 300 m of depth" }, { "One", "18", "63", "194" }, { "By the time of birth", "At 10 years", "At 20 years", "At 30 years" }, { "Edible jelly", "Plasma", "Placenta", "Infant fat" }, { "10%", "30%", "70%", "90%" }, { "Tierra del Fuego", "In Alaska", "In Siberia", "In theArabian Peninsula" }, { "Snail shaped", "Turmoil shape", "Whirpool shape", "Spiral shape" }, { "Blue Planet", "Home Planet", "Red Planet", "Ringed Planet" }, { "Leonardo da Vinci", "Galileo Galilei", "Isaac Newton", "Albert Einstein" }, { "Mercury", "Wostock 1", "Space Shuttle", "Enterprise" } };
    private int[] riposteCorrette = { 2, 0, 2, 0, 1, 0, 2, 3, 1, 3, 3, 2, 3, 0, 2, 0, 2, 2, 1, 3, 3, 2, 2, 1, 2, 2, 2, 0, 1, 2, 0, 0, 0, 1, 0, 0, 1, 2, 1, 2, 1, 2, 2, 0, 3, 2, 1, 1 };
    // risposte come "lista" di stringhe e poi le rispettive risposte corrette
    public Risposta r1, r2, r3, r4, domanda, GameCPU, GamePG, puntiCPU, PuntiPG; // risposte di tipo Risposta (classe)

    private int dom, rand1, rand2, rand3, rand4; // domanda random e le sue risposte collegate

    public CursoreCampoDaTennis cursore; // cursore per il campo da tennis: quiz
    public ManoCampoDaTennis mano; // mano del campo da tennis

    public GameObject sfonfoGioco, sfonfoPausa, PlayPause, ExitPause, sfondoVictory, sfondoLose, sfondoRules, sfondoRulesBack, sfondoRulesEng, sfondoRulesBackEng; // variabili per lo sfondo, che non sono più come le altre che al posto di "sfond(f)o" come suffisso avevano 'b'
    public GameObject buttonRules, buttonPause, buttonPlay, buttonExit, GenitorePallina, buttonBack; // oggetti bottoni
    private bool Pausa, bPause, bRules, bPlayPause, bExitPause, bGioco, Rules, vittoria, exManoChiusa; // booleane per i background, vittoria, regole e stato passato della mano

    public Rigidbody pallina; // pallina come prefab di Unity
    private bool creat, creaDomanda; // variabili per creare le domande: testo e domanda
    
    void Start(){
        NDOMANDE = domande.GetLength(0); // la lunghezza di domande viene assegnata alla costante NDOMANDE
        explosion.sfondo = GenitorePallina; // si sceglie il colore dell'esplosione della pallina
        creat = true;
        creaDomanda = true; // creazione domande con font
        nPuntiGiocatore = 0;
        nPuntiCPU = 0;
        nGameCPU = 0;
        nGameGiocatore = 0; // nome e punteggio giocatori
        Pausa = false; // scena pausa
        bPause = false;
        bRules = false;
        bPlayPause = false;
        bExitPause = false;
        bGioco = true; // background settati a falsi
        vittoria = false; // appena spownata la schermata == !vittoria
        exManoChiusa = false; // mano nel passato == aperta
        sfondoRules.SetActive(false);
        sfondoRulesBack.SetActive(false);
        sfondoLose.SetActive(false); // disattivati gli sfondi
        mainMusic.Play(); // parte la musica apposita
    }
    
    void Update() {
        sfonfoGioco.SetActive(bGioco);
        sfonfoPausa.SetActive(bPause);
        PlayPause.SetActive(bPlayPause);
        ExitPause.SetActive(bExitPause); // si attivano tutti i background del gioco e della pausa

        if (!Pausa && !Rules) // se n'è la pausa nè le regole sono "in azione"
        {
            GameCPU.testo = "CPU\n" + nPuntiCPU.ToString();
            GamePG.testo = "PG\n" + nPuntiGiocatore.ToString();
            puntiCPU.testo = nGameCPU.ToString();
            PuntiPG.testo = nGameGiocatore.ToString(); // stampa dei punteggi e dei nomi: primo giro: a 0

            if (nGameCPU == 3 || nGameGiocatore == 3) { // numero di set vinti
                vittoria = true; // se si sono vinti 3 set: come nel tennis
                if (nGameGiocatore == 3) sfondoVictory.SetActive(true); // schermata vittoria
                else sfondoLose.SetActive(true); // sfonde della sconfitta dell'utente

                if (mano.isManoChiusa() && exManoChiusa == false) { // mano adesso == chiusa && mano passato == aperta
                    selezione.Play(); // suono della selezione
                    mainMusic.Play(); // musica del gioco
                    vittoriaMusic.Stop();
                    sconfittaMusica.Stop(); // fermate le musiche vittoria e sconfitta
                    nGameCPU = 0; nGameGiocatore = 0; nPuntiCPU = 0; nPuntiGiocatore = 0; // riazzerato tutto
                    sfondoVictory.SetActive(false);
                    sfondoLose.SetActive(false); // sfondi vittoria e sconfitta non settati attivi
                    vittoria = false; // nessuna vittoria
                } // il gioco è ripartito
            } else {
                if (MuoviPallina.isWaiting && creat != true) { // se la pallina sta aspettando e crea testo + font è falso allora:
                    if (creaDomanda) { // crea domanda
                        if (Cursore.lingua == 0) { // se la lingua è impostata su italiano
                            dom = Random.Range(0, NDOMANDE); // registro domande della lingua italiana
                            rand1 = Random.Range(0, 4);
                            
                            do { rand2 = Random.Range(0, 4);
                            } while (rand2 == rand1);
                            do { rand3 = Random.Range(0, 4);
                            } while (rand3 == rand1 || rand3 == rand2);
                            do { rand4 = Random.Range(0, 4);
                            } while (rand4 == rand1 || rand4 == rand2 || rand4 == rand3); // si scelgono con un algoritmo pseudo casuale le domande e le loro relative risposte
                            
                            domanda.testo = domande[dom]; // al testo viene assegnato il testo della domanda
                            r1.testo = risposte[dom, rand1];
                            r2.testo = risposte[dom, rand2];
                            r3.testo = risposte[dom, rand3];
                            r4.testo = risposte[dom, rand4]; // stessa cosa alle risposte
                            creaDomanda = false; // lo "turno" off dato che la domanda è stata già creata
                        } else { // lingua inglese
                            dom = Random.Range(0, NDOMANDE);
                            rand1 = Random.Range(0, 4);
                            
                            do { rand2 = Random.Range(0, 4);
                            } while (rand2 == rand1);
                            do { rand3 = Random.Range(0, 4);
                            } while (rand3 == rand1 || rand3 == rand2);
                            do { rand4 = Random.Range(0, 4);
                            } while (rand4 == rand1 || rand4 == rand2 || rand4 == rand3);
                            
                            domanda.testo = domandeEng[dom];
                            r1.testo = risposteEng[dom, rand1];
                            r2.testo = risposteEng[dom, rand2];
                            r3.testo = risposteEng[dom, rand3];
                            r4.testo = risposteEng[dom, rand4];
                            creaDomanda = false;
                        } // si fa la stessa cosa ma la lingua delle domande e delle risposte sarà quella inglese
                    }

                    if (cursore.isOnRisposta1() && mano.isManoChiusa() && exManoChiusa == false) // cursore su risposta 1 && ora la mano è chiusa && prima la mano era aperta
                    {
                        selezione.Play(); // suono selezione
                        MuoviPallina.isWaiting = false; // la pallina non sta aspettando
                        MuoviPallina.answer = MuoviPallina.answer1; // la pallina si muove sulla risposta 1
                        creat = true;
                        creaDomanda = true; // creazione della prossima domanda e delle rispettive risposte
                        if (controllaRisposta(rand1)) // controllo che la risposta data sia giusta
                        {
                            explosion.right = true; // esplosione verde == risposta corretta
                            nPuntiGiocatore += 15; // aggiungo i punti al giocatore: come nel tennis
                            if (nPuntiGiocatore == 60) {// fine set
                                nPuntiGiocatore = 0;
                                nGameGiocatore += 1; // azzero i punti e aggiungo un set
                            }
                        } else {
                            explosion.right = false; // esplosione rossa == risposta errata
                            nPuntiCPU += 15; // aggiungo i punti al pc
                            if (nPuntiCPU == 60) { // come nel tennis: il set
                                nPuntiCPU = 0;
                                nGameCPU += 1; // azzero i punti e aggiungo un set vinto al pc: avversario
                            }
                        }
                    }
                    if (cursore.isOnRisposta2() && mano.isManoChiusa() && exManoChiusa == false) // quello della risposta uno si rifà per tutte le altre domande-risposte date dall'utente
                    {
                        selezione.Play();
                        MuoviPallina.isWaiting = false;
                        MuoviPallina.answer = MuoviPallina.answer2;
                        creat = true;
                        creaDomanda = true;
                        if (controllaRisposta(rand2))
                        {
                            explosion.right = true;
                            nPuntiGiocatore += 15;
                            if (nPuntiGiocatore == 60)
                            {
                                nPuntiGiocatore = 0;
                                nGameGiocatore += 1;
                            }
                        }
                        else
                        {
                            nPuntiCPU += 15;
                            explosion.right = false;
                            if (nPuntiCPU == 60)
                            {
                                nPuntiCPU = 0;
                                nGameCPU += 1;
                            }
                        }
                    }
                    if (cursore.isOnRisposta3() && mano.isManoChiusa() && exManoChiusa == false) // risposta 3
                    {
                        selezione.Play();
                        MuoviPallina.isWaiting = false;
                        MuoviPallina.answer = MuoviPallina.answer3;
                        creat = true;
                        creaDomanda = true;
                        if (controllaRisposta(rand3))
                        {
                            explosion.right = true;
                            nPuntiGiocatore += 15;
                            if (nPuntiGiocatore == 60)
                            {
                                nPuntiGiocatore = 0;
                                nGameGiocatore += 1;
                            }
                        }
                        else
                        {
                            nPuntiCPU += 15;
                            explosion.right = false;
                            if (nPuntiCPU == 60)
                            {
                                nPuntiCPU = 0;
                                nGameCPU += 1;
                            }
                        }
                    }
                    if (cursore.isOnRisposta4() && mano.isManoChiusa() && exManoChiusa == false) // risposta 4
                    {
                        selezione.Play();
                        MuoviPallina.isWaiting = false;
                        MuoviPallina.answer = MuoviPallina.answer4;
                        creat = true;
                        creaDomanda = true;
                        if (controllaRisposta(rand4))
                        {
                            explosion.right = true;
                            nPuntiGiocatore += 15;
                            if (nPuntiGiocatore == 60)
                            {
                                nPuntiGiocatore = 0;
                                nGameGiocatore += 1;
                            }
                        }
                        else
                        {
                            nPuntiCPU += 15;
                            explosion.right = false;
                            if (nPuntiCPU == 60)
                            {
                                nPuntiCPU = 0;
                                nGameCPU += 1;
                            }
                        }
                    }
                    
                    if (cursore.isOnQ(buttonPause) && mano.isManoChiusa() && exManoChiusa == false) // mano sul pulsante pausa && mano chiusa adesso && mano aperta prima
                    {
                        selezione.Play(); // selezione game-play (suono)
                        mainMusic.Stop();
                        pauseMusic.Play(); // stop canzone gioco play canzone pausa
                        Pausa = true; // scena della pausa
                        bGioco = false;
                        bPause = true; // backgound impostati: on pausa off gioco
                    }
                    
                    if (cursore.isOnQ(buttonRules) && mano.isManoChiusa() && exManoChiusa == false) // mano sul pulsante regole && mano chiusa adesso && mano aperta prima
                    {
                        selezione.Play(); // selezione
                        bRules = true; // cambio sfondo
                        bGioco = false;
                        Rules = true; // schermata delle regole
                    }
                }
                
                if (creat) // creazione della nuova domanda con le risposte cl font
                {
                    Rigidbody p = Instantiate(pallina, pallina.transform.position, pallina.transform.rotation); // reimposta la posizione della pallina al centro
                    p.transform.SetParent(GenitorePallina.transform, false);
                    creat = false; // lo spengo dato che l'ho fatto ormai
                }
                
                if (nGameCPU == 3 || nGameGiocatore == 3) { // vittoria di una delle 2 parti
                    mainMusic.Stop(); // stop musica del gioco
                    if (nGameCPU == 3) sconfittaMusica.Play(); // musica della sconfitta
                    else  vittoriaMusic.Play(); // fa partire "We Are The Champions" creata dagli audio designer del team
                }
            }
        } else {
            if (Pausa) { // se siamo nella schermata della pausa
                if (cursore.isOnQ(buttonPlay)) { // si vuole ritornare a giocare: cursore sul bottone del Play
                    bPause = false;
                    bPlayPause = true; // cambio background
                    if (mano.isManoChiusa() && exManoChiusa == false) { // mano chiusa adesso e prima aperta
                        selezione.Play(); // suono selezione
                        mainMusic.Play();
                        pauseMusic.Stop(); // fermata musica pausa ripresa musica del gioco
                        bPlayPause = false;
                        bGioco = true; // impostazone backgrouns
                        Pausa = false; // schermata pausa finita
                    }
                } else {
                    bPause = true;
                    bPlayPause = false;
                    if (cursore.isOnQ(buttonExit)) { // se il cursore è sul tasto exit
                        bPause = false;
                        bExitPause = true;
                        if (mano.isManoChiusa() && exManoChiusa == false) {
                            selezione.Play();
                            bExitPause = false;
                            bGioco = true;
                            Pausa = false;
                            SceneManager.LoadScene(0); // si fa il load della scena del menù principale
                        }
                    } else {
                        bPause = true;
                        bExitPause = false; // si setta il background della pausa
                    }
                }
            } else {
                if (Cursore.lingua == 0) { // lingua italiana
                    if (cursore.isOnQ(buttonBack)) { // bottone del back
                        sfondoRules.SetActive(false);
                        sfondoRulesBack.SetActive(true); // impostazione degli sfondi, attivato quello del bottone back più grande
                        if (mano.isManoChiusa() && exManoChiusa == false)  {
                            selezione.Play();
                            sfondoRulesBack.SetActive(false);
                            bGioco = true;
                            Rules = false; // ritorno al gioco, turned off schermata delle regole
                        }
                    } else {
                        sfondoRules.SetActive(true);
                        sfondoRulesBack.SetActive(false); // altrimenti la schermata delle regole sarebbe andata avanti
                    }
                } else {
                    if (cursore.isOnQ(buttonBack)) { // se è sul pulsante per andare indietro
                        sfondoRulesEng.SetActive(false);
                        sfondoRulesBackEng.SetActive(true); // si cambia lingua: in inglese
                        if (mano.isManoChiusa() && exManoChiusa == false) {
                            selezione.Play();
                            sfondoRulesBackEng.SetActive(false);
                            bGioco = true;
                            Rules = false; // si ritorna al gioco si reimpostano gli sfondi e le schermate
                        }
                    } else {
                        sfondoRulesEng.SetActive(true);
                        sfondoRulesBackEng.SetActive(false); // altrimenti si restava sulla schermata delle regole in inglese
                    }
                }
            }
        }
        exManoChiusa = mano.isManoChiusa(); // stato della mano passato quello attuale
    }

    private bool controllaRisposta(int n) return n == riposteCorrette[dom]; // controlla se la risposta data è corretta o meno in base ai "dizionari" scritti nelle prime righe del codice
}
