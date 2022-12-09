namespace FootBall.API.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateUser
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "FirstName is Required field!")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName is Required field!")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Age is Required field!")]
        public int Age { get; set; }
    }
}
