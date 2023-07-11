using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;
    private readonly IPersistence _persistence;

    public CustomerService(IRepository<Customer> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;

    }

    public Customer CreateNewCustomer(Customer customer)
    {
        try
        {
            var newCustomer = _repository.Save(customer);
            _persistence.SaveChanges();
            return newCustomer;
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e);
            throw;
        }
    }

    public Customer GetById(string id)
    {
        try
        {
            var customer = _repository.FindById(Guid.Parse(id));
            if (customer is null) throw new Exception("Customer not found");
            return customer;
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e);
            throw;
        }
    }
}