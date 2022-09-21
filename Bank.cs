
public class Bank
{
    string name;

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

    public List<Client> GetAllClients()
    {
        return clients;
    }

}
