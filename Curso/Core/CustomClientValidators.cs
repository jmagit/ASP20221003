namespace Curso.Core {
    using global::Core.Validators;
    using Microsoft.AspNetCore.Mvc.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using Microsoft.Extensions.Localization;

    using System.ComponentModel.DataAnnotations;

    public class NIFAttributeAdapter : AttributeAdapterBase<NIFAttribute> {
        public NIFAttributeAdapter(NIFAttribute attribute, IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer) { }
        public override void AddValidation(ClientModelValidationContext context) {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-nif", GetErrorMessage(context));
        }
        public override string GetErrorMessage(ModelValidationContextBase validationContext) =>
            Attribute.DefaultErrorMessage;
    }
    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider {
        private readonly IValidationAttributeAdapterProvider baseProvider = new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute,
            IStringLocalizer stringLocalizer) {
            if(attribute is NIFAttribute NIFAttribute)
                return new NIFAttributeAdapter(NIFAttribute, stringLocalizer);
            return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
