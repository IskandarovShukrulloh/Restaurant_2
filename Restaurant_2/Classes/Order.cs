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

        public virtual int GetQuantity() => quantity;

        public virtual void Cook() { /* Cooking logic here*/ }
    }
}