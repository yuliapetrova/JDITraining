using System.Runtime.Remoting;
using Epam.Tests.Scenarios.Entities;
using Epam.Tests.Scenarios.Page_Objects;
using Epam.Tests.Scenarios.Page_Objects.Pages;
using Epam.Tests.Scenarios.Page_Objects.Sections;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using static Epam.Tests.Scenarios.Enums.HeaderMenuValues;
using static Epam.Tests.Scenarios.Page_Objects.EpamSite;
using static Epam.JDI.Web.Selenium.DriverFactory.WebDriverUtils;

namespace Epam.Tests.Scenarios.Tests

{
    [TestFixture]
    public class RequestInfoPageTests : TestsBase

{
    [Test]
    public void SendFeedbackTest()
    {
        var customer = new Customer();
        EpamSite.RequestInfoPage.Open();
        EpamSite.RequestInfoPage.CheckOpened();
        EpamSite.RequestInfoPage.RegistrationForm.Submit(customer);
        EpamSite.RequestInfoPage.RegistrationForm.Verify(customer);
    }

}
}