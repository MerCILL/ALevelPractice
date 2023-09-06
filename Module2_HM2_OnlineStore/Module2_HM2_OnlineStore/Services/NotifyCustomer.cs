using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HM2_OnlineStore.Services
{
    internal class NotifyCustomer
    {
        public void SuccesfulOrderCreationMessage(string login, int orderId)
        {
            Console.WriteLine($"Order #{orderId} was succesfully placed by {login}");
        }
    }
}
