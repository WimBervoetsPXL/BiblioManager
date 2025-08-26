using BiblioManager.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiblioManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<LibraryItem> _items = new List<LibraryItem>();
        Dictionary<string, List<LibraryItem>> _loans = new Dictionary<string, List<LibraryItem>>();

        public MainWindow()
        {
            InitializeComponent();

            SeedData();
        }

        private void SeedData()
        {
            // === Books ===
            _items.Add(new Book("Clean Code", "Robert C. Martin", 464));
            _items.Add(new Book("The Pragmatic Programmer", "Andrew Hunt", 352));
            _items.Add(new Book("Design Patterns", "Erich Gamma", 395));
            _items.Add(new Book("Refactoring", "Martin Fowler", 431));
            _items.Add(new Book("Head First C#", "Andrew Stellman", 720));
            _items.Add(new Book("Introduction to Algorithms", "Thomas H. Cormen", 1312));
            _items.Add(new Book("C# in Depth", "Jon Skeet", 900));

            // === DVDs ===
            _items.Add(new Dvd("Inception", "Christopher Nolan", 148));
            _items.Add(new Dvd("The Matrix", "Wachowskis", 136));
            _items.Add(new Dvd("Interstellar", "Christopher Nolan", 169));
            _items.Add(new Dvd("The Godfather", "Francis Ford Coppola", 175));
            _items.Add(new Dvd("Lord of the Rings: Fellowship", "Peter Jackson", 178));
            _items.Add(new Dvd("Jurassic Park", "Steven Spielberg", 127));
            _items.Add(new Dvd("The Dark Knight", "Christopher Nolan", 152));

            // === Games ===
            _items.Add(new Game("Zelda: Tears of the Kingdom", "Switch", 12));
            _items.Add(new Game("Forza Horizon 5", "Xbox", 3));
            _items.Add(new Game("Elden Ring", "PC", 16));
            _items.Add(new Game("FIFA 24", "PlayStation", 3));
            _items.Add(new Game("Minecraft", "PC", 7));
            _items.Add(new Game("The Witcher 3", "PC", 18));
        }

        private void ItemType_Checked(object sender, RoutedEventArgs e)
        {
            if(panelBook == null || panelDvd == null || panelGame == null)
            {
                //Bug tijdens laden van venster, panels bestaan nog niet.
                return;
            }

            if (rbBook.IsChecked == true)
            {
                panelBook.Visibility = Visibility.Visible;
                panelDvd.Visibility = Visibility.Collapsed;
                panelGame.Visibility = Visibility.Collapsed;
            }
            else if (rbDvd.IsChecked == true)
            {
                panelBook.Visibility = Visibility.Collapsed;
                panelDvd.Visibility = Visibility.Visible;
                panelGame.Visibility = Visibility.Collapsed;
            }
            else if (rbGame.IsChecked == true)
            {
                panelBook.Visibility = Visibility.Collapsed;
                panelDvd.Visibility = Visibility.Collapsed;
                panelGame.Visibility = Visibility.Visible;
            }
        }

        private void OnLoanItem_Clicked(object sender, RoutedEventArgs e)
        {
            //Loan selected item:
            LibraryItem selected = lstItems.SelectedItem as LibraryItem;
            string borrower = txtBorrower.Text?.Trim();

            if (!selected.IsAvailable)
            {
                MessageBox.Show("Item is niet beschikbaar");
                return;
            }

            selected.LoanTo(borrower);

            //Add to user loans:
            if(!_loans.ContainsKey(borrower))
            {
                _loans.Add(borrower, new List<LibraryItem>());
            }
            List<LibraryItem> userLoans = _loans[borrower];
            userLoans.Add(selected);

            lstItems.Items.Refresh();
        }

        private void OnReturnItem_Clicked(object sender, RoutedEventArgs e)
        {
            LibraryItem selected = lstItems.SelectedItem as LibraryItem;
            string borrower = txtBorrower.Text?.Trim();

            if (selected.IsAvailable)
            {
                MessageBox.Show("Item is niet uitgeleend");
                return;
            }

            _loans[selected.Borrower].Remove(selected);
            selected.Return();

            lstItems.Items.Refresh();
        }

        private void OnAddItem_Clicked(object sender, RoutedEventArgs e)
        {
            //Add new library item:
            LibraryItem newItem = null;

            if (rbBook.IsChecked == true)
            {
                newItem = new Book(txtBookTitle.Text, txtBookAuthor.Text, Convert.ToInt32(txtBookPages.Text));
            }
            else if (rbDvd.IsChecked == true)
            {
                newItem = new Dvd(txtDvdTitle.Text, txtDvdDirector.Text, Convert.ToInt32(txtDvdMinutes.Text));
            }
            else if (rbGame.IsChecked == true)
            {
                newItem = new Game(txtGameTitle.Text, txtGamePlatform.Text, Convert.ToInt32(txtGamePegi.Text));
            }

            _items.Add(newItem);
            lstItems.Items.Refresh();
        }

        private void OnShowOverview_Clicked(object sender, RoutedEventArgs e)
        {
            //Show borrowed items:
            string borrower = txtOverviewName.Text;
            if (!_loans.ContainsKey(borrower) || _loans[borrower].Count == 0)
            {
                MessageBox.Show("Deze gebruiker heeft momenteel geen boek in zijn bezit");
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();
            for(int i=0; i < _loans[borrower].Count; i++)
            {
                var item = _loans[borrower][i];
                stringBuilder.AppendLine($"{i}: {item.Title}");
            }
            MessageBox.Show(stringBuilder.ToString(), "Borrowed items:");
        }

        private void OnWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lstItems.ItemsSource = _items;
        }

        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstItems.SelectedItem is LibraryItem item)
            {
                txtDetails.Text = item.GetDetails();
            }
            else
            {
                txtDetails.Text = "";
            }
        }
    }
}