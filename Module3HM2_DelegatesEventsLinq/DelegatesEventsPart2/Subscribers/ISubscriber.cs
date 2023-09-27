using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsPart2.Subscribers
{
    internal interface ISubscriber
    {
        void SubscribeEmail(PostOffice postOffice);
        void SubscribePackage(PostOffice postOffice);
        void SubscribeNotification(PostOffice postOffice);
        void UnsubscribeEmail(PostOffice postOffice);
        void UnsubscribePackage(PostOffice postOffice);
        void UnsubscribeNotification(PostOffice postOffice);
    }
}
