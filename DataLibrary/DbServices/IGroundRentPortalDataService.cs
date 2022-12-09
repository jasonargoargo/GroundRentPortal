using DataLibrary.Models;

namespace DataLibrary.DbServices;
public interface IGroundRentPortalDataService
{
    Task<bool> Delete(string accountId);
    Task<List<AddressModel>> ReadByCountyWhereIsLegibleTrueAndIsProcessedFalse(int unprocessedAddressListAmount, string county);
    Task<List<AddressModel>> ReadByVerificationPercentageWhereIsLegibleTrueAndIsProcessedTrue(int unverifiedAddressListAmount);
    Task<bool> Update(AddressModel addressModel);
}