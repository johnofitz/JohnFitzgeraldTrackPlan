using System.ComponentModel.DataAnnotations;


namespace JohnFitzgeraldTrackPlan.Models
{
    public class DataModel
    {
        [Required(ErrorMessage = "Input cannot be empty!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Words cannot contain numbers or special characters, please try again!")]
        public string Word { get; set; }

        public char[] CharArray { get; set; }
    }
}