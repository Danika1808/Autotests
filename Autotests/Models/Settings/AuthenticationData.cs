namespace Autotests.Models.Settings
{
    public class AuthenticationData
    {
        public string ValidLogin { get; set; }
        public string ValidPassword { get; set; }
        
        public string InvalidLogin { get; set; }
        public string InvalidPassword { get; set; }
        

        public AuthenticationData()
        {
        }

        public AuthenticationData(string validLogin, string validPassword, string invalidLogin, string invalidPassword)
        {
            ValidLogin = validLogin;
            ValidPassword = validPassword;
            InvalidLogin = invalidLogin;
            InvalidPassword = invalidPassword;
        }
    }
}