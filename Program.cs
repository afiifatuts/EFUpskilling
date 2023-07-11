using EFUpskilling.Repositories;
using EFUpskilling.Entities;
using EFUpskilling.Services;
using Microsoft.EntityFrameworkCore;

namespace EFUpskilling
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new();
            IRepository<Purchase> repoPurchase = new Repository<Purchase>(context);
            IRepository<Product> repoPruduct = new Repository<Product>(context);
            IPersistence persistence = new DbPersistence(context);
            IProductService productService = new ProductService(repoPruduct, persistence);
            IPurchaseService purchaseService = new PurchaseService(repoPurchase, persistence, productService);

            var purchase = new Purchase
            {
                TransDate = DateTime.UtcNow,
                CustomerId = Guid.Parse("eaabb66e-3ef1-4e4d-ad78-27561367b697"),
                PurchaseDetails = new List<PurchaseDetail>
                {
                    new () {ProductId = Guid.Parse("016e0eda-5f57-49e8-8249-e7e05a032cbe"), Qty =1,},
                    new () {ProductId = Guid.Parse("b1f3750d-fff4-4f16-9de2-92d8e479befe"), Qty =2,}
                }
            };
            purchaseService.CreateNewTransactions(purchase);

        }
    }
}

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