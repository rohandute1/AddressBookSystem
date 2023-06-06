using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Address Book Program");
            Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Address Book Menu");
                Console.WriteLine("--------------------");
                Console.WriteLine(" 1. Create Address Book\n 2. Open Address Book\n 3. Add Contact\n 4. Display All Contacts\n 5. Edit Contact\n 6. Delete Contact\n 7. Exit");

                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Address Book Name: ");
                        string addressBookName = Console.ReadLine();
                        addressBooks[addressBookName] = new AddressBook();
                        Console.WriteLine($"Address Book '{addressBookName}' created successfully");
                        break;
                    case 2:
                        Console.WriteLine("Enter Address Book Name: ");
                        string openAddressBookName = Console.ReadLine();
                        if (addressBooks.ContainsKey(openAddressBookName))
                        {
                            AddressBook openAddressBook = addressBooks[openAddressBookName];
                            OpenAddressBookMenu(openAddressBook);
                        }
                        else
                        {
                            Console.WriteLine($"Address Book '{openAddressBookName}' does not exist");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Address Book Name: ");
                        string addContactAddressBookName = Console.ReadLine();
                        if (addressBooks.ContainsKey(addContactAddressBookName))
                        {
                            AddressBook addContactAddressBook = addressBooks[addContactAddressBookName];
                            addContactAddressBook.AddContact();
                        }
                        else
                        {
                            Console.WriteLine($"Address Book '{addContactAddressBookName}' does not exist");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Address Book Name: ");
                        string displayContactsAddressBookName = Console.ReadLine();
                        if (addressBooks.ContainsKey(displayContactsAddressBookName))
                        {
                            AddressBook displayContactsAddressBook = addressBooks[displayContactsAddressBookName];
                            displayContactsAddressBook.DisplayContacts();
                        }
                        else
                        {
                            Console.WriteLine($"Address Book '{displayContactsAddressBookName}' does not exist");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter Address Book Name: ");
                        string editContactAddressBookName = Console.ReadLine();
                        if (addressBooks.ContainsKey(editContactAddressBookName))
                        {
                            AddressBook editContactAddressBook = addressBooks[editContactAddressBookName];
                            editContactAddressBook.EditContact();
                        }
                        else
                        {
                            Console.WriteLine($"Address Book '{editContactAddressBookName}' does not exist");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter Address Book Name: ");
                        string deleteContactAddressBookName = Console.ReadLine();
                        if (addressBooks.ContainsKey(deleteContactAddressBookName))
                        {
                            AddressBook deleteContactAddressBook = addressBooks[deleteContactAddressBookName];
                            deleteContactAddressBook.DeleteContact();
                        }
                        else
                        {
                            Console.WriteLine($"Address Book '{deleteContactAddressBookName}' does not exist");
                        }
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void OpenAddressBookMenu(AddressBook addressBook)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Address Book Menu");
                Console.WriteLine("--------------------");
                Console.WriteLine(" 1. Add Contact\n 2. Display All Contacts\n 3. Edit Contact\n 4. Delete Contact\n 5. Exit");

                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addressBook.AddContact();
                        break;
                    case 2:
                        addressBook.DisplayContacts();
                        break;
                    case 3:
                        addressBook.EditContact();
                        break;
                    case 4:
                        addressBook.DeleteContact();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }

    class AddressBook
    {
        public List<Contact> Contacts { get; }

        public AddressBook()
        {
            Contacts = new List<Contact>();
        }

        public void AddContact()
        {
            Console.WriteLine("Enter Contact Details");
            Console.WriteLine("First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            string address = Console.ReadLine();

            Console.WriteLine("City: ");
            string city = Console.ReadLine();

            Console.WriteLine("State: ");
            string state = Console.ReadLine();

            Console.WriteLine("ZIP: ");
            string zip = Console.ReadLine();

            Console.WriteLine("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            Contacts.Add(contact);

            Console.WriteLine("Contact added successfully");
        }

        public void DisplayContacts()
        {
            Console.WriteLine("Contacts in Address Book");
            Console.WriteLine("--------------------");

            foreach (var contact in Contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine($"State: {contact.State}");
                Console.WriteLine($"ZIP: {contact.Zip}");
                Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine();
            }
        }

        public void EditContact()
        {
            Console.WriteLine("Enter the name of the contact you want to edit");
            Console.WriteLine("First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name: ");
            string lastName = Console.ReadLine();

            Contact contactToEdit = Contacts.Find(c => c.FirstName == firstName && c.LastName == lastName);

            if (contactToEdit != null)
            {
                Console.WriteLine("Enter new contact details");
                Console.WriteLine("Address: ");
                contactToEdit.Address = Console.ReadLine();

                Console.WriteLine("City: ");
                contactToEdit.City = Console.ReadLine();

                Console.WriteLine("State: ");
                contactToEdit.State = Console.ReadLine();

                Console.WriteLine("ZIP: ");
                contactToEdit.Zip = Console.ReadLine();

                Console.WriteLine("Phone Number: ");
                contactToEdit.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Email: ");
                contactToEdit.Email = Console.ReadLine();

                Console.WriteLine("Contact updated successfully");
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter the name of the contact you want to delete");
            Console.WriteLine("First Name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name: ");
            string lastName = Console.ReadLine();

            Contact contactToDelete = Contacts.Find(c => c.FirstName == firstName && c.LastName == lastName);

            if (contactToDelete != null)
            {
                Contacts.Remove(contactToDelete);
                Console.WriteLine("Contact deleted successfully");
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }
    }

    class Contact
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
