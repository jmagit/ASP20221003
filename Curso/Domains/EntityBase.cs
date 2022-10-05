using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains.Entities {
    public class EntityBase : IValidatableObject {
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            return getValidationErrors();
        }
        public IEnumerable<ValidationResult> getValidationErrors() {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this,
                      context,
                      validationResults,
                      true);
            return validationResults;
        }


        public bool IsValid {
            get {
                return getValidationErrors().Count() == 0;
            }
        }
        public bool IsInvalid {
            get {
                return !IsValid;
            }
        }
    }
}
