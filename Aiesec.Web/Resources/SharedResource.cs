using System.Reflection;
using Microsoft.Extensions.Localization;

namespace Aiesec.Web.Resources
{
    public class SharedResource
    {
        private readonly IStringLocalizer _localizer;
        
        public SharedResource(IStringLocalizerFactory localizer)
        {
            _localizer = localizer.Create(nameof(SharedResource), new AssemblyName(typeof(SharedResource).Assembly.FullName).Name);
        }
        
        public string LocalizedString(string key)
        {
            return _localizer[key];
        }

        public string About => _localizer[nameof(About)];
        public string UserName => _localizer[nameof(UserName)];
        public string Actions => _localizer[nameof(Actions)];
        public string UsersSettings => _localizer[nameof(UsersSettings)];
        public string Email => _localizer[nameof(Email)];
        public string Search => _localizer[nameof(Search)];
        public string New => _localizer[nameof(New)];
        public string Users => _localizer[nameof(Users)];
        public string Bosnian => _localizer[nameof(Bosnian)];
        public string EnglishUS => _localizer[nameof(EnglishUS)];
        public string LanguageIcon => _localizer[nameof(LanguageIcon)];
        public string PhoneNumber => _localizer[nameof(PhoneNumber)];
        public string Details => _localizer[nameof(Details)];
        public string ActivateDeactivate => _localizer[nameof(ActivateDeactivate)];
        public string Options => _localizer[nameof(Options)];
        public string SubmitNewRecord => _localizer[nameof(SubmitNewRecord)];
        public string ChangeLanguage => _localizer[nameof(ChangeLanguage)];
        public string LogOut => _localizer[nameof(LogOut)];
        public string NewRecordDesc => _localizer[nameof(NewRecordDesc)];
        public string Reset => _localizer[nameof(Reset)];
        public string LockoutEnd => _localizer[nameof(LockoutEnd)];
        public string EmailConfirmed => _localizer[nameof(EmailConfirmed)];
        public string EmailNotConfirmed => _localizer[nameof(EmailNotConfirmed)];
        public string PhoneNumberConfirmed => _localizer[nameof(PhoneNumberConfirmed)];
        public string PhoneNumberNotConfirmed => _localizer[nameof(PhoneNumberNotConfirmed)];
        public string Close => _localizer[nameof(Close)];
        public string AccountSettings => _localizer[nameof(AccountSettings)];
        public string ChangePassword => _localizer[nameof(ChangePassword)];
        public string Back => _localizer[nameof(Back)];
        public string Settings => _localizer[nameof(Settings)];
        public string Active => _localizer[nameof(Active)];
        public string SaveChanges => _localizer[nameof(SaveChanges)];
        public string Cancel => _localizer[nameof(Cancel)];
        public string TwoFactorEnabled => _localizer[nameof(TwoFactorEnabled)];
        public string CurrentPassword => _localizer[nameof(CurrentPassword)];
        public string NewPassword => _localizer[nameof(NewPassword)];
        public string PasswordConfirm => _localizer[nameof(PasswordConfirm)];
        public string Delete => _localizer[nameof(Delete)];
        public string AreYouSure => _localizer[nameof(AreYouSure)];
        public string PersonalInfo => _localizer[nameof(PersonalInfo)];
        public string AccountInfo => _localizer[nameof(AccountInfo)];
        public string NewUser => _localizer[nameof(NewUser)];
        public string DateOfEnrollment => _localizer[nameof(DateOfEnrollment)];
        public string City => _localizer[nameof(City)];
        public string ChooseCity => _localizer[nameof(ChooseCity)];
        public string RegistrationDate => _localizer[nameof(RegistrationDate)];
        public string DateFormat => _localizer[nameof(DateFormat)];
        public string SuccUserUpdate => _localizer[nameof(SuccUserUpdate)];
        public string ErrUserUpdate => _localizer[nameof(ErrUserUpdate)];
        public string Update => _localizer[nameof(Update)];
        public string Inactive => _localizer[nameof(Inactive)];
        public string All => _localizer[nameof(All)];
        public string TwoFactorDisabled => _localizer[nameof(TwoFactorDisabled)];
        public string Next => _localizer[nameof(Next)];
        public string Role => _localizer[nameof(Role)];
        public string ChooseRole => _localizer[nameof(ChooseRole)];
        public string Submit => _localizer[nameof(Submit)];
        public string FirstName => _localizer[nameof(FirstName)];
        public string LastName => _localizer[nameof(LastName)];
        public string Birthdate => _localizer[nameof(Birthdate)];
        public string Gender => _localizer[nameof(Gender)];
        public string ChooseGender => _localizer[nameof(ChooseGender)];
        public string Address => _localizer[nameof(Address)];
        public string ErrUserInsert => _localizer[nameof(ErrUserInsert)];
        public string SuccUserInsert => _localizer[nameof(SuccUserInsert)];
        public string ResourceCantBeRetrieved => _localizer[nameof(ResourceCantBeRetrieved)];
        public string DatePickerFormat => _localizer[nameof(DatePickerFormat)];
        public string ProfileSettings => _localizer[nameof(ProfileSettings)];
        public string ChangeProfilePhoto => _localizer[nameof(ChangeProfilePhoto)];
        public string ProfileInfo => _localizer[nameof(ProfileInfo)];
        public string EnterDetailsAndSubmit => _localizer[nameof(EnterDetailsAndSubmit)];
        public string UsersPersonalInfo => _localizer[nameof(UsersPersonalInfo)];
        public string UsersAccountSettings => _localizer[nameof(UsersAccountSettings)];
        public string AiesecStatus => _localizer[nameof(AiesecStatus)];
        public string UsersAiesecStatus => _localizer[nameof(UsersAiesecStatus)];
        public string Submission => _localizer[nameof(Submission)];
        public string ReviewAndSubmit => _localizer[nameof(ReviewAndSubmit)];
        public string Ok => _localizer[nameof(Ok)];
        public string Loading => _localizer[nameof(Loading)];
        public string LocalCommittees => _localizer[nameof(LocalCommittees)];
        public string LocalCommittee => _localizer[nameof(LocalCommittee)];
        public string DateOfEstablishment => _localizer[nameof(DateOfEstablishment)];
        public string NewLocalCommittee => _localizer[nameof(NewLocalCommittee)];
        public string Teams => _localizer[nameof(Teams)];
        public string NewTeam => _localizer[nameof(NewTeam)];
        public string LocalCommitteeSettings => _localizer[nameof(LocalCommitteeSettings)];
        public string SetupLocalCommitteeSettings => _localizer[nameof(SetupLocalCommitteeSettings)];
        public string LocalCommitteeInfo => _localizer[nameof(LocalCommitteeInfo)];
        public string Previous => _localizer[nameof(Previous)];
        public string EnterEstablishmentDate => _localizer[nameof(EnterEstablishmentDate)];
        public string NumberOfTeams => _localizer[nameof(NumberOfTeams)];
        public string NewOfficeSettings => _localizer[nameof(NewOfficeSettings)];
        public string SetupOfficeSettings => _localizer[nameof(SetupOfficeSettings)];
        public string ChooseLocalCommittee => _localizer[nameof(ChooseLocalCommittee)];
        public string EnterName => _localizer[nameof(EnterName)];
        public string EnterAddress => _localizer[nameof(EnterAddress)];
        public string EnterCapacity => _localizer[nameof(EnterCapacity)];
        public string OfficeInfo => _localizer[nameof(OfficeInfo)];


        #region SuccMessage
        public string SuccUpdate => _localizer[nameof(SuccUpdate)];
        public string SuccAdd => _localizer[nameof(SuccAdd)];
        public string SuccDelete => _localizer[nameof(SuccDelete)];
        public string SuccChangeStatus => _localizer[nameof(SuccChangeStatus)];
        public string SuccLCInsert => _localizer[nameof(SuccLCInsert)];
        public string ErrUpdate => _localizer[nameof(ErrUpdate)];
        public string EditLocalCommittee => _localizer[nameof(EditLocalCommittee)];
        public string Completed => _localizer[nameof(Completed)];
        public string EnterLCInfo => _localizer[nameof(EnterLCInfo)];
        public string NumberOfMembers => _localizer[nameof(NumberOfMembers)];
        public string TeamSettings => _localizer[nameof(TeamSettings)];
        public string SetupTeamSettings => _localizer[nameof(SetupTeamSettings)];
        public string FunctionalField => _localizer[nameof(FunctionalField)];
        public string ChooseFunctionalField => _localizer[nameof(ChooseFunctionalField)];
        public string MemberCommittee => _localizer[nameof(MemberCommittee)];
        public string MemberCommittees => _localizer[nameof(MemberCommittees)];
        public string NewMemberCommittee => _localizer[nameof(NewMemberCommittee)];
        public string Season => _localizer[nameof(Season)];
        public string Offices => _localizer[nameof(Offices)];
        public string NewOffice => _localizer[nameof(NewOffice)];
        public string Name => _localizer[nameof(Name)];
        public string Capacity => _localizer[nameof(Capacity)];

        #endregion

        #region ErrorMessage
        public string ErrDelete => _localizer[nameof(ErrDelete)];
        public string ErrChangeStatus => _localizer[nameof(ErrChangeStatus)];
        public string ErrLCInsert => _localizer[nameof(ErrLCInsert)];
        public string ErrAdd => _localizer[nameof(ErrAdd)];

        #endregion
    }
}