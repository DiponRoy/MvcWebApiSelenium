namespace Csrm.Test.Selenium.Utilities
{
    public class Utility
    {
        public static string FullName(string firstName, string lastName)
        {
            firstName = string.IsNullOrEmpty(firstName) ? "" : firstName.Trim();
            lastName = string.IsNullOrEmpty(lastName) ? "" : lastName.Trim();
            return string.Format("{0} {1}", firstName, lastName).Trim();
        }
    }
}
