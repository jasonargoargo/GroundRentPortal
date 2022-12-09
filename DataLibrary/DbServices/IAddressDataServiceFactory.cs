using DataLibrary.DbAccess;

namespace DataLibrary.DbServices;
public interface IGroundRentPortalDataServiceFactory
{
    IGroundRentPortalDataService CreateAddressDataService(IUnitOfWork uow);
}