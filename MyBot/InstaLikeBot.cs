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

            while (index < countLikesOnTag + 9)
            {
                OpenPictureAndSetLike(index);
                index++;
            }
        }

        // примерно 10ая картинка 
        private void OpenPictureAndSetLike(int index)
        {
            List<IWebElement> elements = browser.FindElements(By.CssSelector(".v1Nh3.kIKUG._bz0w")).ToList();
            if (elements.Count != 0)
            {
                try
                {
                    elements[index].Click();
                    Thread.Sleep(rnd.Next(1000, 2500));

                    SetLike();
                    Thread.Sleep(rnd.Next(1000, 2500));

                    browser.Navigate().Back();
                    //спим примерно 6 минут после фотки
                    Thread.Sleep(rnd.Next(60 * 1000 * 6, 65 * 1000 * 6));
                }
                catch
                {
                    RefreshPage();
                    Thread.Sleep(6000);
                }

            }
        }

        private void SetLike()
        {          
            browser.FindElement(By.CssSelector(".dCJp8.afkep")).Click();         
        }

    }
}
