using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace eApplication.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        //Relationships
        public List<Movie> Movies { get; set; } //Navigation Property
    }
}
