using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var resultValidate = validator.Validate(context);
            if (!resultValidate.IsValid)
            {
                throw new ValidationException(resultValidate.Errors);
            }
        }
    }
}
