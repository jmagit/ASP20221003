using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Validators {
    public static class StringValidators {
        public static bool IsNIF(this string value) {
            if (value is String cad) {
                cad = cad.ToUpper();
                return Regex.IsMatch(cad, @"^\d{2,8}[A-Z]$") &&
                    cad[^1] == "TRWAGMYFPDXBNJZSQVHLCKE"[(int)(long.Parse(cad[0..^1]) % 23)];
            }
            return false;
        }
        public static bool IsNotNIF(this string value) {
            return !IsNIF(value);
        }
        public static bool IsMaxLength(this string value, int max) {
            return value.Length <= max;
        }
        public static bool IsNotMaxLength(this string value, int max) {
            return !IsMaxLength(value, max);
        }
    }
    public static class DateValidators {
        public static bool IsPast(this DateTime value) {
            return value < DateTime.Now;
        }
        public static bool IsNotPast(this DateTime value) {
            return !IsPast(value);
        }
        public static bool IsPastOrPresent(this DateTime value) {
            return value <= DateTime.Now;
        }
        public static bool IsNotPastOrPresent(this DateTime value) {
            return !IsPastOrPresent(value);
        }
        public static bool IsFuture(this DateTime value) {
            return value > DateTime.Now;
        }
        public static bool IsNotFuture(this DateTime value) {
            return !IsFuture(value);
        }
        public static bool IsFutureOrPresent(this DateTime value) {
            return value >= DateTime.Now;
        }
        public static bool IsNotFutureOrPresent(this DateTime value) {
            return !IsFutureOrPresent(value);
        }
    }
}

namespace Core.DataAnnotations {
    using Core.Validators;

    public class PastAttribute : ValidationAttribute {
        public PastAttribute() : this("La fecha debe ser anterior a ahora.") { }
        public PastAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor) { }
        public PastAttribute(string errorMessage) : base(errorMessage) { }
        public string DefaultErrorMessage => ErrorMessageString;

        public override bool IsValid(object value) {
            return value == null || value is DateTime fecha && fecha.IsPast();
        }
    }

    public class NIFAttribute : ValidationAttribute {
        public NIFAttribute() : this("No es un NIF válido.") { }
        public NIFAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor) { }
        public NIFAttribute(string errorMessage) : base(errorMessage) { }

        public string DefaultErrorMessage => ErrorMessageString;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if (value == null) return ValidationResult.Success;
            return value == null || value is string cad && cad.IsNIF() ? ValidationResult.Success : new ValidationResult(ErrorMessageString);
        }
    }
}
