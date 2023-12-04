using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        public int UserId { get; set; }
    }
}
