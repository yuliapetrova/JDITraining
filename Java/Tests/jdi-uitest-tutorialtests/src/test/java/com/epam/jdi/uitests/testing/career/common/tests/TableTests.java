package com.epam.jdi.uitests.testing.career.common.tests;

import com.epam.commons.LinqUtils;
import com.epam.jdi.uitests.testing.career.page_objects.dataProviders.CustomerProvider;
import com.epam.jdi.uitests.testing.career.page_objects.entities.Customer;
import com.epam.web.matcher.testng.Assert;
import com.epam.web.matcher.testng.Check;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import java.io.IOException;
import java.lang.reflect.Method;
import java.util.List;

import static com.epam.commons.LinqUtils.*;
import static com.epam.jdi.uitests.core.preconditions.PreconditionsState.isInState;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders.JOB_CATEGORY;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders.JOB_LOCATION;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders.JOB_NAME;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.Preconditions.HOME_PAGE;
import static com.epam.jdi.uitests.testing.career.page_objects.site.EpamSite.jobDescriptionPage;
import static com.epam.jdi.uitests.testing.career.page_objects.site.EpamSite.jobListingPage;
import static com.epam.jdi.uitests.testing.career.page_objects.site.EpamSite.requestInfoPage;
import static com.epam.jdi.uitests.core.preconditions.PreconditionsState.isInState;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.HeaderMenu.CAREERS;
import static com.epam.jdi.uitests.testing.career.page_objects.site.EpamSite.*;
import static com.epam.web.matcher.testng.Assert.areEquals;
import static com.epam.web.matcher.testng.Assert.assertContains;

/**
 * Created by Iuliia_Petrova on 4/15/2016.
 */
public class TableTests extends TestsBase {
    @BeforeMethod
    public void before(Method method) throws IOException {
        isInState(HOME_PAGE, method);
    }

    @DataProvider(name = "jobFeatures")
    public Object[][] jobFeatures() {
        return new Object[][]{
                {"Software Engineering", "Australia"},
                {"Software Architecture", "Belarus"},
                {"Sales, Marketing & PR", "Sweden"},
                {"Maintenance & Support", "Ukraine"},
                {"Consulting & Business Analysis", "France"}
        };
    }

    // This procedure filters Job List by Job Category and Job Location (using data from DataProvider "jobFeatures") and
    // then verify if each row of the result table contains (in corresponding columns) the expected Job Category and Job Location names
    @Test(dataProvider = "jobFeatures")
    public void CheckJobCategoryLocationColumns(String jobCategory, String jobLocation) {
        jobListingPage.open();
        jobListingPage.checkOpened();
        jobListingPage.categories.select(jobCategory);
        jobListingPage.location.select(jobLocation);
        jobListingPage.location.select("All Cities in " + jobLocation);
          new Check("Table is not empty").isFalse(jobListingPage.jobsList::isEmpty);


        List<String> row = select(jobListingPage.jobsList.column(3), el -> el.value.getText());
        Assert.eachElementOf(row).matches(".*" + jobLocation + ".*", "Not found!");
        row = select(jobListingPage.jobsList.column(2), el -> el.value.getText());
        Assert.eachElementOf(row).matches(".*" + jobCategory + ".*", "Nor found!");

//        for (int i = 0; i < (jobListingPage.jobsList.rows().count() - 1); i++) {
//            assertContains(jobListingPage.jobsList.column(2).get(i).value.getText(), jobCategory, jobCategory + " were not found!");
//            assertContains(jobListingPage.jobsList.column(3).get(i).value.getText(), jobLocation, jobLocation + " were not found! Actual location is: " + jobListingPage.jobsList.column(3).get(i).value.getText());
//        }

    }
}
