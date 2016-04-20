package com.epam.jdi.uitests.testing.career.page_objects.dataProviders;

import com.epam.jdi.uitests.testing.career.page_objects.entities.Attendee;
import com.epam.jdi.uitests.testing.career.page_objects.entities.Customer;
import org.testng.annotations.DataProvider;

/**
 * Created by Iuliia_Petrova on 4/12/2016.
 */
public class CustomerProvider {
    private CustomerProvider() { }

    @DataProvider(name = "customers")
    public static Object[][] customers() {
        return new Object[][]{
                {new Customer()}
        };
    }
}


