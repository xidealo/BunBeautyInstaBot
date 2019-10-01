using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using OpenQA.Selenium;
using System.Threading;


namespace MyBot
{
    class BotVK
    {
        IWebDriver browser;
        // добавить таймер
        System.Timers.Timer timer = new System.Timers.Timer();

        //ссылка на диалоги
        //https://vk.com/im

        public void VkBotGo(string email, string pass)
        {
            //открываем браузер
            OpenBrowser();

            //регистрация, пришлось отключить 2х факторную аутентификацию
            Registration(email, pass);

            Thread.Sleep(1000);

            //переходим к диалогу
            //GoToDialog();

            //выполняем проверку раз в 5 минут
            //таймер

            IsInDialog();
            
        }

        private void OpenBrowser()
        {
            // открыть вк 
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();

            //открываю браузер на весь экран
            browser.Manage().Window.Maximize();

            // отправляемся по ссылке
            browser.Navigate().GoToUrl("https://vk.com/im");

        }

        private void GoToDialog()
        {
            browser.Navigate().GoToUrl("https://vk.com/im");
        }

        private void IsInDialog()
        {

            List<IWebElement> countDialogs = browser.FindElements(By.CssSelector(".nim-dialog_classic.nim-dialog_unread")).ToList();

            for (int i = 0; i < countDialogs.Count; i++)
            {
                IWebElement dialog = browser.FindElement(By.CssSelector(".nim-dialog_classic.nim-dialog_unread"));

                dialog.Click();

                IWebElement answer = browser.FindElement(By.Id("im_editable0"));
                answer.SendKeys("Привет. Я уже не отвечаю больше 5 минут, поэтому за меня это сделает мой бот." +
                    " Расскажи, пока меня нет, как твои дела?" + OpenQA.Selenium.Keys.Enter);

                browser.Navigate().Back();
            }

        }

        private void Registration(string login, string pass)
        {
            //ищем и заполняем поля

            IWebElement element;

            element = browser.FindElement(By.Id("email"));
            element.SendKeys(login);
            Thread.Sleep(1000);

            element = browser.FindElement(By.Id("pass"));
            element.SendKeys(pass);
            Thread.Sleep(1000);

            element = browser.FindElement(By.Id("login_button"));
            element.Click();

        }

    }
}
