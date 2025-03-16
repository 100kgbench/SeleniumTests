using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LearningSelenium
{
    public class Tests
    {
        [Test]
        public void TestMagistratToSearchToHome()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.prerov.eu/";
            Assert.That(driver.Url, Is.EqualTo("https://www.prerov.eu/"));
            driver.Manage().Window.Maximize();
            var CookieRefuse = driver.FindElement(By.ClassName("cookies_info_refuse"));
            CookieRefuse.Click();
            var magistrat = driver.FindElement(By.XPath("//*[contains(@class, 'dil_menu') and contains(@class, 'magistrat')]"));
            magistrat.Click();
            Assert.That(driver.Url, Is.EqualTo("https://www.prerov.eu/cs/magistrat/"));
            var magistratSearch = driver.FindElement(By.ClassName("textpole_zapati"));
            magistratSearch.SendKeys("123");
            var magistratSearchClick = driver.FindElement(By.ClassName("button_zapati"));
            magistratSearchClick.Click();
            Assert.That(driver.Url, Is.EqualTo("https://www.prerov.eu/redakce/index.php?clanek=444&lanG=cs&slozka=1916&short=alphabecical"));
            var magistratToHomePage = driver.FindElement(By.ClassName("odkaz_domu"));
            magistratToHomePage.Click();
            Assert.That(driver.Url, Is.EqualTo("https://www.prerov.eu/"));

            driver.Quit();
        }

        [Test]

        public void TestSearchFunction()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.prerov.eu/";
            Assert.That(driver.Url, Is.EqualTo("https://www.prerov.eu/"));
            driver.Manage().Window.Maximize();
            var CookieRefuse = driver.FindElement(By.ClassName("cookies_info_refuse"));
            CookieRefuse.Click();
            var searchBar = driver.FindElement(By.Id("find_in_redakce"));
            searchBar.SendKeys("test");
            Assert.That(searchBar.GetAttribute("value"), Is.EqualTo("test"));
            var searchBarClick = driver.FindElement(By.ClassName("tlacitko_vyhledat"));
            searchBarClick.Click();
            Assert.That(driver.Url, Is.EqualTo("https://www.prerov.eu/redakce/index.php?xuser=&lanG=cs&subakce=scearch&scearchText=test"));
            var searchResultLink = driver.FindElement(By.LinkText("Cyklostezka v Palackého ulici je už hotová, ještě ji ale čeká kolaudace"));
            searchResultLink.Click();
            Assert.That(driver.Url, Is.EqualTo("https://www.prerov.eu/cs/magistrat/tiskove-centrum/tiskove-zpravy-2022/tz-srpen-2022/cyklostezka-v-palackeho-ulici-je-uz-hotova-jeste-ji-ale-ceka-kolaudace.html"));
            var searchResultToHomePage = driver.FindElement(By.ClassName("odkaz_domu"));
            searchResultToHomePage.Click();
            Assert.That(driver.Url, Is.EqualTo("https://www.prerov.eu/"));

            driver.Quit();
        }
    }
}
