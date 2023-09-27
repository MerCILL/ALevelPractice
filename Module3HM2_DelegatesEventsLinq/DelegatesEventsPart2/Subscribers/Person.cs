using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsPart2.Subscribers
{
    internal class Person : ISubscriber
    {
        public void SubscribeEmail(PostOffice postOffice) => postOffice.Email += OnEmailReceived;

        public void SubscribePackage(PostOffice postOffice) => postOffice.Package += OnPackageReceived;

        public void SubscribeNotification(PostOffice postOffice) => postOffice.Notification += OnNotificationReceived;

        public void UnsubscribeEmail(PostOffice postOffice) => postOffice.Email -= OnEmailReceived;

        public void UnsubscribePackage(PostOffice postOffice) => postOffice.Package -= OnPackageReceived;

        public void UnsubscribeNotification(PostOffice postOffice) => postOffice.Notification -= OnNotificationReceived;

        private void OnEmailReceived(object sender, LetterEventArgs e) => Console.WriteLine($"Incoming email to person: {e.Letter}");
        private void OnPackageReceived(object sender, LetterEventArgs e) => Console.WriteLine($"Incoming package to person: {e.Letter}");
        private void OnNotificationReceived(object sender, LetterEventArgs e) => Console.WriteLine($"Incoming notification to person: {e.Letter}"); 
    }
}
