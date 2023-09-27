using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsPart2.Subscribers
{
    internal class School : ISubscriber
    {
        public void SubscribeEmail(PostOffice postOffice) => postOffice.Email += OnEmailReceived;

        public void SubscribePackage(PostOffice postOffice) => postOffice.Package += OnPackageReceived;

        public void SubscribeNotification(PostOffice postOffice) => postOffice.Notification += OnNotificationReceived;

        public void UnsubscribeEmail(PostOffice postOffice) => postOffice.Email -= OnEmailReceived;

        public void UnsubscribePackage(PostOffice postOffice) => postOffice.Package -= OnPackageReceived;

        public void UnsubscribeNotification(PostOffice postOffice) => postOffice.Notification -= OnNotificationReceived;

        private void OnEmailReceived(object sender, LetterEventArgs e) => Console.WriteLine($"Incoming email to school: {e.Letter}");
        private void OnPackageReceived(object sender, LetterEventArgs e) => Console.WriteLine($"Incoming package to school: {e.Letter}");
        private void OnNotificationReceived(object sender, LetterEventArgs e) => Console.WriteLine($"Incoming notification to school: {e.Letter}");
    }
}
