using OpenQA.Selenium;
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
        private int SPEED_SCROLL_HISTORY = 500;
        private IWebDriver browser;
        private Random rnd = new Random();
        private string pictureFeedUrl;
        private List<String> profileLinksList;
        protected override void startBot(int iterations, IWebDriver browser)
        {
            pictureFeedUrl = browser.Url;
            this.browser = browser;
            profileLinksList = new List<string>();
            StartLookHistory(iterations);
        }

        private void StartLookHistory(int countOfProfiles)
        {
            int index = 9;
            //RefreshPage();
            Thread.Sleep(6000);
            while (index < countOfProfiles + 9)
            {
                List<IWebElement> elements = GetPictures();
                //OpenPicture(elements[index]);
                Thread.Sleep(500);

                //GoToProfile();
                Thread.Sleep(2500);
                if (!profileLinksList.Contains(browser.Url))
                {
                    //повторяющийся профиль
                    string profileLink = browser.Url;
                    profileLinksList.Add(profileLink);
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
                else {
                    countOfProfiles++;
                }
                index++;
            }
        }
  

        private void GoToProfile() {           
            clickOnElement(".FPmhX.notranslate.nJAzx");
        }

        private void GoToHistory()
        {
            clickOnElement("._2dbep");
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
