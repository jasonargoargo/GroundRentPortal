using DataLibrary.Models;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DataLibrary.Services;
public class Scraper
{
	// Docker-Selenium github resources found here: https://github.com/seleniumhq/docker-selenium
	private List<AddressModel> AddressList { get; set; }
	private readonly string BaseUrl = "https://sdat.dat.maryland.gov/RealProperty/Pages/default.aspx";
	private IWebDriver RemoteWebDriver { get; set; }
	private IWebElement FirefoxInput { get; set; }
	private readonly string? CssSelectorBaltimoreCityNameSelect = "#cphMainContentArea_ucSearchType_wzrdRealPropertySearch_ucSearchType_ddlCounty > option:nth-child(4)";
	private readonly string? CssSelectorBaltimoreCityPropertyAccountIdentifierSelect = "#cphMainContentArea_ucSearchType_wzrdRealPropertySearch_ucSearchType_ddlSearchType > option:nth-child(3)";
	private readonly string? CssSelectorBaltimoreCityContinueButtonClick = "#cphMainContentArea_ucSearchType_wzrdRealPropertySearch_StartNavigationTemplateContainerID_btnContinue";
	private readonly string? CssSelectorBaltimoreCityWardInput = "#cphMainContentArea_ucSearchType_wzrdRealPropertySearch_ucEnterData_txtWard";
	private readonly string? CssSelectorBaltimoreCitySectionInput = "#cphMainContentArea_ucSearchType_wzrdRealPropertySearch_ucEnterData_txtSection";
	private readonly string? CssSelectorBaltimoreCityBlockInput = "#cphMainContentArea_ucSearchType_wzrdRealPropertySearch_ucEnterData_txtBlock";
	private readonly string? CssSelectorBaltimoreCityLotInput = "cphMainContentArea_ucSearchType_wzrdRealPropertySearch_ucEnterData_txtLot";
	private readonly string? CssSelectorBaltimoreCityNextButtonClick = "#cphMainContentArea_ucSearchType_wzrdRealPropertySearch_StepNavigationTemplateContainerID_btnStepNextButton";

	public Scraper()
	{

	}
	public async Task SpinUp()
	{
		var gridNetwork = new TestcontainersNetworkBuilder()
			.WithName("seleniumgridnetwork")
			.Build();

		var seleniumHubTestContainer = new TestcontainersBuilder<TestcontainersContainer>()
			.WithImage("selenium/node-firefox:4.7.1-20221208")
			.WithName("selenium-hub")
			.WithPortBinding(4442, 4442)
			.WithPortBinding(4443, 4443)
			.WithPortBinding(4444, 4444)
			.WithNetwork(gridNetwork)
			.WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(4444))
			.Build();

		var firefoxEnvironment = new Dictionary<string, string>()
		{
			{ "SE_EVENT_BUS_HOST", "selenium-hub" },
			{ "SE_EVENT_BUS_PUBLISH_PORT", "4442" },
			{ "SE_EVENT_BUS_SUBSCRIBE_PORT", "4443" }
		};

		var firefoxTestContainerBuilder = new TestcontainersBuilder<TestcontainersContainer>()
			.WithImage("selenium/node-firefox:4.7.1-20221208")
			.WithEnvironment(firefoxEnvironment)
			.WithNetwork(gridNetwork)
			.Build();

		await gridNetwork.CreateAsync();
		await seleniumHubTestContainer.StartAsync();
		await firefoxTestContainerBuilder.StartAsync();

		var firefoxOptions = new FirefoxOptions();
		firefoxOptions.AddArguments("--headless");
		RemoteWebDriver = new RemoteWebDriver(new Uri("http://localhost:4444/"), firefoxOptions);
		RemoteWebDriver.Navigate().GoToUrl(BaseUrl);
	}
	public async Task Scrape(List<AddressModel> addressList)
	{
		WebDriverWait webDriverWait = new(RemoteWebDriver, TimeSpan.FromSeconds(10));
		// Business logic to direct user to specific page per address in the AddressList
		AddressList = new(addressList);
		try
		{
			foreach (var address in AddressList)
			{
				if (address.County == "BaltimoreCity")
				{
					RemoteWebDriver.Navigate().GoToUrl(BaseUrl);
					// Select "BALTIMORE CITY"
					webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorBaltimoreCityNameSelect)));
					FirefoxInput.Click();
					// Select "PROPERTY ACCOUNT IDENTIFIER"
					webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorBaltimoreCityPropertyAccountIdentifierSelect)));
					FirefoxInput.Click();
					// Click Continue Button
					webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorBaltimoreCityContinueButtonClick)));
					FirefoxInput.Click();
					// Input Ward
					webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(CssSelectorBaltimoreCityWardInput)));
					FirefoxInput.Clear();
					FirefoxInput.SendKeys(address.Ward);
					// Input Section
					webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(CssSelectorBaltimoreCitySectionInput)));
					FirefoxInput.Clear();
					FirefoxInput.SendKeys(address.Section);
					// Input Block
					webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(CssSelectorBaltimoreCityBlockInput)));
					FirefoxInput.Clear();
					FirefoxInput.SendKeys(address.Block);
					// Input Lot
					webDriverWait.Until(ExpectedConditions.ElementExists(By.CssSelector(CssSelectorBaltimoreCityLotInput)));
					FirefoxInput.Clear();
					FirefoxInput.SendKeys(address.Lot);
					// Click Next Button
					webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CssSelectorBaltimoreCityNextButtonClick)));
					FirefoxInput.Click();
				}
			}
		}
		catch (Exception)
		{

			throw;
		}
		finally
		{
			RemoteWebDriver.Quit();
		}
	}
}
