using System;

// Create a cardHolder class
public class CardHolder
{
    private string cardNum;
    private int pin;
    private string firstName;
    private string lastName;
    private double balance;

    // Create constructor for CardHolder assigning it its associated properties
    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance) {
        this.CardNum = cardNum;
        this.Pin = pin;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Balance = balance;
    }

    // Create getters and setters for each Cardholder property 
    public string CardNum
    {
        get { return cardNum; }
        set { cardNum = value; } 
    }

    public int Pin
    {
        get { return pin; }
        set { pin = value;  }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public double Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    // Create main 
    public static void Main(string[] args)
    {
        CardHolder cardHolder = new CardHolder("444", 1234, "Ann", "Wanjiru", 505345.50);
    }

    // Display options available to currentUser/CardHolder 
    void PrintOptions()
    {
        Console.WriteLine("Please choose from one of the following options: ");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Show Balance");
        Console.WriteLine("4. Exit");
    }

    void Deposit(CardHolder currentUser)
    {
        Console.WriteLine("How much $$ would you like to deposit: ");
        // Get amount to withdraw
        double deposit = Convert.ToDouble(Console.ReadLine());
        // Update currentUser balance
        currentUser.Balance += deposit;
        Console.WriteLine($"Deposit successful. Your current balance is {currentUser.Balance}");
    }

    void Withdraw(CardHolder currentUser)
    {
        Console.WriteLine("How much money would you like to withdraw: ");
        double withdrawal = Convert.ToDouble(Console.ReadLine());
        // Check that user has more money than they want to withdraw
        if(currentUser.Balance > withdrawal)
        {
            // Proceed with transaction. Update balance with withdrawal amount less than before
            currentUser.Balance -= withdrawal;
            Console.WriteLine("Withdrawal successful.");
        } else
        {
            Console.WriteLine($"You have insufficient funds to withdraw {withdrawal}. Your current balance is {currentUser.Balance}");
        }
    }

    void getBalance()
    {
        Console.WriteLine($"Your current account balance is {currentUser.Balance}");
    }










}