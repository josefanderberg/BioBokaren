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

    string selectedMovie = "";
    string selectedShowtime = "";
    int ticketCount = 0;
    bool hasStudentDiscount = false;


        
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
                Console.Write("~ Ogiltigt val, försök igen (1-5): ");
            }
            switch (input)
            {
                case 1:
                    ListMovies();
                    Console.WriteLine("--------------");
                    Console.Write("> Klicka på Enter");
                    Console.ReadLine();
                    break;
                case 2:
                    selectedMovie = GetMovieChoice();
                    selectedShowtime = GetShowtimeChoice();
                    ticketCount = GetTicketCount();
                    SelectMovieAndTickets(selectedMovie, selectedShowtime, ticketCount);
                    break;
                case 3:
                    hasStudentDiscount = ToggleStudentDiscount(hasStudentDiscount);
                    break;
                case 4:
                    PrintReceipt(selectedMovie, selectedShowtime, ticketCount, hasStudentDiscount);
                    break;
                case 5:
                    Console.WriteLine("Tack för besöket! Hej då!");
                    return;
                default:
                    Console.WriteLine("~ Ogiltigt val, försök igen.");
                    break;
            }
        }
    }
    static void ListMovies()
    {
        Console.Clear();
        Console.WriteLine("----- FILMER -----");
        for (int i = 0; i < movies.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {movies[i]} - {showtimes[i]} - {basePrices[i]} {CURRENCY}");
        }
    }
    static void SelectMovieAndTickets(string selectedMovie, string selectedShowtime, int ticketCount)
    {
        Console.Clear();
        Console.WriteLine("---- DINA VAL ----");
        Console.WriteLine($"Du har valt {selectedMovie} kl {selectedShowtime} - {ticketCount} biljetter.");
        Console.WriteLine("------------------");
        Console.Write("> Klicka på Enter");
        Console.ReadLine();
    }

    static string GetMovieChoice()
    {
        Console.Clear();
        ListMovies();
        Console.Write("Ange filmnummer (1-3): ");

        string selectedMovie;
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
                Console.Write("~ Ogiltigt val, försök igen (1-3): ");
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
        
        return selectedMovie;
    }

    static string GetShowtimeChoice()
    {
        string selectedShowtime;
        int timeChoice;
        //Select time
        while (!int.TryParse(Console.ReadLine(), out timeChoice) || timeChoice < 1 || timeChoice > showtimes.Length)
        {
            Console.Write("~ Ogiltigt val, försök igen (1-3): ");
        }
        selectedShowtime = showtimes[timeChoice - 1];
        return selectedShowtime;
    }

    static int GetTicketCount()
    {
        int ticketCount;
        //Select number of tickets
        Console.Write("Ange antal biljetter: ");
        while (!int.TryParse(Console.ReadLine(), out ticketCount) || ticketCount < 1)
        {
            Console.Write("~ Ogiltigt antal, försök igen: ");
        }
        return ticketCount;
    }


    static bool ToggleStudentDiscount(bool hasStudentDiscount)
    {
        Console.Clear();
        Console.WriteLine("--------------");

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
        Console.Write("> Klicka på Enter");
        Console.ReadLine();
        return hasStudentDiscount;
    }

    static void PrintReceipt(string selectedMovie, string selectedShowtime, int ticketCount, bool hasStudentDiscount)
    {
        Console.Clear();
        if (string.IsNullOrEmpty(selectedMovie))
        {
            Console.WriteLine("----------------");
            Console.WriteLine("˙~ Ingen film vald. Vänligen välj en film först.");
            Console.WriteLine("----------------");
            Console.Write("> Klicka på Enter");
            Console.ReadLine();
            return;
        }
        else
        {
            string showStudentDiscount;
            double totalPrice;
            if (hasStudentDiscount)
            {
                showStudentDiscount = "JA - 15% Rabatt";
                totalPrice = CalculateTotalPrice(selectedMovie, ticketCount, hasStudentDiscount);
            }
            else
            {
                showStudentDiscount = "Nej";
                totalPrice = CalculateTotalPrice(selectedMovie, ticketCount);
            }

            // Beräkna pris exklusive moms och momsbelopp direkt i metoden
            double priceExclTax = totalPrice / (1 + TAX_RATE);
            double taxAmount = totalPrice - priceExclTax;

            Console.Clear();
            Console.WriteLine("---- Kvitto ----");
            Console.WriteLine($"Film: {selectedMovie}");
            Console.WriteLine($"Tid: {selectedShowtime}");
            Console.WriteLine($"Antal biljetter: {ticketCount}");
            Console.WriteLine($"Studentrabatt: {showStudentDiscount}");
            Console.WriteLine("----------------");
            Console.WriteLine($"Pris exkl. moms: {Math.Round(priceExclTax, 2)} {CURRENCY}");
            Console.WriteLine($"Moms (6%): {Math.Round(taxAmount, 2)} {CURRENCY}");
            Console.WriteLine($"Totalt pris: {totalPrice} {CURRENCY}");
            Console.WriteLine("----------------");
            Console.Write("> Klicka på Enter");
            Console.ReadLine();
        }
    }
    static double CalculateTotalPrice(string selectedMovie, int ticketCount)
    {
        int indexOfMovie = Array.IndexOf(movies, selectedMovie);
        double calculatePrice = ticketCount * basePrices[indexOfMovie];
        return Math.Round(calculatePrice, 2);
    }

    static double CalculateTotalPrice(string selectedMovie, int ticketCount, bool hasStudentDiscount)
    {
        int indexOfMovie = Array.IndexOf(movies, selectedMovie);
        double calculatePrice = ticketCount * basePrices[indexOfMovie];
        
        if (hasStudentDiscount)
        {
            calculatePrice = calculatePrice * (1 - STUDENT_DISCOUNT);
        }
        
        return Math.Round(calculatePrice, 2);    
    }
}