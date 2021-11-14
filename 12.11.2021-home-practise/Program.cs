using _12._11._2021_home_practise.CRUD;
using System;
using System.Collections.Generic;

namespace _12._11._2021_home_practise
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1

            byte choise;
            int choosenId;
            Contact foundContact = null;
            List<Contact> returnedContacts = new();
            AddressBookService addressBook = new();

            Console.WriteLine("Welcome to AddressBook application.");

            do
            {
                Console.WriteLine("------- Actions -------");
                Console.WriteLine("1. Create contact");
                Console.WriteLine("2. Update contact");
                Console.WriteLine("3. Delete contact");
                Console.WriteLine("4. Find contact");
                Console.WriteLine("5. All contacts");
                Console.WriteLine("0. Exit\n");
                Console.Write("Choose action: ");

                while (byte.TryParse(Console.ReadLine(), out choise) == false)
                {
                    Console.Write("- Please enter integer value in range [0-5]: ");
                }

                Console.WriteLine();

                switch (choise)
                {
                    case 1:
                        addressBook.Create(ReadContactInfoFromUser());
                        Console.WriteLine("\n- new contact created successfully.");
                        break;
                    case 2:
                        if (HasData(addressBook))
                        {
                            PrintContacts(addressBook);
                            choosenId = CheckIdAndExisting(addressBook, "edit");
                            if (choosenId != -1)
                            {
                                addressBook.Update(choosenId, ReadContactInfoFromUser(addressBook.Find(choosenId)));
                                Console.WriteLine("\n- contact updated successfully.");
                            }
                        }
                        break;
                    case 3:
                        if (HasData(addressBook))
                        {
                            PrintContacts(addressBook);
                            choosenId = CheckIdAndExisting(addressBook, "delete");
                            if (choosenId != -1)
                            {
                                addressBook.Delete(choosenId);
                                Console.WriteLine("\n- contact deleted successfully!");
                            }
                        }
                        break;
                    case 4:
                        if (HasData(addressBook))
                        {
                            choosenId = CheckIdAndExisting(addressBook, "find");
                            if (choosenId != -1)
                            {
                                PrintContact(choosenId, addressBook);
                            }
                        }
                        break;
                    case 5:
                        if (HasData(addressBook))
                        {
                            PrintContacts(addressBook);
                        }
                        break;
                    default:
                        Console.WriteLine("- application terminated.");
                        break;
                }

                Console.WriteLine();

            } while (choise != 0);
            #endregion
        }

        public static bool HasData(AddressBookService addressBook)
        {
            if (addressBook.GetContacts().Count == 0)
            {
                Console.WriteLine("- no data.");
                return false;
            }
            return true;
        }

        public static int CheckIdAndExisting(AddressBookService addressBook, string method)
        {
            bool isInteger;
            int choosenId;
            Contact foundContact = null;

            Console.Write($"Enter the contact id you want to {method} (-1 for go back): ");
            while ((isInteger = int.TryParse(Console.ReadLine(), out choosenId)) == false || (foundContact = addressBook.Find(choosenId)) == null)
            {
                if (choosenId == -1)
                {
                    break;
                }
                if (!isInteger)
                {
                    Console.Write("- please enter integer value (-1 for go back): ");
                    continue;
                }
                if (foundContact == null)
                {
                    Console.Write("- contact not found, try again (-1 for go back): ");
                    continue;
                }
            }
            return isInteger && foundContact != null ? choosenId : -1;
        }

        public static Contact ReadContactInfoFromUser(Contact original = null)
        {
            Console.WriteLine(original != null ? "\nEnter new contact info:\n" : "Enter contact info:\n");
            
            Console.Write(original != null ? $"Name ({original.Name}): " : "Name: ");
            string cName = Console.ReadLine();
            Console.Write(original != null ? $"Phone number ({original.Number}): " : "Phone number: ");
            string cNumber = Console.ReadLine();
            Console.Write(original != null ? $"Email ({original.Email}): " : "Email: ");
            string cEmail = Console.ReadLine();
            Console.Write(original != null ? $"Address ({original.Address}): " : "Address: ");
            string cAddress = Console.ReadLine();

            return new Contact
            {
                Name = cName,
                Number = cNumber,
                Email = cEmail,
                Address = cAddress
            };
        }

        public static void PrintContact(int contactId, AddressBookService addressBook)
        {
            Contact contact = addressBook.Find(contactId);
            Console.WriteLine("\nContact:\n");
            Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone number: {contact.Number}, Address: {contact.Address}");
        }

        public static void PrintContacts(AddressBookService addressBook)
        {
            Console.WriteLine("Contacts:\n");
            foreach (var item in addressBook.GetContacts())
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}, Phone number: {item.Number}, Address: {item.Address}");
            }
            Console.WriteLine();
        }
    }
}
