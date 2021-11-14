using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._11._2021_home_practise.CRUD
{
    class AddressBookService : IAddressBookService
    {
        public List<Contact> Contacts = new();

        public Contact Create(Contact newContact)
        {
            if (Contacts.Count == 0)
                newContact.Id = 1;
            else
                newContact.Id = Contacts[Contacts.Count - 1].Id + 1;
            Contacts.Add(newContact);
            return Contacts[Contacts.Count - 1];
        }

        public Contact Update(int Id, Contact newContact)
        {
            Contact foundContact = Contacts.Find(contact => contact.Id == Id);
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i].Id == Id)
                {
                    newContact.Id = Contacts[i].Id;
                    Contacts[i] = newContact;
                    return Contacts[i];
                }
            }
            return null;
        }

        public void Delete(int Id)
        {
            Contacts.Remove(Contacts.Find(contact => contact.Id == Id));
        }

        public Contact Find(int Id)
        {
            Contact foundContact = Contacts.Find(contact => contact.Id == Id);
            return foundContact;
        }

        public List<Contact> GetContacts()
        {
            return this.Contacts;
        }
    }
}
