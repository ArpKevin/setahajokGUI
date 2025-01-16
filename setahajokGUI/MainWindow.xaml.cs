using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace setahajokGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string filePath = @"..\..\..\src\hajo.txt";
        List<Hajo> boats = new();
        public MainWindow()
        {
            InitializeComponent();

            

            foreach (var item in File.ReadAllLines(filePath))
            {
                boats.Add(new(item));
            }

            boatsCombobox.ItemsSource = boats.Select(b => b.Name);

            using StreamWriter sw = new(@"..\..\..\src\kishajok.txt");

            var smallBoats = boats.Where(b => b.PassengerCapacity < 6).Select(b => $"{b.Name} {b.FeePrice}");

            foreach (var item in smallBoats)
            {
                sw.WriteLine(item);
            }
        }

        private void boatFeeForRequestedDaysButton_Click(object sender, RoutedEventArgs e)
        {
            if (boatsCombobox.SelectedItem != null && daysTextbox.Text != null && int.TryParse(daysTextbox.Text, out int daysCount))
            {
                int boatDailyFee = boats.Where(b => b.Name == boatsCombobox.SelectedItem).Select(b => b.FeePrice).FirstOrDefault();

                if (boatDailyFee != null)
                {
                    var totalPrice = getFeeForRequestedDays(daysCount, boatDailyFee);

                    totalPriceLabel.Content = $"{daysCount} napi költség: {totalPrice} FT";
                }
            }
        }

        private int getFeeForRequestedDays(int days, int dailyFee)
        {
            return days * dailyFee;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        { 

            var passengersCount = passengersCountTextbox.Text;

            if (passengersCount != null && int.TryParse(passengersCount, out int passengersCountInt))
            {
                var recommendedBoat = boats.FirstOrDefault(b => b.PassengerCapacity >= passengersCountInt);
                if (recommendedBoat != null)
                {
                    recommendedBoatLabel.Content = $"Ajánlott hajó: {recommendedBoat.Name}\n{recommendedBoat.PassengerCapacity} fő befogadására képes\nNapidíja {recommendedBoat.FeePrice} FT";
                }
                else recommendedBoatLabel.Content = "Sajnos nem tudunk hajót ajánlani";
            }
        }
    }
}