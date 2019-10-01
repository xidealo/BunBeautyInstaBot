using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using System.IO;
namespace MyBot
{
    class EmaiBot
    {
        IWebDriver browser;


        public void EmailBotGo()
        {

            OpenBrowser();

            Registration();

        }



        private void OpenBrowser()
        {
            // открыть вк 
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();

            //открываю браузер на весь экран
            browser.Manage().Window.Maximize();

            // отправляемся по ссылке
            browser.Navigate().GoToUrl("https://passport.yandex.ru/auth?origin=yandex&retpath=https%3A%2F%2Fmail.yandex.ru%2F%2F%3Fmsid%3D1535539579.83507.176498.166148%26m_pssp%3Ddomik&backpath=https%3A%2F%2Fwww.yandex.ru");
        }

        private void Registration()
        {
            IWebElement element;

            element = browser.FindElement(By.Name("login"));
            element.SendKeys("shavl.mark@yandex.ru");
            Thread.Sleep(1000);

            element = browser.FindElement(By.Name("passwd"));
            element.SendKeys("");
            Thread.Sleep(1000);

            element = browser.FindElement(By.ClassName("passport-Button-Text"));
            element.Click();
        }


    }
}
