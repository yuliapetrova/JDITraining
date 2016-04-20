package com.epam.jdi.uitests.testing.career.common.tests;

import com.epam.jdi.uitests.testing.career.page_objects.dataProviders.AttendeeProvider;
import com.epam.jdi.uitests.testing.career.page_objects.dataProviders.CustomerProvider;
import com.epam.jdi.uitests.testing.career.page_objects.entities.Attendee;
import com.epam.jdi.uitests.testing.career.page_objects.entities.Customer;
import com.epam.jdi.uitests.testing.career.page_objects.enums.Countries;
import com.epam.web.matcher.testng.Check;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.io.IOException;
import java.lang.reflect.Method;
import java.util.List;

import static com.epam.jdi.uitests.core.preconditions.PreconditionsState.isInState;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.HeaderMenu.CAREERS;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.Preconditions.HOME_PAGE;
import static com.epam.jdi.uitests.testing.career.page_objects.site.EpamSite.*;
import static org.testng.Assert.assertEquals;
/**
 * Created by Iuliia_Petrova on 4/12/2016.
 */
public class RequestInfoPageTests extends TestsBase{

    @BeforeMethod
    public void before(Method method) throws IOException {
        isInState(HOME_PAGE, method);
    }

    @Test(dataProvider = "customers", dataProviderClass = CustomerProvider.class)
    public void sendFeedbackTest(Customer customer) {
        requestInfoPage.open();
        requestInfoPage.checkOpened();
        requestInfoPage.registrationForm.submit(customer);
        requestInfoPage.registrationForm.verify(customer);
    }

}
