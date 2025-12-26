namespace Restaurant_2.Classes
{
    internal class ChickenOrder : Order
    {
        public ChickenOrder(int quantity)
            : base(quantity)
        {
        }

        public void CutUp()
        {
            // Logic to cut up the chicken
        }
    }
}
