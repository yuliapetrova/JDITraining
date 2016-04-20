package com.epam.jdi.uitests.testing.career.page_objects.site.pages;

import com.epam.commons.map.MapArray;
import com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders;
import com.epam.jdi.uitests.web.selenium.elements.complex.table.Table;
import com.epam.jdi.uitests.web.selenium.elements.complex.table.interfaces.ICell;
import com.epam.jdi.uitests.web.selenium.elements.complex.table.interfaces.ITable;
import com.epam.jdi.uitests.web.selenium.elements.composite.WebPage;
import org.openqa.selenium.By;
import org.openqa.selenium.support.FindBy;
import com.epam.jdi.uitests.web.selenium.elements.complex.Dropdown;
import com.epam.jdi.uitests.core.interfaces.complex.IDropDown;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders.APPLY;
import static com.epam.jdi.uitests.testing.career.page_objects.enums.JobListHeaders.JOB_NAME;
import static com.epam.jdi.uitests.web.selenium.elements.complex.table.Column.column;

/**
 * Created by Roman_Iovlev on 10/22/2015.
 */
public class JobListingPage extends WebPage {

    @FindBy (className = "selected-params")
    public IDropDown<Enum> categories = new Dropdown<>(By.xpath("//*[contains(@class,'selected-params')]"),
            By.xpath("//*[*[contains(@class,'selected-params')]]//li"));

    @FindBy(name = "location_select")
    public IDropDown<Enum> location = new Dropdown<>(By.xpath("//*[*[contains(@id,'select-box-location-select-container')]]//*[@class='arrow']"),
            By.xpath("//*[contains(@id, 'location-select')]//li"));

    @FindBy(className = "search-result-list")
    public ITable jobsList = new Table(null,
            By.xpath(".//li[%s]//div"),
            By.xpath(".//li//div[%s]"))
            .hasColumnHeaders(JobListHeaders.class);

    public void getJobRowByName(String jobName) {
        MapArray<String, ICell> row = jobsList.row(jobName, column(JOB_NAME.toString()));
        row.get(APPLY.toString()).select();
    }
}
