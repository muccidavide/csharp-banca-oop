
public class Client
{
    static int idCounter = 1;
    public int id { get; protected set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CV { get; set; }
    public int Salary { get; set; }

    List<Loan> loanClient;

    public Client(string firstname, string lastName, string cV, int salary)
    {
        this.id = idCounter++;
        this.Firstname = firstname;
        this.LastName = lastName;
        CV = cV;
        this.Salary = salary;
        this.loanClient = new List<Loan>();
    }
}
