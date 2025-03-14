using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPCRUD.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="First name required")]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name requird")]
        [DisplayName("Last name")]
        public string LastName{ get; set; }
        [Required(ErrorMessage ="Date of birth required")]
        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="Email required")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Salary required")]
        [DisplayName("Salary")]
        public double Salary { get; set; }
    }
}
