using System;
using CommonLibs.Implementation;
using OpenQA.Selenium;

namespace Guru99Application.Pages
{
   public  class BasePage
    {

        public CommonElement commonElement;
        public DropdownControl dropdownControl;

        public BasePage()
        {
            commonElement = new CommonElement();

            dropdownControl = new DropdownControl();
        }

    }
}
