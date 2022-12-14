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
<<<<<<< HEAD
        public bool? IsLegible { get; set; }
        public enum InputType { PaymentAmount, PaymentFrequency, PaymentDate, IsLegible, NotLegibleType, Blank }
=======
        [Required] public bool? IsLegible { get; set; }
		public enum InputType { PaymentAmount, PaymentDate, PaymentFrequency, IsLegible, NotLegibleType, Blank }
>>>>>>> 4ef766d08fd6c8a9f532ff67476b0ce74abd50c6
		public InputType NotVerifiedType { get; set; } = new();
		public InputType NotLegibleType { get; set; } = new();
        [MaxLength(1024)] public string? DifferencesNotesToDb { get; set; }
        [Required] [DataType(DataType.Currency)] public decimal? PaymentAmount { get; set; }
        public enum PaymentFrequency { Annual, SemiAnnual, Quarterly, Other, Blank }
        [Required] public PaymentFrequency GroundRentPaymentFrequency { get; set; } = new();
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
