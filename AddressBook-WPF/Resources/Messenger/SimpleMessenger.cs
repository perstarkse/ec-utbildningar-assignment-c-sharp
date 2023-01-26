using AddressBook_Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_assignment.Resources.Messenger
{
    public class SimpleMessenger
    {
        private static SimpleMessenger _instance;

        public static SimpleMessenger Instance => _instance ?? (_instance = new SimpleMessenger());

        public event EventHandler<MessageValueChangedEventArgs> MessageValueChanged;

        public void RaiseMessageValueChanged(Contact selectedContact)
        {
            MessageValueChanged?.Invoke(this, new MessageValueChangedEventArgs() { selectedContact = selectedContact });
        }
        public class MessageValueChangedEventArgs : EventArgs
        {
            //declaring EventHandler
            public Contact selectedContact { get; set; }
        }
    }
 
    //custom event args class

    //raising the event for a property


}
