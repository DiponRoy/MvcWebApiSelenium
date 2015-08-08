using Csrm.Test.Selenium.TestSetting.Model;

namespace Csrm.Test.Selenium.TestSetting.Data
{
    /*
     * set what default data is need to perform test, like login, users
     */
    public abstract class DataContainer
    {
        public abstract string BaseUrl { get; }
        public abstract User User { get; }
    }
}