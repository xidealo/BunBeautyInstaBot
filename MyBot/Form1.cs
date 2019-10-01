using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;

namespace MyBot
{
    public partial class Form1 : Form
    {
        IWebDriver browser;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // определяю ссылку, где откроется
            browser.Navigate().GoToUrl("https://www.yandex.ru/");

            //создаю и ищу элемент на странице с таким-то ID
            IWebElement searchLine = browser.FindElement(By.Id("lst-ib"));

            //обращаюсь к элементу и вписываю в него запрос также нажимаю enter
            searchLine.SendKeys("Привет. мой первый бот?" + OpenQA.Selenium.Keys.Enter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //закрываем браузер
            browser.Quit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // открытие браузера
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();

            //открываю браузер на весь экран
            browser.Manage().Window.Maximize();

            browser.Navigate().GoToUrl("https://vk.com/im?peers=196629811");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IWebElement element;

            //поиск элемента по ID
            //element = browser.FindElement(By.Id("text"));
            // element.SendKeys("test");

            // поиск элемента по div классу
            // element = browser.FindElement(By.ClassName("home-logo__default"));
            // element.Click();

            //поиск элемента по ТЕКСТУ ВНУТРИ ссылки 
            //element = browser.FindElement(By.LinkText("Видео"));
            //element.Click();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // считаю все новости при помощи css селетора, также можно нажимать сраз несколько кнопок и тд
            List<IWebElement> elements = browser.FindElements(By.CssSelector("#tabnews_newsc a")).ToList();

         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BotVK bot = new BotVK();

            bot.VkBotGo(EmailTB.Text, PassTB.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EmaiBot bot = new EmaiBot();

            bot.EmailBotGo();
        }

        private void PassTB_TextChanged(object sender, EventArgs e)
        {
            PassTB.PasswordChar = '*';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int countRepet = int.Parse(RepetNmbr.Text);
            InstBot bot = new InstBot();
            while (countRepet != 0) {

                bot.InstBotGo(EmailTB.Text, PassTB.Text, TB_tags.Text, int.Parse(TB_count_likes.Text));
                countRepet--;
                Thread.Sleep(10000);
            }
        }

        private void EmailTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void TB_tags_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
