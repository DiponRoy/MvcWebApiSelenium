using System;
using System.Collections.Generic;
using Csrm.Test.Selenium.JslibHelpers.Model;
using Csrm.Test.Selenium.Utilities;
using OpenQA.Selenium;

namespace Csrm.Test.Selenium.JslibHelpers
{
    /*
     * this one is like the SelectElement for selenium
     */
    public class KendoDropdown
    {
        public readonly IWebElement DropdownElement;
        public readonly IWebDriver WebDriver;

        public IReadOnlyCollection<DropdownOption> DropdownOptions
        {
            get
            {
                var data = WebDriver.AsJsExecutor().ExecuteScriptForData<IReadOnlyCollection<DropdownOption>>(@"
                                                        return (function() {
                                                            var ddl = $(arguments[0]).data('kendoDropDownList');
                                                            var options = []; /*arry of object{ text:string , value:string }*/

                                                            /*default option*/
                                                            //code here when defaul option is needed

                                                            /*data source options*/
                                                            var data = ddl.dataSource.data();
                                                            var textField = ddl.options.dataTextField;
                                                            var valueField = ddl.options.dataValueField;
                                                            for (var i = 0; i < data.length; i++) {
                                                                options.push({ text: (data[i])[textField], value: (data[i])[valueField] });
                                                            }

                                                            return options;
                                                        })();
                                                    ", DropdownElement);
                return data;
            }
        }

        public KendoDropdown(IWebElement dropdownElement, IWebDriver webDriver)
        {
            DropdownElement = dropdownElement;
            WebDriver = webDriver;
        }

        public void TriggerChange()
        {
            WebDriver.AsJsExecutor().ExecuteScript("$(arguments[0]).data('kendoDropDownList').trigger('change')", DropdownElement);
        }

        public string SelectedText()
        {
            return
                (string)
                    WebDriver.AsJsExecutor()
                        .ExecuteScript("return $(arguments[0]).data('kendoDropDownList').text();", DropdownElement);
        }

        public void SelectByText(string text)
        {
            WebDriver.AsJsExecutor()
                .ExecuteScript(String.Format("$(arguments[0]).data('kendoDropDownList').text('{0}');", text),
                    DropdownElement);
            TriggerChange();
        }

        public string SelectedValue()
        {
            return
                (string)
                    WebDriver.AsJsExecutor()
                        .ExecuteScript("return $(arguments[0]).data('kendoDropDownList').value();", DropdownElement);
        }

        public void SelectByValue(string value)
        {
            WebDriver.AsJsExecutor()
                .ExecuteScript(String.Format("$(arguments[0]).data('kendoDropDownList').value('{0}')", value),
                    DropdownElement);
            TriggerChange();
        }

        public int SelectedIndex()
        {
            return
                (int)
                    WebDriver.AsJsExecutor()
                        .ExecuteScript("return $(arguments[0]).data('kendoDropDownList').select();", DropdownElement);
        }

        public void SelectByIndex(int index)
        {
            WebDriver.AsJsExecutor().ExecuteScript(String.Format("$(arguments[0]).data('kendoDropDownList').select({0});", index), DropdownElement);
            TriggerChange();
        }
    }

    
}



/*
    alert(JSON.stringify($('#cmbDoctorsList').data('kendoDropDownList').dataSource.data()));

    alert(JSON.stringify($('#cmbDoctorsList').data('kendoDropDownList').options));

    alert($('#cmbDoctorsList').data('kendoDropDownList').select());
    $('#cmbDoctorsList').data('kendoDropDownList').select(2);

    alert($('#cmbDoctorsList').data('kendoDropDownList').value());
    $('#cmbDoctorsList').data('kendoDropDownList').value("");

    alert($('#cmbDoctorsList').data('kendoDropDownList').text());
    $('#cmbDoctorsList').data('kendoDropDownList').text("Select Doctor..");
 */
