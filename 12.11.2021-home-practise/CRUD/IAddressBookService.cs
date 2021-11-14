using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._11._2021_home_practise.CRUD
{
    public interface IAddressBookService
    {
        Contact Create(Contact newContact);
        Contact Update(int Id, Contact newContact);
        void Delete(int Id);
        Contact Find(int Id);
        List<Contact> GetContacts();
    }
}
