using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Models
{
    public class Addresses
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Street { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(100)]
        public string? Suburb { get; set; }

        [StringLength(4)]
        [RegularExpression("[1-9]\\d{3}",
            ErrorMessage = "Enter a valid 4 digit postcode.")]
        [Required]
        public string? PostCode { get; set; }

        [Required]
        [StringLength(3)]
        [RegularExpression("[A-Z]{3}",
            ErrorMessage = "Enter your state eg: QLD.")]
        public string? State { get; set; }
    }
}
