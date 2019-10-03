using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBot
{
    class InstaHistoryBot : InstaBot
    {
        protected override void startBot(int iterations, IWebDriver browser)
        {
            startLookHistory(iterations);
        }

        private void startLookHistory(int countOfProfiles) { 

        }
    }
}
