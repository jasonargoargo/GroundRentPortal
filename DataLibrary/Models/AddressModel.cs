using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace DataLibrary.Models
{
    public class AddressModel
    {
        public string? AccountId { get; set; }
        public string? County { get; set; }
        public string? AccountNumber { get; set; }
        public string? Ward { get; set; }
        public string? Section { get; set; }
        public string? Block { get; set; }
        public string? Lot { get; set; }
        public string? LandUseCode { get; set; }
        public int? YearBuilt { get; set; }
        public bool? IsRedeemed { get; set; }
        public bool? IsGroundRent { get; set; }
        public bool? IsProcessed { get; set; }
        public bool? IsVerified { get; set; }
		[Required] public bool? IsLegible { get; set; }		
		public enum InputType { Blank, PaymentAmount, PaymentDateAnnual, PaymentDateSemiAnnual1, PaymentDateSemiAnnual2, PaymentDateQuarterly1, PaymentDateQuarterly2, PaymentDateQuarterly3, PaymentDateQuarterly4, PaymentDateOther }
		[RequiredIf("IsLegible == false", ErrorMessage = "Input what is illegible!")]
        public InputType? NotLegibleType { get; set; }
        [MaxLength(2048)] public string? DataDifferencesJson { get; set; }
        [Required] [DataType(DataType.Currency)] public decimal? PaymentAmount { get; set; }
        public enum PaymentFrequency { Blank, Annual, SemiAnnual, Quarterly, Other }
        [Required] public PaymentFrequency? GroundRentPaymentFrequency { get; set; }
		[RequiredIf("GroundRentPaymentFrequency == PaymentFrequency.Annual", ErrorMessage = "An annual date selection must be made")]
        [DataType(DataType.DateTime)] public DateTime? PaymentDateAnnual { get; set; }
		[RequiredIf("GroundRentPaymentFrequency == AddressModel.PaymentFrequency.SemiAnnual", ErrorMessage = "All Semi-Annual date selections must be made.")]
		[DataType(DataType.DateTime)] public DateTime? PaymentDateSemiAnnual1 { get; set; }
		[RequiredIf("GroundRentPaymentFrequency == AddressModel.PaymentFrequency.SemiAnnual", ErrorMessage = "All Semi-Annual date selections must be made.")]
		[DataType(DataType.DateTime)] public DateTime? PaymentDateSemiAnnual2 { get; set; }
		[RequiredIf("GroundRentPaymentFrequency == AddressModel.PaymentFrequency.Quarterly", ErrorMessage = "All Quarterly date selections must be made.")]
		[DataType(DataType.DateTime)] public DateTime? PaymentDateQuarterly1 { get; set; }
		[RequiredIf("GroundRentPaymentFrequency == AddressModel.PaymentFrequency.Quarterly", ErrorMessage = "All Quarterly date selections must be made.")]
		[DataType(DataType.DateTime)] public DateTime? PaymentDateQuarterly2 { get; set; }
		[RequiredIf("GroundRentPaymentFrequency == AddressModel.PaymentFrequency.Quarterly", ErrorMessage = "All Quarterly date selections must be made.")]
		[DataType(DataType.DateTime)] public DateTime? PaymentDateQuarterly3 { get; set; }
		[RequiredIf("GroundRentPaymentFrequency == AddressModel.PaymentFrequency.Quarterly", ErrorMessage = "All Quarterly date selection must be made.")]
		[DataType(DataType.DateTime)] public DateTime? PaymentDateQuarterly4 { get; set; }
		[MaxLength(64)]public string? PaymentDateOther { get; set; }
        public string? UserWhoProcessed { get; set; }
        public string? UserWhoVerified { get; set; }
    }
}
