using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Login.Models
{
    public class _login
    {
        [Required(ErrorMessage="Please enter valid username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage ="Please enter valid Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
      
    }
}
