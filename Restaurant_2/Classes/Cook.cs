using Restaurant_2.Classes;
using Restaurant2.Classes;

namespace Restaurant_2.Classes
{
    public class Cook
    {
        private int _chickenQuantity;
        private int _eggQuantity;

        public Cook(MenuItems[][] tableOrders)
        {
            for (int i = 0; i < tableOrders.Length; i++)
            {
                if (tableOrders[i] == null)
                {
                    break;
                }

                MenuItems[] items = tableOrders[i];

                foreach (MenuItems item in items)
                {
                    if (item == MenuItems.Chicken)
                    {
                        _chickenQuantity++;
                    }
                    else if (item == MenuItems.Egg)
                    {
                        _eggQuantity++;
                    }
                }
            }
        }

        public string SubmitChicken()
        {
            try
            {
                if (_chickenQuantity == 0)
                {
                    return string.Empty;
                }

                ChickenOrder chicken = new ChickenOrder(_chickenQuantity);

                for (int i = 0; i < chicken.GetQuantity(); i++)
                {
                    chicken.CutUp();
                }

                chicken.Cook();

                return "Chicken cut up and cooked!\n";
            }
            catch
            {
                throw new Exception("Error occurred while cutting up chicken.");
            }
        }

        public string SubmitEgg()
        {
            try
            {
                if (_eggQuantity == 0)
                {
                    return string.Empty;
                }

                EggOrder egg = new EggOrder(_eggQuantity);

                int eggQuality = egg.GetQuality();
                egg.Crack();

                // Discard all eggs before cooking
                for (int i = 0; i < egg.GetQuantity(); i++)
                {
                    egg.Discard();
                }

                egg.Cook();

                return
                    "Eggs inspected, discarded and cooked at once!" +
                    $"\nEgg quality: {eggQuality}";
            }
            catch
            {
                throw new Exception("Error occurred while inspecting eggs.\n");
            }
        }
    }
}
