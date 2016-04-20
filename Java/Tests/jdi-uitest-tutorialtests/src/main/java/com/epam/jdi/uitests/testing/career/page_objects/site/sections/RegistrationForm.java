package com.epam.jdi.uitests.testing.career.page_objects.site.sections;

import com.epam.jdi.uitests.core.annotations.Name;
import com.epam.jdi.uitests.core.interfaces.common.IButton;
import com.epam.jdi.uitests.core.interfaces.common.ITextField;
import com.epam.jdi.uitests.core.interfaces.complex.IComboBox;
import com.epam.jdi.uitests.testing.career.page_objects.entities.Customer;
import com.epam.jdi.uitests.web.selenium.elements.common.Text;
import com.epam.jdi.uitests.web.selenium.elements.common.TextField;
import com.epam.jdi.uitests.web.selenium.elements.complex.ComboBox;
import com.epam.jdi.uitests.web.selenium.elements.complex.Dropdown;
import com.epam.jdi.uitests.core.interfaces.complex.IDropDown;
import com.epam.jdi.uitests.web.selenium.elements.composite.Form;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.support.FindBy;

/**
 * Created by Iuliia_Petrova on 4/13/2016.
 */
public class RegistrationForm extends Form<Customer> {
    // Subject
    @FindBy(name = "mail_subjects")
    public IDropDown<Enum> subject = new Dropdown<>(By.xpath("//*[*[contains(@id,'select-box-mail_subjects')]]//*[@class='arrow']"),
            By.xpath("//*[contains(@id, 'select-box-mail_subjects')]//li"));
    // First Name
    @FindBy(name = "user_first_name")
    public TextField name;
    // Last Name
    @FindBy(name = "user_last_name")
    public TextField lastName;
    // Email
    @FindBy(name = "user_email")
    public TextField email;
    // Phone
    @FindBy(name = "user_phone")
    @Name (value="phone")
    public TextField phone;
    // Company
    @FindBy(name = "user_company")
    public TextField company;
    // Position
    @FindBy(name = "user_position")
    public IDropDown<Enum> position = new Dropdown<>(By.xpath("//*[*[contains(@id,'user_position')]]//*[@class='arrow']"),
            By.xpath("//*[contains(@id, 'select-box-user_position')]//li"));
    // Country
    public IComboBox<Enum> country = new ComboBox<Enum>(
            By.xpath("//*[*[contains(@id,'user_country')]]//*[@class='arrow']"),
            By.xpath("//*[contains(@id,'select-box-user_country-rz-container')]"),
            By.cssSelector(".select-box-search.dropdown > input")) {
        @Override
        public String getValueAction() {
            return new Text(By.xpath("//*[*[contains(@id,'user_country')]]//*[@class='rendered']")).getText();
        }
        @Override
        public void clearAction() {

        }
        @Override
        public void inputAction(CharSequence text) {
            expandAction("");
            new TextField(By.cssSelector(".field")).sendKeys(text.toString() + Keys.ENTER);
        }
    };
    // Your inquiry or comments
    @FindBy(name = "user_comment")
    public TextField message1;
    // How did you hear about EPAM
    @FindBy(name="user_comment_how_hear_about")
    public TextField message2;
    // Submit
    @FindBy(xpath = "//*[.='Submit']")
    private IButton submit;


}
