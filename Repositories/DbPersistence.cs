namespace EFUpskilling.Repositories;

public class DbPersistence : IPersistence
{
    private readonly AppDbContext _appDbContect;

    public DbPersistence(AppDbContext appDbContext)
    {
        _appDbContect = appDbContext;
    }
    public void SaveChanges()
    {
        _appDbContect.SaveChanges();
    }
    public void BeginTransaction()
    {
        _appDbContect.Database.BeginTransaction();
    }

    public void Commit()
    {
        _appDbContect.Database.CommitTransaction();
    }

    public void Rollback()
    {
        _appDbContect.Database.RollbackTransaction();
    }

}