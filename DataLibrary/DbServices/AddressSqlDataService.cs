using System.Data;
using DataLibrary.Models;
using DataLibrary.DbAccess;
using Dapper;

namespace DataLibrary.DbServices;

public class AddressSqlDataService : IGroundRentPortalDataService
{
    private readonly IUnitOfWork _unitOfWork;

    public AddressSqlDataService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Update(AddressModel addressModel)
    {
        try
        {
            var parms = new
            {
                addressModel.AccountId,
                addressModel.IsProcessed,
                addressModel.IsVerified,
                addressModel.IsLegible,
                addressModel.NotLegibleType,
                addressModel.PaymentAmount,
                addressModel.GroundRentPaymentFrequency,
                addressModel.PaymentDateAnnual,
                addressModel.PaymentDateSemiAnnual1,
                addressModel.PaymentDateSemiAnnual2,
                addressModel.PaymentDateQuarterly1,
                addressModel.PaymentDateQuarterly2,
                addressModel.PaymentDateQuarterly3,
                addressModel.PaymentDateQuarterly4,
                addressModel.PaymentDateOther,
                addressModel.UserWhoProcessed,
                addressModel.UserWhoVerified
            };
            await _unitOfWork.Connection.ExecuteAsync("spAddress_Update", parms,
                commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
    public async Task<List<AddressModel>> ReadByCountyWhereIsLegibleTrueAndIsProcessedFalse(int unprocessedAddressListAmount, string county)
    {
        return (await _unitOfWork.Connection.QueryAsync<AddressModel>("spAddress_ReadByCountyWhereIsLegibleTrueAndIsProcessedFalse",
            new { UnprocessedAddressListAmount = unprocessedAddressListAmount, County = county },
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction)).ToList();
    }
    public async Task<List<AddressModel>> ReadByVerificationPercentageWhereIsLegibleTrueAndIsProcessedTrue(int unverifiedAddressListAmount)
    {
        return (await _unitOfWork.Connection.QueryAsync<AddressModel>("spAddress_ReadByVerificationPercentageWhereIsLegibleTrueAndIsProcessedTrue",
            new { UnverifiedAddressListAmount = unverifiedAddressListAmount },
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction)).ToList();
    }
    public async Task<bool> Delete(string accountId)
    {
        try
        {
            await _unitOfWork.Connection.ExecuteAsync("spAddress_Delete", new { AccountId = accountId },
            commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
