using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;

namespace CommonLibs.Utils
{
    public class ScreenshotUtils
    {
        ITakesScreenshot camera;

        public ScreenshotUtils(IWebDriver driver)
        {
            camera = (ITakesScreenshot)driver;
        }
        public void CaptureAndSaveScreenshot(string Filename)
        {
            _ = Filename.Trim();

            if (File.Exists(Filename))
            {
                throw new Exception("File already exist.." + Filename);
            }

            Screenshot screenshot = camera.GetScreenshot();

            screenshot.SaveAsFile(Filename);

        }
    }
}