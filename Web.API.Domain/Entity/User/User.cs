using System.ComponentModel.DataAnnotations;

namespace Web.API.Domain.Entity.User
{
    /// <summary>Data model that represents a user.</summary>
    /// <seealso cref="Web.API.Domain.Entity.BaseEntity" />
    public class User : BaseEntity
    {
        /// <summary>  Represents first name of the user.</summary>
        /// <value>  First name of the user.</value>
        public string FirstName { get; set; }
        /// <summary>  Represents last name of the user.</summary>
        /// <value>  Last name of the user.</value>
        public string LastName { get; set; }
        /// <summary>  Represents middle name of the user.</summary>
        /// <value>  Middle name of the user.</value>
        public string MiddleName { get; set; }
        /// <summary>Represents login username for the user.</summary>
        /// <value>The username for login.</value>
        /// <remarks>The <c>Username</c> property has a max length of <c>25</c> characters.</remarks>
        [StringLength(25, ErrorMessage = "Username property value length exceeding 25")]
        public string Username { get; set; }
        /// <summary>  Represents the login password for the user.</summary>
        /// <value>The password for login.</value>
        public string Password { get; set; }
    }
}
