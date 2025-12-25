using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_2.Classes
{
    public class Order
    {
        protected int quantity;
        public Order(int quantity) 
        {
            this.quantity = quantity;
        }

        protected int GetQuantity() => quantity;

        protected void Cook() { /* Cooking logic here*/ }
    }
}