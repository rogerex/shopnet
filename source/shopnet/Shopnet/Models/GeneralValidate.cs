using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Web.Mvc;
using System.Globalization;
using System.Collections.Generic;
using System;

namespace Shopnet.Models
{
        [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidateLengthAttribute : ValidationAttribute, IClientValidatable
        {
            private const string _defaultMessage = "'{0}' must be at least {1} characters long.";
            //private readonly int _minChars =5;// Membership.Provider.MinRequiredPasswordLength;
            public int _minChars = 0;
            public void setMinChars(int val)
            {
                this._minChars = val;
            }
            public ValidateLengthAttribute()
                : base(_defaultMessage)
            {
            }

            public override string FormatErrorMessage(string name)
            {
                return String.Format(CultureInfo.CurrentCulture, ErrorMessageString,
                    name, _minChars);
            }

            public override bool IsValid(object value)
            {
                string valueAsString = value as string;
                return (valueAsString != null && valueAsString.Length >= _minChars);
            }

            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                return new[]{
                        new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()), _minChars, int.MaxValue)
                    };
            }
        }
    
}//end namespace