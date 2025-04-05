namespace KonyvtarAsztali
{
    internal class Statistics
    {
        private readonly List<Book> books = new BookRepository().Books.ToList();
        internal List<Book> Books => books;

        internal int MoreThanNumberOfPages(int numberOfPages)
        {
            return books.Count((book) => book.Page_count > numberOfPages);
        }

        internal bool IsBookExistEarlierThanGivenYear(int year)
        {
            return books.Any((book) => book.Publish_year < year);
        }

        internal Book? LongestBook()
        {
            return books.MaxBy((book) => book.Page_count);
        }

        internal KeyValuePair<string, int> AuthorWithMostBooks()
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            for (int i = 0; i < books.Count; i++)
            {
                if (keyValuePairs.ContainsKey(books[i].Author))
                {
                    keyValuePairs[books[i].Author]++;
                }
                else
                {
                    keyValuePairs.Add(books[i].Author, 1);
                }
            }
            foreach (KeyValuePair<string, int> keyValuePair in keyValuePairs)
            {
                Console.WriteLine(keyValuePair);
            }
            return keyValuePairs.MaxBy((KeyValuePair) => KeyValuePair.Value);
        }

        internal Book? GetBookByTitle(string? title)
        {
            return books.Find((book) => book.Title == title);
        }
    }
}
