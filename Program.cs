using EFUpskilling.Repositories;
using EFUpskilling.Entities;
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

            using AppDbContext context = new();
            /*Customer customer = new()
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

        }
    }
}