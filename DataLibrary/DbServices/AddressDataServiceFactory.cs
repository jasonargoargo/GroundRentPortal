using DataLibrary.DbAccess;

namespace DataLibrary.DbServices;
public class AddressDataServiceFactory : IGroundRentPortalDataServiceFactory
{
    public IGroundRentPortalDataService CreateAddressDataService(IUnitOfWork uow) => new AddressSqlDataService(uow);
}
