using Restaurant_2.Classes;
using Restaurant2.Classes;

namespace Restaurant_2.Classes
{
    public class Server
    {
        // Jagged array to store up to 8 customers' orders
        // Each element represents a single customer's menu items
        private MenuItems[][] _tableOrders = new MenuItems[8][];

        private int _customerCount;
        private bool _isSent;

        public Server()
        {
            _customerCount = 0;
            _isSent = false;
        }

        public string ReceiveOrder(int eggQuantity, int chickenQuantity, MenuItems? drink)
        {
            if (_isSent)
            {
                throw new Exception("Previous table not served yet!");
            }

            if (chickenQuantity <= 0 && eggQuantity <= 0 && !drink.HasValue)
            {
                throw new Exception("Null order!");
            }

            if (_customerCount >= 8)
            {
                throw new Exception("Max customer count for a table reached!\n");
            }

            _customerCount++;

            // Eggs + Chickens + optional Drink
            _tableOrders[_customerCount - 1] =
                new MenuItems[eggQuantity + chickenQuantity + (drink.HasValue ? 1 : 0)];

            // Add chicken orders
            for (int i = 0; i < chickenQuantity; i++)
            {
                _tableOrders[_customerCount - 1][i] = MenuItems.Chicken;
            }

            // Add egg orders
            for (int i = 0; i < eggQuantity; i++)
            {
                _tableOrders[_customerCount - 1][chickenQuantity + i] = MenuItems.Egg;
            }

            // Add drink if present
            if (drink.HasValue)
            {
                _tableOrders[_customerCount - 1][chickenQuantity + eggQuantity] = drink.Value;
            }

            return
                $"Customer {_customerCount} ordered: " +
                $"{chickenQuantity} chicken, {eggQuantity} egg, {drink}\n";
        }

        public string SendToCook()
        {
            /*
             * Sending orders to Cook:
             * SubmitChicken() and SubmitEgg() are called
             */
            if (_isSent)
            {
                throw new Exception("Orders have already been sent to cook!\n");
            }

            if (_customerCount == 0)
            {
                throw new Exception("No orders to send to cook!\n");
            }

            string result = string.Empty;

            Cook cook = new Cook(_tableOrders);

            result += cook.SubmitChicken();
            result += cook.SubmitEgg() + "\n";

            _isSent = true;
            return result;
        }

        public string Serve()
        {
            /*
             * Output example:
             * Customer 1 is served 3 chicken, 3 egg, Milk
             */
            if (_customerCount == 0)
            {
                throw new Exception("No customers to serve!\n");
            }

            if (!_isSent)
            {
                throw new Exception("Orders have not been sent to cook yet!\n");
            }

            string result = string.Empty;

            for (int i = 0; i < _customerCount; i++)
            {
                int chickenCount = 0;
                int eggCount = 0;
                string drink = "no drink";

                foreach (MenuItems item in _tableOrders[i])
                {
                    if (item == MenuItems.Chicken)
                    {
                        chickenCount++;
                    }
                    else if (item == MenuItems.Egg)
                    {
                        eggCount++;
                    }
                    else
                    {
                        drink = item.ToString();
                    }
                }

                string drinkOutput =
                    drink != "no drink" ? $", {drink}" : string.Empty;

                result +=
                    $"Customer {i + 1} is served " +
                    $"{chickenCount} chicken, {eggCount} egg{drinkOutput}.\n";
            }

            _isSent = false;
            _customerCount = 0;

            return result;
        }
    }
}
