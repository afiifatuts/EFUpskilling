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

/*
            //transactions
            var transaction = context.Database.BeginTransaction();
            try
            {
                var purchase = new Purchase
                {
                    TransDate = DateTime.UtcNow,
                    // CustomerId = Guid.Parse("eaabb66e-3ef1-4e4d-ad78-27561367b697"),
                    Customer = new Customer
                    {
                        CustomerName = "Abdul",
                        Address = "Jl, kancil",
                        MobilePhone = "0856253652",
                        Email = "abdul@gmail.com"
                    },
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


*/

            /*
            IRepository<Customer> repository = new Repository<Customer>(context);
            IRepository<Product> productRepo = new Repository<Product>(context);

            var purchase = context.Purchases
            //.Include(p => p.Customer)
            .Include("Customer")
            //.Include("PurchaseDetails.Product")
            .Include(p => p.PurchaseDetails)
            .ThenInclude(pd => pd.Product)
            .FirstOrDefault(p => p.Id.Equals(Guid.Parse("eaabb66e-3ef1-4e4d-ad78-27561367b697")));

            System.Console.WriteLine(purchase);
           
            QUERYNYA :
            SELECT * FROM t_purchase as tp
            JOIN m_customer as mc On mc.id = tp.customer_id
            JOIN t_purchase_detail as tpd On tpd.purchase_id = tp.id
            JOIN m_product as mp On mp.id = tpd.product_id;
            */