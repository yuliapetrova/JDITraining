﻿using System;
using System.Collections.Generic;
using System.Linq;
using Epam.JDI.Commons;
using Epam.JDI.Core;
using Epam.JDI.Core.Interfaces.Base;
using Epam.JDI.Web.Selenium.Base;
using Epam.JDI.Web.Selenium.DriverFactory;
using Epam.JDI.Web.Selenium.Elements.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static Epam.JDI.Core.Settings.JDISettings;

namespace Epam.JDI.Web.Selenium.Elements.Complex
{
    public abstract class BaseSelector<TEnum> : WebBaseElement, IVisible
        where TEnum : IConvertible
    {
        protected bool IsSelector;
        private readonly GetElementType _allLabels;
        protected SelectElement Selector
        {
            get
            {
                IsSelector = true;
                return new SelectElement(WebElement);
            }
        }
        protected BaseSelector(By optionsNamesLocator, By allLabelsLocator) : base(optionsNamesLocator)
        {
            _allLabels = new GetElementType(allLabelsLocator);
        }

        public TextList AllLabels => _allLabels.Get(new TextList(), WebAvatar);

        public Action<BaseSelector<TEnum>, string> SelectNameAction = (s, name) =>
        {
            if (!s.HasLocator && s.AllLabels == null)
                throw Exception($"Can't find option '{name}'. No optionsNamesLocator and _allLabelsLocator found");
            if (s.Locator.ToString().Contains("{0}"))
            {
                new Clickable(s.Locator.FillByTemplate(name)).Click();
                return;
            }
            if (s.AllLabels != null)
            {
                s.SelectFromList(s.AllLabels.WebElements, name);
                return;
            }
            var elements = s.WebAvatar.SearchAll().WebElements;
            if (elements.Count == 1)
                s.Selector.SelectByText(name);
            else
                s.SelectFromList(elements, name);
        };


        public Action<BaseSelector<TEnum>, int> SelectNumAction = (s, index) =>
        {
            if (!s.HasLocator && s.AllLabels == null)
                throw Exception($"Can't find option '{index}'. No optionsNamesLocator and _allLabelsLocator found");
            if (s.AllLabels != null)
            {
                s.SelectFromList(s.AllLabels.WebElements, index);
                return;
            }
            if (s.Locator.ToString().Contains("%s"))
            {
                new Clickable(s.Locator.FillByTemplate(index)).Click();
                return;
            }
            var els = s.WebAvatar.SearchAll().WebElements;
            if (els.Count == 1)
                s.Selector.SelectByIndex(index);
            else
                s.SelectFromList(els, index);
        };
        private void SelectFromList(IList<IWebElement> els, string name)
        {
            var element = els.FirstOrDefault(el => el.Text.Equals(name));
            if (element == null)
                throw Exception($"Can't find option '{name}'. Please fix _allLabelsLocator");
            element.Click();
        }


        private void SelectFromList(IList<IWebElement> els, int index)
        {
            if (index <= 0)
                throw Exception($"Can't get option with index '{index}'. Index should be 1 or more");
            if (els == null)
                throw Exception($"Can't find option with index '{index}'. Please fix _allLabelsLocator");
            if (els.Count < index)
                throw Exception($"Can't find option with index '{index}'. Find only '{els.Count}' options");
            els[index - 1].Click();
        }

        public Func<BaseSelector<TEnum>, string, bool> SelectedNameAction;
        public Func<BaseSelector<TEnum>, int, bool> SelectedNumAction;
        public Func<BaseSelector<TEnum>, string> GetValueAction;

        public Func<BaseSelector<TEnum>, IWebElement, bool> SelectedElementAction = (s, el) =>
        {
            if (s.IsSelector)
                return el.Selected;
            var attr = el.GetAttribute("checked");
            return attr != null && attr.Equals("true");
        };

        public void WaitSelected(string name)
        {
            Actions.Selected(name, (el, n) => TimerExtensions.ForceDone(() => SelectedNameAction(this, n)));
        }

        public void WaitSelected(TEnum enumType)
        {
            WaitSelected(enumType.ToString());
        }

        public bool Selected(string name)
        {
            return Actions.Selected(name, (el, n) => SelectedNameAction(this, n));
        }

        public bool Selected(TEnum enumType)
        {
            return Selected(enumType.ToString());
        }

        public Func<BaseSelector<TEnum>, List<string>> GetOptionsAction = 
            s => s.Elements.Select(el => el.Text).ToList();


        public Action<BaseSelector<TEnum>, string> SetValueAction = (s, value) => s.SelectNameAction(s, value);

        public string Value
        {
            get { return Actions.GetValue(el => GetValueAction(this)); }
            set { Actions.SetValue(value, (el, val) => SetValueAction(this, val)); }
        }

        public IList<string> Options => GetOptionsAction(this);
        public IList<string> Names => Options;
        public IList<string> Values => Options;

        public string OptionsAsText => Options.Print();

        protected IList<IWebElement> Elements
        {
            get
            {
                if (!HasLocator && AllLabels == null)
                    throw Exception(
                        "Can't check is element displayed or not. No optionsNamesLocator and allLabelsLocator found");
                if (AllLabels != null)
                    return AllLabels.WebElements;
                if (Locator.ToString().Contains("%s"))
                    throw Exception(
                        "Can't check is element displayed or not. Please specify allLabelsLocator or correct optionsNamesLocator (should not contain '%s')");
                var els = WebAvatar.SearchAll().WebElements;
                if (els.Count == 1)
                    els = Selector.AllSelectedOptions.ToList();
                return els;
            }
        }

        public Func<BaseSelector<TEnum>, string, bool> DisplayedNameAction = (s, name) =>
        {
            if (!s.HasLocator && s.AllLabels == null)
                throw Exception(
                    $"Can't check is option '{name}' displayed. No optionsNamesLocator and _allLabelsLocator found");
            if (s.Locator.ToString().Contains("%s"))
                return new Clickable(s.Locator.FillByTemplate(name)).Displayed;
            if (s.AllLabels != null)
                return s.DisplayedInList(s.AllLabels.WebElements, name);
            List<IWebElement> els;
            try { els = s.WebAvatar.SearchAll().WebElements; }
            catch { return false; }
            return s.DisplayedInList(els.Count == 1 ? s.Selector.Options.ToList() : els, name);
        };

        private bool DisplayedInList(IList<IWebElement> els, string name)
        {
            var element = els.FirstOrDefault(el => el.Text.Equals(name));
            return element != null && element.Displayed;
        }

        public Func<BaseSelector<TEnum>, int, bool> DisplayedNumAction => (s, index) =>
        {
            if (!HasLocator && AllLabels == null)
                throw Exception(
                    $"Can't check is option '{index}' displayed. No optionsNamesLocator and _allLabelsLocator found");
            if (Locator.ToString().Contains("%s"))
                return new Clickable(Locator.FillByTemplate(index)).Displayed;
            if (AllLabels != null)
                return DisplayedInList(AllLabels.WebElements, index);
            var els = WebAvatar.SearchAll().WebElements;
            return DisplayedInList(els.Count == 1 ? Selector.Options.ToList() : els, index);
        };

        private static bool DisplayedInList(IList<IWebElement> els, int index)
        {
            if (index <= 0)
                throw Exception($"Can't get option with index '{index}'. Index should be 1 or more");
            if (els == null)
                throw Exception($"Can't find option with index '{index}'. Please fix _allLabelsLocator");
            if (els.Count < index)
                throw Exception($"Can't find option with index '{index}'. Find '{els.Count}' options");
            return els[index - 1].Displayed;
        }

        public Func<BaseSelector<TEnum>, bool> DisplayedAction = s =>
        {
            var els = s.WebAvatar.FindImmediately(() => s.Elements, null);
            return els != null && els.Any() && els[0].Displayed;
        };

        public Func<BaseSelector<TEnum>, bool> WaitDisplayedAction = s => 
        {
            return s.Timer.Wait(() => {
                var els = s.Elements;
                return els != null && els.Any() && els[0].Displayed;
            });
        };

        public Func<BaseSelector<TEnum>, bool> WaitVanishedAction = 
            s => s.Timer.Wait(() => !s.DisplayedAction(s));

        public bool Displayed => Actions.IsDisplayed(s => DisplayedAction(this));

        public bool Hidden => Actions.IsDisplayed(s => !DisplayedAction(this));

        public void WaitDisplayed()
        {
            Actions.WaitDisplayed(s => WaitDisplayedAction(this));
        }

        public void WaitVanished()
        {
            Actions.WaitVanished(s => Timer.Wait(() => !DisplayedAction(this)));
        }
    }
}
