using System;
using System.Windows;
using Restaurant_2.Classes;
using Restaurant2.Classes;

namespace Restaurant_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Server _server = new Server();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReceiveRequestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MenuItems? selectedDrink = null;

                // Convert selected drink (string) to enum
                if (DrinkTextBox.SelectedValue != null)
                {
                    string drink = DrinkTextBox.SelectedValue.ToString();

                    if (drink == "Tea")
                        selectedDrink = MenuItems.Tea;
                    else if (drink == "Cola")
                        selectedDrink = MenuItems.Cola;
                    else if (drink == "Milk")
                        selectedDrink = MenuItems.Milk;
                    else if (drink == "Coffee")
                        selectedDrink = MenuItems.Coffee;
                    else if (drink == "Water")
                        selectedDrink = MenuItems.Water;
                    else if (drink == "Mojito")
                        selectedDrink = MenuItems.Mojito;
                }

                // Get order from UI and send to server
                ResultTextBox.Text = string.Empty;
                ResultTextBox.Text += _server.ReceiveOrder(
                    int.Parse(EggQtyTextBox.Text),
                    int.Parse(ChickenQtyTextBox.Text),
                    selectedDrink
                );
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
                if (int.Parse(EggQtyTextBox.Text) <= 0 &&
                    int.Parse(ChickenQtyTextBox.Text) <= 0)
                {
                    throw new Exception("No orders to send to Cook.\n");
                }

                ResultTextBox.Text = "Sending orders to Cook...\n";
                ResultTextBox.Text += _server.SendToCook();
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
                ResultTextBox.Text = _server.Serve();
            }
            catch (Exception ex)
            {
                ResultTextBox.Text += ex.Message + "\n";
            }
        }
    }
}
