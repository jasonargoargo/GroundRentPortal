using System.ComponentModel.DataAnnotations;

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
        public bool? IsLegible { get; set; }
        public enum NotLegible { PaymentAmount, PaymentDate, PaymentFrequency, Other }
        public NotLegible NotLegibleType { get; set; } = new();
        [Required] [DataType(DataType.Currency)] public decimal? PaymentAmount { get; set; }
        public enum PaymentFrequency { Annual, SemiAnnual, Quarterly, Other, Blank }
        [Required] public PaymentFrequency GroundRentPaymentFrequency { get; set; }
        [DataType(DataType.DateTime)] public DateTime? PaymentDateAnnual { get; set; }
        [DataType(DataType.DateTime)] public DateTime? PaymentDateSemiAnnual1 { get; set; }
		[DataType(DataType.DateTime)] public DateTime? PaymentDateSemiAnnual2 { get; set; }
		[DataType(DataType.DateTime)] public DateTime? PaymentDateQuarterly1 { get; set; }
		[DataType(DataType.DateTime)] public DateTime? PaymentDateQuarterly2 { get; set; }
		[DataType(DataType.DateTime)] public DateTime? PaymentDateQuarterly3 { get; set; }
		[DataType(DataType.DateTime)] public DateTime? PaymentDateQuarterly4 { get; set; }
		[MaxLength(64)]public string? PaymentDateOther { get; set; }
        public string? UserWhoProcessed { get; set; }
        public string? UserWhoVerified { get; set; }
    }
}
