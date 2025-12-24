using Restaurant_2.Classes;
using Restaurant2.Classes;
using System.Windows;


namespace Restaurant_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Server server = new Server();
        private void ReceiveRequestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // which drink is selected
                MenuItems? selectedDrink;

                // string to enum 
                if (DrinkTextBox.SelectedValue.ToString() == "Tea")
                    selectedDrink = MenuItems.Tea;
                else if (DrinkTextBox.SelectedValue.ToString() == "Cola")
                    selectedDrink = MenuItems.Cola;
                else if (DrinkTextBox.SelectedValue.ToString() == "Milk")
                    selectedDrink = MenuItems.Milk;
                else if (DrinkTextBox.SelectedValue.ToString() == "Coffee")
                    selectedDrink = MenuItems.Coffee;
                else if (DrinkTextBox.SelectedValue.ToString() == "Water")
                    selectedDrink = MenuItems.Water;
                else if (DrinkTextBox.SelectedValue.ToString() == "Mojito")
                    selectedDrink = MenuItems.Mojito;
                else
                    selectedDrink = null;

                /* Get order from UI and send to Server */
                ResultTextBox.Text += server.ReceiveOrder(int.Parse(EggQtyTextBox.Text),
                                                          int.Parse(ChickenQtyTextBox.Text),
                                                          selectedDrink);
            }
            catch (Exception ex)
            {
                ResultTextBox.Text += ex.Message + "\n";
            }
        }
        private void SendToCookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultTextBox.Text = "Sending orders to Cook...\n";
                ResultTextBox.Text += server.SendToCook();
            }
            catch (Exception ex)
            {
                ResultTextBox.Text += ex.Message + "\n";
            }

        }

        private void ServeFoodButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultTextBox.Text = server.Serve();
            }
            catch (Exception ex)
            {
                ResultTextBox.Text += ex.Message + "\n";
            }
        }
    }
}