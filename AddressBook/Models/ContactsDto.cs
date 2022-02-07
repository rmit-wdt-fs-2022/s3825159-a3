using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Models
{
    public class ContactsDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(30)]
        public string? FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(30)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Must be a valid email address!")]
        [StringLength(320)]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"/^0(4)\d{8}$/")]
        [StringLength(10)]
        public string? MobilePhone { get; set; }


        [ForeignKey("AddressID")]
        public int? HomeAddressID { get; set; }

        [ForeignKey("AddressID")]
        public int? WorkAddressID { get; set; }
    }
}
