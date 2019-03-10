using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VideoStoreNew.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnURL { get; set; }
        [Display(Name ="Remeber Me")]
        public bool RememberMe { get; set; }
    }
}
