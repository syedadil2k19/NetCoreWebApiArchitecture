using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.API.Domain.Entity.User
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [StringLength(25, ErrorMessage = "Username property value length exceeding 25")]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
