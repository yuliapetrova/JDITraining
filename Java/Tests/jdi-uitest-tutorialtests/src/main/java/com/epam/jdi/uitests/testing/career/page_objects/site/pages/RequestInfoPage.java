package com.epam.jdi.uitests.testing.career.page_objects.site.pages;

import com.epam.commons.map.MapArray;
import com.epam.jdi.uitests.core.interfaces.complex.IComboBox;
import com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders;
import com.epam.jdi.uitests.testing.career.page_objects.site.sections.RegistrationForm;
import com.epam.jdi.uitests.web.selenium.elements.common.Text;
import com.epam.jdi.uitests.web.selenium.elements.complex.ComboBox;
import com.epam.jdi.uitests.web.selenium.elements.complex.table.Table;
import com.epam.jdi.uitests.web.selenium.elements.complex.table.interfaces.ICell;
import com.epam.jdi.uitests.web.selenium.elements.complex.table.interfaces.ITable;
import com.epam.jdi.uitests.web.selenium.elements.composite.WebPage;
import org.openqa.selenium.By;
import org.openqa.selenium.support.FindBy;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders.APPLY;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders.JOB_NAME;
import static com.epam.jdi.uitests.web.selenium.elements.complex.table.Column.column;
import com.epam.jdi.uitests.testing.career.page_objects.enums.Subjects;
import com.epam.jdi.uitests.testing.career.page_objects.enums.Countries;
import com.epam.jdi.uitests.testing.career.page_objects.enums.Locations;
import com.epam.jdi.uitests.core.interfaces.common.IButton;
import com.epam.jdi.uitests.core.interfaces.common.ITextField;
import com.epam.jdi.uitests.core.interfaces.complex.IDropDown;
import com.epam.jdi.uitests.web.selenium.elements.complex.Dropdown;
import com.epam.jdi.uitests.core.interfaces.common.IButton;
import com.epam.jdi.uitests.core.interfaces.common.IImage;
import com.epam.jdi.uitests.core.interfaces.common.IText;
import com.epam.jdi.uitests.core.interfaces.common.ITextField;
import com.epam.jdi.uitests.web.selenium.elements.common.TextArea;
import com.epam.jdi.uitests.web.selenium.elements.common.TextField;
import com.epam.jdi.uitests.web.selenium.elements.composite.Form;
import org.openqa.selenium.By;
import org.openqa.selenium.support.FindBy;
/**
 * Created by Iuliia_Petrova on 4/12/2016.
 */
public class RequestInfoPage extends WebPage {

    public RegistrationForm registrationForm;
}
