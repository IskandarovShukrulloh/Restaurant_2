namespace Restaurant_2.Classes
{
    public class Order
    {
        protected int _quantity;

        public Order(int quantity)
        {
            _quantity = quantity;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public void Cook()
        {
            // Cooking logic here
        }
    }
}
