using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RESTserver.Models;

namespace RESTserver.Service
{
    public class CustomerService
    {
        public List<Customer> Customers;

        public CustomerService() 
        {
            Customers = new List<Customer>();
            LoadCustomerList();

        }

        public List<Customer> GetCustomersDetails()
        {
            return Customers.ToList<Customer>()
                .OrderBy(l => l.lastName)
                .ThenBy(f => f.firstName)
                .ToList();
        }

        public List<Customer> AddCustomerData(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                var uniqueId = Customers.Where(x => x.id == customer.id).FirstOrDefault();
                if (customer == null)
                    throw new ArgumentNullException("Customer cannot be null, please check!");
                else if (customer.id == 0)
                    throw new ArgumentException("Customer id is invalid!");
                else if (string.IsNullOrEmpty(customer.firstName))
                    throw new ArgumentException($"Customer first name is required!");
                else if (string.IsNullOrEmpty(customer.lastName))
                    throw new ArgumentException($"Customer last name is required!");
                else if (customer.age < 18 && customer.age > 90)
                    throw new ArgumentException($"Customer age cannot be less than 18 and not more than 90!");
                else if (uniqueId != null)
                {
                    throw new ArgumentException($"Customer Data is already existed. Name :'{customer.lastName} {customer.firstName}'" );
                }

                Customers.Add(customer);
            }

            return GetCustomersDetails();
        }

        // static list of customer
        public void LoadCustomerList()
        {
            var customer1 = new Customer
            {
                id = 3,
                age = 20,
                firstName = "Aaaa",
                lastName = "Aaaa",
            };

            var customer2 = new Customer
            {
                id = 2,
                age = 56,
                firstName = "Bbbb",
                lastName = "Aaaa"
            };

            var customer3 = new Customer
            {
                id = 5,
                age = 32,
                firstName = "Aaaa",
                lastName = "Cccc"
            };

            var customer4 = new Customer
            {
                id = 1,
                age = 50,
                firstName = "Bbbb",
                lastName = "Cccc"
            };


            var customer5 = new Customer
            {
                id = 4,
                firstName = "Aaaa",
                lastName = "Dddd",
                age = 70
            };

            Customers.Add(customer1);
            Customers.Add(customer2);
            Customers.Add(customer3);
            Customers.Add(customer4);
            Customers.Add(customer5);
        }

    }

}
