using Restaurant2.Classes;

namespace Restaurant_2.Classes
{
    public class Server
    {
        // A jagged array to store up to 8 customers' orders.
        // Each element is an array of MenuItems (chicken, egg, and possibly one drink).
        private MenuItems[][] tableOrders = new MenuItems[8][];
        private int _customerCount;
        public Server()
        {
            this._customerCount = 0;
        }
        public string ReceiveOrder(int eggQty, int chickenQty, MenuItems? drink)
        {
            /* Here jagged array of orders is created */

            if (chickenQty <= 0 && eggQty <= 0 && !drink.HasValue)
                throw new Exception ("Null order!");

            else if (_customerCount >= 8)
                throw new Exception ("Max customer count for a table reached!\n");
           
            else
            {
                _customerCount++;

                // An array to hold the current customer's order
                /* Eggs + Chickens + Drink */
                tableOrders[_customerCount - 1]
                    = new MenuItems[eggQty + chickenQty + (drink.HasValue ? 1 : 0)];

                // Add chicken orders
                for (int i = 0; i < chickenQty; i++)
                {
                    tableOrders[_customerCount - 1][i] = MenuItems.Chicken;
                }

                // Add egg orders
                for (int j = 0; j < eggQty; j++)
                {
                    tableOrders[_customerCount - 1][chickenQty + j] = MenuItems.Egg;
                }

                // Add drink order if present
                if (drink.HasValue)
                {
                    tableOrders[_customerCount - 1][chickenQty + eggQty] = drink.Value;
                }

                return $"Customer {_customerCount} ordered: {chickenQty} chicken, {eggQty} egg, {drink}\n";
            }
        }

        public string SendToCook()
        {
            /* Here sending to Cook logic
             *   Cook's Submit() & Prepare() for both chicken & egg are called  
             */

            if (_customerCount == 0)
                throw new Exception ("No orders to send to cook!\n");

            string res = "";

            Cook cook = new(this.tableOrders);

            res += cook.SubmitChicken();
            res += cook.SubmitEgg() + "\n";

            return res;
        }

        public void Serve()
        {
            /* Forming outputs here, like:
             *  Customer 0 is served 3 chicken, 3 egg, Milk*/
        }
    }
}
