using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBot
{
    class InstaLikeBot: InstaBot
    {

        IWebDriver browser;
        Random rnd = new Random();

        protected override void startBot(int iterations, IWebDriver browser)
        {
            this.browser = browser;
            startLike(iterations);
        }

        void startLike(int countLikesOnTag)
        {
            int index = 9;
            RefreshPage();
            Thread.Sleep(6000);

            List<IWebElement> elements = GetPictures();

            if (elements.Count != 0)
            {
                while (index < countLikesOnTag + 9)
                {
                    OpenPicture(elements[index]);
                    Thread.Sleep(1000);
                    SetLike();
                    Thread.Sleep(1000);
                    BackPage();
                    Thread.Sleep(rnd.Next(60 * 1000 * 6, 65 * 1000 * 6));
                    index++;
                }
            }
        }

  
        private void SetLike()
        {          
            clickOnElement(".dCJp8.afkep");
        }

    }
}
