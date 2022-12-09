using DataLibrary.DbAccess;

namespace DataLibrary.DbServices;
public class TestDataServiceFactory : IGroundRentPortalDataServiceFactory
{
    public IGroundRentPortalDataService CreateAddressDataService(IUnitOfWork uow) => new TestSqlDataService(uow);
}
