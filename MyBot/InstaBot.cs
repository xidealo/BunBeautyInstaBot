﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace MyBot
{
    internal abstract class InstaBot
    {
        IWebDriver browser;
        Random rnd = new Random();
        protected abstract void startBot(int iterations, IWebDriver browser);

        public void start(string login, string pass, string tag, int iterations) //count_likes_on_tags это количество лайков на 1 тег
        {
            if (isDataCorrect(login, pass))
            {
                OpenBrowser();                

                Registration(login, pass);

                Thread.Sleep(2000);

                NotificationCheck();

                // отправляем количество поисковых тегов
                searchTag(tag);
                Thread.Sleep(3000);

                startBot(iterations, browser);
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

        private void Registration(string email, string password)
        {
            //ищем и заполняем поля
            IWebElement element;
            Thread.Sleep(1000);

            element = browser.FindElement(By.Name("username"));
            element.SendKeys(email);
            Thread.Sleep(1000);

            element = browser.FindElement(By.Name("password"));
            element.SendKeys(password);
            Thread.Sleep(1000);

            element = browser.FindElement(By.CssSelector(".sqdOP.L3NKy"));
            element.Click();
        }

        private void searchTag(string tag)
        {
            IWebElement element;

            element = browser.FindElement(By.CssSelector(".XTCLo.x3qfX")); //.XTCLo.x3qfX// ошибка с недостуцпной страницей

            element.SendKeys(tag);
            Thread.Sleep(1000);

            try
            {
                element = browser.FindElement(By.ClassName("uyeeR"));
                element.Click();
            }
            catch (Exception e) {
                element.Clear();
                RefreshPage();
                searchTag(tag);
            }
        }

        private void NotificationCheck()
        {
            IWebElement element;

            element = browser.FindElement(By.CssSelector(".aOOlW.HoLwm"));
            element.Click();
            Thread.Sleep(1000);
        }

  
        protected void BackPage()
        {
            browser.Navigate().Back();
        }

        protected void RefreshPage()
        {
            browser.Navigate().Refresh();
        }

        //проверка данных, заполнены ли поля
        private bool isDataCorrect(string login, string pass)
        {
            if ((login != "") && (pass != ""))
            {
                return true;
            }
            return false;
        }

    }
}