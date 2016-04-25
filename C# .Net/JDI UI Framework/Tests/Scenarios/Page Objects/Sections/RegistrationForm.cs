using System;
using System.Net.Mime;
using Epam.JDI.Web.Selenium.Elements.Composite;
using Epam.JDI.Core.Interfaces.Common;
using Epam.JDI.Core.Interfaces.Complex;
using Epam.JDI.Web.Attributes;
using Epam.JDI.Web.Selenium.Base;
using Epam.JDI.Web.Selenium.Elements.Common;
using Epam.JDI.Web.Selenium.Elements.Complex;

using Epam.Tests.Scenarios.Entities;
using OpenQA.Selenium;

namespace Epam.Tests.Scenarios.Page_Objects.Sections
{
    public class RegistrationForm : Form<Customer>
    {
     // Subject
     [FindBy(Name = "mail_subjects")]
     public IDropDown<Enum> subject = new Dropdown<Enum>(By.XPath("//*[*[contains(@id,'select-box-mail_subjects')]]//*[@class='arrow']"),
            By.XPath("//*[contains(@id, 'select-box-mail_subjects')]//li"));
    // First Name
    [FindBy(Name = "user_first_name")]
    public TextField name;
    // Last Name
    [FindBy(Name = "user_last_name")]
    public TextField lastName;
    // Email
    [FindBy(Name = "user_email")]
    public TextField email;
    // Phone
    [FindBy(Name = "user_phone")]
    //[Name(value= "phone")]
    public TextField phone;
    // Company
    [FindBy(Name = "user_company")]
    public TextField company;
    // Position
    [FindBy(Name = "user_position")]
    public IDropDown<Enum> position = new Dropdown<Enum>(By.XPath("//*[*[contains(@id,'user_position')]]//*[@class='arrow']"),
            By.XPath("//*[contains(@id, 'select-box-user_position')]//li"));

        public class MyComboBox<TEnum> : ComboBox<Enum>
          where TEnum : IConvertible
        {
            private readonly GetElementType _textField;

            public MyComboBox() : this(null) { }
            public MyComboBox(By selectorLocator = null, By optionsNamesLocatorTemplate = null)
                : base(selectorLocator, optionsNamesLocatorTemplate)
            {
                SetValueAction = (c, value) => NewInput(value);
                GetTextAction = c => TextField.Text;
                _textField = new GetElementType(selectorLocator);
            }

            public MyComboBox(By selectorLocator, By optionsNamesLocatorTemplate, By valueLocator, By allOptionsNamesLocator = null)
                : base(selectorLocator, optionsNamesLocatorTemplate, allOptionsNamesLocator)
            {
                _textField = new GetElementType(valueLocator);
            }

            public TextField TextField => _textField.Get(new TextField(), WebAvatar);

            public Action<ComboBox<TEnum>, string> InputAction =
                (c, text) => c.TextField.SendKeys(text);

            public virtual void ClearAction()
            {
               // TextField.Clear();
            }

            public void FocusAction()
            {
                TextField.Focus();
            }

            //public void Input(string text)
            //{
            //    Actions.Input(text, (c, t) => InputAction(this, text));
            //}

            public void SendKeys(string text)
            {
                Input(text);
            }

            public void NewInput(string text)
            {
              //  Clear();
                //Input(text + Keys.Enter);

                //Input(By.CssSelector(".field").SendKeys(text.ToString() + Keys.Enter);// to do (see ITextField)
            }

            public new void Clear()
            {
             //   Actions.Clear(c => ClearAction());
            }

            public void Focus()
            {
                Actions.Focus(c => FocusAction());
            }
        }

        // Country
        public IComboBox<Enum> country = new ComboBox<Enum>(
            By.XPath("//*[*[contains(@id,'user_country')]]//*[@class='arrow']"),
            By.XPath("//*[contains(@id,'select-box-user_country-rz-container')]"),
            By.CssSelector(".select-box-search.dropdown > input"))
        {
            ClearAction = cb => { },

        }

       
//         {
//            //  @Override
//        public override String getValueAction()
//{
//    return new MediaTypeNames.Text(By.xpath("//*[*[contains(@id,'user_country')]]//*[@class='rendered']")).getText();
//        }
//      //  @Override
//        public void clearAction()
//        {

//        }
//       // @Override
//        public void inputAction(CharSequence text)
//        {
//            expandAction("");
//            new TextField(By.cssSelector(".field")).sendKeys(text.toString() + Keys.ENTER);
//        }
//    };


    // Your inquiry or comments
    [FindBy(Name = "user_comment")]
    public TextField message1;
    // How did you hear about EPAM
    [FindBy(Name = "user_comment_how_hear_about")]
    public TextField message2;
    // Submit
    [FindBy(XPath = "//*[.='Submit']")]
    private IButton submit;

}
}