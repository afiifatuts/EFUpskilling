using EFUpskilling.Repositories;
using EFUpskilling.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFUpskilling
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             EF = Entity Framework
            Nugget yang diinstall
            - Microsoft.EntityFrameworkCore
            - Microsoft.EntityFrameworkCore.Tools
            - Microsoft.EntityFrameworkCore.Npgsl
            - Microsoft.EntityFrameworkCore.Design - Digunakan saat menggunakan Dependency Injection
             */

            /*
            ChangeTracker - 
            1. Added - Penanda saat di insert ke database tapi belum ter-insert
            2. Datched - Entity jejaknya dicopot
            3. Unchanged - saat select query
            4. Modified - saat terupdate
            5. Delete - saat dihapus

            */

            AppDbContext context = new();
            IRepository<Customer> repository = new Repository<Customer>(context);
            Customer rio = new()
            {
                CustomerName = "Rio",
                Address = "Trenggalek",
                MobilePhone = "08445323",
                Email = "Rio@gmail.com",
            };
            //repository.Save(rio);
            //var customer = repository.FindById(Guid.Parse("eaabb66e-3ef1-4e4d-ad78-27561367b697"));
            var customer = repository.FindBy(c => c.CustomerName.Equals("Rio"));
            System.Console.WriteLine(customer.CustomerName);


            /*
            INSERT
            Customer customer = new()
            {
                Id = 1,
                CustomerName = "Budi",
                Address = "Trenggalek",
                MobilePhone = "08656354",
                Email = "budi@gmail.com"
            };
            context.Customers.Add(customer);
            context.SaveChanges();
            */

            /* 
            SELECT ONE
            var customer = context.Customers.FirstOrDefault(c => c.Id.Equals(1));
             System.Console.WriteLine($"Customer: ID: {customer.Id},  Name: {customer.CustomerName}, " +
                                         $" MobilePhone: {customer.MobilePhone},  Email: {customer.Email}");
             System.Console.WriteLine(context.Entry(customer).State);
             System.Console.WriteLine(context.Customers.ToQueryString()); //<- query select
            */

            /* 
           SELECT Kondisi
            var customer = context.Customers.FirstOrDefault(c => c.CustomerName.ToLower().Equals("udin".ToLower()));
            System.Console.WriteLine($"Customer: ID: {customer.Id},  Name: {customer.CustomerName}, " +
                                        $" MobilePhone: {customer.MobilePhone},  Email: {customer.Email}");
           */


            /* 
            SELECT ALL
            var customers = context.Customers.ToList();
            foreach (var c in customers)
            {
                System.Console.WriteLine($"Customer: ID: {c.Id},  Name: {c.CustomerName}, " +
                                            $" MobilePhone: {c.MobilePhone},  Email: {c.Email}");
            }
            */

            /* 
           Update
            var customer = context.Customers.FirstOrDefault(c => c.CustomerName.ToLower().Equals("udin".ToLower()));
            // System.Console.WriteLine($"Customer: ID: {customer.Id},  Name: {customer.CustomerName}, " +
            //                             $" MobilePhone: {customer.MobilePhone},  Email: {customer.Email}");
            Customer udin = new Customer
            {
                Id = 2,
                CustomerName = "udin",
                Address = "Tulungagung",
                MobilePhone = "08656356253",
                Email = "udin@gmail.com",
            };
            //customer.CustomerName = "andik";
            context.Customers.Update(udin);
            context.SaveChanges();            
            */

            /* 
       DELETE
            var customer = context.Customers.FirstOrDefault(c => c.CustomerName.ToLower().Equals("udin".ToLower()));
            var customers = context.Customers.ToList();
            foreach (var c in customers)
            {
                System.Console.WriteLine($"Customer: ID: {c.Id},  Name: {c.CustomerName}, " +
                                            $" MobilePhone: {c.MobilePhone},  Email: {c.Email}");
            }
            //customer.CustomerName = "andik";
            context.Customers.Remove(customer);
            context.SaveChanges();  
        */


        }
    }
}