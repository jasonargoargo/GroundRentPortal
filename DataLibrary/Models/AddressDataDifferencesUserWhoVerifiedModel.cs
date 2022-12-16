namespace DataLibrary.Models;
public class AddressDataDifferencesUserWhoVerifiedModel
{
	public string? User { get; set; }
	public bool? VerifiedIsLegible { get; set; }
	public AddressModel.InputType? VerifiedNotLegibleType { get; set; }
	public decimal? VerifiedPaymentAmount { get; set; }
	public AddressModel.PaymentFrequency? VerifiedGroundRentPaymentFrequency { get; set; }
	public DateTime? VerifiedPaymentDateAnnual { get; set; }
	public DateTime? VerifiedPaymentDateSemiAnnual1 { get; set; }
	public DateTime? VerifiedPaymentDateSemiAnnual2 { get; set; }
	public DateTime? VerifiedPaymentDateQuarterly1 { get; set; }
	public DateTime? VerifiedPaymentDateQuarterly2 { get; set; }
	public DateTime? VerifiedPaymentDateQuarterly3 { get; set; }
	public DateTime? VerifiedPaymentDateQuarterly4 { get; set; }
	public string? VerifiedPaymentDateOther { get; set; }
}
