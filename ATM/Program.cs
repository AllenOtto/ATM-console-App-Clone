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

    // Create main function
    public static void Main(string[] args)
    {
        // Create a list of users of type CardHolder each having a card number, a pin number,
        // a first and last name and an account balance
        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("4587456698525221", 1232, "Pamela", "Ombuds", 34540.20));
        cardHolders.Add(new CardHolder("1254785412569875", 5698, "John", "Ondimu", 2365480.40));
        cardHolders.Add(new CardHolder("2587569832547896", 1478, "Kelvin", "Karanja", 6012.23));
        cardHolders.Add(new CardHolder("9856321478569874", 5890, "Elvis", "Gatimu", 23569875.08));
        cardHolders.Add(new CardHolder("2452241789654755", 2365, "Nafula", "Mary", 33.03));
        cardHolders.Add(new CardHolder("2358744589996211", 7854, "Lucy", "Wamuyu", 7890.62));

        // Prompt user
        Console.WriteLine("Welcome to SimpleATM.");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        CardHolder currentUser;

        // Check if user has a valid card number
        while(true)
        {
            try
            {
                // Fetch card number from user
                debitCardNum = Console.ReadLine();
                // Check for availability of user entered cardNumber in our db/list
                // If present, return it the object that contains it, storing it in currentUser
                currentUser = cardHolders.FirstOrDefault(arr => arr.CardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again."); }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Card not recognized. Please try again. {e}");
            }
        }

        // Check if PIN entered matches that of the user whose card number was used to return our currentUser object
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                // Fetch pin number from user parsing it into a string then storing it in userPin variable
                userPin = int.Parse(Console.ReadLine());
                
                // Checked if user entered PIN number equals PIN of currentUser
                if (currentUser.Pin == userPin) { break; }
                else { Console.WriteLine("PIN error. Please try again."); }
            }
            catch (Exception e)
            {
                Console.WriteLine($"PIN error. Please try again. {e}");
            }
        }

        Console.WriteLine($"Welcome, {currentUser.FirstName} :) ");
        int option = 0;

        do
        {
            // Display our options
            currentUser.PrintOptions();
            try
            {
                // Get user choice
                option = int.Parse(Console.ReadLine());
            } // Watch for any errors
            catch (Exception e) { Console.WriteLine(e); }

            // Run relevant methods based on user choice.
            if (option == 1) { currentUser.Deposit(currentUser); Console.WriteLine("Select another option: "); }
            else if(option == 2) { currentUser.Withdraw(currentUser); Console.WriteLine("Select another option: "); }
            else if(option == 3) { currentUser.GetBalance(currentUser); Console.WriteLine("Select another option: "); }
            else if(option == 4) { break; }
            else { option = 0; }
        } // Keep running unless option equals 4
        while (option != 4);
        Console.WriteLine($"Thank you, {currentUser.FirstName}. Have a nice day.");
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
            Console.WriteLine($"Withdrawal successful. Your current balance is: {currentUser.Balance}");
        } else
        {
            Console.WriteLine($"You have insufficient funds to withdraw {withdrawal}. Your current balance is {currentUser.Balance}");
        }
    }

    void GetBalance(CardHolder currentUser)
    {
        Console.WriteLine($"Your current account balance is {currentUser.Balance}");
    }
}