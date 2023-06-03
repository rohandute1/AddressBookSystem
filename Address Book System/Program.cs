using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class Program
    {
        public static List<Contact> contacts = new List<Contact>();
        static void Main()
        {
            Console.WriteLine("Welcome to Address Book Program");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Address Book Menue");
                Console.WriteLine("--------------------");
                Console.WriteLine(" 1. Add Contact\n 2. Display All Contacts\n 3. Exit");

                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        DisplayContacts();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
        static void AddContact()
        {
            Console.Write("Enter Contact Details");

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
            contacts.Add(contact);

            Console.WriteLine("Contact added successfully");

        }

        static void DisplayContacts()
        {
            Console.WriteLine("Contacts in Address Book");
            Console.WriteLine("--------------------");

            foreach (var contact in contacts)
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

    }
    class Contact
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }
        public string PhoneNumber { get; }
        public string Email { get; }

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
