using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBot
{
    class InstaHistoryBot : InstaBot
    {
        private int SPEED_SCROLL_HISTORY = 1000;
        private IWebDriver browser;
        private Random rnd = new Random();
        private string pictureFeedUrl;
        private List<String> profileNamesList;
        private bool IsDubna = true;

        protected override void startBot(int iterations, IWebDriver browser)
        {
            pictureFeedUrl = browser.Url;
            this.browser = browser;
            profileNamesList = new List<string>();
            StartLookHistory(iterations);
        }

        private void StartLookHistory(int countOfProfiles)
        {
            int index = 9;
            //RefreshPage();
            Thread.Sleep(2000);
            Actions actions = new Actions(browser);
            List<IWebElement> elements;
            while (index < countOfProfiles + 9)
            {
                elements = GetPictures();

                try
                {   //заканчивается количество элементов
                    OpenPicture(elements[index]);
                }
                catch
                {
                    index = 9;
                    if (IsDubna)
                    {
                        pictureFeedUrl = SearchTag("#Кимры");
                        IsDubna = false;
                        profileNamesList.Clear();
                    }
                    else {
                        pictureFeedUrl = SearchTag("#Дубна");
                        IsDubna = true;
                        profileNamesList.Clear();
                    }                
                    elements = GetPictures();
                    OpenPicture(elements[index]);
                }

                Thread.Sleep(1000);

                if (!profileNamesList.Contains(GetProfileName()))
                {
                    profileNamesList.Add(GetProfileName());
                    GoToProfile();
                    Thread.Sleep(3000);
                    //повторяющийся профиль
                    string profileLink = browser.Url;              
                    GoToHistory();
                    Thread.Sleep(1000);
                    if (browser.Url.Equals(profileLink))
                    {
                        //если нет историй
                        GoToPictureFeed();
                    }
                    else
                    {
                        //пока не вышли из историй
                        while (!browser.Url.Equals(profileLink))
                        {
                            clickOnElement(".coreSpriteRightChevron");
                            Thread.Sleep(SPEED_SCROLL_HISTORY);
                        }
                        GoToPictureFeed();
                    }
                }
                else
                {
                    countOfProfiles++;
                    GoToPictureFeed();
                }
                index++;
            }
        }

        private void scrollToLastElement(Actions actions, IWebElement element) {
            //прокручиваем к последнему                   
            actions.MoveToElement(element);
            actions.Perform();
            Thread.Sleep(3000);
        }

        private void GoToProfile() {           
            clickOnElement(".FPmhX.notranslate.nJAzx");
        }

        private string GetProfileName() {
            return browser.FindElement(By.CssSelector(".FPmhX.notranslate.nJAzx")).Text;
        }

        private void GoToHistory()
        {
            clickOnElement("._2dbep");
            rnd.Next(1000, 5000);
        }

        private void GoToPictureFeed() {
            while (!browser.Url.Equals(pictureFeedUrl))
            {
                BackPage();
                Thread.Sleep(2000);
            }
        }

    }
}
