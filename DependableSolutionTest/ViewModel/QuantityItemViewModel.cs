using System.ComponentModel.DataAnnotations;

namespace DependableSolutionTest.ViewModel
{
    public class QuantityItemViewModel
    {
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Contains Alphabetic and Numeric Characters")]
        [Required]
        public string Item { set; get; }
        [Required(ErrorMessage = "Qty is Required and Must be Numaric Value")]
        public int Qty { set; get; }
        [Required(ErrorMessage = "Rate is Required and Must be Numaric Value")]
        public double Rate { set; get; }
    }
}
