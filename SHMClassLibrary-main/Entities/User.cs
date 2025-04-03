using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SHMClassLibrary.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // "Admin", "TravelAgent", "Customer"

        public string ContactNumber { get; set; }



        public override string ToString()
        {
            return $"Id:{UserID}, Name:{Name}, Email:{Email},Role:{Role} ";
        }
    }
}
