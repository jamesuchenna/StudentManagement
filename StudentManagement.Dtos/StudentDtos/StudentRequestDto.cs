using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dtos.StudentDtos
{
    public class StudentRequestDto
    {
        [Required(ErrorMessage = "Enter this detail")]
        [StringLength(50)]
        public string Email { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Enter this detail")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Enter this detail")]
        [StringLength(50)]
        public string LastName { get; set; }
        [DisplayName("Favourite Quote")]
        [Required(ErrorMessage = "Enter this detail")]
        [StringLength(50)]
        public string FavouriteQuote { get; set; }
    }
}
