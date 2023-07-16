using System.ComponentModel.DataAnnotations;

namespace Test_Core3.BusinessLayer.Utility
{
    public class MustBeSelectedAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int categoryId=(int) value;
            return categoryId != 0;
        }
    }
}
