using Csrm.Test.Selenium.TestSetting.Model;

namespace Csrm.Test.Selenium.TestSetting.Data
{
    public class LocalServerDataContainer : DataContainer
    {
        public override string BaseUrl
        {
            get { throw new System.NotImplementedException(); }
        }

        public override User User
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}