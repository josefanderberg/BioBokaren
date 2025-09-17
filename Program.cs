using System;
class Program
{

    private static string[] movies = { "Sausage Party", "Kapernaum", "I Origin" };
    private static string[] showtimes = { "14:00", "16:00", "18:00" };
    private static double[] basePrices = { 129.00, 139.00, 149.00 };

    const double TAX_RATE = 0.06;
    const double STUDENT_DISCOUNT = 0.15;
    const string CURRENCY = "kr";

    static void Main(string[] args)
    {
        ShowMenu();
    }
    static void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---- BIOBOKAREN ----");
            Console.WriteLine("1. Lista filmer");
            Console.WriteLine("2. Välj film & tid, ange biljetter");
            Console.WriteLine("3. Lägg på/ta bort studentrabatt");
            Console.WriteLine("4. Skriv ut kvitto");
            Console.WriteLine("5. Avsluta");

            int input;
            Console.Write("Välj ett alternativ (1-5): ");
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 5)
            {
                Console.Write("Ogiltigt val, försök igen (1-5): ");
            }
            switch (input)
            {
                case 1:
                    ListMovies();
                    Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
                    Console.ReadLine();
                    break;
                case 2:
                    SelectMovieAndTickets();
                    break;
                case 3:
                    ToggleStudentDiscount();
                    break;
                case 4:
                    PrintReceipt();
                    break;
                case 5:
                    Console.WriteLine("Tack för besöket! Hej då!");
                    return;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }
    static void ListMovies()
    {
        Console.Clear();
        Console.WriteLine("Tillgängliga filmer:");
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {movies[i]} - {showtimes[i]} - {basePrices[i]} {CURRENCY}");
        }

    }
    static void SelectMovieAndTickets()
    {
        Console.Clear();
        ListMovies();
        Console.Write("Ange filmnummer (1-3):");

        int movieChoice;
        //Selcet movie
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out movieChoice) && movieChoice >= 1 && movieChoice <= movies.Length)
            {
                break;
            }
            else
            {
                Console.Write("Ogiltigt val, försök igen (1-3): ");
            }
        }

        int timeChoice;
        //Show the times
        Console.Write("Välj tid:");
        for (int i = 0; i < showtimes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {showtimes[i]}");
        }
        //Select time
        while (!int.TryParse(Console.ReadLine(), out timeChoice) || timeChoice < 1 || timeChoice > showtimes.Length)
        {
            Console.Write("Ogiltigt val, försök igen (1-3): ");
        }

        //Select number of tickets
        Console.Write("Ange antal biljetter: ");
        int ticketCount;
        while (!int.TryParse(Console.ReadLine(), out ticketCount) || ticketCount < 1) ;
        {
            Console.Write("Ogiltigt antal, försök igen: ");
        }
        Console.WriteLine($"Du har valt Film {movieChoice} vid {timeChoice} med {ticketCount} biljetter.");
        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
        Console.ReadLine();
    }
    static void ToggleStudentDiscount()
    {
        Console.Write("Vill du lägga på eller ta bort studentrabatt? (på/av): ");
        string discountChoice = Console.ReadLine();

        if (discountChoice.ToLower() == "på")
        {
            Console.WriteLine("Studentrabatt har lagts på.");
        }
        else if (discountChoice.ToLower() == "av")
        {
            Console.WriteLine("Studentrabatt har tagits bort.");
        }
        else
        {
            Console.WriteLine("Ogiltigt val, försök igen.");
        }
    }
    static void PrintReceipt()
    {
        Console.WriteLine("Här är ditt kvitto:");
        Console.WriteLine("Film: Film A");
        Console.WriteLine("Tid: 14:00");
        Console.WriteLine("Antal biljetter: 2");
        Console.WriteLine("Studentrabatt: Ja");
        Console.WriteLine("Totalt pris: 120 kr");
    }
}