using System;

namespace Csrm.Test.Selenium.TestSetting.Model
{
    public class WaitingTimeout
    {
        public readonly TimeSpan Explicit;
        public readonly TimeSpan Implicit;
        public readonly TimeSpan PageLoad;
        public readonly TimeSpan ScriptLoad;


        public WaitingTimeout(double timeOutInSeconds = 10)
        {
            Implicit = Explicit = PageLoad = ScriptLoad = TimeSpan.FromSeconds(timeOutInSeconds);
        }

    }
}
