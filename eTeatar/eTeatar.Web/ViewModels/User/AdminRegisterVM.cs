namespace eTeatar.Web.ViewModels.User
{
    public class AdminRegisterVM
    {
        public string Username { get; set; }
        public string UsernameError { get; set; }
        public string Password { get; set; }
        public string PasswordError { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string EmailError { get; set; }
    }
}
