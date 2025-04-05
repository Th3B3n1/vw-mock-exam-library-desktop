using System.Windows;
using MySql.Data.MySqlClient;

namespace KonyvtarAsztali
{
    public partial class MainWindow : Window
    {
        private readonly BookRepository bookRepository = new BookRepository();
        public MainWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                table.ItemsSource = bookRepository.Books.ToList();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Database error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unknown error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Biztos szeretné törölni\r\na kiválasztott könyvet?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Book? book = table.SelectedItem as Book;
                    bookRepository.Books.Remove(book);
                    bookRepository.SaveChanges();
                    table.ItemsSource = bookRepository.Books.ToList();
                    MessageBox.Show("Sikeres törlés", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Nem történt törlés", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Törléshez előbb válasszon ki könyvet", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
