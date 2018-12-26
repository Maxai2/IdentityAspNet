using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAspNet.Models
{
    public class User : IdentityUser
    {
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string FullName { get; set; }
    }
}
