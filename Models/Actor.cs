using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace eApplication.Models
{
    public class Actor
    {
        [Key]
        public int Id {  get; set; }
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureName { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string FullName {  get; set; }
        [Required(ErrorMessage = "Biography is required")]
        public string Bio {  get; set; }

        public List<Actor_Movie> Actors_Movies { get; set; } // navigation property.

    }
}
