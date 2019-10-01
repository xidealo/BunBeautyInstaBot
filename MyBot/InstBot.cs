using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace MyBot
{
    class InstBot
    {
        IWebDriver browser;
        Random rnd = new Random();
        int count_like = 0;
        int count_tags;
        int count_likes_on_tags;

        public void InstBotGo(string login, string pass, string tags, int count_likes_on_tags) //count_likes_on_tags это количество лайков на 1 тег
        {
            this.count_tags = tags.Where(x => x == '#').Count();
            if (CheckData(login, pass, count_tags, count_likes_on_tags))
            {
                OpenBrowser();                

                Registration(login, pass);

                Thread.Sleep(2000);

                NotificationCheck();
                // отправляем количество поисковых тегов
                this.count_likes_on_tags = count_likes_on_tags;
                Count_Search_tags(this.count_tags, this.count_likes_on_tags, tags);
            }

        }

        private void OpenBrowser()
        {
            // открыть  
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();

            //открываю браузер на весь экран
            browser.Manage().Window.Maximize();

            // отправляемся по ссылке
            browser.Navigate().GoToUrl("https://www.instagram.com/accounts/login/?source=auth_switcher");
        }

        private void Registration(string login, string pass)
        {
            //ищем и заполняем поля
            IWebElement element;
            Thread.Sleep(1000);

            element = browser.FindElement(By.Name("username"));
            element.SendKeys(login);
            Thread.Sleep(1000);

            element = browser.FindElement(By.Name("password"));
            element.SendKeys(pass);
            Thread.Sleep(1000);

            element = browser.FindElement(By.CssSelector(".sqdOP.L3NKy"));
            element.Click();

        }

        private void SearchTag(string tags, int indexOftag)
        {
            
            string [] massTags = tags.Split(' ');

            IWebElement element;

            element = browser.FindElement(By.CssSelector(".XTCLo.x3qfX")); //.XTCLo.x3qfX// ошибка с недостуцпной страницей

            element.SendKeys(massTags[indexOftag]);
            Thread.Sleep(1000);

            try
            {
                element = browser.FindElement(By.ClassName("uyeeR"));
                element.Click();
            }
            catch
            {
                RefreshPage();
                SearchTag(tags, indexOftag);
            }
        }

        // примерно 10ая картинка 
        private bool OpenPictureAndSetLike(int count_likes_on_tags)
        {
            RefreshPage();
            Thread.Sleep(4000);

            List<IWebElement> elements = browser.FindElements(By.CssSelector(".v1Nh3.kIKUG._bz0w")).ToList();
            if (elements.Count != 0)
            {
                for (int i = 0 + 10; i < count_likes_on_tags + 10; i++)
                {
                    try
                    {
                        elements[i].Click();
                        Thread.Sleep(rnd.Next(1000, 2500));

                        SetLike();
                        Thread.Sleep(rnd.Next(1000, 2500));

                        browser.Navigate().Back();
                        //спим примерно 6 минут после фотки
                        Thread.Sleep(rnd.Next(60 * 1000 * 6, 65 * 1000 * 6));
                    }
                    catch
                    {
                        i--;
                        return false;
                    }
                }
            }
            return true;
        }

        private void NotificationCheck()
        {
            IWebElement element;

            element = browser.FindElement(By.CssSelector(".aOOlW.HoLwm"));
            element.Click();
            Thread.Sleep(1000);
        }

        private void SetLike()
        {
            count_like++;
            // ЕСТЬ ОШИБКА? Вроде не рабюотает катч, посмотреть! 
            IWebElement element;

            element = browser.FindElement(By.CssSelector(".dCJp8.afkep"));
            element.Click();          
        }

        private void Count_Search_tags(int count_search_tag, int count_likes_on_tags, string tags)
        {

            int indexOfTag = 0;
            for (int i = 0; i < count_search_tag; i++)
            {
                SearchTag(tags, indexOfTag);
                indexOfTag++;
                Thread.Sleep(3000);
                
                // если не поставился лайк и была какая-то ошибка, то просто -1 попыток и пробуем еще раз с другим тегом
                if (!OpenPictureAndSetLike(count_likes_on_tags))
                {
                    i--;
                }

                Thread.Sleep(rnd.Next(1000, 2500));

                // чтобы не было вложенных циклов сделал запрошенное количество лайков и остановился
                if (count_like == count_tags*count_likes_on_tags)
                {
                    browser.Close();
                    break;
                }
            }
        }

        private void BackPage()
        {
            browser.Navigate().Back();
        }

        private void RefreshPage()
        {
            browser.Navigate().Refresh();
        }

        //проверка данных, заполнены ли поля
        private bool CheckData(string login, string pass, int count_tags, int count_likes_on_tags)
        {
            if ((count_tags > 0) && (count_likes_on_tags > 0))
            {
                if ((login != "") && (pass != ""))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
