using System.ComponentModel.DataAnnotations;

namespace worken_api.CustomAttributes
{
    public class MaxArrayLengthAttribute : ValidationAttribute
    {
        private int _maxArrayLength;

        public MaxArrayLengthAttribute(int maxArrayLength)
        {
            _maxArrayLength = maxArrayLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var array = value as Array;
            if (array != null && array.Length > _maxArrayLength)
            {
                return new ValidationResult($"The array cannot contain more than {_maxArrayLength} elements.");
            }
            return ValidationResult.Success;
        }
    }
}
