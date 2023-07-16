using System.ComponentModel.DataAnnotations;

namespace Test_Core3.BusinessLayer.Utility
{
    public class MyCustomValidator:ValidationAttribute
    {
        public MyCustomValidator(string _tmpText)
        {
            TmpProp = _tmpText;
        }
        private string TmpProp { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // return base.IsValid(value, validationContext);
            if (value!=null)
            {
                string date = value.ToString();
                if (DateTime.Today.Date> Convert.ToDateTime(date).Date)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "This field is not valid");
        }
    }
}
