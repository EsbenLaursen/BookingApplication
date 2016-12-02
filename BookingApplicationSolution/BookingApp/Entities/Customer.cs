using System;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Entities
{
    
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "UUUUUUUDFYLD")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool IsRegistered { get; set; }


    }
}