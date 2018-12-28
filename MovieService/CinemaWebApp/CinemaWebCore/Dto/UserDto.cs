using System.ComponentModel.DataAnnotations;

namespace CinemaWebCore.Dto
{
    public class UserDto
    {

        //----------------------------------------------------------------//

        [Required]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public bool IsOnline { get; set; }
        
        public string Country { get; set; }

        [MaxLength(80, ErrorMessage = "Maximum length of city is 80")]
        public string City { get; set; }

        [MaxLength(80, ErrorMessage = "Maximum length of city is 80")]
        public string Address { get; set; }

        public string Gender { get; set; }
        
        [MaxLength(100, ErrorMessage = "Maximum length of path is 100")]
        public string PathOfPhoto { get; set; }

        //----------------------------------------------------------------//

    }
}
