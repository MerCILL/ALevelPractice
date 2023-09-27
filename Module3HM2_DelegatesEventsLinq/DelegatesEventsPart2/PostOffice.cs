using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsPart2
{
    internal class PostOffice
    {
        public event EventHandler<LetterEventArgs> Email;
        public event EventHandler<LetterEventArgs> Package;
        public event EventHandler<LetterEventArgs> Notification;

        public void AddEmail(string email)
        {
           if(ValidationLetter(email) == true)
            {
                LetterEventArgs args = new();
                args.Letter = email;
                OnEmail(args);
                return;
            }
            throw new InvalidOperationException("null or empty email");
        }

        public void AddPackage(string package)
        {
            if (ValidationLetter(package) == true)
            {
                LetterEventArgs args = new();
                args.Letter = package;
                OnPackage(args);
                return;
            }
            throw new InvalidOperationException("null or empty package");
        }

        public void AddNotification(string notification) 
        {
            if (ValidationLetter(notification) == true)
            {
                LetterEventArgs args = new();
                args.Letter = notification;
                OnNotification(args);
                return;
            }
            throw new InvalidOperationException("null or empty notification");
        }

        protected virtual void OnEmail(LetterEventArgs e) 
        {
            EventHandler<LetterEventArgs> handler = Email;
            handler?.Invoke(this, e);
        }

        protected virtual void OnPackage(LetterEventArgs e) 
        {
            EventHandler<LetterEventArgs> handler = Package;
            handler?.Invoke(this, e);
        }

        protected virtual void OnNotification(LetterEventArgs e) 
        {
            EventHandler<LetterEventArgs> handler = Notification;
            handler?.Invoke(this, e);
        }
        
        private bool ValidationLetter(string letter)
        {
            if (letter == null) return false;
            if (letter.Length == 0) return false;
            return true;
        }

    }
}
