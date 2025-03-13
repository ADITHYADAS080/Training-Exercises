using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserRegistration.Models
{
	public  class User
	{
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="First name is required")]
        [Display(Name ="First Name")]
        public string UserFirstName{ get; set; }

        [Required(ErrorMessage ="Last name is required")]
        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage ="DateOfBirth is required")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage ="Gender required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="PhoneNumber required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Email id Required")]
        [EmailAddress(ErrorMessage ="Invalid email format")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage ="Address required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage ="state required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage ="city required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage ="Username is required")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [Display(Name = "Password")]
        [StringLength(50,MinimumLength =8,ErrorMessage ="Atleast 8 charecters required")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}