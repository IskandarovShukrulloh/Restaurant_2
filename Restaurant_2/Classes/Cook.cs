using Restaurant2.Classes;

namespace Restaurant_2.Classes
{
    public class Cook
    {
        private int _chickenQty = 0;
        private int _eggQty = 0;

        public Cook(MenuItems[][] tableOrders)
        {
            for (int i = 0; i < tableOrders.Length; i++)
            {
                if (tableOrders[i] == null)
                    break;

                MenuItems[] items = tableOrders[i];
                foreach (MenuItems item in items)
                {
                    if (item == MenuItems.Chicken) _chickenQty++;
                    else if (item == MenuItems.Egg) _eggQty++;
                }
            }
        }

        public string SubmitChicken()
        {
            try
            { 
                if (_chickenQty == 0)
                    return "";

                ChickenOrder chicken = new(_chickenQty);

                for (int i = 0; i < chicken.GetQuantity(); i++)
                {
                    chicken.CutUp();
                }

                chicken.Cook();

                return "Chicken Cut up and cooked! \n";
            }

            catch {
                throw new Exception("Error ocurried cutting up chicken");
            }
        }
        public string SubmitEgg()
        {
            try
            {
                if (_eggQty == 0)
                    return "";

                EggOrder egg = new(_eggQty);

                int eggQuality = egg.GetQuality();
                egg.Crack();

                /* Discard all eggs before cooking */
                for (int i = 0; i < egg.GetQuantity(); i++)
                {
                    egg.Discard();
                }

                egg.Cook();
                

                return $"Eggs inspected, discarded and Cooked at once!" +
                        $"\nEgg quality: {eggQuality}";
            }
            catch
            {
                throw new Exception("Error ocurried while inspecting egg\n");
            }
        }
    }
}
