using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace Aiesec.Web
{
    public class ValidationErrors
    {
        private readonly IStringLocalizer<ValidationErrors> _localizer;

        public ValidationErrors(IStringLocalizer<ValidationErrors> localizer)
        {
            _localizer = localizer;
        }

        public string LocalizedString(string value)
        {
            return _localizer[value];
        }

        #region ErrorMessages

        public string ErrThisFieldIsRequired => _localizer[nameof(ErrThisFieldIsRequired)];
        public string ErrEnterValidNumber => _localizer[nameof(ErrEnterValidNumber)];
        public string ErrEnterTheSameValueAgain => _localizer[nameof(ErrEnterTheSameValueAgain)];
        public string EmailWrongFormat => _localizer[nameof(EmailWrongFormat)];
        public string ErrMaxNumberOfCharacters => _localizer[nameof(ErrMaxNumberOfCharacters)];
        public string ErrMinNumberOfCharacters => _localizer[nameof(ErrMinNumberOfCharacters)];
        public string ErrUsernamePolicy => _localizer[nameof(ErrUsernamePolicy)];
        public string ErrNoUsername => _localizer[nameof(ErrNoUsername)];
        public string ErrNoEmail => _localizer[nameof(ErrNoEmail)];
        public string ErrNoPhoneNumber => _localizer[nameof(ErrNoPhoneNumber)];
        public string ErrTypePhoneNumber => _localizer[nameof(ErrTypePhoneNumber)];
        public string ErrFirstName => _localizer[nameof(ErrFirstName)];
        public string ErrLastName => _localizer[nameof(ErrLastName)];
        public string ErrNoFirstName => _localizer[nameof(ErrNoFirstName)];
        public string ErrNoLastName => _localizer[nameof(ErrNoLastName)];
        public string ErrNoBirthDate => _localizer[nameof(ErrNoBirthDate)];
        public string ErrNoGender => _localizer[nameof(ErrNoGender)];
        public string ErrNoAddress => _localizer[nameof(ErrNoAddress)];
        public string ErrNoCity => _localizer[nameof(ErrNoCity)];
        public string ErrNoRole => _localizer[nameof(ErrNoRole)];
        public string ErrNoPassword => _localizer[nameof(ErrNoPassword)];
        public string ErrPasswordPolicy => _localizer[nameof(ErrPasswordPolicy)];
        public string ErrNoPasswordConfirm => _localizer[nameof(ErrNoPasswordConfirm)];
        public string ErrNotSamePasswordConfirm => _localizer[nameof(ErrNotSamePasswordConfirm)];
        public string SorryTryAgain => _localizer[nameof(SorryTryAgain)];
        public string ErrNoEstablishmentDate => _localizer[nameof(ErrNoEstablishmentDate)];
        public string ErrNoLocalCommittee => _localizer[nameof(ErrNoLocalCommittee)];
        public string ErrNoFunctionalField => _localizer[nameof(ErrNoFunctionalField)];
        public string ErrNoName => _localizer[nameof(ErrNoName)];
        public string ErrNoCapacity => _localizer[nameof(ErrNoCapacity)];


        public string ErrUserNameExists(string userName)
        {
            return LocalizedString(nameof(ErrUserNameExists)).Replace("{0}", userName);
        }
        #endregion
    }
}
