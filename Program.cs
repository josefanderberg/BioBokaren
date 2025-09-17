using System;
class Program
{

    private static string[] movies = { "Sausage Party", "Kapernaum", "I Origin" };
    private static string[] showtimes = { "14:00", "16:00", "18:00" };
    private static double[] basePrices = { 129.00, 139.00, 149.00 };

    const double TAX_RATE = 0.06;
    const double STUDENT_DISCOUNT = 0.15;
    const string CURRENCY = "kr";

    private static string selectedMovie = "";
    private static string selectedShowtime = "";
    private static int ticketCount;
    private static bool hasStudentDiscount = false;

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
                    Console.WriteLine("--------------");
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
        Console.WriteLine("----FILMER----");
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {movies[i]} - {showtimes[i]} - {basePrices[i]} {CURRENCY}");
        }

    }
    static void SelectMovieAndTickets()
    {
        Console.Clear();
        ListMovies();
        Console.Write("Ange filmnummer (1-3): ");

        int movieChoice;
        //Select movie
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

        selectedMovie = movies[movieChoice - 1];

        //Show the times
        Console.WriteLine("Välj tid:");
        for (int i = 0; i < showtimes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {showtimes[i]}");
        }
        Console.Write("> ");

        int timeChoice;
        //Select time
        while (!int.TryParse(Console.ReadLine(), out timeChoice) || timeChoice < 1 || timeChoice > showtimes.Length)
        {
            Console.Write("Ogiltigt val, försök igen (1-3): ");
        }
        selectedShowtime = showtimes[timeChoice - 1];

        //Select number of tickets
        Console.Write("Ange antal biljetter: ");
        while (!int.TryParse(Console.ReadLine(), out ticketCount) || ticketCount < 1)
        {
            Console.Write("Ogiltigt antal, försök igen: ");
        }

        Console.WriteLine($"Du har valt {selectedMovie} vid {selectedShowtime} med {ticketCount} biljetter.");
        Console.WriteLine("--------------");
        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
        Console.ReadLine();
    }
    static void ToggleStudentDiscount()
    {

        if (hasStudentDiscount == !true)
        {
            hasStudentDiscount = true;
            Console.WriteLine("Du har aktiverat din studentrabatt.");
        }
        else
        {
            hasStudentDiscount = false;
            Console.WriteLine("Du har avaktiverat din studentrabatt.");
        }
        Console.WriteLine("--------------");
        Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
        Console.ReadLine();
    }
    static void PrintReceipt()
    {
        if (string.IsNullOrEmpty(selectedMovie))
        {
            Console.WriteLine("Ingen film vald. Vänligen välj en film först.");
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadLine();
            return;
        }
        else
        {
            double totalPrice = CalculateTotalPrice(selectedMovie);

            Console.Clear();
            Console.WriteLine("---- Kvitto ----");
            Console.WriteLine($"Film: {selectedMovie}");
            Console.WriteLine($"Tid: {selectedShowtime}");
            Console.WriteLine($"Antal biljetter: {ticketCount}");
            Console.WriteLine($"Studentrabatt: {hasStudentDiscount}");
            Console.WriteLine($"Totalt pris: {totalPrice} {CURRENCY}");
            Console.WriteLine("----------------");
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadLine();
        }
    }
    public static double CalculateTotalPrice(string selectedMovie)
    {
        


        double showTotalPrice = 0.0;
        return showTotalPrice;
    }
}