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


            AppDbContext context = new();
            IRepository<Customer> repository = new Repository<Customer>(context);
            IRepository<Product> productRepo = new Repository<Product>(context);

            //transactions
            var transaction = context.Database.BeginTransaction();
            try
            {
                var purchase = new Purchase
                {
                    TransDate = DateTime.UtcNow,
                    CustomerId = Guid.Parse("eaabb66e-3ef1-4e4d-ad78-27561367b697"),
                    PurchaseDetails = new List<PurchaseDetail>
                    {
                        new () {ProductId = Guid.Parse("016e0eda-5f57-49e8-8249-e7e05a032cbe"), Qty=2,},
                        new () {ProductId = Guid.Parse("b1f3750d-fff4-4f16-9de2-92d8e479befe"), Qty=2,},
                    }
                };
                context.Purchases.Add(purchase);
                context.SaveChanges();

                foreach (var purchaseDetail in purchase.PurchaseDetails)
                {
                    var product = context.Products.FirstOrDefault(p => p.Id.Equals(purchaseDetail.ProductId));
                    if (product != null) product.Stock -= purchaseDetail.Qty;
                }

                context.SaveChanges();
                transaction.Commit();
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e);
                transaction.Rollback();
                throw;
            }





        }
    }
}
/*
   Product nabati = new()
            {
                ProductName = "Rich rich nabati",
                ProductPrice = 3000,
                Stock = 15
            };
            Product tango = new()
            {
                ProductName = "Tango coklat",
                ProductPrice = 5000,
                Stock = 10
            };
            Product nextmonth = new()
            {
                ProductName = "Nextmonth",
                ProductPrice = 4000,
                Stock = 5
            };

            productRepo.Save(nabati);
            productRepo.Save(tango);
            productRepo.Save(nextmonth);

*/