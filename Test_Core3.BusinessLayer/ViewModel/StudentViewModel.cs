using System.ComponentModel.DataAnnotations;

namespace Test_Core3.BusinessLayer.ViewModel
{
    public class StudentViewModel:IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(15,MinimumLength =3,ErrorMessage ="Min is 3")]
        public string FatherName { get; set; }
        [Required]
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob {  get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [Range(18, 99, ErrorMessage = "Age must be between 18 and 99.")]
        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Dob>DateTime.Now)
            {
                yield return new ValidationResult("Dob can not be greater than today");
            }
            if (Dob<DateTime.Now.AddYears(50))
            {
                yield return new ValidationResult("Dob can not be too past");
            }
            if (Name!="Student")
            {
                yield return new ValidationResult("Student is invalid");
            }
        }
    }
}
