using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Validators {
    public class NIFAttribute : ValidationAttribute {
        public NIFAttribute() : this("No es un NIF válido.") { }
        public NIFAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor) { }
        public NIFAttribute(string errorMessage) : base(errorMessage) { }
        public string DefaultErrorMessage => ErrorMessageString;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if(value == null) return ValidationResult.Success;
            if(value is String cad) {
                cad = cad.ToUpper();
                if(Regex.IsMatch(cad, @"^\d{2,8}[A-Z]$") &&
                    cad[^1] == "TRWAGMYFPDXBNJZSQVHLCKE"[(int)(long.Parse(cad[0..^1]) % 23)])
                    return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessageString);
        }
    }
}
