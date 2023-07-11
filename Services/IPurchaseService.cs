using EFUpskilling.Entities;

namespace EFUpskilling.Services;

public interface IPurchaseService
{
    Purchase CreateNewTransactions(Purchase purchase);
}