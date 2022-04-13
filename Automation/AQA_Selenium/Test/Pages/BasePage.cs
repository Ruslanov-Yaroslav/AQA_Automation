﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Test.Pages
{
    public class BasePage
    {
        public WebDriver driver;

        public BasePage(WebDriver driver) => this.driver = driver;
    }
}
