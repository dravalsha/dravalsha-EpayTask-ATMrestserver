using System.ComponentModel.DataAnnotations;

namespace RESTserver.Models
{
    public class Customer
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Range(19, 90, ErrorMessage = "Enter Valid Age")]
        public int age { get; set; }
    }
}
