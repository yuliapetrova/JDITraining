﻿using System;
using System.Reflection;
using Epam.JDI.Web.Selenium.Elements.Composite;
using static System.String;
using static Epam.JDI.Web.Selenium.Elements.Composite.CheckPageTypes;
using static Epam.JDI.Web.Selenium.Elements.Composite.WebPage;
using static Epam.JDI.Web.Settings.WebSettings;

namespace Epam.JDI.Web.Attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public class PageAttribute : Attribute
    {
        public string Url           = "";
        public string UrlTemplate   = "";
        public string Title         = "";
        public CheckPageTypes CheckType        = None;
        public CheckPageTypes UrlCheckType     = None;
        public CheckPageTypes TitleCheckType   = None;
        
        public static PageAttribute Handler(FieldInfo field)
        {
            return field.GetCustomAttribute<PageAttribute>(false);
        }

        public static PageAttribute Handler(object obj)
        {
            return obj.GetType().GetCustomAttribute<PageAttribute>(false);
        }

        public void FillPage(WebPage page, Type parentClass)
        {
            var url = Url;
            var site = SiteAttribute.Get(parentClass);
            if (!HasDomain && parentClass != null && site != null)
                Domain = site.Domain;
            url = url.Contains("://") || parentClass == null || !HasDomain
                    ? url
                    : GetUrlFromUri(url);
            var title = Title;
            var urlTemplate = UrlTemplate;
            if (!IsNullOrEmpty(urlTemplate))
                urlTemplate = urlTemplate.Contains("://") || parentClass == null || !HasDomain
                        ? urlTemplate
                        : GetMatchFromDomain(urlTemplate);
            var checkType = CheckType;
            var urlCheckType = UrlCheckType;
            var titleCheckType = TitleCheckType;
            if (urlCheckType == None)
                urlCheckType = checkType != None ? checkType : Equal;
            if (titleCheckType == None)
                titleCheckType = checkType != None ? checkType : Equal;
            if (urlCheckType == CheckPageTypes.Match || urlCheckType == Contain && IsNullOrEmpty(urlTemplate))
                urlTemplate = url;
            page.UpdatePageData(url, title, urlCheckType, titleCheckType, urlTemplate);
        }

    }

    public enum PageCheckType { NoCheck, Equal, Contains }
}
