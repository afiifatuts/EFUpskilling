namespace EFUpskilling.Repositories;
//Untuk handle :saveChanges, transactions, commit dan rollback

public interface IPersistence
{
    void SaveChanges();
    void BeginTransaction();
    void Commit();
    void Rollback();
}