
public class Bank
{
    string name;
    int idCounter;

    List<Client> clients;
    List<Loan> loans;

    public Bank(string name)
    {
        this.name = name;
        this.clients = new List<Client>();
        this.loans = new List<Loan>();
    }



    // Aggiungere Cliente
    public void AddNewClient(string firstName, string lastName, string CV, int salary)
    {
        Client client = new Client(firstName, lastName, CV, salary);
        this.clients.Add(client);
    }
    // Modificare cliente 
    public void modifyClient(int ID, string toModify, string modification) 
    {
        foreach (Client client in this.clients)
        {
            if(client.id == ID)
            {
       
                switch (toModify)
                {
                    case "firstName":

                        // Funzione name
                        client.FirstName = modification;
                        break;

                    case "lastName":
                        // Funzione Cognome
                        client.LastName = modification;
                        break;

                    case "CV":
                        // Funzione Cv
                        client.CV = modification;
                        break ;
                    case "salary":
                        // Funzione salario
                        client.Salary = Convert.ToInt32(modification);
                        break;
                }
            }
        }

    }
    // Rimuovere Cliente 
    public void RemoveClient(int ID)
    {
        for (int i = 0; i < this.clients.Count; i++)
        {
            if (clients[i].id == ID)
            {
                this.clients.Remove(clients[i]);
            }
        }   
    }

    // Cercare un utente
    public Client SearchClient(string query)
    {
        foreach(Client client in this.clients)
        {
            if(client.FirstName.Contains(query) || 
                client.LastName.Contains(query) || 
                client.CV.Contains(query))
            {
                return client;
            }
        }

        return clients[1]; // DA FIXARE IN CASO DI RISULTATO NN TROVATO
        
    }
    
    
    
    
    
    
    
    // Stampare Clienti (DA FIXARE: Provvisoria per vedere risultati a schermo)
    public void GetAllClientsAndPrint()
    {

        foreach (Client client in clients)
        {
            Console.WriteLine(client.id + " " + client.FirstName + " " + client.LastName + " " + client.Salary);
        }
    }

}
