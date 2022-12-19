using DataLibrary.Models;

namespace DataLibrary.Models;
public class AddressDataDifferencesUserWhoProcessedModel
{
	public string? User { get; set; }
	public bool? ProcessedIsLegible { get; set; }
	public AddressModel.InputType? ProcessedNotLegibleType { get; set; }
	public decimal? ProcessedPaymentAmount { get; set; }
	public AddressModel.PaymentFrequency? ProcessedGroundRentPaymentFrequency { get; set; }
	public DateTime? ProcessedPaymentDateAnnual { get; set; }
	public DateTime? ProcessedPaymentDateSemiAnnual1 { get; set; }
	public DateTime? ProcessedPaymentDateSemiAnnual2 { get; set; }
	public DateTime? ProcessedPaymentDateQuarterly1 { get; set; }
	public DateTime? ProcessedPaymentDateQuarterly2 { get; set; }
	public DateTime? ProcessedPaymentDateQuarterly3 { get; set; }
	public DateTime? ProcessedPaymentDateQuarterly4 { get; set; }
	public string? ProcessedPaymentDateOther { get; set; }
}
