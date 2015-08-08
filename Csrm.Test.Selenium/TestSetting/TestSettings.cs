//#define TEST_SERVER
#define LOCAL_SERVER

using Csrm.Test.Selenium.TestSetting.Data;
using Csrm.Test.Selenium.TestSetting.Model;

namespace Csrm.Test.Selenium.TestSetting
{
    public static class TestSettings
    {
        public static readonly DataContainer Datas;
        public static readonly WaitingTimeout Timeouts;

        static TestSettings()
        {
#if TEST_SERVER
            Datas = new TestServerDataContainer();
            Timeouts = new WaitingTimeout();
#elif LOCAL_SERVER
            Datas = new LocalServerDataContainer();
            Timeouts = new WaitingTimeout();
#endif
        }
    }
}
