using System.ComponentModel.DataAnnotations;

namespace DependableSolutionTest.ViewModel
{
    public class OrderViewModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "RefId must be a numeric string with a maximum length of 10 characters.")]
        public string RefId { set; get; }
        [Required]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]*$",ErrorMessage = "Only Contains Alphabetic and Numeric Characters")]
        public string PONO { set; get; }
        [Required]
        public string PODATE { get; set; }
        [Required]
        public string Supplier { get; set; }
        [Required]
        public string ExpectedDate { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Contains Alphabetic and Numeric Characters")]
        public string Remarks { get; set; }
        public List<QuantityItemViewModel> QuantityItems { set; get; }
    }
}
