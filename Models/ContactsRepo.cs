using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppMaui.Models
{
    public static class ContactsRepo
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact{ContactId=1,Name="Abbhizit",Email="gabbhizit@gmail.com"},
            new Contact{ContactId=2,Name="Bharath",Email="bharathch@gmail.com"},
            new Contact{ContactId=3,Name="Karan",Email="karanreddy@gmail.com"},
            new Contact{ContactId=4,Name="Niharika",Email="niharika@gmail.com"},
            new Contact{ContactId=5,Name="Sravanthi",Email="sravanthi@gmail.com"}
        };
        public static List<Contact> GetContacts() => _contacts;
        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;
            var contactToUpdate=GetContatcById(contactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Phone = contact.Phone;
            }
        }
        public static Contact GetContatcById(int contactId)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == contactId);
        }
    }
}
