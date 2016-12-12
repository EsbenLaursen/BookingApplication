using System.ComponentModel.DataAnnotations;

namespace DLL.Entities
{

    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Dit første navn mangler")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Dit sidste navn mangler")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Din email mangler")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobil nummer tak")]
        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Telephone { get; set; }
        public bool IsRegistered { get; set; }


    }
}