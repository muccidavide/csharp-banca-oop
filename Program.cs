
/*
 Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.
La banca è caratterizzata da
- un nome
- un insieme di clienti (una lista)
- un insieme di prestiti concessi ai clienti (una lista)
I clienti sono caratterizzati da
- nome,
- cognome,
- codice fiscale
- stipendio
I prestiti sono caratterizzati da
- ID
- intestatario del prestito (il cliente),
- un ammontare,
- una rata,
- una data inizio,
- una data fine.
Per la banca deve essere possibile:
aggiungere, modificare e ricercare un cliente.
aggiungere un prestito.
effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
Bonus:
visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.
 */

Bank bancaIntesa = new Bank("Banca Intesa");

// FAKE DB CLIENTS
bancaIntesa.AddNewClient("Giovanni", "Rossi", "GVNNRSS23M456G", 1800);
bancaIntesa.AddNewClient("Giovanni", "Mucci", "GVNNMCC23M456G", 1600);

bancaIntesa.AddNewClient("Giovanni", "Rossi", "GRNNRSS23M456G", 1800);
bancaIntesa.AddNewClient("Giovanni", "Mucci", "GYNNMCC23M456G", 1600);

// FAKE DB:
DateTime startDate = DateTime.Now;
Client clientRandom = bancaIntesa.SearchClient("GYNNMCC23M456G");

// Aggiunta/modifica/rimozione clienti
bancaIntesa.AddNewLoanToClient(10000, 200, startDate,  clientRandom);
bancaIntesa.AddNewLoanToClient(40000, 1000, startDate,  clientRandom);

bancaIntesa.RemoveClient(2);
bancaIntesa.modifyClient(1, "salary", "1234566");

// Stampa Info tutti i clienti
bancaIntesa.GetAllClientsAndPrint();

// Stampa Info Tutti i Prestiti
bancaIntesa.GetAllLoansAndPrint();

// Ricerca Prestiti Concessi
List<Loan> listLoan = bancaIntesa.GetLoanOfAClient("GYNNMCC23M456G");


// La ricerca è effettuata in base all'ULTIMA RATA DA PAGARE non alla somma delle mensilità
// (un cliente puo aprire piu prestiti ma la somma mensile da versare va ad aumentare in base alle rate mensili dei singoli prestiti)
// !!! QUINDI NON VENGONO SOMMATE LE MENSILITA' DELLE RATE
Console.WriteLine("mesi rimanenti da pagare: " + bancaIntesa.TimeLeftClient("GYNNMCC23M456G"));





