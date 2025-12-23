using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_2.Classes
{
    internal class ChickenOrder : Order
    {
        public ChickenOrder(int quantity) : base(quantity)
        {
        }

        public void CutUp()
        {
            // Logic to cut up the chicken
        }
    }
}
