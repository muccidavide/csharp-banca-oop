
using Microsoft.VisualBasic;
using System.Data;

public class Loan
{
    static int idCounter = 1;
    public int id { get; protected set; }
    public int amount { get; set; }
    public int singleRate { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }

    public Client client;

    public Loan(int amount, int singleRate, DateTime startDate,  Client client)
    {

        this.id = idCounter++;
        this.amount = amount;
        this.singleRate = singleRate;
        this.startDate = startDate;
        this.client = client;
        // Per calcolare la data di fine divido amount totale per la singola rata e aggiungo i mesi dalla data di inizio
       
        this.endDate = setEndDate(amount,singleRate);
    }

    public DateTime setEndDate(int amount, int singleRate)
    {
        int monthLeft;
        if (amount % singleRate == 0)
        {
            monthLeft = amount / singleRate;
        }
        else
        {
            monthLeft = (amount / singleRate) + 1;
        }

        DateTime newEndDate = startDate.AddMonths(monthLeft);
        return newEndDate;
    }

    public int TimeLeft()
    {
        DateTime today = DateTime.Now;

        int left = ((this.endDate.Year - today.Year) * 12) + endDate.Month - today.Month;

        return left;
    }

    public void Print()
    {
        Console.WriteLine("Cliente: " + client.FirstName + " " + client.LastName);
        Console.WriteLine("Prestito - ID: " + id);
        Console.WriteLine("Somma Prestata: " + amount);
        Console.WriteLine("Rata: " + singleRate);
        Console.WriteLine("Data d'inizio: " + startDate);
        Console.WriteLine("Data di fine: " + endDate);
        Console.WriteLine("/////////////////");
    }
}