using System.Windows;
using MySql.Data.MySqlClient;

namespace KonyvtarAsztali
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Contains("--stat"))
            {
                try
                {
                    Statistics statistics = new();
                    List<Book> books = statistics.Books;
                    for (int i = 0; i < books.Count; i++)
                    {
                        Console.WriteLine(books[i].Title);
                    }
                    Console.WriteLine($"500 oldalnál hosszabb könyvek száma: {statistics.MoreThanNumberOfPages(500)}");
                    Console.WriteLine(statistics.IsBookExistEarlierThanGivenYear(1950) ? "Van 1950-nél régebbi könyv" : "Nincs 1950-nél régebbi könyv");
                    Book? longestBook = statistics.LongestBook();
                    Console.WriteLine($"A leghosszabb könyv:\n\tSzerző: {longestBook?.Author}\n\tCím: {longestBook?.Title}\n\tKiadás éve: {longestBook?.Publish_year}\n\tOldalszám: {longestBook?.Page_count}\n\t");
                    Console.WriteLine(statistics.AuthorWithMostBooks().Key);
                    Console.WriteLine("Adjon meg egy könyv címet:");
                    string? title = Console.ReadLine();
                    Book? book = statistics.GetBookByTitle(title);
                    Console.WriteLine($"Az megadott könyv szerzője: {book?.Author}");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
            }
            else
            {
                MainWindow window = new();
                Application application = new();
                application.Run(window);
            }
        }
    }
}
