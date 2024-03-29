﻿using System;
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
            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId); ;
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
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                return new Contact
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Phone = contact.Phone,
                    Address = contact.Address,
                    Email = contact.Email,
                };
            }
            return null;
        }
        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);
        }
        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }
        public static List<Contact> SearchContacts(string filterText)
        { 
            var contacts = _contacts.Where(x => !String.IsNullOrWhiteSpace(x.Name) && x.Name.Contains(filterText,StringComparison.OrdinalIgnoreCase) || !String.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(filterText, StringComparison.OrdinalIgnoreCase) || !String.IsNullOrWhiteSpace(x.Phone) && x.Phone.Contains(filterText, StringComparison.OrdinalIgnoreCase) || !String.IsNullOrWhiteSpace(x.Address) && x.Address.Contains(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            return contacts;
        }
    }
}
