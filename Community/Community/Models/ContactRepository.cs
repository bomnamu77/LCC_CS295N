
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Community.Models
{
    public class ContactRepository
    {
        private static List<Contact> contacts = new List<Contact>();

        public static List<Contact> Contacts { get { return contacts; } }
        public static void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
    }
}
