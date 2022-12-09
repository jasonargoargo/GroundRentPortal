﻿using OpenQA.Selenium;

namespace DataLibrary.Models;
public class WebDriverModel
{
    public WebDriver Driver { get; set; }
    public IWebElement Input { get; set; }
    public List<AddressModel> AddressList { get; set; }
}