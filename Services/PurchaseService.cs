using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IRepository<Purchase> _repository;
    private readonly IPersistence _persistence;
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;

    public PurchaseService(IRepository<Purchase> repository, IPersistence persistence, IProductService productService)
    {
        _repository = repository;
        _persistence = persistence;
        _productService = productService;
    }

    public Purchase CreateNewTransactions(Purchase purchase)
    {
        _persistence.BeginTransaction();
        try
        {
            var newPurchase = _repository.Save(purchase);
            _persistence.SaveChanges();

            foreach (var pd in newPurchase.PurchaseDetails)
            {
                var product = _productService.GetById(pd.ProductId.ToString());
                product.Stock -= pd.Qty;
            }
            _persistence.SaveChanges();
            _persistence.Commit();
            return newPurchase;
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }
}