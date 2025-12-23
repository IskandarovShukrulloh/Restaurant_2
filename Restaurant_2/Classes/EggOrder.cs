using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_2.Classes
{
    internal class EggOrder : Order
    {
        Random rand = new Random();
        public EggOrder(int quantity) : base(quantity)
        {

        }
        public int GetQuality() => rand.Next(25, 101); // Quality between 25 and 100

        public void Crack() { /* Rotten eggs will be ignored this time */ }
        public void Discard() { }
    }
}
