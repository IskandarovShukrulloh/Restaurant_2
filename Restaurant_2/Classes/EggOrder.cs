namespace Restaurant_2.Classes
{
    internal class EggOrder : Order
    {
        private static readonly Random RandomGenerator = new Random();

        public EggOrder(int quantity)
            : base(quantity)
        {
        }

        // Returns egg quality between 25 and 100
        public int GetQuality()
        {
            return RandomGenerator.Next(25, 101);
        }

        public void Crack()
        {
            // Rotten eggs are ignored in this version
        }

        public void Discard()
        {
            // Discard each egg before cooking
        }
    }
}
