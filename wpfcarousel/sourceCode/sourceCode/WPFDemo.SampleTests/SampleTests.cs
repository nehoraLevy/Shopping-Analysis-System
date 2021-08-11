using System.Threading;
using System.Windows.Automation;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WPFDemo.SampleTests
{
    [TestClass]
    public class SampleTests
    {
        public const string LOCAL_EXE_LOCATION = @"..\..\..\WPFDemo\bin\Debug\WPFDemo.exe";

        public const int DURATION_TO_WAIT_FOR_EXPAND_ANIMATION = 1000;
        public const int DURATION_TO_WAIT_FOR_COLLAPSE_ANIMATION = 800;

        private AutomationElement _window = null;

        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            // Warm up the application; initialize WPF
            AutomationElement window = null;

            window = UIAutomationHelper.LaunchApplication(LOCAL_EXE_LOCATION);

            Thread.Sleep(1000);

            if (window != null)
                (window.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern).Close();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            Thread.Sleep(1000);

            _window = UIAutomationHelper.LaunchApplication(LOCAL_EXE_LOCATION);
                        
            Thread.Sleep(2000);
        }


        [TestCleanup()]
        public void MyTestCleanup()
        {
            Thread.Sleep(1000);

            if (_window != null)
                (_window.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern).Close();
        }



        [TestMethod]
        public void TestCarousel()
        {
            UIAutomationHelper.SelectElement(_window, "VerticalSelectionRadio");

            TestCarouselSelection("RedSphere");
            TestCarouselSelection("BlueSphere");
            TestCarouselSelection("GreenSphere");
            TestCarouselSelection("BlackSphere");
            TestCarouselSelection("YellowSphere");
            TestCarouselSelection("PurpleSphere");
            TestCarouselSelection("OrangeSphere");
        }

        private void TestCarouselSelection(string carouselItemName)
        {
            UIAutomationHelper.PerformMouseClickOnItem(_window, carouselItemName);
            Thread.Sleep(500);
            Assert.AreEqual(carouselItemName, UIAutomationHelper.GetElementName(_window, "CurrentlySelectedNameTextBlock"), string.Format("The expected element '{0}' was not selected.", carouselItemName));
        }



    }
}
