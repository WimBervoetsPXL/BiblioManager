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
        

        public MainWindow()
        {
            InitializeComponent();

            SeedData();
        }

        private void OnWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SeedData()
        {
            //// === Books ===
            //_items.Add(new Book("Clean Code", "Robert C. Martin", 464));
            //_items.Add(new Book("The Pragmatic Programmer", "Andrew Hunt", 352));
            //_items.Add(new Book("Design Patterns", "Erich Gamma", 395));
            //_items.Add(new Book("Refactoring", "Martin Fowler", 431));
            //_items.Add(new Book("Head First C#", "Andrew Stellman", 720));
            //_items.Add(new Book("Introduction to Algorithms", "Thomas H. Cormen", 1312));
            //_items.Add(new Book("C# in Depth", "Jon Skeet", 900));

            //// === DVDs ===
            //_items.Add(new Dvd("Inception", "Christopher Nolan", 148));
            //_items.Add(new Dvd("The Matrix", "Wachowskis", 136));
            //_items.Add(new Dvd("Interstellar", "Christopher Nolan", 169));
            //_items.Add(new Dvd("The Godfather", "Francis Ford Coppola", 175));
            //_items.Add(new Dvd("Lord of the Rings: Fellowship", "Peter Jackson", 178));
            //_items.Add(new Dvd("Jurassic Park", "Steven Spielberg", 127));
            //_items.Add(new Dvd("The Dark Knight", "Christopher Nolan", 152));

            //// === Games ===
            //_items.Add(new Game("Zelda: Tears of the Kingdom", "Switch", 12));
            //_items.Add(new Game("Forza Horizon 5", "Xbox", 3));
            //_items.Add(new Game("Elden Ring", "PC", 16));
            //_items.Add(new Game("FIFA 24", "PlayStation", 3));
            //_items.Add(new Game("Minecraft", "PC", 7));
            //_items.Add(new Game("The Witcher 3", "PC", 18));
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



        }

        private void OnReturnItem_Clicked(object sender, RoutedEventArgs e)
        {
           //Return selected item

        }

        private void OnAddItem_Clicked(object sender, RoutedEventArgs e)
        {
            //Add new library item:


        }

        private void OnShowOverview_Clicked(object sender, RoutedEventArgs e)
        {
            //Show borrowed items:
           

        }



        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Show details for selected item:
        }
    }
}