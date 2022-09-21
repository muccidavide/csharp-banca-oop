
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

// FAKE DB CLIENTS : 
// Aggiunta/modifica/rimozione clienti
bancaIntesa.AddNewClient("Giovanni", "Rossi", "GVNNRSS23M456G", 1800);
bancaIntesa.AddNewClient("Davide", "Mucci", "GVNNMCC23M456G", 1600);

bancaIntesa.AddNewClient("Giovanni", "Rossi", "GRNNRSS23M456G", 1800);
bancaIntesa.AddNewClient("Davide", "Mucci", "GYNNMCC23M456G", 1600);

bancaIntesa.RemoveClient(2);
bancaIntesa.modifyClient(1, "salary", "1234566");

// FAKE DB:
DateTime startDate = DateTime.Now;
Client clientRandom = bancaIntesa.SearchClient("GYNNMCC23M456G");

bancaIntesa.AddNewLoanToClient(10000, 200, startDate,  clientRandom);
bancaIntesa.AddNewLoanToClient(40000, 1000, startDate,  clientRandom);

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

// TABELLA PRESTITI
Console.WriteLine("//////////////////////////////////////");
Console.WriteLine(" TABELLA PRESTITI");
Console.WriteLine(String.Format("|{0,2}|{1,6}|{2,20}|{3,20}|", "ID","TOTALE", "INIZIO", "FINE"));
foreach (Loan loan in listLoan)
{
    Console.WriteLine(String.Format("|{0,2}|{1,6}|{2,20}|{3,20}|", loan.id, loan.amount, loan.startDate, loan.endDate));
}


// TABELLA CLIENTI
Console.WriteLine("//////////////////////////////////////");
Console.WriteLine(" TABELLA CLIENTI");
Console.WriteLine(String.Format("|{0,2}|{1,10}|{2,10}|{3,16}|{4,10}|", "ID", "NOME", "COGNOME", "CV", "SALARIO"));
foreach (Client client in bancaIntesa.clients)
{
    Console.WriteLine(String.Format("|{0,2}|{1,10}|{2,10}|{3,16}|{4,10}|", client.id, client.FirstName, client.LastName, client.CV, client.Salary));
}


