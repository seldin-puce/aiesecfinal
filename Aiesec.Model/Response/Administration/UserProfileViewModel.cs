namespace Aiesec.Model.Response.Administration
{
    public class UserProfileViewModel
    {
        public Model.Response.Administration.User User { get; set; }
        public Model.Response.Administration.Profile Profile { get; set; }
        public string OldEncryptedId { get; set; }
    }
}
